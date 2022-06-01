using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI.Relational;
using MySql.Data.MySqlClient;

namespace Media_Bazaar
{
    public partial class Administration_Form : Form
    {
        AdministrationManagement administrationManagement;
        ScheduleManagement scheduleManagement;
        
        int selectedWorkWeek = -1;
        LoginDataObject loginData;
        public Administration_Form(LoginDataObject loginData)
        {
            InitializeComponent();
            this.loginData = loginData;
            administrationManagement = new AdministrationManagement();
            scheduleManagement = new ScheduleManagement();
            ShowEmployeesIndataGrid();
            PopulateComboboxRole();
            PopulateComboboxDepartments();
            PopulateComboboxWorkWeek();
            PopulateComboboxDepartmentsEmployees();
        }

        public void PopulateComboboxRole()
        {
            var positions = scheduleManagement.PopulateComboboxRole();

            cmbRole.DisplayMember = "name";
            cmbRole.ValueMember = "id";
            cmbRole.DataSource = positions;


        }

       

        public void PopulateComboboxDepartments()
        {
            var departments = scheduleManagement.PopulateComboboxDepartment();

            cmbDepartments.DisplayMember = "name";
            cmbDepartments.ValueMember = "id";
            cmbDepartments.DataSource = departments;


        }
        public void PopulateComboboxDepartmentsEmployees()
        {
            var departments = scheduleManagement.PopulateComboboxDepartment();

            cmbDepartmentAdd.DisplayMember = "name";
            cmbDepartmentAdd.ValueMember = "id";
            cmbDepartmentAdd.DataSource = departments;


        }


