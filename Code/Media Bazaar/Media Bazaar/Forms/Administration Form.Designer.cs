using System.Windows.Forms;

namespace Media_Bazaar
{
    partial class Administration_Form
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
            this.tabControl_Administration = new System.Windows.Forms.TabControl();
            this.tabPage_ManageEmployees = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnPartTime = new System.Windows.Forms.RadioButton();
            this.rbtnFulltime = new System.Windows.Forms.RadioButton();
            this.button_GenerateQR = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox_ID_ManageEmployees_Administration = new System.Windows.Forms.TextBox();
            this.cmbDepartmentAdd = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbSpouse = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbtnUnknown = new System.Windows.Forms.RadioButton();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.rbtMale = new System.Windows.Forms.RadioButton();
            this.Salary = new System.Windows.Forms.Label();
            this.tbSalary = new System.Windows.Forms.TextBox();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpBirth = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.tbFunctions = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_Email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.panel_ManageEmployees_Administartion = new System.Windows.Forms.Panel();
            this.label_ManageEmployees_Administartion = new System.Windows.Forms.Label();
            this.button_Logout_ManageEmployee_Administration = new System.Windows.Forms.Button();
            this.dataGridView_ManageEmployees_Administration = new System.Windows.Forms.DataGridView();
            this.button_Rmv_ManageEmployee_Administration = new System.Windows.Forms.Button();
            this.button_Edit_ManageEmployee_Administration = new System.Windows.Forms.Button();
            this.button_Add_ManageEmployee_Administration = new System.Windows.Forms.Button();
            this.radioButton_No_ManageEmployee_Administration = new System.Windows.Forms.RadioButton();
            this.radioButton_Yes_ManageEmployee_Administration = new System.Windows.Forms.RadioButton();
            this.textBox_Languages_ManageEmployee_Administration = new System.Windows.Forms.TextBox();
            this.textBox_Certificates_ManageEmployee_Administration = new System.Windows.Forms.TextBox();
            this.textBox_Address_ManageEmployee_Administration = new System.Windows.Forms.TextBox();
            this.textBox_BSN_ManageEmployee_Administration = new System.Windows.Forms.TextBox();
            this.textBox_Phone_ManageEmployees_Administration = new System.Windows.Forms.TextBox();
            this.textBox_LastName_ManageEmployee_Administartion = new System.Windows.Forms.TextBox();
            this.textBox_FirstName_ManageEmloyee_Administration = new System.Windows.Forms.TextBox();
            this.label_Married_ManageEmployee_Administration = new System.Windows.Forms.Label();
            this.label_Languages_ManageEmployees_Administration = new System.Windows.Forms.Label();
            this.label_Certificates_ManagEepoyee_Administartion = new System.Windows.Forms.Label();
            this.label_Address_ManageEmployee_Administration = new System.Windows.Forms.Label();
            this.label_Role_ManageEmployee_Administration = new System.Windows.Forms.Label();
            this.label_StartDate_ManageEmployee_Administration = new System.Windows.Forms.Label();
            this.label_BSN_ManageEmployee_Administration = new System.Windows.Forms.Label();
            this.label_DateOfBirth_ManageEmployee_Administration = new System.Windows.Forms.Label();
            this.label_Phone_ManageEmloyee_Admnistartion = new System.Windows.Forms.Label();
            this.label_LastName_ManageEmployee_Administration = new System.Windows.Forms.Label();
            this.label_FirstName_ManageEmployee_Administration = new System.Windows.Forms.Label();
            this.label_ID_ManageEmployees_Administration = new System.Windows.Forms.Label();
            this.tabPage_MangeShifts = new System.Windows.Forms.TabPage();
            this.label26 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.lbSundayEvening = new System.Windows.Forms.ListBox();
            this.lbSundayAfternoon = new System.Windows.Forms.ListBox();
            this.lbSundayMorning = new System.Windows.Forms.ListBox();
            this.lbSaturdayEvening = new System.Windows.Forms.ListBox();
            this.lbSaturdayAfternoon = new System.Windows.Forms.ListBox();
            this.lbSaturdayMorning = new System.Windows.Forms.ListBox();
            this.lbFridayEvening = new System.Windows.Forms.ListBox();
            this.lbFridayAfternoon = new System.Windows.Forms.ListBox();
            this.lbFridayMorning = new System.Windows.Forms.ListBox();
            this.lbThursdayEvening = new System.Windows.Forms.ListBox();
            this.lbThursdayAfternoon = new System.Windows.Forms.ListBox();
            this.lbThursdayMorning = new System.Windows.Forms.ListBox();
            this.lbWednesdayEvening = new System.Windows.Forms.ListBox();
            this.lbWednesdayAfternoon = new System.Windows.Forms.ListBox();
            this.lbWednesdayMorning = new System.Windows.Forms.ListBox();
            this.lbTuesdayEvening = new System.Windows.Forms.ListBox();
            this.lbTuesdayAfternoon = new System.Windows.Forms.ListBox();
            this.lbTuesdayMorning = new System.Windows.Forms.ListBox();
            this.lbMondayEvening = new System.Windows.Forms.ListBox();
            this.lbMondayAfternoon = new System.Windows.Forms.ListBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbMondayMorning = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbWeek = new System.Windows.Forms.ComboBox();
            this.btnAssignAutomaticShift = new System.Windows.Forms.Button();
            this.cmbDepartments = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel_ManageShifts_Administartion = new System.Windows.Forms.Panel();
            this.label_ManageShifts_Administartion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button_Logout_ManageShifts_Adminisration = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbNumberPerShift = new System.Windows.Forms.TextBox();
            this.btnCreateSchedule = new System.Windows.Forms.Button();
            this.cmbShiftType = new System.Windows.Forms.ComboBox();
            this.cmbPosition = new System.Windows.Forms.ComboBox();
            this.cmbWeekOfYear = new System.Windows.Forms.ComboBox();
            this.dataGridViewWeeks = new System.Windows.Forms.DataGridView();
            this.mySqlCommand1 = new MySql.Data.MySqlClient.MySqlCommand();
            this.tabControl_Administration.SuspendLayout();
            this.tabPage_ManageEmployees.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.panel_ManageEmployees_Administartion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ManageEmployees_Administration)).BeginInit();
            this.tabPage_MangeShifts.SuspendLayout();
            this.panel_ManageShifts_Administartion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeeks)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl_Administration
            // 
            this.tabControl_Administration.Controls.Add(this.tabPage_ManageEmployees);
            this.tabControl_Administration.Controls.Add(this.tabPage_MangeShifts);
            this.tabControl_Administration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl_Administration.Location = new System.Drawing.Point(-4, 2);
            this.tabControl_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl_Administration.Name = "tabControl_Administration";
            this.tabControl_Administration.SelectedIndex = 0;
            this.tabControl_Administration.Size = new System.Drawing.Size(1720, 842);
            this.tabControl_Administration.TabIndex = 0;
            // 
            // tabPage_ManageEmployees
            // 
            this.tabPage_ManageEmployees.BackColor = System.Drawing.Color.LightCyan;
            this.tabPage_ManageEmployees.Controls.Add(this.label6);
            this.tabPage_ManageEmployees.Controls.Add(this.groupBox1);
            this.tabPage_ManageEmployees.Controls.Add(this.button_GenerateQR);
            this.tabPage_ManageEmployees.Controls.Add(this.pictureBox1);
            this.tabPage_ManageEmployees.Controls.Add(this.textBox_ID_ManageEmployees_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.cmbDepartmentAdd);
            this.tabPage_ManageEmployees.Controls.Add(this.label5);
            this.tabPage_ManageEmployees.Controls.Add(this.tbSpouse);
            this.tabPage_ManageEmployees.Controls.Add(this.label10);
            this.tabPage_ManageEmployees.Controls.Add(this.cmbRole);
            this.tabPage_ManageEmployees.Controls.Add(this.groupBox3);
            this.tabPage_ManageEmployees.Controls.Add(this.Salary);
            this.tabPage_ManageEmployees.Controls.Add(this.tbSalary);
            this.tabPage_ManageEmployees.Controls.Add(this.dtpStart);
            this.tabPage_ManageEmployees.Controls.Add(this.dtpBirth);
            this.tabPage_ManageEmployees.Controls.Add(this.label4);
            this.tabPage_ManageEmployees.Controls.Add(this.tbFunctions);
            this.tabPage_ManageEmployees.Controls.Add(this.label3);
            this.tabPage_ManageEmployees.Controls.Add(this.tb_Email);
            this.tabPage_ManageEmployees.Controls.Add(this.label2);
            this.tabPage_ManageEmployees.Controls.Add(this.tbPassword);
            this.tabPage_ManageEmployees.Controls.Add(this.label1);
            this.tabPage_ManageEmployees.Controls.Add(this.tbUserName);
            this.tabPage_ManageEmployees.Controls.Add(this.panel_ManageEmployees_Administartion);
            this.tabPage_ManageEmployees.Controls.Add(this.dataGridView_ManageEmployees_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.button_Rmv_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.button_Edit_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.button_Add_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.radioButton_No_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.radioButton_Yes_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.textBox_Languages_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.textBox_Certificates_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.textBox_Address_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.textBox_BSN_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.textBox_Phone_ManageEmployees_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.textBox_LastName_ManageEmployee_Administartion);
            this.tabPage_ManageEmployees.Controls.Add(this.textBox_FirstName_ManageEmloyee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.label_Married_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.label_Languages_ManageEmployees_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.label_Certificates_ManagEepoyee_Administartion);
            this.tabPage_ManageEmployees.Controls.Add(this.label_Address_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.label_Role_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.label_StartDate_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.label_BSN_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.label_DateOfBirth_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.label_Phone_ManageEmloyee_Admnistartion);
            this.tabPage_ManageEmployees.Controls.Add(this.label_LastName_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.label_FirstName_ManageEmployee_Administration);
            this.tabPage_ManageEmployees.Controls.Add(this.label_ID_ManageEmployees_Administration);
            this.tabPage_ManageEmployees.Location = new System.Drawing.Point(4, 26);
            this.tabPage_ManageEmployees.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tabPage_ManageEmployees.Name = "tabPage_ManageEmployees";
            this.tabPage_ManageEmployees.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_ManageEmployees.Size = new System.Drawing.Size(1712, 812);
            this.tabPage_ManageEmployees.TabIndex = 0;
            this.tabPage_ManageEmployees.Text = "Manage Employees";
            this.tabPage_ManageEmployees.Click += new System.EventHandler(this.tabPage_ManageEmployees_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(157, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(300, 29);
            this.label6.TabIndex = 29;
            this.label6.Text = "Enter employee\'s details";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnPartTime);
            this.groupBox1.Controls.Add(this.rbtnFulltime);
            this.groupBox1.Location = new System.Drawing.Point(320, 538);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(195, 44);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contract";
            // 
            // rbtnPartTime
            // 
            this.rbtnPartTime.AutoSize = true;
            this.rbtnPartTime.Location = new System.Drawing.Point(96, 18);
            this.rbtnPartTime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnPartTime.Name = "rbtnPartTime";
            this.rbtnPartTime.Size = new System.Drawing.Size(85, 21);
            this.rbtnPartTime.TabIndex = 18;
            this.rbtnPartTime.TabStop = true;
            this.rbtnPartTime.Text = "Part time";
            this.rbtnPartTime.UseVisualStyleBackColor = true;
            // 
            // rbtnFulltime
            // 
            this.rbtnFulltime.AutoSize = true;
            this.rbtnFulltime.Location = new System.Drawing.Point(5, 18);
            this.rbtnFulltime.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnFulltime.Name = "rbtnFulltime";
            this.rbtnFulltime.Size = new System.Drawing.Size(81, 21);
            this.rbtnFulltime.TabIndex = 17;
            this.rbtnFulltime.TabStop = true;
            this.rbtnFulltime.Text = "Full time";
            this.rbtnFulltime.UseVisualStyleBackColor = true;
            // 
            // button_GenerateQR
            // 
            this.button_GenerateQR.Location = new System.Drawing.Point(247, 706);
            this.button_GenerateQR.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_GenerateQR.Name = "button_GenerateQR";
            this.button_GenerateQR.Size = new System.Drawing.Size(100, 28);
            this.button_GenerateQR.TabIndex = 27;
            this.button_GenerateQR.Text = "Show QR";
            this.button_GenerateQR.UseVisualStyleBackColor = true;
            this.button_GenerateQR.Click += new System.EventHandler(this.button_GenerateQR_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(1506, 187);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(194, 170);
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // textBox_ID_ManageEmployees_Administration
            // 
            this.textBox_ID_ManageEmployees_Administration.BackColor = System.Drawing.SystemColors.Window;
            this.textBox_ID_ManageEmployees_Administration.Location = new System.Drawing.Point(128, 219);
            this.textBox_ID_ManageEmployees_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ID_ManageEmployees_Administration.Name = "textBox_ID_ManageEmployees_Administration";
            this.textBox_ID_ManageEmployees_Administration.Size = new System.Drawing.Size(132, 23);
            this.textBox_ID_ManageEmployees_Administration.TabIndex = 1;
            // 
            // cmbDepartmentAdd
            // 
            this.cmbDepartmentAdd.FormattingEnabled = true;
            this.cmbDepartmentAdd.Location = new System.Drawing.Point(417, 491);
            this.cmbDepartmentAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbDepartmentAdd.Name = "cmbDepartmentAdd";
            this.cmbDepartmentAdd.Size = new System.Drawing.Size(132, 25);
            this.cmbDepartmentAdd.TabIndex = 27;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(316, 494);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Department";
            // 
            // tbSpouse
            // 
            this.tbSpouse.Location = new System.Drawing.Point(418, 356);
            this.tbSpouse.Name = "tbSpouse";
            this.tbSpouse.Size = new System.Drawing.Size(128, 23);
            this.tbSpouse.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(314, 356);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 24;
            this.label10.Text = "Spouse";
            // 
            // cmbRole
            // 
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Location = new System.Drawing.Point(130, 494);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(132, 25);
            this.cmbRole.TabIndex = 23;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbtnUnknown);
            this.groupBox3.Controls.Add(this.rbtnFemale);
            this.groupBox3.Controls.Add(this.rbtMale);
            this.groupBox3.Location = new System.Drawing.Point(28, 538);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(260, 44);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Gender";
            // 
            // rbtnUnknown
            // 
            this.rbtnUnknown.AutoSize = true;
            this.rbtnUnknown.Location = new System.Drawing.Point(166, 18);
            this.rbtnUnknown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnUnknown.Name = "rbtnUnknown";
            this.rbtnUnknown.Size = new System.Drawing.Size(87, 21);
            this.rbtnUnknown.TabIndex = 19;
            this.rbtnUnknown.TabStop = true;
            this.rbtnUnknown.Text = "Unknown";
            this.rbtnUnknown.UseVisualStyleBackColor = true;
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.AutoSize = true;
            this.rbtnFemale.Location = new System.Drawing.Point(82, 18);
            this.rbtnFemale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(75, 21);
            this.rbtnFemale.TabIndex = 18;
            this.rbtnFemale.TabStop = true;
            this.rbtnFemale.Text = "Female";
            this.rbtnFemale.UseVisualStyleBackColor = true;
            // 
            // rbtMale
            // 
            this.rbtMale.AutoSize = true;
            this.rbtMale.Location = new System.Drawing.Point(9, 18);
            this.rbtMale.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rbtMale.Name = "rbtMale";
            this.rbtMale.Size = new System.Drawing.Size(59, 21);
            this.rbtMale.TabIndex = 17;
            this.rbtMale.TabStop = true;
            this.rbtMale.Text = "Male";
            this.rbtMale.UseVisualStyleBackColor = true;
            // 
            // Salary
            // 
            this.Salary.AutoSize = true;
            this.Salary.Location = new System.Drawing.Point(313, 428);
            this.Salary.Name = "Salary";
            this.Salary.Size = new System.Drawing.Size(48, 17);
            this.Salary.TabIndex = 20;
            this.Salary.Text = "Salary";
            // 
            // tbSalary
            // 
            this.tbSalary.Location = new System.Drawing.Point(417, 423);
            this.tbSalary.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbSalary.Name = "tbSalary";
            this.tbSalary.Size = new System.Drawing.Size(132, 23);
            this.tbSalary.TabIndex = 16;
            // 
            // dtpStart
            // 
            this.dtpStart.Location = new System.Drawing.Point(418, 391);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(132, 23);
            this.dtpStart.TabIndex = 15;
            // 
            // dtpBirth
            // 
            this.dtpBirth.Location = new System.Drawing.Point(130, 396);
            this.dtpBirth.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtpBirth.Name = "dtpBirth";
            this.dtpBirth.Size = new System.Drawing.Size(130, 23);
            this.dtpBirth.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 460);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Functions";
            // 
            // tbFunctions
            // 
            this.tbFunctions.Location = new System.Drawing.Point(417, 460);
            this.tbFunctions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFunctions.Name = "tbFunctions";
            this.tbFunctions.Size = new System.Drawing.Size(132, 23);
            this.tbFunctions.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(316, 320);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Email:";
            // 
            // tb_Email
            // 
            this.tb_Email.Location = new System.Drawing.Point(418, 315);
            this.tb_Email.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tb_Email.Name = "tb_Email";
            this.tb_Email.Size = new System.Drawing.Size(132, 23);
            this.tb_Email.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 288);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Password";
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(128, 282);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.Size = new System.Drawing.Size(132, 23);
            this.tbPassword.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 255);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "UserName:";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(128, 249);
            this.tbUserName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(132, 23);
            this.tbUserName.TabIndex = 6;
            // 
            // panel_ManageEmployees_Administartion
            // 
            this.panel_ManageEmployees_Administartion.BackColor = System.Drawing.Color.Teal;
            this.panel_ManageEmployees_Administartion.Controls.Add(this.label_ManageEmployees_Administartion);
            this.panel_ManageEmployees_Administartion.Controls.Add(this.button_Logout_ManageEmployee_Administration);
            this.panel_ManageEmployees_Administartion.Location = new System.Drawing.Point(0, 0);
            this.panel_ManageEmployees_Administartion.Margin = new System.Windows.Forms.Padding(4);
            this.panel_ManageEmployees_Administartion.Name = "panel_ManageEmployees_Administartion";
            this.panel_ManageEmployees_Administartion.Size = new System.Drawing.Size(1716, 68);
            this.panel_ManageEmployees_Administartion.TabIndex = 5;
            // 
            // label_ManageEmployees_Administartion
            // 
            this.label_ManageEmployees_Administartion.AutoSize = true;
            this.label_ManageEmployees_Administartion.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ManageEmployees_Administartion.Location = new System.Drawing.Point(765, 11);
            this.label_ManageEmployees_Administartion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ManageEmployees_Administartion.Name = "label_ManageEmployees_Administartion";
            this.label_ManageEmployees_Administartion.Size = new System.Drawing.Size(204, 43);
            this.label_ManageEmployees_Administartion.TabIndex = 0;
            this.label_ManageEmployees_Administartion.Text = "Manage Emloyees";
            // 
            // button_Logout_ManageEmployee_Administration
            // 
            this.button_Logout_ManageEmployee_Administration.Location = new System.Drawing.Point(1580, 700);
            this.button_Logout_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.button_Logout_ManageEmployee_Administration.Name = "button_Logout_ManageEmployee_Administration";
            this.button_Logout_ManageEmployee_Administration.Size = new System.Drawing.Size(96, 34);
            this.button_Logout_ManageEmployee_Administration.TabIndex = 3;
            this.button_Logout_ManageEmployee_Administration.Text = "Logout";
            this.button_Logout_ManageEmployee_Administration.UseVisualStyleBackColor = true;
            this.button_Logout_ManageEmployee_Administration.Click += new System.EventHandler(this.button_Logout_ManageEmployee_Administration_Click);
            // 
            // dataGridView_ManageEmployees_Administration
            // 
            this.dataGridView_ManageEmployees_Administration.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_ManageEmployees_Administration.Location = new System.Drawing.Point(588, 135);
            this.dataGridView_ManageEmployees_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_ManageEmployees_Administration.Name = "dataGridView_ManageEmployees_Administration";
            this.dataGridView_ManageEmployees_Administration.RowHeadersWidth = 51;
            this.dataGridView_ManageEmployees_Administration.Size = new System.Drawing.Size(894, 640);
            this.dataGridView_ManageEmployees_Administration.TabIndex = 4;
            // 
            // button_Rmv_ManageEmployee_Administration
            // 
            this.button_Rmv_ManageEmployee_Administration.Location = new System.Drawing.Point(367, 650);
            this.button_Rmv_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.button_Rmv_ManageEmployee_Administration.Name = "button_Rmv_ManageEmployee_Administration";
            this.button_Rmv_ManageEmployee_Administration.Size = new System.Drawing.Size(99, 30);
            this.button_Rmv_ManageEmployee_Administration.TabIndex = 3;
            this.button_Rmv_ManageEmployee_Administration.Text = "Remove";
            this.button_Rmv_ManageEmployee_Administration.UseVisualStyleBackColor = true;
            this.button_Rmv_ManageEmployee_Administration.Click += new System.EventHandler(this.button_Rmv_ManageEmployee_Administration_Click);
            // 
            // button_Edit_ManageEmployee_Administration
            // 
            this.button_Edit_ManageEmployee_Administration.Location = new System.Drawing.Point(247, 653);
            this.button_Edit_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.button_Edit_ManageEmployee_Administration.Name = "button_Edit_ManageEmployee_Administration";
            this.button_Edit_ManageEmployee_Administration.Size = new System.Drawing.Size(99, 28);
            this.button_Edit_ManageEmployee_Administration.TabIndex = 3;
            this.button_Edit_ManageEmployee_Administration.Text = "Edit";
            this.button_Edit_ManageEmployee_Administration.UseVisualStyleBackColor = true;
            this.button_Edit_ManageEmployee_Administration.Click += new System.EventHandler(this.button_Edit_ManageEmployee_Administration_Click);
            // 
            // button_Add_ManageEmployee_Administration
            // 
            this.button_Add_ManageEmployee_Administration.Location = new System.Drawing.Point(131, 651);
            this.button_Add_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.button_Add_ManageEmployee_Administration.Name = "button_Add_ManageEmployee_Administration";
            this.button_Add_ManageEmployee_Administration.Size = new System.Drawing.Size(99, 30);
            this.button_Add_ManageEmployee_Administration.TabIndex = 3;
            this.button_Add_ManageEmployee_Administration.Text = "Add";
            this.button_Add_ManageEmployee_Administration.UseVisualStyleBackColor = true;
            this.button_Add_ManageEmployee_Administration.Click += new System.EventHandler(this.button_Add_ManageEmployee_Administration_Click);
            // 
            // radioButton_No_ManageEmployee_Administration
            // 
            this.radioButton_No_ManageEmployee_Administration.AutoSize = true;
            this.radioButton_No_ManageEmployee_Administration.Location = new System.Drawing.Point(194, 597);
            this.radioButton_No_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_No_ManageEmployee_Administration.Name = "radioButton_No_ManageEmployee_Administration";
            this.radioButton_No_ManageEmployee_Administration.Size = new System.Drawing.Size(47, 21);
            this.radioButton_No_ManageEmployee_Administration.TabIndex = 2;
            this.radioButton_No_ManageEmployee_Administration.TabStop = true;
            this.radioButton_No_ManageEmployee_Administration.Text = "No";
            this.radioButton_No_ManageEmployee_Administration.UseVisualStyleBackColor = true;
            // 
            // radioButton_Yes_ManageEmployee_Administration
            // 
            this.radioButton_Yes_ManageEmployee_Administration.AutoSize = true;
            this.radioButton_Yes_ManageEmployee_Administration.Location = new System.Drawing.Point(109, 597);
            this.radioButton_Yes_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_Yes_ManageEmployee_Administration.Name = "radioButton_Yes_ManageEmployee_Administration";
            this.radioButton_Yes_ManageEmployee_Administration.Size = new System.Drawing.Size(53, 21);
            this.radioButton_Yes_ManageEmployee_Administration.TabIndex = 2;
            this.radioButton_Yes_ManageEmployee_Administration.TabStop = true;
            this.radioButton_Yes_ManageEmployee_Administration.Text = "Yes";
            this.radioButton_Yes_ManageEmployee_Administration.UseVisualStyleBackColor = true;
            // 
            // textBox_Languages_ManageEmployee_Administration
            // 
            this.textBox_Languages_ManageEmployee_Administration.Location = new System.Drawing.Point(418, 282);
            this.textBox_Languages_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Languages_ManageEmployee_Administration.Name = "textBox_Languages_ManageEmployee_Administration";
            this.textBox_Languages_ManageEmployee_Administration.Size = new System.Drawing.Size(132, 23);
            this.textBox_Languages_ManageEmployee_Administration.TabIndex = 1;
            // 
            // textBox_Certificates_ManageEmployee_Administration
            // 
            this.textBox_Certificates_ManageEmployee_Administration.Location = new System.Drawing.Point(418, 249);
            this.textBox_Certificates_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Certificates_ManageEmployee_Administration.Name = "textBox_Certificates_ManageEmployee_Administration";
            this.textBox_Certificates_ManageEmployee_Administration.Size = new System.Drawing.Size(132, 23);
            this.textBox_Certificates_ManageEmployee_Administration.TabIndex = 1;
            // 
            // textBox_Address_ManageEmployee_Administration
            // 
            this.textBox_Address_ManageEmployee_Administration.Location = new System.Drawing.Point(418, 215);
            this.textBox_Address_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Address_ManageEmployee_Administration.Name = "textBox_Address_ManageEmployee_Administration";
            this.textBox_Address_ManageEmployee_Administration.Size = new System.Drawing.Size(132, 23);
            this.textBox_Address_ManageEmployee_Administration.TabIndex = 1;
            // 
            // textBox_BSN_ManageEmployee_Administration
            // 
            this.textBox_BSN_ManageEmployee_Administration.Location = new System.Drawing.Point(130, 460);
            this.textBox_BSN_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_BSN_ManageEmployee_Administration.Name = "textBox_BSN_ManageEmployee_Administration";
            this.textBox_BSN_ManageEmployee_Administration.Size = new System.Drawing.Size(132, 23);
            this.textBox_BSN_ManageEmployee_Administration.TabIndex = 1;
            // 
            // textBox_Phone_ManageEmployees_Administration
            // 
            this.textBox_Phone_ManageEmployees_Administration.Location = new System.Drawing.Point(128, 426);
            this.textBox_Phone_ManageEmployees_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Phone_ManageEmployees_Administration.Name = "textBox_Phone_ManageEmployees_Administration";
            this.textBox_Phone_ManageEmployees_Administration.Size = new System.Drawing.Size(132, 23);
            this.textBox_Phone_ManageEmployees_Administration.TabIndex = 1;
            // 
            // textBox_LastName_ManageEmployee_Administartion
            // 
            this.textBox_LastName_ManageEmployee_Administartion.Location = new System.Drawing.Point(128, 356);
            this.textBox_LastName_ManageEmployee_Administartion.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_LastName_ManageEmployee_Administartion.Name = "textBox_LastName_ManageEmployee_Administartion";
            this.textBox_LastName_ManageEmployee_Administartion.Size = new System.Drawing.Size(132, 23);
            this.textBox_LastName_ManageEmployee_Administartion.TabIndex = 1;
            // 
            // textBox_FirstName_ManageEmloyee_Administration
            // 
            this.textBox_FirstName_ManageEmloyee_Administration.Location = new System.Drawing.Point(128, 320);
            this.textBox_FirstName_ManageEmloyee_Administration.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_FirstName_ManageEmloyee_Administration.Name = "textBox_FirstName_ManageEmloyee_Administration";
            this.textBox_FirstName_ManageEmloyee_Administration.Size = new System.Drawing.Size(132, 23);
            this.textBox_FirstName_ManageEmloyee_Administration.TabIndex = 1;
            // 
            // label_Married_ManageEmployee_Administration
            // 
            this.label_Married_ManageEmployee_Administration.AutoSize = true;
            this.label_Married_ManageEmployee_Administration.Location = new System.Drawing.Point(29, 600);
            this.label_Married_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Married_ManageEmployee_Administration.Name = "label_Married_ManageEmployee_Administration";
            this.label_Married_ManageEmployee_Administration.Size = new System.Drawing.Size(56, 17);
            this.label_Married_ManageEmployee_Administration.TabIndex = 0;
            this.label_Married_ManageEmployee_Administration.Text = "Married";
            // 
            // label_Languages_ManageEmployees_Administration
            // 
            this.label_Languages_ManageEmployees_Administration.AutoSize = true;
            this.label_Languages_ManageEmployees_Administration.Location = new System.Drawing.Point(314, 286);
            this.label_Languages_ManageEmployees_Administration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Languages_ManageEmployees_Administration.Name = "label_Languages_ManageEmployees_Administration";
            this.label_Languages_ManageEmployees_Administration.Size = new System.Drawing.Size(79, 17);
            this.label_Languages_ManageEmployees_Administration.TabIndex = 0;
            this.label_Languages_ManageEmployees_Administration.Text = "Languages";
            // 
            // label_Certificates_ManagEepoyee_Administartion
            // 
            this.label_Certificates_ManagEepoyee_Administartion.AutoSize = true;
            this.label_Certificates_ManagEepoyee_Administartion.Location = new System.Drawing.Point(314, 252);
            this.label_Certificates_ManagEepoyee_Administartion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Certificates_ManagEepoyee_Administartion.Name = "label_Certificates_ManagEepoyee_Administartion";
            this.label_Certificates_ManagEepoyee_Administartion.Size = new System.Drawing.Size(78, 17);
            this.label_Certificates_ManagEepoyee_Administartion.TabIndex = 0;
            this.label_Certificates_ManagEepoyee_Administartion.Text = "Certificates";
            // 
            // label_Address_ManageEmployee_Administration
            // 
            this.label_Address_ManageEmployee_Administration.AutoSize = true;
            this.label_Address_ManageEmployee_Administration.Location = new System.Drawing.Point(314, 219);
            this.label_Address_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Address_ManageEmployee_Administration.Name = "label_Address_ManageEmployee_Administration";
            this.label_Address_ManageEmployee_Administration.Size = new System.Drawing.Size(60, 17);
            this.label_Address_ManageEmployee_Administration.TabIndex = 0;
            this.label_Address_ManageEmployee_Administration.Text = "Address";
            // 
            // label_Role_ManageEmployee_Administration
            // 
            this.label_Role_ManageEmployee_Administration.AutoSize = true;
            this.label_Role_ManageEmployee_Administration.Location = new System.Drawing.Point(29, 500);
            this.label_Role_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Role_ManageEmployee_Administration.Name = "label_Role_ManageEmployee_Administration";
            this.label_Role_ManageEmployee_Administration.Size = new System.Drawing.Size(37, 17);
            this.label_Role_ManageEmployee_Administration.TabIndex = 0;
            this.label_Role_ManageEmployee_Administration.Text = "Role";
            // 
            // label_StartDate_ManageEmployee_Administration
            // 
            this.label_StartDate_ManageEmployee_Administration.AutoSize = true;
            this.label_StartDate_ManageEmployee_Administration.Location = new System.Drawing.Point(315, 397);
            this.label_StartDate_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_StartDate_ManageEmployee_Administration.Name = "label_StartDate_ManageEmployee_Administration";
            this.label_StartDate_ManageEmployee_Administration.Size = new System.Drawing.Size(68, 17);
            this.label_StartDate_ManageEmployee_Administration.TabIndex = 0;
            this.label_StartDate_ManageEmployee_Administration.Text = "StartDate";
            // 
            // label_BSN_ManageEmployee_Administration
            // 
            this.label_BSN_ManageEmployee_Administration.AutoSize = true;
            this.label_BSN_ManageEmployee_Administration.Location = new System.Drawing.Point(28, 465);
            this.label_BSN_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_BSN_ManageEmployee_Administration.Name = "label_BSN_ManageEmployee_Administration";
            this.label_BSN_ManageEmployee_Administration.Size = new System.Drawing.Size(36, 17);
            this.label_BSN_ManageEmployee_Administration.TabIndex = 0;
            this.label_BSN_ManageEmployee_Administration.Text = "BSN";
            // 
            // label_DateOfBirth_ManageEmployee_Administration
            // 
            this.label_DateOfBirth_ManageEmployee_Administration.AutoSize = true;
            this.label_DateOfBirth_ManageEmployee_Administration.Location = new System.Drawing.Point(27, 396);
            this.label_DateOfBirth_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_DateOfBirth_ManageEmployee_Administration.Name = "label_DateOfBirth_ManageEmployee_Administration";
            this.label_DateOfBirth_ManageEmployee_Administration.Size = new System.Drawing.Size(82, 17);
            this.label_DateOfBirth_ManageEmployee_Administration.TabIndex = 0;
            this.label_DateOfBirth_ManageEmployee_Administration.Text = "DateOfBirth";
            // 
            // label_Phone_ManageEmloyee_Admnistartion
            // 
            this.label_Phone_ManageEmloyee_Admnistartion.AutoSize = true;
            this.label_Phone_ManageEmloyee_Admnistartion.Location = new System.Drawing.Point(27, 434);
            this.label_Phone_ManageEmloyee_Admnistartion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_Phone_ManageEmloyee_Admnistartion.Name = "label_Phone_ManageEmloyee_Admnistartion";
            this.label_Phone_ManageEmloyee_Admnistartion.Size = new System.Drawing.Size(49, 17);
            this.label_Phone_ManageEmloyee_Admnistartion.TabIndex = 0;
            this.label_Phone_ManageEmloyee_Admnistartion.Text = "Phone";
            // 
            // label_LastName_ManageEmployee_Administration
            // 
            this.label_LastName_ManageEmployee_Administration.AutoSize = true;
            this.label_LastName_ManageEmployee_Administration.Location = new System.Drawing.Point(27, 358);
            this.label_LastName_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_LastName_ManageEmployee_Administration.Name = "label_LastName_ManageEmployee_Administration";
            this.label_LastName_ManageEmployee_Administration.Size = new System.Drawing.Size(72, 17);
            this.label_LastName_ManageEmployee_Administration.TabIndex = 0;
            this.label_LastName_ManageEmployee_Administration.Text = "LastName";
            // 
            // label_FirstName_ManageEmployee_Administration
            // 
            this.label_FirstName_ManageEmployee_Administration.AutoSize = true;
            this.label_FirstName_ManageEmployee_Administration.Location = new System.Drawing.Point(27, 322);
            this.label_FirstName_ManageEmployee_Administration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_FirstName_ManageEmployee_Administration.Name = "label_FirstName_ManageEmployee_Administration";
            this.label_FirstName_ManageEmployee_Administration.Size = new System.Drawing.Size(72, 17);
            this.label_FirstName_ManageEmployee_Administration.TabIndex = 0;
            this.label_FirstName_ManageEmployee_Administration.Text = "FirstName";
            // 
            // label_ID_ManageEmployees_Administration
            // 
            this.label_ID_ManageEmployees_Administration.AutoSize = true;
            this.label_ID_ManageEmployees_Administration.Location = new System.Drawing.Point(27, 225);
            this.label_ID_ManageEmployees_Administration.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ID_ManageEmployees_Administration.Name = "label_ID_ManageEmployees_Administration";
            this.label_ID_ManageEmployees_Administration.Size = new System.Drawing.Size(21, 17);
            this.label_ID_ManageEmployees_Administration.TabIndex = 0;
            this.label_ID_ManageEmployees_Administration.Text = "ID";
            // 
            // tabPage_MangeShifts
            // 
            this.tabPage_MangeShifts.BackColor = System.Drawing.Color.LightCyan;
            this.tabPage_MangeShifts.Controls.Add(this.label26);
            this.tabPage_MangeShifts.Controls.Add(this.label25);
            this.tabPage_MangeShifts.Controls.Add(this.label24);
            this.tabPage_MangeShifts.Controls.Add(this.lbSundayEvening);
            this.tabPage_MangeShifts.Controls.Add(this.lbSundayAfternoon);
            this.tabPage_MangeShifts.Controls.Add(this.lbSundayMorning);
            this.tabPage_MangeShifts.Controls.Add(this.lbSaturdayEvening);
            this.tabPage_MangeShifts.Controls.Add(this.lbSaturdayAfternoon);
            this.tabPage_MangeShifts.Controls.Add(this.lbSaturdayMorning);
            this.tabPage_MangeShifts.Controls.Add(this.lbFridayEvening);
            this.tabPage_MangeShifts.Controls.Add(this.lbFridayAfternoon);
            this.tabPage_MangeShifts.Controls.Add(this.lbFridayMorning);
            this.tabPage_MangeShifts.Controls.Add(this.lbThursdayEvening);
            this.tabPage_MangeShifts.Controls.Add(this.lbThursdayAfternoon);
            this.tabPage_MangeShifts.Controls.Add(this.lbThursdayMorning);
            this.tabPage_MangeShifts.Controls.Add(this.lbWednesdayEvening);
            this.tabPage_MangeShifts.Controls.Add(this.lbWednesdayAfternoon);
            this.tabPage_MangeShifts.Controls.Add(this.lbWednesdayMorning);
            this.tabPage_MangeShifts.Controls.Add(this.lbTuesdayEvening);
            this.tabPage_MangeShifts.Controls.Add(this.lbTuesdayAfternoon);
            this.tabPage_MangeShifts.Controls.Add(this.lbTuesdayMorning);
            this.tabPage_MangeShifts.Controls.Add(this.lbMondayEvening);
            this.tabPage_MangeShifts.Controls.Add(this.lbMondayAfternoon);
            this.tabPage_MangeShifts.Controls.Add(this.label23);
            this.tabPage_MangeShifts.Controls.Add(this.label22);
            this.tabPage_MangeShifts.Controls.Add(this.label21);
            this.tabPage_MangeShifts.Controls.Add(this.label20);
            this.tabPage_MangeShifts.Controls.Add(this.label19);
            this.tabPage_MangeShifts.Controls.Add(this.label18);
            this.tabPage_MangeShifts.Controls.Add(this.label17);
            this.tabPage_MangeShifts.Controls.Add(this.lbMondayMorning);
            this.tabPage_MangeShifts.Controls.Add(this.label16);
            this.tabPage_MangeShifts.Controls.Add(this.label15);
            this.tabPage_MangeShifts.Controls.Add(this.lblStartDate);
            this.tabPage_MangeShifts.Controls.Add(this.lblEndDate);
            this.tabPage_MangeShifts.Controls.Add(this.label14);
            this.tabPage_MangeShifts.Controls.Add(this.cmbWeek);
            this.tabPage_MangeShifts.Controls.Add(this.btnAssignAutomaticShift);
            this.tabPage_MangeShifts.Controls.Add(this.cmbDepartments);
            this.tabPage_MangeShifts.Controls.Add(this.label12);
            this.tabPage_MangeShifts.Controls.Add(this.panel_ManageShifts_Administartion);
            this.tabPage_MangeShifts.Location = new System.Drawing.Point(4, 26);
            this.tabPage_MangeShifts.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage_MangeShifts.Name = "tabPage_MangeShifts";
            this.tabPage_MangeShifts.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage_MangeShifts.Size = new System.Drawing.Size(1712, 812);
            this.tabPage_MangeShifts.TabIndex = 1;
            this.tabPage_MangeShifts.Text = "ManageShifts";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(38, 542);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(186, 17);
            this.label26.TabIndex = 112;
            this.label26.Text = "Evening Shift(16:00 - 20:00)";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(38, 429);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(201, 17);
            this.label25.TabIndex = 111;
            this.label25.Text = "Afternoon Shift (12:00 - 16:00)";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(38, 299);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(182, 17);
            this.label24.TabIndex = 110;
            this.label24.Text = "Morning Shift (8:00 - 12:00)";
            // 
            // lbSundayEvening
            // 
            this.lbSundayEvening.FormattingEnabled = true;
            this.lbSundayEvening.ItemHeight = 17;
            this.lbSundayEvening.Location = new System.Drawing.Point(1379, 493);
            this.lbSundayEvening.Name = "lbSundayEvening";
            this.lbSundayEvening.Size = new System.Drawing.Size(193, 123);
            this.lbSundayEvening.TabIndex = 109;
            this.lbSundayEvening.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSundayEvening_MouseDoubleClick);
            // 
            // lbSundayAfternoon
            // 
            this.lbSundayAfternoon.FormattingEnabled = true;
            this.lbSundayAfternoon.ItemHeight = 17;
            this.lbSundayAfternoon.Location = new System.Drawing.Point(1379, 373);
            this.lbSundayAfternoon.Name = "lbSundayAfternoon";
            this.lbSundayAfternoon.Size = new System.Drawing.Size(193, 123);
            this.lbSundayAfternoon.TabIndex = 108;
            this.lbSundayAfternoon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSundayAfternoon_MouseDoubleClick);
            // 
            // lbSundayMorning
            // 
            this.lbSundayMorning.FormattingEnabled = true;
            this.lbSundayMorning.ItemHeight = 17;
            this.lbSundayMorning.Location = new System.Drawing.Point(1379, 254);
            this.lbSundayMorning.Name = "lbSundayMorning";
            this.lbSundayMorning.Size = new System.Drawing.Size(193, 123);
            this.lbSundayMorning.TabIndex = 107;
            this.lbSundayMorning.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSundayMorning_MouseDoubleClick);
            // 
            // lbSaturdayEvening
            // 
            this.lbSaturdayEvening.FormattingEnabled = true;
            this.lbSaturdayEvening.ItemHeight = 17;
            this.lbSaturdayEvening.Location = new System.Drawing.Point(1189, 493);
            this.lbSaturdayEvening.Name = "lbSaturdayEvening";
            this.lbSaturdayEvening.Size = new System.Drawing.Size(193, 123);
            this.lbSaturdayEvening.TabIndex = 106;
            this.lbSaturdayEvening.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSaturdayEvening_MouseDoubleClick);
            // 
            // lbSaturdayAfternoon
            // 
            this.lbSaturdayAfternoon.FormattingEnabled = true;
            this.lbSaturdayAfternoon.ItemHeight = 17;
            this.lbSaturdayAfternoon.Location = new System.Drawing.Point(1189, 373);
            this.lbSaturdayAfternoon.Name = "lbSaturdayAfternoon";
            this.lbSaturdayAfternoon.Size = new System.Drawing.Size(193, 123);
            this.lbSaturdayAfternoon.TabIndex = 105;
            this.lbSaturdayAfternoon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSaturdayAfternoon_MouseDoubleClick);
            // 
            // lbSaturdayMorning
            // 
            this.lbSaturdayMorning.FormattingEnabled = true;
            this.lbSaturdayMorning.ItemHeight = 17;
            this.lbSaturdayMorning.Location = new System.Drawing.Point(1189, 254);
            this.lbSaturdayMorning.Name = "lbSaturdayMorning";
            this.lbSaturdayMorning.Size = new System.Drawing.Size(193, 123);
            this.lbSaturdayMorning.TabIndex = 104;
            this.lbSaturdayMorning.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbSaturdayMorning_MouseDoubleClick);
            // 
            // lbFridayEvening
            // 
            this.lbFridayEvening.FormattingEnabled = true;
            this.lbFridayEvening.ItemHeight = 17;
            this.lbFridayEvening.Location = new System.Drawing.Point(1000, 493);
            this.lbFridayEvening.Name = "lbFridayEvening";
            this.lbFridayEvening.Size = new System.Drawing.Size(193, 123);
            this.lbFridayEvening.TabIndex = 103;
            this.lbFridayEvening.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbFridayEvening_MouseDoubleClick);
            // 
            // lbFridayAfternoon
            // 
            this.lbFridayAfternoon.FormattingEnabled = true;
            this.lbFridayAfternoon.ItemHeight = 17;
            this.lbFridayAfternoon.Location = new System.Drawing.Point(1000, 373);
            this.lbFridayAfternoon.Name = "lbFridayAfternoon";
            this.lbFridayAfternoon.Size = new System.Drawing.Size(193, 123);
            this.lbFridayAfternoon.TabIndex = 102;
            this.lbFridayAfternoon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbFridayAfternoon_MouseDoubleClick);
            // 
            // lbFridayMorning
            // 
            this.lbFridayMorning.FormattingEnabled = true;
            this.lbFridayMorning.ItemHeight = 17;
            this.lbFridayMorning.Location = new System.Drawing.Point(1000, 254);
            this.lbFridayMorning.Name = "lbFridayMorning";
            this.lbFridayMorning.Size = new System.Drawing.Size(193, 123);
            this.lbFridayMorning.TabIndex = 101;
            this.lbFridayMorning.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbFridayMorning_MouseDoubleClick);
            // 
            // lbThursdayEvening
            // 
            this.lbThursdayEvening.FormattingEnabled = true;
            this.lbThursdayEvening.ItemHeight = 17;
            this.lbThursdayEvening.Location = new System.Drawing.Point(812, 493);
            this.lbThursdayEvening.Name = "lbThursdayEvening";
            this.lbThursdayEvening.Size = new System.Drawing.Size(193, 123);
            this.lbThursdayEvening.TabIndex = 100;
            this.lbThursdayEvening.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbThursdayEvening_MouseDoubleClick);
            // 
            // lbThursdayAfternoon
            // 
            this.lbThursdayAfternoon.FormattingEnabled = true;
            this.lbThursdayAfternoon.ItemHeight = 17;
            this.lbThursdayAfternoon.Location = new System.Drawing.Point(812, 373);
            this.lbThursdayAfternoon.Name = "lbThursdayAfternoon";
            this.lbThursdayAfternoon.Size = new System.Drawing.Size(193, 123);
            this.lbThursdayAfternoon.TabIndex = 99;
            this.lbThursdayAfternoon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbThursdayAfternoon_MouseDoubleClick);
            // 
            // lbThursdayMorning
            // 
            this.lbThursdayMorning.FormattingEnabled = true;
            this.lbThursdayMorning.ItemHeight = 17;
            this.lbThursdayMorning.Location = new System.Drawing.Point(812, 254);
            this.lbThursdayMorning.Name = "lbThursdayMorning";
            this.lbThursdayMorning.Size = new System.Drawing.Size(193, 123);
            this.lbThursdayMorning.TabIndex = 98;
            this.lbThursdayMorning.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbThursdayMorning_MouseDoubleClick);
            // 
            // lbWednesdayEvening
            // 
            this.lbWednesdayEvening.FormattingEnabled = true;
            this.lbWednesdayEvening.ItemHeight = 17;
            this.lbWednesdayEvening.Location = new System.Drawing.Point(620, 493);
            this.lbWednesdayEvening.Name = "lbWednesdayEvening";
            this.lbWednesdayEvening.Size = new System.Drawing.Size(193, 123);
            this.lbWednesdayEvening.TabIndex = 97;
            this.lbWednesdayEvening.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbWednesdayEvening_MouseDoubleClick);
            // 
            // lbWednesdayAfternoon
            // 
            this.lbWednesdayAfternoon.FormattingEnabled = true;
            this.lbWednesdayAfternoon.ItemHeight = 17;
            this.lbWednesdayAfternoon.Location = new System.Drawing.Point(620, 373);
            this.lbWednesdayAfternoon.Name = "lbWednesdayAfternoon";
            this.lbWednesdayAfternoon.Size = new System.Drawing.Size(193, 123);
            this.lbWednesdayAfternoon.TabIndex = 96;
            this.lbWednesdayAfternoon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbWednesdayAfternoon_MouseDoubleClick);
            // 
            // lbWednesdayMorning
            // 
            this.lbWednesdayMorning.FormattingEnabled = true;
            this.lbWednesdayMorning.ItemHeight = 17;
            this.lbWednesdayMorning.Location = new System.Drawing.Point(620, 254);
            this.lbWednesdayMorning.Name = "lbWednesdayMorning";
            this.lbWednesdayMorning.Size = new System.Drawing.Size(193, 123);
            this.lbWednesdayMorning.TabIndex = 95;
            this.lbWednesdayMorning.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbWednesdayMorning_MouseDoubleClick);
            // 
            // lbTuesdayEvening
            // 
            this.lbTuesdayEvening.FormattingEnabled = true;
            this.lbTuesdayEvening.ItemHeight = 17;
            this.lbTuesdayEvening.Location = new System.Drawing.Point(438, 493);
            this.lbTuesdayEvening.Name = "lbTuesdayEvening";
            this.lbTuesdayEvening.Size = new System.Drawing.Size(193, 123);
            this.lbTuesdayEvening.TabIndex = 94;
            this.lbTuesdayEvening.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbTuesdayEvening_MouseDoubleClick);
            // 
            // lbTuesdayAfternoon
            // 
            this.lbTuesdayAfternoon.FormattingEnabled = true;
            this.lbTuesdayAfternoon.ItemHeight = 17;
            this.lbTuesdayAfternoon.Location = new System.Drawing.Point(438, 373);
            this.lbTuesdayAfternoon.Name = "lbTuesdayAfternoon";
            this.lbTuesdayAfternoon.Size = new System.Drawing.Size(193, 123);
            this.lbTuesdayAfternoon.TabIndex = 93;
            this.lbTuesdayAfternoon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbTuesdayAfternoon_MouseDoubleClick);
            // 
            // lbTuesdayMorning
            // 
            this.lbTuesdayMorning.FormattingEnabled = true;
            this.lbTuesdayMorning.ItemHeight = 17;
            this.lbTuesdayMorning.Location = new System.Drawing.Point(438, 254);
            this.lbTuesdayMorning.Name = "lbTuesdayMorning";
            this.lbTuesdayMorning.Size = new System.Drawing.Size(193, 123);
            this.lbTuesdayMorning.TabIndex = 92;
            this.lbTuesdayMorning.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbTuesdayMorning_MouseDoubleClick);
            // 
            // lbMondayEvening
            // 
            this.lbMondayEvening.FormattingEnabled = true;
            this.lbMondayEvening.ItemHeight = 17;
            this.lbMondayEvening.Location = new System.Drawing.Point(248, 493);
            this.lbMondayEvening.Name = "lbMondayEvening";
            this.lbMondayEvening.Size = new System.Drawing.Size(193, 123);
            this.lbMondayEvening.TabIndex = 91;
            this.lbMondayEvening.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbMondayEvening_MouseDoubleClick);
            // 
            // lbMondayAfternoon
            // 
            this.lbMondayAfternoon.FormattingEnabled = true;
            this.lbMondayAfternoon.ItemHeight = 17;
            this.lbMondayAfternoon.Location = new System.Drawing.Point(248, 373);
            this.lbMondayAfternoon.Name = "lbMondayAfternoon";
            this.lbMondayAfternoon.Size = new System.Drawing.Size(193, 123);
            this.lbMondayAfternoon.TabIndex = 90;
            this.lbMondayAfternoon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbMondayAfternoon_MouseDoubleClick);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(1441, 186);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 20);
            this.label23.TabIndex = 89;
            this.label23.Text = "Sunday";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(1262, 186);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(75, 20);
            this.label22.TabIndex = 88;
            this.label22.Text = "Saturday";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(1072, 186);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(55, 20);
            this.label21.TabIndex = 87;
            this.label21.Text = "Friday";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(874, 186);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 20);
            this.label20.TabIndex = 86;
            this.label20.Text = "Thursday";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(678, 186);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 20);
            this.label19.TabIndex = 85;
            this.label19.Text = "Wednesday";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(499, 186);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 20);
            this.label18.TabIndex = 84;
            this.label18.Text = "Tuesday";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(315, 186);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 20);
            this.label17.TabIndex = 83;
            this.label17.Text = "Monday";
            // 
            // lbMondayMorning
            // 
            this.lbMondayMorning.FormattingEnabled = true;
            this.lbMondayMorning.ItemHeight = 17;
            this.lbMondayMorning.Location = new System.Drawing.Point(248, 254);
            this.lbMondayMorning.Name = "lbMondayMorning";
            this.lbMondayMorning.Size = new System.Drawing.Size(193, 123);
            this.lbMondayMorning.TabIndex = 82;
            this.lbMondayMorning.SelectedIndexChanged += new System.EventHandler(this.lbMondayMorning_SelectedIndexChanged);
            this.lbMondayMorning.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbMondayMorning_MouseDoubleClick);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(898, 96);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(44, 17);
            this.label16.TabIndex = 81;
            this.label16.Text = "From:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1072, 96);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(29, 17);
            this.label15.TabIndex = 80;
            this.label15.Text = "To:";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(971, 96);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(12, 17);
            this.lblStartDate.TabIndex = 79;
            this.lblStartDate.Text = ".";
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(1196, 96);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(12, 17);
            this.lblEndDate.TabIndex = 78;
            this.lblEndDate.Text = ".";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(579, 96);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 17);
            this.label14.TabIndex = 77;
            this.label14.Text = "Select week:";
            // 
            // cmbWeek
            // 
            this.cmbWeek.FormattingEnabled = true;
            this.cmbWeek.Location = new System.Drawing.Point(694, 93);
            this.cmbWeek.Name = "cmbWeek";
            this.cmbWeek.Size = new System.Drawing.Size(172, 25);
            this.cmbWeek.TabIndex = 76;
            this.cmbWeek.SelectedIndexChanged += new System.EventHandler(this.cmbWeek_SelectedIndexChanged);
            this.cmbWeek.SelectedValueChanged += new System.EventHandler(this.cmbWeek_SelectedValueChanged);
            // 
            // btnAssignAutomaticShift
            // 
            this.btnAssignAutomaticShift.Location = new System.Drawing.Point(1302, 86);
            this.btnAssignAutomaticShift.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAssignAutomaticShift.Name = "btnAssignAutomaticShift";
            this.btnAssignAutomaticShift.Size = new System.Drawing.Size(195, 46);
            this.btnAssignAutomaticShift.TabIndex = 11;
            this.btnAssignAutomaticShift.Text = "Automatically assign employees per department\r\n";
            this.btnAssignAutomaticShift.UseVisualStyleBackColor = true;
            this.btnAssignAutomaticShift.Click += new System.EventHandler(this.btnAssignAutomaticShift_Click);
            // 
            // cmbDepartments
            // 
            this.cmbDepartments.FormattingEnabled = true;
            this.cmbDepartments.Location = new System.Drawing.Point(392, 94);
            this.cmbDepartments.Name = "cmbDepartments";
            this.cmbDepartments.Size = new System.Drawing.Size(121, 25);
            this.cmbDepartments.TabIndex = 18;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(245, 101);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 17);
            this.label12.TabIndex = 17;
            this.label12.Text = "Department:";
            // 
            // panel_ManageShifts_Administartion
            // 
            this.panel_ManageShifts_Administartion.BackColor = System.Drawing.Color.Teal;
            this.panel_ManageShifts_Administartion.Controls.Add(this.label_ManageShifts_Administartion);
            this.panel_ManageShifts_Administartion.Controls.Add(this.label9);
            this.panel_ManageShifts_Administartion.Controls.Add(this.button_Logout_ManageShifts_Adminisration);
            this.panel_ManageShifts_Administartion.Location = new System.Drawing.Point(0, 0);
            this.panel_ManageShifts_Administartion.Margin = new System.Windows.Forms.Padding(4);
            this.panel_ManageShifts_Administartion.Name = "panel_ManageShifts_Administartion";
            this.panel_ManageShifts_Administartion.Size = new System.Drawing.Size(1716, 68);
            this.panel_ManageShifts_Administartion.TabIndex = 9;
            // 
            // label_ManageShifts_Administartion
            // 
            this.label_ManageShifts_Administartion.AutoSize = true;
            this.label_ManageShifts_Administartion.Font = new System.Drawing.Font("Gloucester MT Extra Condensed", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_ManageShifts_Administartion.Location = new System.Drawing.Point(722, 14);
            this.label_ManageShifts_Administartion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label_ManageShifts_Administartion.Name = "label_ManageShifts_Administartion";
            this.label_ManageShifts_Administartion.Size = new System.Drawing.Size(163, 43);
            this.label_ManageShifts_Administartion.TabIndex = 0;
            this.label_ManageShifts_Administartion.Text = "Manage Shifts";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(915, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(99, 24);
            this.label9.TabIndex = 14;
            this.label9.Text = "Schedule";
            // 
            // button_Logout_ManageShifts_Adminisration
            // 
            this.button_Logout_ManageShifts_Adminisration.Location = new System.Drawing.Point(1103, 14);
            this.button_Logout_ManageShifts_Adminisration.Margin = new System.Windows.Forms.Padding(4);
            this.button_Logout_ManageShifts_Adminisration.Name = "button_Logout_ManageShifts_Adminisration";
            this.button_Logout_ManageShifts_Adminisration.Size = new System.Drawing.Size(121, 40);
            this.button_Logout_ManageShifts_Adminisration.TabIndex = 5;
            this.button_Logout_ManageShifts_Adminisration.Text = "Logout";
            this.button_Logout_ManageShifts_Adminisration.UseVisualStyleBackColor = true;
            this.button_Logout_ManageShifts_Adminisration.Click += new System.EventHandler(this.button_Logout_ManageShifts_Adminisration_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1285, 99);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = "People per shift";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(876, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 20);
            this.label13.TabIndex = 20;
            this.label13.Text = "Shift Type:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1099, 99);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Position:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(87, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(124, 20);
            this.label11.TabIndex = 16;
            this.label11.Text = "Pick work week";
            // 
            // tbNumberPerShift
            // 
            this.tbNumberPerShift.Location = new System.Drawing.Point(1288, 135);
            this.tbNumberPerShift.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbNumberPerShift.Name = "tbNumberPerShift";
            this.tbNumberPerShift.Size = new System.Drawing.Size(116, 22);
            this.tbNumberPerShift.TabIndex = 13;
            // 
            // btnCreateSchedule
            // 
            this.btnCreateSchedule.Location = new System.Drawing.Point(1429, 99);
            this.btnCreateSchedule.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCreateSchedule.Name = "btnCreateSchedule";
            this.btnCreateSchedule.Size = new System.Drawing.Size(156, 56);
            this.btnCreateSchedule.TabIndex = 11;
            this.btnCreateSchedule.Text = "Create schedule";
            this.btnCreateSchedule.UseVisualStyleBackColor = true;
            // 
            // cmbShiftType
            // 
            this.cmbShiftType.FormattingEnabled = true;
            this.cmbShiftType.Location = new System.Drawing.Point(880, 135);
            this.cmbShiftType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbShiftType.Name = "cmbShiftType";
            this.cmbShiftType.Size = new System.Drawing.Size(174, 25);
            this.cmbShiftType.TabIndex = 19;
            // 
            // cmbPosition
            // 
            this.cmbPosition.FormattingEnabled = true;
            this.cmbPosition.Location = new System.Drawing.Point(1102, 135);
            this.cmbPosition.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbPosition.Name = "cmbPosition";
            this.cmbPosition.Size = new System.Drawing.Size(136, 25);
            this.cmbPosition.TabIndex = 0;
            // 
            // cmbWeekOfYear
            // 
            this.cmbWeekOfYear.FormattingEnabled = true;
            this.cmbWeekOfYear.Location = new System.Drawing.Point(240, 106);
            this.cmbWeekOfYear.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbWeekOfYear.Name = "cmbWeekOfYear";
            this.cmbWeekOfYear.Size = new System.Drawing.Size(174, 25);
            this.cmbWeekOfYear.TabIndex = 15;
            // 
            // dataGridViewWeeks
            // 
            this.dataGridViewWeeks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWeeks.Location = new System.Drawing.Point(51, 155);
            this.dataGridViewWeeks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewWeeks.Name = "dataGridViewWeeks";
            this.dataGridViewWeeks.RowHeadersWidth = 51;
            this.dataGridViewWeeks.RowTemplate.Height = 24;
            this.dataGridViewWeeks.Size = new System.Drawing.Size(552, 399);
            this.dataGridViewWeeks.TabIndex = 21;
            // 
            // mySqlCommand1
            // 
            this.mySqlCommand1.CacheAge = 0;
            this.mySqlCommand1.Connection = null;
            this.mySqlCommand1.EnableCaching = false;
            this.mySqlCommand1.Transaction = null;
            // 
            // Administration_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1710, 840);
            this.Controls.Add(this.tabControl_Administration);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Administration_Form";
            this.Text = "Administraton Form";
            this.tabControl_Administration.ResumeLayout(false);
            this.tabPage_ManageEmployees.ResumeLayout(false);
            this.tabPage_ManageEmployees.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel_ManageEmployees_Administartion.ResumeLayout(false);
            this.panel_ManageEmployees_Administartion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_ManageEmployees_Administration)).EndInit();
            this.tabPage_MangeShifts.ResumeLayout(false);
            this.tabPage_MangeShifts.PerformLayout();
            this.panel_ManageShifts_Administartion.ResumeLayout(false);
            this.panel_ManageShifts_Administartion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWeeks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_Administration;
        private System.Windows.Forms.TabPage tabPage_ManageEmployees;
        private System.Windows.Forms.TextBox textBox_Certificates_ManageEmployee_Administration;
        private System.Windows.Forms.TextBox textBox_Address_ManageEmployee_Administration;
        private System.Windows.Forms.TextBox textBox_BSN_ManageEmployee_Administration;
        private System.Windows.Forms.TextBox textBox_Phone_ManageEmployees_Administration;
        private System.Windows.Forms.TextBox textBox_LastName_ManageEmployee_Administartion;
        private System.Windows.Forms.TextBox textBox_FirstName_ManageEmloyee_Administration;
        private System.Windows.Forms.Label label_Married_ManageEmployee_Administration;
        private System.Windows.Forms.Label label_Languages_ManageEmployees_Administration;
        private System.Windows.Forms.Label label_Certificates_ManagEepoyee_Administartion;
        private System.Windows.Forms.Label label_Address_ManageEmployee_Administration;
        private System.Windows.Forms.Label label_Role_ManageEmployee_Administration;
        private System.Windows.Forms.Label label_StartDate_ManageEmployee_Administration;
        private System.Windows.Forms.Label label_BSN_ManageEmployee_Administration;
        private System.Windows.Forms.Label label_DateOfBirth_ManageEmployee_Administration;
        private System.Windows.Forms.Label label_Phone_ManageEmloyee_Admnistartion;
        private System.Windows.Forms.Label label_LastName_ManageEmployee_Administration;
        private System.Windows.Forms.Label label_FirstName_ManageEmployee_Administration;
        private System.Windows.Forms.TabPage tabPage_MangeShifts;
        private System.Windows.Forms.TextBox tbNumberPerShift;
        private System.Windows.Forms.TextBox textBox_Languages_ManageEmployee_Administration;
        private System.Windows.Forms.Button button_Rmv_ManageEmployee_Administration;
        private System.Windows.Forms.Button button_Edit_ManageEmployee_Administration;
        private System.Windows.Forms.Button button_Logout_ManageEmployee_Administration;
        private System.Windows.Forms.Button btnCreateSchedule;    
        private System.Windows.Forms.Button button_Add_ManageEmployee_Administration;
        private System.Windows.Forms.RadioButton radioButton_No_ManageEmployee_Administration;
        private System.Windows.Forms.RadioButton radioButton_Yes_ManageEmployee_Administration;
        private System.Windows.Forms.DataGridView dataGridView_ManageEmployees_Administration;
        private System.Windows.Forms.DataGridView dataGridViewWeeks;
        private System.Windows.Forms.Panel panel_ManageEmployees_Administartion;
        private System.Windows.Forms.Label label_ManageEmployees_Administartion;
        private System.Windows.Forms.Panel panel_ManageShifts_Administartion;
        private System.Windows.Forms.Label label_ManageShifts_Administartion;
        private System.Windows.Forms.Button button_Logout_ManageShifts_Adminisration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_Email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbFunctions;
        private System.Windows.Forms.DateTimePicker dtpBirth;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.Button btnAssignAutomaticShift;
        private MySql.Data.MySqlClient.MySqlCommand mySqlCommand1;
        private System.Windows.Forms.ComboBox cmbPosition;
        private System.Windows.Forms.ComboBox cmbShiftType;
        private System.Windows.Forms.Label Salary;
        private System.Windows.Forms.RadioButton rbtnUnknown;
        private System.Windows.Forms.RadioButton rbtnFemale;
        private System.Windows.Forms.RadioButton rbtMale;
        private System.Windows.Forms.TextBox tbSalary;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbSpouse;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbDepartments;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbWeekOfYear;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_GenerateQR;
        private System.Windows.Forms.ComboBox cmbDepartmentAdd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_ID_ManageEmployees_Administration;
        private System.Windows.Forms.Label label_ID_ManageEmployees_Administration;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private Label label14;
        private ComboBox cmbWeek;
        private Label lblStartDate;
        private Label lblEndDate;
        private Label label16;
        private Label label15;
        private Label label26;
        private Label label25;
        private Label label24;
        private ListBox lbSundayEvening;
        private ListBox lbSundayAfternoon;
        private ListBox lbSundayMorning;
        private ListBox lbSaturdayEvening;
        private ListBox lbSaturdayAfternoon;
        private ListBox lbSaturdayMorning;
        private ListBox lbFridayEvening;
        private ListBox lbFridayAfternoon;
        private ListBox lbFridayMorning;
        private ListBox lbThursdayEvening;
        private ListBox lbThursdayAfternoon;
        private ListBox lbThursdayMorning;
        private ListBox lbWednesdayEvening;
        private ListBox lbWednesdayAfternoon;
        private ListBox lbWednesdayMorning;
        private ListBox lbTuesdayEvening;
        private ListBox lbTuesdayAfternoon;
        private ListBox lbTuesdayMorning;
        private ListBox lbMondayEvening;
        private ListBox lbMondayAfternoon;
        private Label label23;
        private Label label22;
        private Label label21;
        private Label label20;
        private Label label19;
        private Label label18;
        private Label label17;
        private ListBox lbMondayMorning;
        private GroupBox groupBox1;
        private RadioButton rbtnPartTime;
        private RadioButton rbtnFulltime;
        private Label label6;
    }
}

