using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace PBS_NTP_Proje
{
    public partial class LoginPage : Form
    {
        
        public LoginPage()
        {
            InitializeComponent();
        }


        private void LoginPage_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string admin = "180541093";
            string psw = "123456";
            string k_adi = txtUserName.Text;
            string sifre = txtPsw.Text;
            
            if (k_adi == admin && sifre==psw)
                {                    
                    MessageBox.Show("Giriş Başarılı!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Form1 frm = new Form1();
                    frm.Show();
                    this.Hide();
                }
            else
                {
                    MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);                
                }
          
            
        }
    }
}