        private void button_Add_ManageEmployee_Administration_Click(object sender, EventArgs e)
        {
            try
            {
                string username = tbUserName.Text;
                string password = tbPassword.Text;
                int id = Convert.ToInt32(textBox_ID_ManageEmployees_Administration.Text);
                string fName = textBox_FirstName_ManageEmloyee_Administration.Text;
                string surname = textBox_LastName_ManageEmployee_Administartion.Text;
                int phoneNumber = Convert.ToInt32(textBox_Phone_ManageEmployees_Administration.Text);
                DateTime birth = dtpBirth.Value;
                int bsn = Convert.ToInt32(textBox_BSN_ManageEmployee_Administration.Text);
                DateTime startDate = dtpStart.Value;
                Position position = (Position)cmbRole.SelectedItem;
                int positionId = position.id;
                string address = textBox_Address_ManageEmployee_Administration.Text;
                string certificates = textBox_Certificates_ManageEmployee_Administration.Text;
                string languages = textBox_Languages_ManageEmployee_Administration.Text;
                int isMarried = -1;
                if (radioButton_No_ManageEmployee_Administration.Checked)
                {
                    isMarried = 0;
                }
                if (radioButton_Yes_ManageEmployee_Administration.Checked)
                {
                    isMarried = 1;
                }

                string email = tb_Email.Text;
                string functions = tbFunctions.Text;
                decimal salary = Convert.ToDecimal(tbSalary.Text);
                int gender = -1;
                string spouse = tbSpouse.Text;
                if (rbtMale.Checked)
                {
                    gender = 1;
                }
                if (rbtnFemale.Checked)
                {
                    gender = 0;
                }
                if (rbtnUnknown.Checked)
                {
                    gender = 2;
                }
                int contract = -1;
                if (rbtnFulltime.Checked)
                {
                    contract = 1;
                }
                if (rbtnPartTime.Checked)
                {
                    contract = 0;
                }

                Department department = (Department)cmbDepartmentAdd.SelectedItem;
                int departmentId = department.id;
                administrationManagement.AddEmployee(username, password, fName, surname, phoneNumber, address, birth.ToString("yyyy-MM-dd HH:mm:ss"), email, isMarried, bsn, functions, id, startDate.ToString("yyyy-MM-dd HH:mm:ss"), languages, certificates, positionId, salary, gender, spouse, departmentId,contract);
                ShowEmployeesIndataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Edit_ManageEmployee_Administration_Click(object sender, EventArgs e)
        {
            try
            {
                string username = tbUserName.Text;
                string password = tbPassword.Text;
                int id = Convert.ToInt32(textBox_ID_ManageEmployees_Administration.Text);
                string fName = textBox_FirstName_ManageEmloyee_Administration.Text;
                string surname = textBox_LastName_ManageEmployee_Administartion.Text;
                int phoneNumber = Convert.ToInt32(textBox_Phone_ManageEmployees_Administration.Text);
                DateTime birth = dtpBirth.Value;
                int bsn = Convert.ToInt32(textBox_BSN_ManageEmployee_Administration.Text);
                DateTime startDate = dtpStart.Value;
                Position position = (Position)cmbRole.SelectedItem;
                int positionId = position.id;
                string address = textBox_Address_ManageEmployee_Administration.Text;
                string certificates = textBox_Certificates_ManageEmployee_Administration.Text;
                string languages = textBox_Languages_ManageEmployee_Administration.Text;
                int isMarried = -1;
                if (radioButton_No_ManageEmployee_Administration.Checked)
                {
                    isMarried = 0;
                }
                if (radioButton_Yes_ManageEmployee_Administration.Checked)
                {
                    isMarried = 1;
                }
                decimal salary = Convert.ToDecimal(tbSalary.Text);
                int gender = -1;
                if (rbtMale.Checked)
                {
                    gender = 1;
                }
                if (rbtnFemale.Checked)
                {
                    gender = 0;
                }
                if (rbtnUnknown.Checked)
                {
                    gender = 2;
                }
                int contract = -1;
                if (rbtnFulltime.Checked)
                {
                    contract = 1;
                }
                if (rbtnPartTime.Checked)
                {
                    contract = 0;
                }

                string email = tb_Email.Text;
                string functions = tbFunctions.Text;
                string spouse = tbSpouse.Text;
                Department dp = (Department)cmbDepartmentAdd.SelectedItem;
                int dpId = dp.id;

                administrationManagement.EditEmployee(username, password, fName, surname, phoneNumber, address, birth.ToString("yyyy-MM-dd HH:mm:ss"), email, isMarried, bsn, functions, id, startDate.ToString("yyyy-MM-dd HH:mm:ss"), languages, certificates, positionId, salary, gender, spouse, dpId,contract);
                ShowEmployeesIndataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Rmv_ManageEmployee_Administration_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox_ID_ManageEmployees_Administration.Text);
                administrationManagement.FireEmployee(id);
                ShowEmployeesIndataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void ShowEmployeesIndataGrid()
        {
            dataGridView_ManageEmployees_Administration.DataSource = administrationManagement.ShowEmployees();
        }
      
      
       

      

        private void button_Logout_ManageEmployee_Administration_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form fm = new Login_Form();
            fm.ShowDialog();
            this.Close();
        }

        private void button_Logout_ManageShifts_Adminisration_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form fm = new Login_Form();
            fm.ShowDialog();
            this.Close();
        }

        private void btnAssignAutomaticShift_Click(object sender, EventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            bool success= scheduleManagement.AutomaticallyAssignEmployeesToShifts(department, selectedWorkWeek);
            if (success)
            {
                MessageBox.Show("Shifts assigned succesfully");
                ClearListBoxes();
                FillNumberOfPeople(department.id, selectedWorkWeek);
                FillPeopleInListBoxes(department.id, selectedWorkWeek);
            }
            else MessageBox.Show("Employees couldn't be assigned succesfully");

        }


        private void button_GenerateQR_Click(object sender, EventArgs e)
        {
            var id = textBox_ID_ManageEmployees_Administration.Text;
            QRCoder.QRCodeGenerator qR = new QRCoder.QRCodeGenerator();
            var crt = qR.CreateQrCode(id, QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(crt);
            pictureBox1.Image = code.GetGraphic(5);
        }

       
        public void PopulateComboboxWorkWeek()
        {
            var workWeeks = scheduleManagement.PopulateComboboxWorkWeeks();

            cmbWeek.DisplayMember = "ToString()";
            cmbWeek.ValueMember = "id";
            cmbWeek.DataSource = workWeeks;

            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            if (workWeek != null)
            {

                selectedWorkWeek = workWeek.id;
            }


        }

        private void cmbWeek_SelectedValueChanged(object sender, EventArgs e)
        {
            ClearListBoxes();
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            if (workWeek != null)
            {
                selectedWorkWeek = workWeek.id;
                lblStartDate.Text = scheduleManagement.GetMondayFromWeek(selectedWorkWeek);
                lblEndDate.Text = scheduleManagement.GetSundayFromWeek(selectedWorkWeek);
                FillNumberOfPeople(department.id, selectedWorkWeek);
                FillPeopleInListBoxes(department.id, selectedWorkWeek);
            }
        }


        private void FillNumberOfPeople(int departmentId, int workWeekid)
        {
            DataTable numberOfPeopleDataTable = scheduleManagement.SelectNumberOfPeoplePerShift(departmentId, workWeekid);
            foreach (DataRow row in numberOfPeopleDataTable.Rows)
            {
                int numberOfPeople = Convert.ToInt32(row["People"]);
                int shift = Convert.ToInt32(row["Shift"]);
                int day = Convert.ToInt32(row["Day"]);
                switch (day)
                {
                    case 1:
                        {

                            if (shift == 1)
                            {
                                lbMondayMorning.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbMondayMorning.Items.Add("-------------------------------");
                            }
                            if (shift == 2)
                            {
                                lbMondayAfternoon.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbMondayAfternoon.Items.Add("-------------------------------");
                            }
                            if (shift == 3)
                            {
                                lbMondayEvening.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbMondayEvening.Items.Add("-------------------------------");
                            }
                            break;
                        }
                    case 2:
                        {

                            if (shift == 1)
                            {
                                lbTuesdayMorning.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbTuesdayMorning.Items.Add("----------------------");
                            }
                            if (shift == 2)
                            {
                                lbTuesdayAfternoon.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbTuesdayAfternoon.Items.Add("----------------------");
                            }
                            if (shift == 3)
                            {
                                lbTuesdayEvening.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbTuesdayEvening.Items.Add("----------------------");
                            }
                            break;
                        }
                    case 3:
                        {

                            if (shift == 1)
                            {
                                lbWednesdayMorning.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbWednesdayMorning.Items.Add("----------------------");
                            }
                            if (shift == 2)
                            {
                                lbWednesdayAfternoon.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbWednesdayAfternoon.Items.Add("----------------------");
                            }
                            if (shift == 3)
                            {
                                lbWednesdayEvening.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbWednesdayEvening.Items.Add("----------------------");
                            }
                            break;
                        }
                    case 4:
                        {

                            if (shift == 1)
                            {
                                lbThursdayMorning.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbThursdayMorning.Items.Add("----------------------");
                            }
                            if (shift == 2)
                            {
                                lbThursdayAfternoon.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbThursdayAfternoon.Items.Add("----------------------");
                            }
                            if (shift == 3)
                            {
                                lbThursdayEvening.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbThursdayEvening.Items.Add("----------------------");
                            }
                            break;
                        }
                    case 5:
                        {

                            if (shift == 1)
                            {
                                lbFridayMorning.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbFridayMorning.Items.Add("----------------------");
                            }
                            if (shift == 2)
                            {
                                lbFridayAfternoon.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbFridayAfternoon.Items.Add("----------------------");
                            }
                            if (shift == 3)
                            {
                                lbFridayEvening.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbFridayEvening.Items.Add("----------------------");
                            }
                            break;
                        }
                    case 6:
                        {

                            if (shift == 1)
                            {
                                lbSaturdayMorning.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbSaturdayMorning.Items.Add("----------------------");
                            }
                            if (shift == 2)
                            {
                                lbSaturdayAfternoon.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbSaturdayAfternoon.Items.Add("----------------------");
                            }
                            if (shift == 3)
                            {
                                lbSaturdayEvening.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbSaturdayEvening.Items.Add("----------------------");
                            }
                            break;
                        }
                    case 7:
                        {

                            if (shift == 1)
                            {
                                lbSundayMorning.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbSundayMorning.Items.Add("----------------------");
                            }
                            if (shift == 2)
                            {
                                lbSundayAfternoon.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbSundayAfternoon.Items.Add("----------------------");
                            }
                            if (shift == 3)
                            {
                                lbSundayEvening.Items.Add("Nr of people needed: " + numberOfPeople);
                                lbSundayEvening.Items.Add("----------------------");
                            }
                            break;
                        }

                }

            }
        }


        private void FillPeopleInListBoxes(int departmentId, int workWeekid)
        {
            DataTable numberOfPeopleDataTable = scheduleManagement.SelectPeoplePerShift(departmentId, workWeekid);
            bool mondayMorning = false;
            bool mondayAfternoon = false;
            bool mondayEvening = false;
            bool tuesdayMorning = false;
            bool tuesdayAfternoon = false;
            bool tuesdayEvening = false;
            bool wednesdayMorning = false;
            bool wednesdayAfternoon = false;
            bool wednesdayEvening = false;
            bool thursdayMorning = false;
            bool thursdayAfternoon = false;
            bool thursdayEvening = false;
            bool fridayMorning = false;
            bool fridayAfternoon = false;
            bool fridayEvening = false;
            bool saturdayMorning = false;
            bool saturdayAfternoon = false;
            bool saturdayEvening = false;
            bool sundayMorning = false;
            bool sundayAfternoon = false;
            bool sundayEvening = false;

            foreach (DataRow row in numberOfPeopleDataTable.Rows)
            {
                string name = row["Name"].ToString();
                int shift = Convert.ToInt32(row["Shift"]);
                int assignedPeople = Convert.ToInt32(row["Assigned"]);
                int day = Convert.ToInt32(row["Day"]);

                switch (day)
                {
                    case 1:
                        {

                            if (shift == 1)
                            {
                                if (assignedPeople > 6 )
                                {
                                    if (mondayMorning == false)
                                    {
                                        lbMondayMorning.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        mondayMorning = true;
                                    }
                                   
                                }
                                else
                                {
                                    lbMondayMorning.Items.Add(name);
                                }
                              
                            }
                            if (shift == 2)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (mondayAfternoon == false)
                                    {
                                        lbMondayAfternoon.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        mondayAfternoon = true;
                                    }

                                }
                                else
                                {
                                    lbMondayAfternoon.Items.Add(name);
                                }
                            }
                            if (shift == 3)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (mondayEvening == false)
                                    {
                                        lbMondayEvening.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        mondayEvening = true;
                                    }

                                }
                                else
                                {
                                    lbMondayEvening.Items.Add(name);
                                }

                            }
                            break;
                        }
                    case 2:
                        {

                            if (shift == 1)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (tuesdayMorning == false)
                                    {
                                        lbTuesdayMorning.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        tuesdayMorning = true;
                                    }

                                }
                                else
                                {
                                    lbTuesdayMorning.Items.Add(name);
                                }
                            }
                            if (shift == 2)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (tuesdayAfternoon == false)
                                    {
                                        lbTuesdayAfternoon.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        tuesdayAfternoon = true;
                                    }

                                }
                                else
                                {
                                    lbTuesdayAfternoon.Items.Add(name);
                                }
                            }
                            if (shift == 3)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (tuesdayEvening == false)
                                    {
                                        lbTuesdayEvening.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        tuesdayEvening = true;
                                    }

                                }
                                else
                                {
                                    lbTuesdayEvening.Items.Add(name);
                                }
                            }
                            break;
                        }
                    case 3:
                        {

                            if (shift == 1)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (wednesdayMorning == false)
                                    {
                                        lbWednesdayMorning.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        wednesdayMorning = true;
                                    }

                                }
                                else
                                {
                                    lbWednesdayMorning.Items.Add(name);
                                }
                            }
                            if (shift == 2)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (wednesdayAfternoon == false)
                                    {
                                        lbWednesdayAfternoon.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        wednesdayAfternoon = true;
                                    }

                                }
                                else
                                {
                                    lbWednesdayAfternoon.Items.Add(name);
                                }
                            }
                            if (shift == 3)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (wednesdayEvening == false)
                                    {
                                        lbWednesdayEvening.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        wednesdayEvening = true;
                                    }

                                }
                                else
                                {
                                    lbWednesdayEvening.Items.Add(name);
                                }
                            }
                            break;
                        }
                    case 4:
                        {

                            if (shift == 1)
                            {

                                if (assignedPeople > 6)
                                {
                                    if (thursdayMorning == false)
                                    {
                                        lbThursdayMorning.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        thursdayMorning = true;
                                    }

                                }
                                else
                                {
                                    lbThursdayMorning.Items.Add(name);
                                }
                            }
                            if (shift == 2)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (thursdayAfternoon == false)
                                    {
                                        lbThursdayAfternoon.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        thursdayAfternoon = true;
                                    }

                                }
                                else
                                {
                                    lbThursdayAfternoon.Items.Add(name);
                                }
                            }
                            if (shift == 3)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (thursdayEvening == false)
                                    {
                                        lbThursdayEvening.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        thursdayEvening = true;
                                    }

                                }
                                else
                                {
                                    lbThursdayEvening.Items.Add(name);
                                }
                            }
                            break;
                        }
                    case 5:
                        {

                            if (shift == 1)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (fridayMorning == false)
                                    {
                                        lbFridayMorning.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        fridayMorning = true;
                                    }

                                }
                                else
                                {
                                    lbFridayMorning.Items.Add(name);
                                }
                            }
                            if (shift == 2)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (fridayAfternoon == false)
                                    {
                                        lbFridayAfternoon.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        fridayAfternoon = true;
                                    }

                                }
                                else
                                {
                                    lbFridayAfternoon.Items.Add(name);
                                }
                            }
                            if (shift == 3)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (fridayEvening == false)
                                    {
                                        lbFridayEvening.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        fridayEvening = true;
                                    }

                                }
                                else
                                {
                                    lbFridayEvening.Items.Add(name);
                                }
                            }
                            break;
                        }
                    case 6:
                        {

                            if (shift == 1)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (saturdayMorning == false)
                                    {
                                        lbSaturdayMorning.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        saturdayMorning = true;
                                    }

                                }
                                else
                                {
                                    lbSaturdayMorning.Items.Add(name);
                                }
                            }
                            if (shift == 2)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (saturdayAfternoon == false)
                                    {
                                        lbSaturdayAfternoon.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        saturdayAfternoon = true;
                                    }

                                }
                                else
                                {
                                    lbSaturdayAfternoon.Items.Add(name);
                                }
                            }
                            if (shift == 3)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (saturdayEvening == false)
                                    {
                                        lbSaturdayEvening.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        saturdayEvening = true;
                                    }

                                }
                                else
                                {
                                    lbSaturdayEvening.Items.Add(name);
                                }
                            }
                            break;
                        }
                    case 7:
                        {

                            if (shift == 1)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (sundayMorning == false)
                                    {
                                        lbSundayMorning.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        sundayMorning = true;
                                    }

                                }
                                else
                                {
                                    lbSundayMorning.Items.Add(name);
                                }
                            }
                            if (shift == 2)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (sundayAfternoon == false)
                                    {
                                        lbSundayAfternoon.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        sundayAfternoon = true;
                                    }

                                }
                                else
                                {
                                    lbSundayAfternoon.Items.Add(name);
                                }
                            }
                            if (shift == 3)
                            {
                                if (assignedPeople > 6)
                                {
                                    if (sundayEvening == false)
                                    {
                                        lbSundayEvening.Items.Add("Nr of assigned employees: " + assignedPeople);
                                        sundayEvening = true;
                                    }

                                }
                                else
                                {
                                    lbSundayEvening.Items.Add(name);
                                }
                            }
                            break;
                        }

                }

            }
           
        }
        public void ClearListBoxes()
        {
            lbMondayMorning.Items.Clear();
            lbMondayAfternoon.Items.Clear();
            lbMondayEvening.Items.Clear();
            lbTuesdayMorning.Items.Clear();
            lbTuesdayAfternoon.Items.Clear();
            lbTuesdayEvening.Items.Clear();
            lbWednesdayMorning.Items.Clear();
            lbWednesdayAfternoon.Items.Clear();
            lbWednesdayEvening.Items.Clear();
            lbThursdayMorning.Items.Clear();
            lbThursdayAfternoon.Items.Clear();
            lbThursdayEvening.Items.Clear();
            lbFridayMorning.Items.Clear();
            lbFridayAfternoon.Items.Clear();
            lbFridayEvening.Items.Clear();
            lbSaturdayMorning.Items.Clear();
            lbSaturdayAfternoon.Items.Clear();
            lbSaturdayEvening.Items.Clear();
            lbSundayMorning.Items.Clear();
            lbSundayAfternoon.Items.Clear();
            lbSundayEvening.Items.Clear();
        }

        private void cmbWeek_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lbMondayMorning_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void lbMondayMorning_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 1;
            int shift = 1;
            
            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
            
        }

        private void lbMondayAfternoon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 1;
            int shift = 2;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();

        }

        private void lbMondayEvening_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 1;
            int shift = 3;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbTuesdayMorning_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 2;
            int shift = 1;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbTuesdayAfternoon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 2;
            int shift = 2;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbTuesdayEvening_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 2;
            int shift = 3;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbWednesdayMorning_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 3;
            int shift = 1;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbWednesdayAfternoon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 3;
            int shift = 2;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbWednesdayEvening_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 3;
            int shift = 3;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbThursdayMorning_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 4;
            int shift = 1;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbThursdayAfternoon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 4;
            int shift = 2;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbThursdayEvening_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 4;
            int shift = 3;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbFridayMorning_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 5;
            int shift = 1;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbFridayAfternoon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 5;
            int shift = 2;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbFridayEvening_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 5;
            int shift = 3;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbSaturdayMorning_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 6;
            int shift = 1;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbSaturdayAfternoon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 6;
            int shift = 2;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbSaturdayEvening_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 6;
            int shift = 3;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbSundayMorning_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 7;
            int shift = 1;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbSundayAfternoon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 7;
            int shift = 2;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void lbSundayEvening_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            int day = 7;
            int shift = 3;

            ManualScheduler fm = new ManualScheduler(department.id, workWeek.id, day, shift);
            fm.ShowDialog();
        }

        private void tabPage_ManageEmployees_Click(object sender, EventArgs e)
        {

        }
    }
}
