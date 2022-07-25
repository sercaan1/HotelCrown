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
    public partial class FormNewReservation : Form
    {
        ContextDb _db;
        public FormNewReservation(ContextDb db)
        {
            _db = db;
            InitializeComponent();
            ShowComboBox();
            ListCheckBox();
        }

        private void ListCheckBox()
        {
            clbCustomers.DataSource = _db.Customers.Where(x => x.Reservation == null).ToList();
        }

        private void ShowComboBox()
        {

            // Tarihler arasındaki rezervasyonları çek
            // Bu rezervasyonlara ait odaları ayırt
            // Bu odaların dışındaki odaları listele

            var roomsWithoutReservation = _db.Rooms.Where(x => x.Reservations.Count == 0).ToList();
            var roomsFreeThatDate = _db.Reservations.Where(x => x.CheckInDate.Value > dtpCheckOut.Value || x.CheckOutDate < dtpCheckIn.Value).Select(x => x.Room).ToList();
            roomsWithoutReservation.AddRange(roomsFreeThatDate);
            cmbRooms.DataSource = roomsWithoutReservation.ToList();

            //var roomsWithoutRzzzzzzzzerv = _db.Reservations.Where(x => x.CheckInDate.Value > dtpCheckIn.Value && x.CheckOutDate.Value < dtpCheckOut.Value).Select(x => x.Room).ToList();
            //var roomsWithoutRezerv = _db.Rooms.Where(x => x.Reservations.Count == 0).ToList();
            //roomsWithoutRezerv.AddRange(roomsWithoutRzzzzzzzzerv);
            //cmbRooms.DataSource = roomsWithoutRezerv.ToList();
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
            if (cmbRooms.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose a room!");
                return;
            }

            string[] dateString = dtpCheckIn.Value.ToShortDateString().Split('.');

            int[] dateInt = Array.ConvertAll(dateString, x => int.Parse(x));

            string[] dateString2 = dtpCheckOut.Value.ToShortDateString().Split('.');

            int[] dateInt2 = Array.ConvertAll(dateString2, x => int.Parse(x));

            Reservation reservation = new Reservation();
            DateTime checkIn = new DateTime(dateInt[2], dateInt[1], dateInt[0], 14, 0, 0);
            reservation.CheckInDate = new DateTime?(checkIn);
            DateTime checkOut = new DateTime(dateInt2[2], dateInt2[1], dateInt2[0], 12, 0, 0);
            reservation.CheckOutDate = new DateTime?(checkOut);
            reservation.Room = (Room)cmbRooms.SelectedItem;
            for (int i = 0; i < clbCustomers.Items.Count; i++)
            {
                if (clbCustomers.GetItemChecked(i))
                {
                    Customer customer = (Customer)clbCustomers.Items[i];
                    reservation.Customers.Add(customer);
                }
            }
            _db.Reservations.Add(reservation);
            _db.SaveChanges();
            ClearFills();
        }

        private void ClearFills()
        {
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now;
            ShowComboBox();
            ListCheckBox();
        }

        private void dtpCheckOut_ValueChanged(object sender, EventArgs e)
        {
            ShowComboBox();
        }

        private void dtpCheckIn_ValueChanged(object sender, EventArgs e)
        {
            ShowComboBox();
        }
    }
}
