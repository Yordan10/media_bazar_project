using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Media_Bazaar
{
    public partial class Managment_Form : Form
    {
        LoginDataObject loginData;
        StatisticsManagement statisticsManagement;
        AdministrationManagement administrationManagement;
        ScheduleManagement scheduleManagement;
        Admin admin;
        int selectedWorkWeek = -1;
        public Managment_Form(LoginDataObject loginData)
        {
            InitializeComponent();
            this.loginData = loginData;
            statisticsManagement = new StatisticsManagement();
            administrationManagement = new AdministrationManagement();
            scheduleManagement = new ScheduleManagement();
            ShowRolesInComboBox();
            admin = new Admin();
            ShowRolesInComboBox();
            //ShowStockTypesInComboBox();
            PopulateComboboxWorkWeek();
 
            //show most sold product
            var dt = statisticsManagement.stockst();
            SetPie2(dt);
            label1.Text = "Most Sold Product";
            // PopulateComboboxShiftType();
            PopulateComboboxDepartmentsEmployees();
            //view attendance
            var date = dateTimePicker1.Value.ToShortDateString();
            var dt1 = statisticsManagement.EmpOnTime(date);
            var dt2 = statisticsManagement.delh(date);
            EmpPie4(dt1);
            sethist(dt2);
            //pop combo
            comboBox1.DataSource = statisticsManagement.allemp();
            comboBox1.DisplayMember = "FirstName";
            comboBox1.ValueMember = "ID";

            
        }

        public void PopulateComboboxWorkWeek()
        {
            var workWeeks = scheduleManagement.PopulateComboboxWorkWeeks();

            cmbWeekSearch.DisplayMember = "ToString()";
            cmbWeekSearch.ValueMember = "id";
            cmbWeekSearch.DataSource = workWeeks;
            WorkWeek workWeek1 = (WorkWeek)cmbWeekSearch.SelectedItem;
            if (workWeek1 != null)
            {

                selectedWorkWeek = workWeek1.id;
            }

        }
       
        private void button_Logout_ViewEmployees_Management_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form fm = new Login_Form();
            fm.ShowDialog();
            this.Close();
        }

        private void button_Logout_ViewStock_Management_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form fm = new Login_Form();
            fm.ShowDialog();
            this.Close();
        }

        private void button_Logout_ViewShifts_Management_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form fm = new Login_Form();
            fm.ShowDialog();
            this.Close();
        }

        private void button_ShowResult_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedDepartment = comboBox_Roles.SelectedItem.ToString();
                if (selectedDepartment == "All")
                {
                    selectedDepartment = "";
                }
                if (radioButton_EmployeesByAge.Checked)
                {
                    int StartAge = Convert.ToInt32(textBox_StartAge.Text);
                    int EndAge = Convert.ToInt32(textBox_EndAge.Text);
                    var dt = statisticsManagement.ShowEmployeesByAge(StartAge, EndAge, selectedDepartment);
                    SetChart(dt, "Age");
                }

                if (radioButton_ByGender.Checked)
                {
                    var dt = statisticsManagement.ShowEmployeesByGender(selectedDepartment);
                    SetChart(dt, "Gen");
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show("Something went wrong!");
            }
        }


        void SetChart(DataTable dt, string col)
        {

            this.chartEmp.DataSource = dt;
            this.chartEmp.ChartAreas[0].AxisX.Title = col;
            this.chartEmp.ChartAreas[0].AxisX.Interval = 1;

            this.chartEmp.Series[0].XValueMember = col;

            this.chartEmp.Series[0].YValueMembers = "NoOfEmployees";

            this.chartEmp.DataBind();


        }

        void sethist(DataTable dt)
        {
            this.chart3.DataSource = dt;
            this.chart3.ChartAreas[0].AxisX.Title = "delayHours";
            this.chart3.ChartAreas[0].AxisY.Title = "Number Of Employees";
            this.chart3.ChartAreas[0].AxisX.Interval = 1;
            this.chart3.ChartAreas[0].AxisY.Interval = 1;


            this.chart3.Series[0].XValueMember = "delaytime";

            this.chart3.Series[0].YValueMembers = "NumberOfEmployees";
            chart3.Series["Series1"].LegendText = "HoursLate";


            this.chart3.DataBind();
        }

        void SetPie(DataTable dt)
        {
            this.chart1.DataSource = dt;

            chart1.Series["Series1"].XValueMember = "type";
            chart1.Series["Series1"].YValueMembers = "products";
            chart1.Series["Series1"].Label = "#VALY";
            //chart1.Series["Series1"].Label = "#PERCENT";

            chart1.Series["Series1"].LegendText = "#VALX";
            chart1.Series["Series1"].XValueType = ChartValueType.String;


            this.chart1.DataBind();

        }
        void SetPie2(DataTable dt)
        {
            this.chart1.DataSource = dt;
            chart1.Series["Series1"].XValueMember = "type";
            chart1.Series["Series1"].YValueMembers = "Quantity";
            chart1.Series["Series1"].Label = "#VALY";
            chart1.Series["Series1"].LegendText = "#VALX";
            chart1.Series["Series1"].XValueType = ChartValueType.String;


            this.chart1.DataBind();
        }

        void SetPie3(DataTable dt)
        {
            this.chart1.DataSource = dt;
            chart1.Series["Series1"].XValueMember = "type";
            chart1.Series["Series1"].YValueMembers = "Profit";
            chart1.Series["Series1"].Label = "#VALY"+"$";
            chart1.Series["Series1"].LegendText = "#VALX";
            chart1.Series["Series1"].XValueType = ChartValueType.String;


            this.chart1.DataBind();
        }

        void EmpPie4(DataTable dt)
        {
            this.chart2.DataSource = dt;
            chart2.Series["Series1"].XValueMember = "attendstatus";
            chart2.Series["Series1"].YValueMembers = "No_of_emp";
            chart2.Series["Series1"].Label = "#VALY";
            chart2.Series["Series1"].LegendText = "#VALX";
            chart2.Series["Series1"].XValueType = ChartValueType.String;


            this.chart2.DataBind();
        }

        void NewEmp(DataTable dt)
        {
            this.chart4.DataSource = dt;
            this.chart4.ChartAreas[0].AxisX.Title = "date";
            this.chart4.ChartAreas[0].AxisY.Title = "DelayHours";
            chart4.Series["Series1"].XValueMember = "date";
            chart4.Series["Series1"].YValueMembers = "delaytime";
            chart4.Series["Series1"].Label = "#VALY";
            chart4.Series["Series1"].LegendText = "HoursLate";
            chart4.Series["Series1"].XValueType = ChartValueType.String;


            this.chart4.DataBind();
        }


        void hist(DataTable dt)
        {

            this.chart3.DataSource = dt;
            chart3.Series["Series1"].XValueMember = "delaytime";
            chart3.Series["Series1"].YValueMembers = "NumberOfEmployees";
            chart3.Series["Series1"].Label = "#VALY";
            chart3.Series["Series1"].LegendText = "#VALX";
            chart3.Series["Series1"].XValueType = ChartValueType.String;


            this.chart3.DataBind();
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void ShowRolesInComboBox()
        {
            comboBox_Roles.DataSource = statisticsManagement.GetAllRoles();
        }

        private void tabPage_viewstock_Management_Click(object sender, EventArgs e)
        {

        }



        private void button_MostSoldProduct_ViewStock_Managment_Click(object sender, EventArgs e)
        {
            var dt = statisticsManagement.stockst();
            SetPie2(dt);
            label1.Text = "Most Requested Product";
        }







        private void button_ProductQuantity_Click(object sender, EventArgs e)
        {
            var dt = statisticsManagement.Product_Quan();
            SetPie(dt);
            label1.Text = "Product Quantity";
        }

        private void button_Profit_Click(object sender, EventArgs e)
        {
            var dt = statisticsManagement.Profit_cat();
            SetPie3(dt);
            label1.Text = "Profit Per Requested Product";
        }

       

        private void btnCreateSchedule_Click(object sender, EventArgs e)
        {

            DateTime firstDay = dtpStartDate.Value;
            DateTime lastDay = dtmEndDate.Value;
            TimeSpan difference = lastDay - firstDay;
            int interval = difference.Days;
            int positionId = -1;
            Dictionary<int, int> shiftTypesPerDepartment = new Dictionary<int, int>(); // key : shiftType, value : number per shift
            Department department = (Department)cmbDepartments.SelectedItem;
            int numberPerShiftMorning = Convert.ToInt32(tbNumberPerShiftMorning.Text);
            int numberPerShiftAfternoon = Convert.ToInt32(tbNumberPerShiftAfternoon.Text);
            int numberPerShiftNight = -1;


            if (cmbDepartments.SelectedIndex == 0 || cmbDepartments.SelectedIndex == 1)
            {
                positionId = 3;
                tbNumberPerShiftNight.Hide();
                lblNight.Hide();
                List<ShiftType> listShiftTypes = scheduleManagement.PopulateComboSalesShiftType();
                foreach (ShiftType shiftType in listShiftTypes)
                {
                    if (shiftType.id == 4)
                    {
                        shiftTypesPerDepartment.Add(shiftType.id, numberPerShiftMorning);
                    }
                    if (shiftType.id == 5)
                    {
                        shiftTypesPerDepartment.Add(shiftType.id, numberPerShiftAfternoon);
                    }

                }

            }
            else
            {
                positionId = 4;
                tbNumberPerShiftNight.Show();
                lblNight.Show();
                numberPerShiftNight = Convert.ToInt32(tbNumberPerShiftNight.Text);
                List<ShiftType> listShiftTypes = scheduleManagement.PopulateComboDepotShiftType();
                foreach (ShiftType shiftType in listShiftTypes)
                {
                    if (shiftType.id == 1)
                    {
                        shiftTypesPerDepartment.Add(shiftType.id, numberPerShiftMorning);
                    }
                    if (shiftType.id == 2)
                    {
                        shiftTypesPerDepartment.Add(shiftType.id, numberPerShiftAfternoon);
                    }
                    if (shiftType.id == 3)
                    {
                        shiftTypesPerDepartment.Add(shiftType.id, numberPerShiftNight);
                    }

                }
            }
            bool success = scheduleManagement.CreateSchedule(firstDay, lastDay, department, numberPerShiftMorning, numberPerShiftAfternoon, numberPerShiftNight, positionId, shiftTypesPerDepartment);
            if (success)
            {
                MessageBox.Show("Schedule has been created");
            }
            else MessageBox.Show("Schedule could not been created");

        }



       
        public void PopulateComboboxDepartmentsEmployees()
        {
            var departments = scheduleManagement.PopulateComboboxDepartment();

            cmbDepartments.DisplayMember = "name";
            cmbDepartments.ValueMember = "id";
            cmbDepartments.DataSource = departments;
        }


        private void cmbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDepartments.SelectedIndex == 0 || cmbDepartments.SelectedIndex == 1)
            {
                tbNumberPerShiftNight.Hide();
                lblNight.Hide();
            }
            else
            {
                tbNumberPerShiftNight.Show();
                lblNight.Show();
            }
        }

      
        private void button1_Click(object sender, EventArgs e)
        {

            var date = dateTimePicker1.Value.ToShortDateString();
            var dt = statisticsManagement.EmpOnTime(date);
            var dt2 = statisticsManagement.delh(date);
            EmpPie4(dt);
            sethist(dt2);



        }

        private void chart2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label_ViewEmployees_Management_Click(object sender, EventArgs e)
        {

        }

        private void button_lo_attend_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form fm = new Login_Form();
            fm.ShowDialog();
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                chart2.Hide();
                chart3.Hide();
                chart4.Show();
               // dateTimePicker1.Hide();
                comboBox1.Show();
                button1.Hide();
                button_statistics_per_employee.Show();
                label11.Show();
               // label10.Hide();

            }
            else
            {
                chart2.Show();
                chart3.Show();
                chart4.Hide();
               // dateTimePicker1.Show();
                comboBox1.Hide();
                button1.Show();
                button_statistics_per_employee.Hide();
                label11.Hide();
                //label10.Show();

            }
        }

        private void button_statistics_per_employee_Click(object sender, EventArgs e)
        {
            // int id = Convert.ToInt32(comboBox1.Text);
            var date = dateTimePicker1.Value.ToShortDateString();
            object id = comboBox1.SelectedValue;
            var dt = statisticsManagement.attendemp(Convert.ToInt32(id), date);
            NewEmp(dt);
        }

        private void ClearListBoxes()
        {
            lbMonday1.Items.Clear();
            lbMonday2.Items.Clear();
            lbMonday3.Items.Clear();
            lbMonday4.Items.Clear();
            lbTuesday1.Items.Clear();
            lbTuesday2.Items.Clear();
            lbTuesday3.Items.Clear();
            lbTuesday4.Items.Clear();
            lbWednesday1.Items.Clear();
            lbWednesday2.Items.Clear();
            lbWednesday3.Items.Clear();
            lbWednesday4.Items.Clear();
            lbThursday1.Items.Clear();
            lbThursday2.Items.Clear();
            lbThursday3.Items.Clear();
            lbThursday4.Items.Clear();
            lbFriday1.Items.Clear();
            lbFriday2.Items.Clear();
            lbFriday3.Items.Clear();
            lbFriday4.Items.Clear();
            lbSaturday1.Items.Clear();
            lbSaturday2.Items.Clear();
            lbSaturday3.Items.Clear();
            lbSaturday4.Items.Clear();
            lbSunday1.Items.Clear();
            lbSunday2.Items.Clear();
            lbSunday3.Items.Clear();
            lbSunday4.Items.Clear();
        }

        private void cmbWeekSearch_SelectedValueChanged(object sender, EventArgs e)
        {
            Department department = (Department)cmbDepartments.SelectedItem;
            WorkWeek workWeek = (WorkWeek)cmbWeekSearch.SelectedItem;
            DataTable dt = null;
            ClearListBoxes();
            if (workWeek != null)
            {
                selectedWorkWeek = workWeek.id;
                dt = scheduleManagement.ShowSchedulesFourWeeks(department.id, workWeek.id);
                int i = 1;
                lblWeek1.Text = "Week: " + (workWeek.id);
                lblWeek2.Text = "Week: " + (workWeek.id + 1);
                lblWeek3.Text = "Week: " + (workWeek.id + 2);
                lblWeek4.Text = "Week: " + (workWeek.id + 3);
                foreach (DataRow schedule in dt.Rows)
                {
                  
                    
                    int numberOfPeople = Convert.ToInt32(schedule["People"]);
                    int shift = Convert.ToInt32(schedule["Shift_type"]);
                    string date = schedule["Date"].ToString();
                    int dayOfWeek = Convert.ToInt32(schedule["Day"]);

                    if (shift == 1) 
                    {
                        // new date and first shift

                        
                        switch (i)
                        {
                            case 1:
                                {
                                    lbMonday1.Items.Add("Date: " + date);
                                    lbMonday1.Items.Add("---------------");
                                    lbMonday1.Items.Add("Morning: " + numberOfPeople);
                                    break;
                                }
                            case 2:
                                {
                                    lbTuesday1.Items.Add("Date: " + date);
                                    lbTuesday1.Items.Add("---------------");
                                    lbTuesday1.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 3:
                                {
                                    lbWednesday1.Items.Add("Date: " + date);
                                    lbWednesday1.Items.Add("---------------");
                                    lbWednesday1.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 4:
                                {
                                    lbThursday1.Items.Add("Date: " + date);
                                    lbThursday1.Items.Add("---------------");
                                    lbThursday1.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 5:
                                {
                                    lbFriday1.Items.Add("Date: " + date);
                                    lbFriday1.Items.Add("---------------");
                                    lbFriday1.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 6:
                                {
                                    lbSaturday1.Items.Add("Date: " + date);
                                    lbSaturday1.Items.Add("---------------");
                                    lbSaturday1.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 7:
                                {
                                    lbSunday1.Items.Add("Date: " + date);
                                    lbSunday1.Items.Add("---------------");
                                    lbSunday1.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }

                            case 8:
                                {
                                    lbMonday2.Items.Add("Date: " + date);
                                    lbMonday2.Items.Add("---------------");
                                    lbMonday2.Items.Add("Morning: " + numberOfPeople);
                                    break;
                                }
                            case 9:
                                {
                                    lbTuesday2.Items.Add("Date: " + date);
                                    lbTuesday2.Items.Add("---------------");
                                    lbTuesday2.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 10:
                                {
                                    lbWednesday2.Items.Add("Date: " + date);
                                    lbWednesday2.Items.Add("---------------");
                                    lbWednesday2.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 11:
                                {
                                    lbThursday2.Items.Add("Date: " + date);
                                    lbThursday2.Items.Add("---------------");
                                    lbThursday2.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 12:
                                {
                                    lbFriday2.Items.Add("Date: " + date);
                                    lbFriday2.Items.Add("---------------");
                                    lbFriday2.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 13:
                                {
                                    lbSaturday2.Items.Add("Date: " + date);
                                    lbSaturday2.Items.Add("---------------");
                                    lbSaturday2.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 14:
                                {
                                    lbSunday2.Items.Add("Date: " + date);
                                    lbSunday2.Items.Add("---------------");
                                    lbSunday2.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 15:
                                {
                                    lbMonday3.Items.Add("Date: " + date);
                                    lbMonday3.Items.Add("---------------");
                                    lbMonday3.Items.Add("Morning: " + numberOfPeople);
                                    break;
                                }
                            case 16:
                                {
                                    lbTuesday3.Items.Add("Date: " + date);
                                    lbTuesday3.Items.Add("---------------");
                                    lbTuesday3.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 17:
                                {
                                    lbWednesday3.Items.Add("Date: " + date);
                                    lbWednesday3.Items.Add("---------------");
                                    lbWednesday3.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 18:
                                {
                                    lbThursday3.Items.Add("Date: " + date);
                                    lbThursday3.Items.Add("---------------");
                                    lbThursday3.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 19:
                                {
                                    lbFriday3.Items.Add("Date: " + date);
                                    lbFriday3.Items.Add("---------------");
                                    lbFriday3.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 20:
                                {
                                    lbSaturday3.Items.Add("Date: " + date);
                                    lbSaturday3.Items.Add("---------------");
                                    lbSaturday3.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 21:
                                {
                                    lbSunday3.Items.Add("Date: " + date);
                                    lbSunday3.Items.Add("---------------");
                                    lbSunday3.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }

                            case 22:
                                {
                                    lbMonday4.Items.Add("Date: " + date);
                                    lbMonday4.Items.Add("---------------");
                                    lbMonday4.Items.Add("Morning: " + numberOfPeople);
                                    break;
                                }
                            case 23:
                                {
                                    lbTuesday4.Items.Add("Date: " + date);
                                    lbTuesday4.Items.Add("---------------");
                                    lbTuesday4.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 24:
                                {
                                    lbWednesday4.Items.Add("Date: " + date);
                                    lbWednesday4.Items.Add("---------------");
                                    lbWednesday4.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 25:
                                {
                                    lbThursday4.Items.Add("Date: " + date);
                                    lbThursday4.Items.Add("---------------");
                                    lbThursday4.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 26:
                                {
                                    lbFriday4.Items.Add("Date: " + date);
                                    lbFriday4.Items.Add("---------------");
                                    lbFriday4.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 27:
                                {
                                    lbSaturday4.Items.Add("Date: " + date);
                                    lbSaturday4.Items.Add("---------------");
                                    lbSaturday4.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                            case 28:
                                {
                                    lbSunday4.Items.Add("Date: " + date);
                                    lbSunday4.Items.Add("---------------");
                                    lbSunday4.Items.Add("Morning: " + numberOfPeople);
                                    break;

                                }
                        }
                    }
                    else
                    {
                        // shift
                        switch (i)
                        {
                            case 1:
                                {

                                    lbMonday1.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;
                                }
                            case 2:
                                {
                                    lbTuesday1.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 3:
                                {
                                    lbWednesday1.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 4:
                                {
                                    lbThursday1.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 5:
                                {
                                    lbFriday1.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 6:
                                {
                                    lbSaturday1.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 7:
                                {
                                    lbSunday1.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }

                            case 8:
                                {

                                    lbMonday2.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;
                                }
                            case 9:
                                {
                                    lbTuesday2.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 10:
                                {
                                    lbWednesday2.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 11:
                                {
                                    lbThursday2.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 12:
                                {
                                    lbFriday2.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 13:
                                {
                                    lbSaturday2.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 14:
                                {
                                    lbSunday2.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 15:
                                {

                                    lbMonday3.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;
                                }
                            case 16:
                                {
                                    lbTuesday3.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 17:
                                {
                                    lbWednesday3.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 18:
                                {
                                    lbThursday3.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 19:
                                {
                                    lbFriday3.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 20:
                                {
                                    lbSaturday3.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 21:
                                {
                                    lbSunday3.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 22:
                                {

                                    lbMonday4.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;
                                }
                            case 23:
                                {
                                    lbTuesday4.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 24:
                                {
                                    lbWednesday4.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 25:
                                {
                                    lbThursday4.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 26:
                                {
                                    lbFriday4.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 27:
                                {
                                    lbSaturday4.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }
                            case 28:
                                {
                                    lbSunday4.Items.Add((shift == 2 ? "Afternoon: " : "Evening: ") + numberOfPeople);
                                    break;

                                }


                        }
                    }
                    if (shift==3)
                    {
                        i++;
                    }
                   
                } // foreach

            }
        }
    }
}
