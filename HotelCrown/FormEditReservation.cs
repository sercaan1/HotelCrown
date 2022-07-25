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
    public partial class FormEditReservation : Form
    {
        ContextDb _db;
        Reservation _reservation;
        public FormEditReservation(ContextDb db, Reservation reservation)
        {
            _db = db;
            _reservation = reservation;
            InitializeComponent();
            ShowDatas();
        }

        private void ShowDatas()
        {
            dtpCheckIn.Value = (DateTime)_reservation.CheckInDate;
            dtpCheckOut.Value = (DateTime)_reservation.CheckOutDate;
            dtpCheckInTime.Value = (DateTime)_reservation.CheckInDate;
            dtpCheckOutTime.Value = (DateTime)_reservation.CheckOutDate;
            nudCheckInHour.Value = (decimal)14.00;
            nudCheckOutHour.Value = (decimal)12.00;
            var rooms = _db.Reservations.Where(x => x.CheckInDate < dtpCheckIn.Value && x.CheckOutDate > dtpCheckOut.Value).Select(x => x.Room).ToList();
            rooms.Insert(0, _reservation.Room);
            cmbRooms.DataSource = rooms.ToList();
            clbCustomers.DataSource = _db.Customers.Where(x => x.Reservation == null || x.Reservation.Id == _reservation.Id).ToList();
            for (int i = 0; i < clbCustomers.Items.Count; i++)
            {
                clbCustomers.SetItemChecked(i, _reservation.Customers.Contains(clbCustomers.Items[i]));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (dtpCheckIn.Value > dtpCheckOut.Value)
            {
                MessageBox.Show("Check-in date can not be further than check-out date");
                return;
            }
            if (dtpCheckIn.Value == dtpCheckOut.Value)
            {
                MessageBox.Show("Customer should stay at least one night!");
                return;
            }
            string[] dateString3 = dtpCheckIn.Value.ToShortDateString().Split('.');

            int[] dateInt3 = Array.ConvertAll(dateString3, x => int.Parse(x));

            string[] dateString4 = dtpCheckOut.Value.ToShortDateString().Split('.');

            int[] dateInt4 = Array.ConvertAll(dateString4, x => int.Parse(x));

            DateTime checkIn1 = new DateTime(dateInt3[2], dateInt3[1], dateInt3[0], 14, 0, 0);

            _reservation.CheckInDate = new DateTime?(checkIn1);

            DateTime checkOut1 = new DateTime(dateInt4[2], dateInt4[1], dateInt4[0], 12, 0, 0);

            _reservation.CheckOutDate = new DateTime?(checkOut1);

            if (cboCheckIn.Checked)
            {
                string[] dateString = dtpCheckInTime.Value.ToShortDateString().Split('.');
                int[] dateInt = Array.ConvertAll(dateString, x => int.Parse(x));

                DateTime checkIn2 = new DateTime(dateInt[2], dateInt[1], dateInt[0], (int)nudCheckInHour.Value, 0, 0);

                _reservation.CheckedInTime = new DateTime?(checkIn2);
            }
            if (cboCheckOut.Checked)
            {
                string[] dateString2 = dtpCheckOutTime.Value.ToShortDateString().Split('.');
                int[] dateInt2 = Array.ConvertAll(dateString2, x => int.Parse(x));

                DateTime checkOut2 = new DateTime(dateInt2[2], dateInt2[1], dateInt2[0], (int)nudCheckOutHour.Value, 0, 0);

                _reservation.CheckedOutTime = new DateTime?(checkOut2);
            }

            _reservation.Room = (Room)cmbRooms.SelectedItem;
            for (int i = 0; i < clbCustomers.Items.Count; i++)
            {
                Customer customer = (Customer)clbCustomers.Items[i];
                _reservation.Customers.Remove(customer);
                if (clbCustomers.GetItemChecked(i))
                {
                    _reservation.Customers.Add(customer);
                }
            }
            _db.SaveChanges();
            this.Close();
        }

        private void cboCheckIn_CheckedChanged(object sender, EventArgs e)
        {
            if (cboCheckIn.Checked)
            {
                dtpCheckInTime.Enabled = true;
                nudCheckInHour.Enabled = true;
            }
            else if (!cboCheckIn.Checked)
            {
                dtpCheckInTime.Enabled = false;
                nudCheckInHour.Enabled = false;
            }
        }

        private void cboCheckOut_CheckedChanged(object sender, EventArgs e)
        {
            if (cboCheckOut.Checked)
            {
                dtpCheckOutTime.Enabled = true;
                nudCheckOutHour.Enabled = true;
            }
            else if (!cboCheckOut.Checked)
            {
                dtpCheckOutTime.Enabled = false;
                nudCheckOutHour.Enabled = false;
            }
        }
    }
}
