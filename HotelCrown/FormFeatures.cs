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
    public partial class FormFeatures : Form
    {
        ContextDb _db;
        public FormFeatures(ContextDb db)
        {
            _db = db;
            InitializeComponent();
            ShowFeatures();
            ListCheckBox();
        }

        private void ShowFeatures()
        {
            dgvFeatures.Rows.Clear();
            if (_db.Features.Count() > 0)
            {
                int i = 0;
                foreach (var feature in _db.Features)
                {
                    dgvFeatures.Rows.Add(new DataGridViewRow());
                    dgvFeatures.Rows[i].Cells[0].Value = feature.Id;
                    dgvFeatures.Rows[i].Cells[1].Value = feature.FeatureName;
                    i++;
                }
            }
            if (_db.Features.Count() > 1)
            {
                dgvFeatures.Rows[1].Selected = true;
                dgvFeatures.Rows[0].Selected = true;
            }
        }

        private void dgvFeatures_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFeatures.SelectedRows.Count < 1)
                return;

            int? id = (int?)dgvFeatures.SelectedRows[0].Cells[0].Value;
            Feature feature = _db.Features.FirstOrDefault(x => x.Id == id);

            if (feature != null)
            {
                lstRooms.DataSource = feature.Rooms.ToList();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Cancel")
                this.Close();
            else if (btnCancel.Text == "Cancel ")
                ClearFills();
        }

        private void ClearFills()
        {
            btnCancel.Text = "Cancel";
            btnCreate.Text = "Create Feature";
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            dgvFeatures.Enabled = true;
            txtName.Text = "";
            ListCheckBox();
        }

        private void ListCheckBox()
        {
            clbRooms.DataSource = _db.Rooms.ToList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Name of the feature can not be empty!");
                return;
            }

            if (btnCreate.Text == "Create Feature")
            {
                Feature feature = new Feature()
                {
                    FeatureName = txtName.Text.Trim(),
                };

                for (int i = 0; i < clbRooms.Items.Count; i++)
                {
                    if (clbRooms.GetItemChecked(i))
                    {
                        Room room = (Room)clbRooms.Items[i];
                        feature.Rooms.Add(room);
                    }
                }
                _db.Features.Add(feature);
            }

            if (btnCreate.Text == "Update")
            {
                int id = (int)dgvFeatures.SelectedRows[0].Cells[0].Value;
                Feature feature = _db.Features.FirstOrDefault(x => x.Id == id);

                feature.FeatureName = txtName.Text;
                for (int i = 0; i < clbRooms.Items.Count; i++)
                {
                    Room room = (Room)clbRooms.Items[i];
                    feature.Rooms.Remove(room);
                    if (clbRooms.GetItemChecked(i))
                    {
                        feature.Rooms.Add(room);
                    }
                }
            }

            _db.SaveChanges();
            ShowFeatures();
            ClearFills();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvFeatures.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please choose a feature");
                return;
            }

            int id = (int)dgvFeatures.SelectedRows[0].Cells[0].Value;
            Feature feature = _db.Features.FirstOrDefault(x => x.Id == id);

            _db.Features.Remove(feature);
            _db.SaveChanges();
            ShowFeatures();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvFeatures.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please choose a feature");
                return;
            }

            int id = (int)dgvFeatures.SelectedRows[0].Cells[0].Value;
            Feature feature = _db.Features.FirstOrDefault(x => x.Id == id);

            btnCancel.Text = "Cancel ";
            btnCreate.Text = "Update";
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            dgvFeatures.Enabled = false;
            txtName.Text = feature.FeatureName;

            for (int i = 0; i < clbRooms.Items.Count; i++)
            {
                clbRooms.SetItemChecked(i, feature.Rooms.Contains(clbRooms.Items[i]));
            }
        }
    }
}
