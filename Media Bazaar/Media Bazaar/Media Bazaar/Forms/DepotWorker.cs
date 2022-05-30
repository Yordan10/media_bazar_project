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
    public partial class DepotWorker : Form
    {
        Admin admin;
        LoginDataObject loginData;
        AdministrationManagement administrationManagement;
        ScheduleManagement scheduleManagement;
        int selectedWorkWeek = -1;

        public DepotWorker(LoginDataObject loginData)
        {
            InitializeComponent();
            this.loginData = loginData;
            admin = new Admin();
            administrationManagement = new AdministrationManagement();
            scheduleManagement = new ScheduleManagement();
            ShowStockInDataGrid();
            ShowStockTypesInComboBox();
            ShowRequestsInGrid();
            ShowShiftDepot();
            GetPersonalInfoDepot();
            PopulateComboboxWorkWeek();
            ShowShiftDepot();
            this.comboBox_Type_ManageStock_DepotWorker.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox_Product_PTypes1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox_Products_PTypes2.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        public void PopulateComboboxWorkWeek()
        {
            var workWeeks = scheduleManagement.PopulateComboboxWorkWeeks();

            cmbWeeks.DisplayMember = "ToString()";
            cmbWeeks.ValueMember = "id";
            cmbWeeks.DataSource = workWeeks;
            WorkWeek workWeek = (WorkWeek)cmbWeeks.SelectedItem;
            if (workWeek != null)
            {

                selectedWorkWeek = workWeek.id;
            }


        }


        private void ShowStockInDataGrid()
        {
            dataGridView_Stock_ManageStock_DepotWorker.DataSource = admin.Show_stock();
        }
        private void ShowProductsInDataGrid()
        {
            dataGridView_Products.DataSource = admin.Show_Products();
        }
        private void ShowProductTypesInDataGrid()
        {
            dataGridView_productTypes.DataSource = admin.Show_ProductTypes();
        }
        private void ShowRequestsInGrid()
        {
            dataGridView_ViewRequests_ViewRequests_DepotWorker.DataSource = admin.Show_Requests();
        }
        
        private void ShowStockTypesInComboBox()
        {
            var types = admin.LoadAllStockTypes();
            var DisplayMemeber = "Name";
            comboBox_Type_ManageStock_DepotWorker.DataSource = types;
            comboBox_Products_PTypes2.DataSource = types;
            comboBox_Product_PTypes1.DataSource = types;
            comboBox_Products_PTypes2.DisplayMember = DisplayMemeber;
            comboBox_Product_PTypes1.DisplayMember = DisplayMemeber;
            comboBox_Type_ManageStock_DepotWorker.DisplayMember = DisplayMemeber;
        }
        private void textBox_Type_ManageStock_DepotWorker_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Edit_ManageStock_DepotWorker_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_ID_ManageStock_DepotWorker.Text == String.Empty)
                {
                    MessageBox.Show("Please make sure to select any product first!");
                }
                else
                {
                    int id = Convert.ToInt32(textBox_ID_ManageStock_DepotWorker.Text);
                    int quantity = Convert.ToInt32(textBox_Quantity_ManageStock_DepotWorker.Text);
                    decimal price = Convert.ToInt32(textBox_Price_ManageStock_DepotWorker.Text);
                    admin.Edit_stock(id, quantity, price);
                    ShowStockInDataGrid();
                    ShowStockTypesInComboBox();
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Please make sure to provide the valid value.Only numeric values are allowed to enter.");
            }
            catch
            {
                MessageBox.Show("Something went wrong!");
            }
        }

        private void dataGridView_Stock_ManageStock_DepotWorker_CellClick(object sender, DataGridViewCellEventArgs e)
        {                    
            int index = e.RowIndex;
            if (index >= 0)
            {
                var selectedRow = dataGridView_Stock_ManageStock_DepotWorker.Rows[index];
                textBox_ID_ManageStock_DepotWorker.Text = selectedRow.Cells["ID"].Value.ToString();
                textBox_Name_ManageStock_DepotWorker.Text = selectedRow.Cells["Name"].Value.ToString();
                textBox_Type_ManageStock_DepotWorker.Text = selectedRow.Cells["Type"].Value.ToString();
                textBox_Quantity_ManageStock_DepotWorker.Text = selectedRow.Cells["Quantity"].Value.ToString();
                textBox_Price_ManageStock_DepotWorker.Text = selectedRow.Cells["Price"].Value.ToString();
            }
            }

        private void button_Remove_ManageStock_DepotWorker_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox_ID_ManageStock_DepotWorker.Text);
            var result = admin.RemoveStock(id);
            if (result)
            {
                MessageBox.Show("Stock deleted successfully");
                ShowStockInDataGrid();
                ShowStockTypesInComboBox();
            }
            else
            {
                MessageBox.Show("Stock deletion failed");
            }
        }

        private void button_Search_ManageStock_DepotWorker_Click(object sender, EventArgs e)
        {
            var type = (comboBox_Type_ManageStock_DepotWorker.SelectedItem as ProductType).ID;
            dataGridView_Stock_ManageStock_DepotWorker.DataSource = admin.Filter_stock_By_Type(type);
        }

        private void btnResetStock_Click(object sender, EventArgs e)
        {
            ShowStockInDataGrid();
        }



        private void tabControl_DepotWorker_Click(object sender, EventArgs e)
        {
            ShowProductsInDataGrid();
            ShowProductTypesInDataGrid();
        }

       

        private void button_Logout_ManageStock_DepotWorker_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form fm = new Login_Form();
            fm.ShowDialog();
            this.Close();
        }

        private void button_Logout_ViewRequest_DepotWorker_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form fm = new Login_Form();
            fm.ShowDialog();
            this.Close();
        }

        private void button_Logout_PersonalInfo_DepotWorker_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form fm = new Login_Form();
            fm.ShowDialog();
            this.Close();
        }

        private void dataGridView_ViewRequests_ViewRequests_DepotWorker_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                var selectedRow = dataGridView_ViewRequests_ViewRequests_DepotWorker.Rows[index];
                textBox_ID_ManageRequests_DepotWorker.Text = selectedRow.Cells["ID"].Value.ToString();
                textBox_Name_ManageRequests_DepotWorker.Text = selectedRow.Cells["Name"].Value.ToString();
                textBox_Quantity_ManageRequests_DepotWorker.Text = selectedRow.Cells["Quantity"].Value.ToString();
                textBox_Type_ManageRequests_DepotWorker.Text = selectedRow.Cells["Type"].Value.ToString();
                RequestStatus requestStatus;
                Enum.TryParse<RequestStatus>(selectedRow.Cells["Status"].Value.ToString(), out requestStatus);
                if (requestStatus == RequestStatus.Sent)
                {
                    button_RequestProceed_ManageRequests_DepotWorker.Enabled = true;
                }
                else
                {
                    button_RequestProceed_ManageRequests_DepotWorker.Enabled = false;
                }



            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var name = textBox_Products_PTypeName.Text;
            admin.Add_ProductType(name);
            ShowProductTypesInDataGrid();
            ShowStockTypesInComboBox();
        }

        private void dataGridView_productTypes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                var selectedRow = dataGridView_productTypes.Rows[index];
                textBox_Products_PTypeID.Text = selectedRow.Cells["ID"].Value.ToString();
                textBox_Products_PTypeName.Text = selectedRow.Cells["Name"].Value.ToString();
            }
        }

        private void dataGridView_Products_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                var selectedRow = dataGridView_Products.Rows[index];
                textBox_Products_PNamesID.Text = selectedRow.Cells["ID"].Value.ToString();
                textBox_Products_PNamesName.Text = selectedRow.Cells["Name"].Value.ToString();
                textBox_Model_PNamesName.Text= selectedRow.Cells["Model"].Value.ToString();
                textBox_Brand_PNamesName.Text= selectedRow.Cells["Brand"].Value.ToString();
                textBox_Weight_PNamesName.Text= selectedRow.Cells["Weight"].Value.ToString();
                textBox_Height_PNamesName.Text= selectedRow.Cells["Height"].Value.ToString();
                textBox_Depth_PNamesName.Text= selectedRow.Cells["Depth"].Value.ToString();
                textBox_Barcode_PNamesName.Text= selectedRow.Cells["Barcode"].Value.ToString();
                textBox_Cost.Text= selectedRow.Cells["Cost"].Value.ToString();


                comboBox_Product_PTypes1.SelectedItem = selectedRow.Cells["Type"].Value.ToString();
            }
        }

        private void textBox_Products_PNamesID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

            try
            {
                string name = textBox_Products_PNamesName.Text;
                string model = textBox_Model_PNamesName.Text;
                string brand = textBox_Brand_PNamesName.Text;
                double weight = Convert.ToDouble(textBox_Weight_PNamesName.Text);
                double height = Convert.ToDouble(textBox_Height_PNamesName.Text);
                double depth = Convert.ToDouble(textBox_Depth_PNamesName.Text);
                int barcode = Convert.ToInt32(textBox_Barcode_PNamesName.Text);
                int cost = Convert.ToInt32(textBox_Cost.Text);
                int type = (comboBox_Product_PTypes1.SelectedItem as ProductType).ID;
                admin.Add_Product(type, name, model, brand, weight, height, depth, barcode,cost);
                ShowProductsInDataGrid();
            }
            catch (FormatException)
            {
                MessageBox.Show("Please make sure to provide valid value only");
            }
            
            
        }

        private void textBox_Products_PNamesName_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox_Products_PNamesID.Text);
            string name = textBox_Products_PNamesName.Text;
            string model = textBox_Model_PNamesName.Text;
            string brand = textBox_Brand_PNamesName.Text;
            string weight = GetDouble(textBox_Weight_PNamesName.Text);
            string height = GetDouble(textBox_Height_PNamesName.Text);
            string depth = GetDouble(textBox_Depth_PNamesName.Text);
            int barcode = Convert.ToInt32(textBox_Barcode_PNamesName.Text);
            int cost = Convert.ToInt32(textBox_Cost.Text);


            int type = (comboBox_Product_PTypes1.SelectedItem as ProductType).ID;
            admin.Edit_Product(id,name,type,model,brand,weight,height,depth,barcode,cost);
            ShowProductsInDataGrid();
        }
        string GetDouble(string value)
        {
            double valueWithcomma = Double.Parse(value, System.Globalization.CultureInfo.InvariantCulture);
            var valueWithDot = valueWithcomma.ToString().Replace(',', '.');
            return valueWithDot;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox_Products_PNamesID.Text);
            admin.DEL_Product(id);
            ShowProductsInDataGrid();
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox_Products_PTypeID.Text);
            string name = textBox_Products_PTypeName.Text;
            admin.Edit_ProductType(id, name);
            ShowProductTypesInDataGrid();
            ShowProductsInDataGrid();
            ShowStockTypesInComboBox();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox_Products_PTypeID.Text);
            admin.DEL_ProductType(id);
            ShowProductTypesInDataGrid();
            ShowProductsInDataGrid();
            ShowStockTypesInComboBox();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int type = (comboBox_Products_PTypes2.SelectedItem as ProductType).ID;
            dataGridView_Products.DataSource = admin.Filter_products_By_Type(type);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ShowProductsInDataGrid();
        }

        private void button_RequestProceed_ManageRequests_DepotWorker_Click(object sender, EventArgs e)
        {
            var id = Convert.ToInt32(textBox_ID_ManageRequests_DepotWorker.Text);
            var  quan = Convert.ToInt32(textBox_Quantity_ManageRequests_DepotWorker.Text);

            admin.ProcessRequest(id,quan);
            ShowRequestsInGrid();
            ShowStockInDataGrid();
        }

        private void textBox_FirstName_PersonalInfo_DepotWorker_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_ID_PersonalInfo_DepotWorker_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label_Phone_PersonalInfo_DepotWorker_Click(object sender, EventArgs e)
        {

        }

        private void tabPage_Personalinfo_Depotworker_Click(object sender, EventArgs e)
        {

        }

        private void textBox_Phone_PersonalInfo_DepotWorker_TextChanged(object sender, EventArgs e)
        {

        }

        private void label_BSN_PersonalInfo_DepotWorker_Click(object sender, EventArgs e)
        {

        }

        private void label_Role_PersonalInfo_DepotWorker_Click(object sender, EventArgs e)
        {

        }

        private void label_Certificates_PersonalInfo_DepotWorker_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button_Edit_PersonalInfo_DepotWorker_Click(object sender, EventArgs e)
        {

            try
            {
                string username = textBox_UserName_PersonalInfo_DepotWorker.Text;
                string password = textBox_Password_PersonalInfo_DepotWorker.Text;
                int id = Convert.ToInt32(textBox_ID_PersonalInfo_DepotWorker.Text);
                string fName = textBox_FirstName_PersonalInfo_DepotWorker.Text;
                string surname = textBox_Lastname_PersonalInfo_DepotWorker.Text;
                int phoneNumber = Convert.ToInt32(textBox_Phone_PersonalInfo_DepotWorker.Text);
                DateTime birth = dateTimePickerBirth_PersonalInfo_DepotWorker.Value;
                int bsn = Convert.ToInt32(textBox_BSN_PersonalInfo_DepotWorker.Text);
                DateTime startDate = dateTimePickerStartDate_PersonalInfo_DepotWorker.Value;
                string address = textBox_Address_PersonalInfo_DepotWorker.Text;
                string certificates = textBox_Certificates_PersonalInfo_DepotWorker.Text;
                string languages = textBox_Languages_PersonalInfo_DepotWorker.Text;
                int isMarried = -1;
                if (radioButton_No_PersonalInfo_DepotWorker.Checked)
                {
                    isMarried = 0;
                }
                if (radioButton_Yes_PersonalInfo_DepotWorker.Checked)
                {
                    isMarried = 1;
                }

                int gender = -1;
                if (rbtnMale_PersonalInfo_DepotWorker.Checked)
                {
                    gender = 1;
                }
                if (rbtnFemale_PersonalInfo_DepotWorker.Checked)
                {
                    gender = 0;
                }
                if (rbtnUnknown_PersonalInfo_DepotWorker.Checked)
                {
                    gender = 2;
                }

                string email = textBox_Email_PersonalInfo_DepotWorker.Text;
                string functions = textBox_Functions_PersonalInfo_DepotWorker.Text;
                string spouse = tbSpouse.Text;
                SaleRepresentative s;
                s = admin.GetSaleRepresentative(loginData.GetEmployeeId());
                administrationManagement.EditEmployee(username, password, fName, surname, phoneNumber, address, birth.ToString("yyyy-MM-dd HH:mm:ss"), email, isMarried, bsn, functions, id, startDate.ToString("yyyy-MM-dd HH:mm:ss"), languages, certificates, s.GetPosition(), s.GetSalary(), gender,spouse,s.GetDepartment(),s.GetContract());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            
        }
        public void ShowShiftDepot()
        {

            dataGridView1.DataSource = scheduleManagement.ShowShift(loginData.GetEmployeeId(), selectedWorkWeek);
        }
        public void GetPersonalInfoDepot()
        {
            SaleRepresentative s;
            s = admin.GetSaleRepresentative(loginData.GetEmployeeId());
            textBox_Address_PersonalInfo_DepotWorker.Text = s.GetAddress();
            textBox_BSN_PersonalInfo_DepotWorker.Text = s.GetBsn().ToString();
            textBox_FirstName_PersonalInfo_DepotWorker.Text = s.GetFirstName();
            textBox_ID_PersonalInfo_DepotWorker.Text = s.GetId().ToString();
            textBox_Languages_PersonalInfo_DepotWorker.Text = s.GetLanguagesSpoken();
            textBox_Lastname_PersonalInfo_DepotWorker.Text = s.GetSurname();
            textBox_Phone_PersonalInfo_DepotWorker.Text = s.GetPhoneNumber().ToString();
            textBox_Role_PersonalInfo_DepotWorker.Text = s.GetPosition().ToString();
            textBox_Salary_PersonalInfo_DepotWorker.Text = s.GetSalary().ToString();
            textBox_Functions_PersonalInfo_DepotWorker.Text = s.GetFunctions();
            textBox_Password_PersonalInfo_DepotWorker.Text = s.GetPassword();
            textBox_UserName_PersonalInfo_DepotWorker.Text = s.GetUsername();
            dateTimePickerStartDate_PersonalInfo_DepotWorker.Value = s.GetStartDate();
            dateTimePickerBirth_PersonalInfo_DepotWorker.Value = s.GetBirth();
            textBox_Certificates_PersonalInfo_DepotWorker.Text = s.GetCertificates();
            int isMarried = s.GetIsMarried();
            if (isMarried == 1)
            {
                radioButton_Yes_PersonalInfo_DepotWorker.Checked = true;
            }
            if (isMarried == 0)
            {
                radioButton_No_PersonalInfo_DepotWorker.Checked = true;
            }
            textBox_Email_PersonalInfo_DepotWorker.Text = s.GetEmail();
            int gender = s.GetGender();
            if (gender == 0)
            {
                rbtnMale_PersonalInfo_DepotWorker.Checked = true;
            }
            if (gender == 1)
            {
                rbtnFemale_PersonalInfo_DepotWorker.Checked = true;
            }
            if (gender == 2)
            {
                rbtnUnknown_PersonalInfo_DepotWorker.Checked = true;
            }
            // Gen QR
            QRCoder.QRCodeGenerator qR = new QRCoder.QRCodeGenerator();
            var crt = qR.CreateQrCode(s.GetId().ToString(), QRCoder.QRCodeGenerator.ECCLevel.H);
            var code = new QRCoder.QRCode(crt);
            pictureBox2.Image = code.GetGraphic(5);
        }

        private void textBox_Products_PTypeID_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_Logout_ManageProduct_DepotWorker_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Login_Form fm = new Login_Form();
            fm.ShowDialog();
            this.Close();
        }

        private void cmbWeeks_SelectedValueChanged(object sender, EventArgs e)
        {
            WorkWeek workWeek = (WorkWeek)cmbWeeks.SelectedItem;
            if (workWeek != null)
            {

                selectedWorkWeek = workWeek.id;
                ShowShiftDepot();
                lblShowWorkingHours.Text = scheduleManagement.ShowWorkingHoursPerWeek(loginData.GetEmployeeId(), selectedWorkWeek).ToString();
            }
        }
    }
    
}
