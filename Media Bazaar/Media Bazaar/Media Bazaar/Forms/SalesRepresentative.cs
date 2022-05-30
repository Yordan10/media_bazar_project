using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar
{
    public partial class SalesRepresentative : Form
    {
        SalesManagement salesManagement;
        LoginDataObject loginData;
        DBConnection dBConnection;
        AdministrationManagement administrationManagement;
        ScheduleManagement scheduleManagement;
        int selectedProductType = -1;
        int selectedWorkWeek = -1;
        public SalesRepresentative(LoginDataObject loginData)
        {

            InitializeComponent();
            this.loginData = loginData;
            dBConnection = new DBConnection();
            salesManagement = new SalesManagement();
            administrationManagement = new AdministrationManagement();
            scheduleManagement = new ScheduleManagement();
            PopulateComboboxProductType();
            PopulateComboboxProduct();
            ShowRequests();
            GetPersonalInfo();
            PopulateComboboxWorkWeek();
            ShowShift();
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
        public void PopulatePersonalData()
        {

            try
            {
                SaleRepresentative s;
                s =dBConnection.SelectSaleRepresentative(loginData.GetEmployeeId());

                //textBox_ID_PersonalInfo_SalesRepresentative.Text = s.GetId().ToString();
                //string fName = dataReader["FirstName"].ToString();
                //string username = dataReader["UserName"].ToString();
                //string password = dataReader["Password"].ToString();
                //string surname = dataReader["Surname"].ToString();
                //int phoneNumber = Convert.ToInt32(dataReader["PhoneNumber"]);
                //string address = dataReader["Address"].ToString();
                //// string birthDate = birthDate;
                //string email = dataReader["Email"].ToString();
                //int isMarried = Convert.ToInt32(dataReader["IsMarried"]);
                //int bsn = Convert.ToInt32(dataReader["BSN"]);
                //string functions = dataReader["Functions"].ToString();
                //decimal salary = Convert.ToDecimal(dataReader["Salary"]);
                //int gender = Convert.ToInt32(dataReader["Gender"]);
                //// string startDate = startDate;
                //string certificates = dataReader["Certificates"].ToString();
                //string languagesSpoken = dataReader["SpokenLanguages"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }
        public void PopulateComboboxProductType()
        {
            var productTypes = salesManagement.PopulateComboboxProductType();

            cmbProductType.DisplayMember = "name";
            cmbProductType.ValueMember = "id";
            cmbProductType.DataSource = productTypes;
            ProductType productType = (ProductType)cmbProductType.SelectedItem;
            if (productType!=null)
            {
              
                selectedProductType = productType.ID;
            }
           
        }
        public void PopulateComboboxProduct()
        {
           
            var products =salesManagement.PopulateComboboxProduct(selectedProductType);

            cmbProducts.DisplayMember = "name";
            cmbProducts.ValueMember = "id";
            cmbProducts.DataSource = products;
        }
        public void ShowRequests()
        {
            datagridViewRequests.DataSource = salesManagement.ShowAllRequests();
        }
        private void button_Request_Request_SalesRepresentative_Click(object sender, EventArgs e)
        {
            try
            {
              //  int id = Convert.ToInt32(tbIdRequest.Text);
                int quantity = Convert.ToInt32(tbQuantity.Text);
                Product product = (Product)cmbProducts.SelectedItem;
                salesManagement.AddRequest(product.id, quantity);
                ShowRequests();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button_Logout_PersonalInfo_SalesRepresentative_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form fm = new Login_Form();
            fm.ShowDialog();
            this.Close();
        }

        private void button_Logout_Request_SalesRepresentative_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form fm = new Login_Form();
            fm.ShowDialog();
            this.Close();
        }

        private void cmbProductType_SelectedValueChanged(object sender, EventArgs e)
        {
            
            ProductType productType = (ProductType)cmbProductType.SelectedItem;
            if (productType != null)
            {

                selectedProductType = productType.ID;
            }
            PopulateComboboxProduct();

        }

        public void GetPersonalInfo()
        {
            SaleRepresentative s;
           s = dBConnection.SelectSaleRepresentative(loginData.GetEmployeeId());
            textBox_Address_PersonalInfo_SalesRepresentative.Text = s.GetAddress();
            textBox_BSN_PersonalInfo_SalesRepresentative.Text = s.GetBsn().ToString();
            textBox_FirstName_PersonalInfo_SalesRepresentative.Text = s.GetFirstName();
            textBox_ID_PersonalInfo_SalesRepresentative.Text = s.GetId().ToString();
            textBox_Languages_PersonalInfo_SalesRepresentative.Text = s.GetLanguagesSpoken();
            textBox_LastName_PersonalInfo_SalesRepresentative.Text = s.GetSurname();
            textBox_Phone_PersonalInfo_SalesRepresentative.Text = s.GetPhoneNumber().ToString();
            textBox_Role_PersonalInfo_SalesRepresentative.Text = s.GetPosition().ToString();
            tbDepartment.Text = s.GetDepartment().ToString();
            textBox_Salary_PersonalInfo_SalesRepresentative.Text = s.GetSalary().ToString();
            tbFunctions.Text = s.GetFunctions();
            tbPassword.Text = s.GetPassword();
            tbUsername.Text = s.GetUsername();
            dateTimePicker1StartDate.Value = s.GetStartDate();
            dateTimePickerBirth.Value = s.GetBirth();

            textBox_Certificates_lesRepresentative.Text = s.GetCertificates();
            int isMarried = s.GetIsMarried();
            if (isMarried==1)
            {
                radioButton_Yes_PersonalInfo_SalesRepresentative.Checked = true;
            }
            if (isMarried==0)
            {
                radioButton_No_PersonalInfo_SalesRepresentative.Checked = true;
            }
            tbEmail.Text = s.GetEmail();
            int gender = s.GetGender();
            if (gender == 0)
            {
                rbtnMale.Checked = true;
            }
            if (gender== 1)
            {
                rbtnFemale.Checked = true;
            }
            if (gender == 2)
            {
                rbtnUnknown.Checked = true;
            }
            QRCoder.QRCodeGenerator qR = new QRCoder.QRCodeGenerator();
            var crt = qR.CreateQrCode(s.GetId().ToString(), QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(crt);
            pictureBox3.Image = code.GetGraphic(5);

        }

        private void button_Edit_PersonalInfo_SalesRepresentative_Click(object sender, EventArgs e)
        {
            try
            {
                string username = tbUsername.Text;
                string password = tbPassword.Text;
                int id = Convert.ToInt32(textBox_ID_PersonalInfo_SalesRepresentative.Text);
                string fName = textBox_FirstName_PersonalInfo_SalesRepresentative.Text;
                string surname = textBox_LastName_PersonalInfo_SalesRepresentative.Text;
                int phoneNumber = Convert.ToInt32(textBox_Phone_PersonalInfo_SalesRepresentative.Text);
                DateTime birth = dateTimePickerBirth.Value;
                int bsn = Convert.ToInt32(textBox_BSN_PersonalInfo_SalesRepresentative.Text);
                DateTime startDate = dateTimePicker1StartDate.Value;
                string address = textBox_Address_PersonalInfo_SalesRepresentative.Text;
                string certificates = textBox_Certificates_lesRepresentative.Text;
                string languages = textBox_Languages_PersonalInfo_SalesRepresentative.Text;
                int isMarried = -1;
                if (radioButton_No_PersonalInfo_SalesRepresentative.Checked)
                {
                    isMarried = 0;
                }
                if (radioButton_Yes_PersonalInfo_SalesRepresentative.Checked)
                {
                    isMarried = 1;
                }

                int gender = -1;
                if (rbtnMale.Checked)
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

                string email = tbEmail.Text;
                string functions = tbFunctions.Text;
                string spouse = tbSpouse.Text;
                SaleRepresentative s;
                s = dBConnection.SelectSaleRepresentative(loginData.GetEmployeeId());
                administrationManagement.EditEmployee(username, password, fName, surname, phoneNumber, address, birth.ToString("yyyy-MM-dd HH:mm:ss"), email, isMarried, bsn, functions, id, startDate.ToString("yyyy-MM-dd HH:mm:ss"), languages, certificates, s.GetPosition(), s.GetSalary(), gender,spouse,s.GetDepartment(),s.GetContract());
            
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
              
            }
        
        }

        public void ShowShift()
        {
            
            dataGridView1.DataSource = scheduleManagement.ShowShift(loginData.GetEmployeeId(), selectedWorkWeek);
        }

        private void cmbWeek_SelectedValueChanged(object sender, EventArgs e)
        {
            WorkWeek workWeek = (WorkWeek)cmbWeek.SelectedItem;
            if (workWeek != null)
            {

                selectedWorkWeek = workWeek.id;
                ShowShift();
                lblWeeklyHours.Text = scheduleManagement.ShowWorkingHoursPerWeek(loginData.GetEmployeeId(), selectedWorkWeek).ToString();
            }
        }

        private void cmbWeek_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label_Role_PersonalInfo_SalesRepresentative_Click(object sender, EventArgs e)
        {

        }

        private void tabPage_PersonalInfo_SalesRepresentative_Click(object sender, EventArgs e)
        {

        }
    }
}
