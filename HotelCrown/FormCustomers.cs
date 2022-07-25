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
    public partial class FormCustomers : Form
    {
        ContextDb _db;
        int gender;
        public FormCustomers(ContextDb db)
        {
            _db = db;
            InitializeComponent();
            ShowCustomers();
            ShowComboBox();
            ListCheckBox();
        }

        private void ListCheckBox()
        {
            clbServices.DataSource = _db.Services.ToList();
        }

        private void ShowComboBox()
        {
            cmbGender.Items.Add("Unknown");
            cmbGender.Items.Add("Male");
            cmbGender.Items.Add("Female");
            cmbGender.SelectedIndex = 0;
        }

        private void ShowCustomers()
        {
            dgvCustomers.Rows.Clear();
            if (_db.Customers.Count() > 0)
            {
                int i = 0;
                foreach (var customer in _db.Customers)
                {
                    dgvCustomers.Rows.Add(new DataGridViewRow());
                    dgvCustomers.Rows[i].Cells[0].Value = customer.Id;
                    dgvCustomers.Rows[i].Cells[1].Value = customer.FullName;
                    dgvCustomers.Rows[i].Cells[2].Value = customer.IdentityNumber;
                    dgvCustomers.Rows[i].Cells[3].Value = customer.PhoneNumber;
                    dgvCustomers.Rows[i].Cells[4].Value = customer.BirthDate.ToShortDateString();
                    dgvCustomers.Rows[i].Cells[5].Value = customer.Gender == 0 ? "Unknown" : customer.Gender == 1 ? "Male" : "Female";
                    dgvCustomers.Rows[i].Cells[6].Value = customer.Description;
                    i++;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (btnCancel.Text == "Cancel")
                this.Close();
            else if (btnCancel.Text == "Cancel ")
                ClearFills();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (cmbGender.SelectedIndex == 0)
                gender = 0;
            else if (cmbGender.SelectedIndex == 1)
                gender = 1;
            else gender = 2;
            string[] number = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0" };
            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Name of the customer can not be empty!");
                return;
            }
            if (dtpBirth.Value > DateTime.Now)
            {
                MessageBox.Show("Birth date of customer can not be further than today!");
                return;
            }
            if (btnCreate.Text == "Create Customer")
            {
                Customer customer = new Customer()
                {
                    FullName = txtName.Text.Trim(),
                    IdentityNumber = Convert.ToInt32(txtId.Text.Trim()),
                    PhoneNumber = Convert.ToInt32(txtPhoneNumber.Text.Trim()),
                    BirthDate = dtpBirth.Value,
                    Gender = gender,
                    Description = txtDescription.Text.Trim(),
                };
                
                for (int i = 0; i < clbServices.Items.Count; i++)
                {
                    if (clbServices.GetItemChecked(i))
                    {
                        Service service = (Service)clbServices.Items[i];
                        customer.Services.Add(service);
                    }
                }
                _db.Customers.Add(customer);
            }

            if (btnCreate.Text == "Update")
            {
                int id = (int)dgvCustomers.SelectedRows[0].Cells[0].Value;
                Customer customer = _db.Customers.FirstOrDefault(x => x.Id == id);

                customer.FullName = txtName.Text.Trim();
                customer.BirthDate = dtpBirth.Value;
                customer.Description = txtDescription.Text.Trim();
                customer.Gender = gender;
                customer.IdentityNumber = Convert.ToInt32(txtId.Text.Trim());
                customer.PhoneNumber = Convert.ToInt32(txtPhoneNumber.Text.Trim());

                for (int i = 0; i < clbServices.Items.Count; i++)
                {
                    Service service = (Service)clbServices.Items[i];
                    customer.Services.Remove(service);
                    if (clbServices.GetItemChecked(i))
                    {
                        customer.Services.Add(service);
                    }
                }
            }

            _db.SaveChanges();
            ShowCustomers();
            ClearFills();
        }

        private void ClearFills()
        {
            btnCancel.Text = "Cancel";
            btnCreate.Text = "Create Customer";
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            dgvCustomers.Enabled = true;
            txtName.Text = "";
            txtDescription.Text = "";
            txtId.Text = "";
            txtPhoneNumber.Text = "";
            dtpBirth.Value = DateTime.Now;
            ListCheckBox();
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count < 1)
                return;

            int? id = (int?)dgvCustomers.SelectedRows[0].Cells[0].Value;
            Customer customer = _db.Customers.FirstOrDefault(x => x.Id == id);

            if (customer != null)
            {
                lstServices.DataSource = customer.Services;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please choose a customer!");
                return;
            }
            int id = (int)dgvCustomers.SelectedRows[0].Cells[0].Value;
            Customer customer = _db.Customers.FirstOrDefault(x => x.Id == id);

            _db.Customers.Remove(customer);
            _db.SaveChanges();
            ShowCustomers();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please choose a customer!");
                return;
            }

            btnCreate.Text = "Update";
            btnCancel.Text = "Cancel ";
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            dgvCustomers.Enabled = false;

            int id = (int)dgvCustomers.SelectedRows[0].Cells[0].Value;
            Customer customer = _db.Customers.FirstOrDefault(x => x.Id == id);

            txtName.Text = customer.FullName;
            txtDescription.Text = customer.Description;
            txtId.Text = customer.IdentityNumber.ToString();
            txtPhoneNumber.Text = customer.PhoneNumber.ToString();
            dtpBirth.Value = customer.BirthDate;

            for (int i = 0; i < clbServices.Items.Count; i++)
            {
                clbServices.SetItemChecked(i, customer.Services.Contains(clbServices.Items[i]));
            }
        }
    }
}
