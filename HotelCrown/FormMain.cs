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
    public partial class FormMain : Form
    {
        ContextDb db = new ContextDb();
        public FormMain()
        {
            InitializeComponent();
            ShowReservations();
        }

        private void ShowReservations()
        {
            dgvReservations.Rows.Clear();
            if (db.Reservations.Count() > 0)
            {
                int i = 0;
                foreach (var reservation in db.Reservations)
                {
                    dgvReservations.Rows.Add(new DataGridViewRow());
                    dgvReservations.Rows[i].Cells[0].Value = reservation.Id;
                    dgvReservations.Rows[i].Cells[1].Value = reservation.Room;
                    dgvReservations.Rows[i].Cells[2].Value = ((DateTime)reservation.CheckInDate).ToShortDateString();
                    dgvReservations.Rows[i].Cells[3].Value = ((DateTime)reservation.CheckOutDate).ToShortDateString();
                    dgvReservations.Rows[i].Cells[4].Value = reservation.CheckedInTime == null ? "No" : "Yes";
                    dgvReservations.Rows[i].Cells[5].Value = reservation.CheckedOutTime == null ? "No" : "Yes";
                    i++;
                }
            }
        }

        private void tsmiRooms_Click(object sender, EventArgs e)
        {
            FormRooms formRooms = new FormRooms(db);
            formRooms.ShowDialog();
        }

        private void tsmiFeatures_Click(object sender, EventArgs e)
        {
            FormFeatures formFeatures = new FormFeatures(db);
            formFeatures.ShowDialog();
        }

        private void tsmiServices_Click(object sender, EventArgs e)
        {
            FormServices formServices = new FormServices(db);
            formServices.ShowDialog();
        }

        private void tsmiCustomers_Click(object sender, EventArgs e)
        {
            FormCustomers formCustomers = new FormCustomers(db);
            formCustomers.ShowDialog();
        }

        private void btnNewReservation_Click(object sender, EventArgs e)
        {
            FormNewReservation formNewReservation = new FormNewReservation(db);
            formNewReservation.ShowDialog();
            ShowReservations();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvReservations.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please choose a reservation to edit!");
                return;
            }
            int id = (int)dgvReservations.SelectedRows[0].Cells[0].Value;
            Reservation reservation = db.Reservations.FirstOrDefault(x => x.Id == id);
            FormEditReservation formEditReservation = new FormEditReservation(db, reservation);
            formEditReservation.ShowDialog();
            ShowReservations();
        }

        private void cboCheckedIn_CheckedChanged(object sender, EventArgs e)
        {
            if (cboCheckedIn.Checked)
            {
                dgvReservations.Rows.Clear();
                if (db.Reservations.Count() > 0)
                {
                    int i = 0;
                    foreach (var reservation in db.Reservations.Where(x => x.CheckedInTime != null))
                    {
                        dgvReservations.Rows.Add(new DataGridViewRow());
                        dgvReservations.Rows[i].Cells[0].Value = reservation.Id;
                        dgvReservations.Rows[i].Cells[1].Value = reservation.Room;
                        dgvReservations.Rows[i].Cells[2].Value = ((DateTime)reservation.CheckInDate).ToShortDateString();
                        dgvReservations.Rows[i].Cells[3].Value = ((DateTime)reservation.CheckOutDate).ToShortDateString();
                        dgvReservations.Rows[i].Cells[4].Value = reservation.CheckedInTime == null ? "No" : "Yes";
                        dgvReservations.Rows[i].Cells[5].Value = reservation.CheckedOutTime == null ? "No" : "Yes";
                        i++;
                    }
                }
            }
        }

        private void cboCheckedOut_CheckedChanged(object sender, EventArgs e)
        {
            if (cboCheckedOut.Checked)
            {
                dgvReservations.Rows.Clear();
                if (db.Reservations.Count() > 0)
                {
                    int i = 0;
                    foreach (var reservation in db.Reservations.Where(x => x.CheckedOutTime != null))
                    {
                        dgvReservations.Rows.Add(new DataGridViewRow());
                        dgvReservations.Rows[i].Cells[0].Value = reservation.Id;
                        dgvReservations.Rows[i].Cells[1].Value = reservation.Room;
                        dgvReservations.Rows[i].Cells[2].Value = ((DateTime)reservation.CheckInDate).ToShortDateString();
                        dgvReservations.Rows[i].Cells[3].Value = ((DateTime)reservation.CheckOutDate).ToShortDateString();
                        dgvReservations.Rows[i].Cells[4].Value = reservation.CheckedInTime == null ? "No" : "Yes";
                        dgvReservations.Rows[i].Cells[5].Value = reservation.CheckedOutTime == null ? "No" : "Yes";
                        i++;
                    }
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Trim() == "")
            {
                ShowReservations();
            }
            else
            {
                dgvReservations.Rows.Clear();
                if (db.Reservations.Count() > 0)
                {
                    int i = 0;
                    foreach (var reservation in db.Reservations.Where(x => x.Room.ToString().Contains(txtSearch.Text.Trim())))
                    {
                        dgvReservations.Rows.Add(new DataGridViewRow());
                        dgvReservations.Rows[i].Cells[0].Value = reservation.Id;
                        dgvReservations.Rows[i].Cells[1].Value = reservation.Room;
                        dgvReservations.Rows[i].Cells[2].Value = ((DateTime)reservation.CheckInDate).ToShortDateString();
                        dgvReservations.Rows[i].Cells[3].Value = ((DateTime)reservation.CheckOutDate).ToShortDateString();
                        dgvReservations.Rows[i].Cells[4].Value = reservation.CheckedInTime == null ? "No" : "Yes";
                        dgvReservations.Rows[i].Cells[5].Value = reservation.CheckedOutTime == null ? "No" : "Yes";
                        i++;
                    }
                }
            }
        }

        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

            //Burada bir şey hatalı ama ne bilmiyorum??
            dgvReservations.Rows.Clear();
            if (db.Reservations.Count() > 0)
            {
                int i = 0;

                var fullList = db.Reservations.Where(x => x.CheckInDate.HasValue && x.CheckOutDate.HasValue).ToList();
                foreach (var item in fullList)
                {
                    MessageBox.Show(item.CheckInDate.Value.ToString());
                    MessageBox.Show(dtpTo.Value.ToString());
                    MessageBox.Show(item.CheckOutDate.Value.ToString());
                    MessageBox.Show(dtpFrom.Value.ToString());
                }
                fullList = fullList.Where(x => x.CheckInDate.Value < dtpTo.Value && x.CheckOutDate.Value > dtpTo.Value).ToList();

                foreach (var reservation in fullList)
                {
                    dgvReservations.Rows.Add(new DataGridViewRow());
                    dgvReservations.Rows[i].Cells[0].Value = reservation.Id;
                    dgvReservations.Rows[i].Cells[1].Value = reservation.Room;
                    dgvReservations.Rows[i].Cells[2].Value = ((DateTime)reservation.CheckInDate).ToShortDateString();
                    dgvReservations.Rows[i].Cells[3].Value = ((DateTime)reservation.CheckOutDate).ToShortDateString();
                    dgvReservations.Rows[i].Cells[4].Value = reservation.CheckedInTime == null ? "No" : "Yes";
                    dgvReservations.Rows[i].Cells[5].Value = reservation.CheckedOutTime == null ? "No" : "Yes";
                    i++;
                }
            }
        }

        private void dgvReservations_SelectionChanged(object sender, EventArgs e)
        {
            if (db.Reservations.Count() < 1 || dgvReservations.SelectedRows.Count < 1)
                return;

            int? id = (int?)dgvReservations.SelectedRows[0].Cells[0].Value;
            if (id != null)
            {
                Reservation reservation = db.Reservations.First(x => x.Id == id);

                if (reservation != null)
                {
                    lstCustomers.DataSource = reservation.Customers.ToList();
                }
            }
        }
    }
}
