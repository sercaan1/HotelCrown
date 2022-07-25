
namespace HotelCrown
{
    partial class FormEditReservation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nudCheckOutHour = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudCheckInHour = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.dtpCheckOutTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpCheckInTime = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.clbCustomers = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbRooms = new System.Windows.Forms.ComboBox();
            this.dtpCheckOut = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpCheckIn = new System.Windows.Forms.DateTimePicker();
            this.cboCheckIn = new System.Windows.Forms.CheckBox();
            this.cboCheckOut = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCheckOutHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCheckInHour)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboCheckOut);
            this.groupBox1.Controls.Add(this.cboCheckIn);
            this.groupBox1.Controls.Add(this.nudCheckOutHour);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.nudCheckInHour);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.dtpCheckOutTime);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpCheckInTime);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnCreate);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.clbCustomers);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cmbRooms);
            this.groupBox1.Controls.Add(this.dtpCheckOut);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpCheckIn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 700);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edit Reservation";
            // 
            // nudCheckOutHour
            // 
            this.nudCheckOutHour.Enabled = false;
            this.nudCheckOutHour.Location = new System.Drawing.Point(173, 364);
            this.nudCheckOutHour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudCheckOutHour.Name = "nudCheckOutHour";
            this.nudCheckOutHour.Size = new System.Drawing.Size(196, 24);
            this.nudCheckOutHour.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(163, 18);
            this.label8.TabIndex = 16;
            this.label8.Text = "Check Out Time(Hour):";
            // 
            // nudCheckInHour
            // 
            this.nudCheckInHour.Enabled = false;
            this.nudCheckInHour.Location = new System.Drawing.Point(176, 216);
            this.nudCheckInHour.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudCheckInHour.Name = "nudCheckInHour";
            this.nudCheckInHour.Size = new System.Drawing.Size(195, 24);
            this.nudCheckInHour.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Check In Time(Hour):";
            // 
            // dtpCheckOutTime
            // 
            this.dtpCheckOutTime.Enabled = false;
            this.dtpCheckOutTime.Location = new System.Drawing.Point(173, 320);
            this.dtpCheckOutTime.Name = "dtpCheckOutTime";
            this.dtpCheckOutTime.Size = new System.Drawing.Size(196, 24);
            this.dtpCheckOutTime.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 320);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "Check Out Time:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Check In Time:";
            // 
            // dtpCheckInTime
            // 
            this.dtpCheckInTime.Enabled = false;
            this.dtpCheckInTime.Location = new System.Drawing.Point(175, 175);
            this.dtpCheckInTime.Name = "dtpCheckInTime";
            this.dtpCheckInTime.Size = new System.Drawing.Size(196, 24);
            this.dtpCheckInTime.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(266, 633);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(105, 49);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(148, 633);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(112, 49);
            this.btnCreate.TabIndex = 8;
            this.btnCreate.Text = "Update Reservation";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 461);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Customers:";
            // 
            // clbCustomers
            // 
            this.clbCustomers.FormattingEnabled = true;
            this.clbCustomers.Location = new System.Drawing.Point(175, 461);
            this.clbCustomers.Name = "clbCustomers";
            this.clbCustomers.Size = new System.Drawing.Size(196, 156);
            this.clbCustomers.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 421);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Available Rooms:";
            // 
            // cmbRooms
            // 
            this.cmbRooms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRooms.FormattingEnabled = true;
            this.cmbRooms.Location = new System.Drawing.Point(175, 413);
            this.cmbRooms.Name = "cmbRooms";
            this.cmbRooms.Size = new System.Drawing.Size(196, 26);
            this.cmbRooms.TabIndex = 4;
            // 
            // dtpCheckOut
            // 
            this.dtpCheckOut.Location = new System.Drawing.Point(175, 84);
            this.dtpCheckOut.Name = "dtpCheckOut";
            this.dtpCheckOut.Size = new System.Drawing.Size(196, 24);
            this.dtpCheckOut.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Check Out Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Check In Date:";
            // 
            // dtpCheckIn
            // 
            this.dtpCheckIn.Location = new System.Drawing.Point(175, 34);
            this.dtpCheckIn.Name = "dtpCheckIn";
            this.dtpCheckIn.Size = new System.Drawing.Size(196, 24);
            this.dtpCheckIn.TabIndex = 0;
            // 
            // cboCheckIn
            // 
            this.cboCheckIn.AutoSize = true;
            this.cboCheckIn.Location = new System.Drawing.Point(9, 133);
            this.cboCheckIn.Name = "cboCheckIn";
            this.cboCheckIn.Size = new System.Drawing.Size(164, 22);
            this.cboCheckIn.TabIndex = 18;
            this.cboCheckIn.Text = "Customer Check-In?";
            this.cboCheckIn.UseVisualStyleBackColor = true;
            this.cboCheckIn.CheckedChanged += new System.EventHandler(this.cboCheckIn_CheckedChanged);
            // 
            // cboCheckOut
            // 
            this.cboCheckOut.AutoSize = true;
            this.cboCheckOut.Location = new System.Drawing.Point(9, 269);
            this.cboCheckOut.Name = "cboCheckOut";
            this.cboCheckOut.Size = new System.Drawing.Size(177, 22);
            this.cboCheckOut.TabIndex = 19;
            this.cboCheckOut.Text = "Customer Check-Out?";
            this.cboCheckOut.UseVisualStyleBackColor = true;
            this.cboCheckOut.CheckedChanged += new System.EventHandler(this.cboCheckOut_CheckedChanged);
            // 
            // FormEditReservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 717);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEditReservation";
            this.Text = "Edit Reservation";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCheckOutHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCheckInHour)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckedListBox clbCustomers;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbRooms;
        private System.Windows.Forms.DateTimePicker dtpCheckOut;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpCheckIn;
        private System.Windows.Forms.DateTimePicker dtpCheckOutTime;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpCheckInTime;
        private System.Windows.Forms.NumericUpDown nudCheckOutHour;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudCheckInHour;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cboCheckOut;
        private System.Windows.Forms.CheckBox cboCheckIn;
    }
}