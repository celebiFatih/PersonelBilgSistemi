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
    public partial class Frm_Web : Form
    {
        public Frm_Web()
        {
            InitializeComponent();
        }

        private void Frm_Web_Load(object sender, EventArgs e)//egm internet ana sayfasını webBrowser aracıyla açar
        {
            webBrowser1.Navigate("https://www.egm.gov.tr");
        }
    }
}
