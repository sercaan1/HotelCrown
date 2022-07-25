using HotelCrown.HotelCrownDatas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelCrown
{
    public partial class FormRooms : Form
    {
        ContextDb _db;
        public FormRooms(ContextDb db)
        {
            _db = db;
            InitializeComponent();
            ShowRooms();
            ListCheckBox();
        }

        private void ShowRooms()
        {
            dgvRooms.Rows.Clear();

            if (_db.Rooms.Count() > 0)
            {
                int i = 0;
                foreach (var room in _db.Rooms)
                {
                    dgvRooms.Rows.Add(new DataGridViewRow());
                    dgvRooms.Rows[i].Cells[0].Value = room.Id;
                    dgvRooms.Rows[i].Cells[1].Value = room.RoomName;
                    dgvRooms.Rows[i].Cells[2].Value = room.Capacity;
                    dgvRooms.Rows[i].Cells[3].Value = room.Price;
                    i++;
                }
            }
            if (_db.Rooms.Count() > 1)
            {
                dgvRooms.Rows[1].Selected = true;
                dgvRooms.Rows[0].Selected = true;
            }
        }

        private void dgvRooms_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count < 1)
                return;

            int? id = (int?)dgvRooms.SelectedRows[0].Cells[0].Value;
            Room room = _db.Rooms.FirstOrDefault(x => x.Id == id);

            if (room != null)
            {
                lstCustomers.DataSource = room.Reservations.Select(x => x.Room).ToList();
                lstFeatures.DataSource = room.Features.ToList();
                lstReservations.DataSource = room.Reservations.ToList();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dgvRooms.Rows.Clear();

            if (_db.Rooms.Count() > 0)
            {
                if (txtSearch.Text.Trim() == "")
                {
                    ShowRooms();
                }
                else
                {
                    int i = 0;
                    foreach (var room in _db.Rooms.Where(x => x.RoomName.Contains(txtSearch.Text.Trim())))
                    {
                        dgvRooms.Rows.Add(new DataGridViewRow());
                        dgvRooms.Rows[i].Cells[0].Value = room.Id;
                        dgvRooms.Rows[i].Cells[1].Value = room.RoomName;
                        dgvRooms.Rows[i].Cells[2].Value = room.Capacity;
                        dgvRooms.Rows[i].Cells[3].Value = room.Price;
                        i++;
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvRooms.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please choose a room!");
                return;
            }

            int? id = (int?)dgvRooms.SelectedRows[0].Cells[0].Value;
            Room room = _db.Rooms.FirstOrDefault(x => x.Id == id);

            _db.Rooms.Remove(room);
            _db.SaveChanges();
            ShowRooms();
            txtSearch.Text = "";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            dgvRooms.Enabled = false;
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            btnCancel.Text = "Cancel ";
            btnCreate.Text = "Update";

            int? id = (int?)dgvRooms.SelectedRows[0].Cells[0].Value;
            Room room = _db.Rooms.FirstOrDefault(x => x.Id == id);

            txtRoomName.Text = room.RoomName;
            nudCapacity.Value = room.Capacity;
            nudPrice.Value = room.Price;
            for (int i = 0; i < clbFeatures.Items.Count; i++)
            {
                clbFeatures.SetItemChecked(i, room.Features.Contains(clbFeatures.Items[i]));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Cancel")
                this.Close();

            if (btnCancel.Text == "Cancel ")
                ClearFills();
        }

        private void ClearFills()
        {
            dgvRooms.Enabled = true;
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            btnCancel.Text = "Cancel";
            btnCreate.Text = "Create Room";
            txtRoomName.Text = "";
            nudCapacity.Value = 1;
            nudPrice.Value = 1;
            ListCheckBox();
        }

        private void ListCheckBox()
        {
            clbFeatures.DataSource = _db.Features.ToList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtRoomName.Text.Trim() == "")
            {
                MessageBox.Show("Name of the room can not be empty!");
                return;
            }

            if (btnCreate.Text == "Create Room")
            {
                Room room = new Room()
                {
                    RoomName = txtRoomName.Text.Trim(),
                    Capacity = (int)nudCapacity.Value,
                    Price = (int)nudPrice.Value
                };

                for (int i = 0; i < clbFeatures.Items.Count; i++)
                {
                    Feature feature = (Feature)clbFeatures.Items[i];
                    if (clbFeatures.GetItemChecked(i))
                    {
                        room.Features.Add(feature);
                    }
                }

                _db.Rooms.Add(room);
            }

            if (btnCreate.Text == "Update")
            {
                int? id = (int?)dgvRooms.SelectedRows[0].Cells[0].Value;
                Room room = _db.Rooms.FirstOrDefault(x => x.Id == id);

                room.RoomName = txtRoomName.Text.Trim();
                room.Capacity = (int)nudCapacity.Value;
                room.Price = (int)nudPrice.Value;
                for (int i = 0; i < clbFeatures.Items.Count; i++)
                {
                    Feature feature = (Feature)clbFeatures.Items[i];
                    room.Features.Remove(feature);
                    if (clbFeatures.GetItemChecked(i))
                    {
                        room.Features.Add(feature);
                    }
                }
            }

            _db.SaveChanges();
            ShowRooms();
            ClearFills();
        }
    }
}
