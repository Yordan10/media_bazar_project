namespace Media_Bazaar
{
    partial class Login_Form
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
            this.label_Login_User_Name = new System.Windows.Forms.Label();
            this.label_login_password = new System.Windows.Forms.Label();
            this.button_login = new System.Windows.Forms.Button();
            this.textBox_login_user_name = new System.Windows.Forms.TextBox();
            this.textBox_login_password = new System.Windows.Forms.TextBox();
            this.label_LoginForm = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_Login_User_Name
            // 
            this.label_Login_User_Name.AutoSize = true;
            this.label_Login_User_Name.Location = new System.Drawing.Point(49, 100);
            this.label_Login_User_Name.Name = "label_Login_User_Name";
            this.label_Login_User_Name.Size = new System.Drawing.Size(57, 13);
            this.label_Login_User_Name.TabIndex = 0;
            this.label_Login_User_Name.Text = "UserName";
            // 
            // label_login_password
            // 
            this.label_login_password.AutoSize = true;
            this.label_login_password.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_login_password.Location = new System.Drawing.Point(49, 161);
            this.label_login_password.Name = "label_login_password";
            this.label_login_password.Size = new System.Drawing.Size(53, 13);
            this.label_login_password.TabIndex = 1;
            this.label_login_password.Text = "Password";
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(132, 217);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(101, 23);
            this.button_login.TabIndex = 2;
            this.button_login.Text = "Login";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // textBox_login_user_name
            // 
            this.textBox_login_user_name.Location = new System.Drawing.Point(133, 100);
            this.textBox_login_user_name.Name = "textBox_login_user_name";
            this.textBox_login_user_name.Size = new System.Drawing.Size(100, 20);
            this.textBox_login_user_name.TabIndex = 3;
            // 
            // textBox_login_password
            // 
            this.textBox_login_password.Location = new System.Drawing.Point(132, 158);
            this.textBox_login_password.Name = "textBox_login_password";
            this.textBox_login_password.Size = new System.Drawing.Size(100, 20);
            this.textBox_login_password.TabIndex = 3;
            // 
            // label_LoginForm
            // 
            this.label_LoginForm.AutoSize = true;
            this.label_LoginForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_LoginForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label_LoginForm.Location = new System.Drawing.Point(102, 21);
            this.label_LoginForm.Name = "label_LoginForm";
            this.label_LoginForm.Size = new System.Drawing.Size(160, 31);
            this.label_LoginForm.TabIndex = 4;
            this.label_LoginForm.Text = "Login Form";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.label_LoginForm);
            this.panel1.Location = new System.Drawing.Point(0, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(368, 64);
            this.panel1.TabIndex = 5;
            // 
            // Login_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightCyan;
            this.ClientSize = new System.Drawing.Size(368, 330);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox_login_password);
            this.Controls.Add(this.textBox_login_user_name);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.label_login_password);
            this.Controls.Add(this.label_Login_User_Name);
            this.Name = "Login_Form";
            this.Text = "Login_Form";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_Login_User_Name;
        private System.Windows.Forms.Label label_login_password;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.TextBox textBox_login_user_name;
        private System.Windows.Forms.TextBox textBox_login_password;
        private System.Windows.Forms.Label label_LoginForm;
        private System.Windows.Forms.Panel panel1;
    }
}