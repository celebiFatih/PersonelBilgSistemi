using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PBS_NTP_Proje
{
    public partial class Frm_List : Form
    {
        //sql kaynağımıza bağlantı kurmamızı sağlayacak baglanti nesnesi türetildi->
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLSERVER2017EXP;Initial Catalog=PersonelBilgiSistemi;Integrated Security=True");

        public void Listele()//veritabanında kayıtlı personel bilgilerini listeler
        {
            SqlDataAdapter da = new SqlDataAdapter("Select*From Tbl_Personal Order By Sicil", baglanti);//Tbl_Personal tablosundan sql sorgusu ile alacağımız verileri SqlDataAdapter sınıfından türettiğimiz da nesnesine atadık
            DataTable dt = new DataTable();//DataTable sınıfından dt isimli sanal bir tablo oluşturduk
            da.Fill(dt);//da nesnesi içriğini dt sanal tablo nesnesine aktardık
            gridControl1.DataSource = dt;//dt nesnesinin içeriğini gridkontrol1 datasource özelliğini kullanarak yansıttık
        }

        public Frm_List()
        {
            InitializeComponent();
        }

        private void Frm_List_Load(object sender, EventArgs e)//Form açıldığında Listele metodu ile personel bilgilerini listeler
        {
            Listele();
        }
    }
}
