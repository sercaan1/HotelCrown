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
    public partial class FormServices : Form
    {
        ContextDb _db; 
        public FormServices(ContextDb db)
        {
            _db = db;
            InitializeComponent();
            ShowServices();
        }

        private void ShowServices()
        {
            dgvServices.Rows.Clear();

            if (_db.Services.Count() > 0)
            {
                int i = 0;
                foreach (var service in _db.Services)
                {
                    dgvServices.Rows.Add(new DataGridViewRow());
                    dgvServices.Rows[i].Cells[0].Value = service.Id;
                    dgvServices.Rows[i].Cells[1].Value = service.ServiceName;
                    dgvServices.Rows[i].Cells[2].Value = service.UnitPrice;
                    i++;
                }
            }
        }

        private void dgvServices_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count < 1)
                return;

            int? id = (int?)dgvServices.SelectedRows[0].Cells[0].Value;
            Service service = _db.Services.FirstOrDefault(x => x.Id == id);

            if (service != null)
            {
                lstCustomers.DataSource = service.Customers.ToList();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please choose a service!");
                return;
            }

            int? id = (int?)dgvServices.SelectedRows[0].Cells[0].Value;
            Service service = _db.Services.FirstOrDefault(x => x.Id == id);

            _db.Services.Remove(service);
            _db.SaveChanges();
            ShowServices();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count < 1)
            {
                MessageBox.Show("Please choose a service!");
                return;
            }

            int? id = (int?)dgvServices.SelectedRows[0].Cells[0].Value;
            Service service = _db.Services.FirstOrDefault(x => x.Id == id);

            btnCreate.Text = "Update";
            btnCancel.Text = "Cancel ";
            btnDelete.Enabled = false;
            btnEdit.Enabled = false;
            dgvServices.Enabled = false;

            txtService.Text = service.ServiceName;
            nudPrice.Value = service.UnitPrice;
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
            btnCreate.Text = "Create Service";
            btnCancel.Text = "Cancel";
            btnDelete.Enabled = true;
            btnEdit.Enabled = true;
            dgvServices.Enabled = true;
            txtService.Text = "";
            nudPrice.Value = 1;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (txtService.Text.Trim() == "")
            {
                MessageBox.Show("Name of the service can not be empty!");
                return;
            }

            if (btnCreate.Text == "Create Service")
            {
                Service service = new Service()
                {
                    ServiceName = txtService.Text.Trim(),
                    UnitPrice = nudPrice.Value,
                };

                _db.Services.Add(service);
            }

            if (btnCreate.Text == "Update")
            {
                int? id = (int?)dgvServices.SelectedRows[0].Cells[0].Value;
                Service service = _db.Services.FirstOrDefault(x => x.Id == id);

                service.ServiceName = txtService.Text.Trim();
                service.UnitPrice = nudPrice.Value;
            }

            _db.SaveChanges();
            ShowServices();
            ClearFills();
        }
    }
}
