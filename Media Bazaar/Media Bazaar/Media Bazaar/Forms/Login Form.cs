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
    public partial class Login_Form : Form
    {
        private DBConnection dBConnection;
        public Login_Form()
        {
            InitializeComponent();
            dBConnection = new DBConnection();
            textBox_login_password.Text = "";
            textBox_login_password.PasswordChar = '*';
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            string username = textBox_login_user_name.Text;
            string password = textBox_login_password.Text;
            
            LoginDataObject login = dBConnection.Login(username, password);
            if (login == null)
            {
                textBox_login_password.Clear();
            }
            else
            {
                if (login.GetEmployeePositionid() == 1)
                {
                    this.Hide();
                    Administration_Form fm = new Administration_Form(login);
                    fm.ShowDialog();
                    this.Close();

                }
                if (login.GetEmployeePositionid() == 2)
                {
                    this.Hide();
                    Managment_Form fm = new Managment_Form(login);
                    fm.ShowDialog();
                    this.Close();
                }
                if (login.GetEmployeePositionid() == 3)
                {
                    this.Hide();
                    SalesRepresentative fm = new SalesRepresentative(login);
                    fm.ShowDialog();
                    this.Close();
                }
                if (login.GetEmployeePositionid() == 4)
                {
                    this.Hide();
                    DepotWorker fm = new DepotWorker(login);
                    fm.ShowDialog();
                    this.Close();

                  

                }
            }
        }
    }
}
