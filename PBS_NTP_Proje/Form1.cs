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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Frm_Add adFrm;
        Frm_List listFrm;
        Frm_Update updateFrm;
        Frm_Delete deleteFrm;
        Frm_Logo logoFrm;

        //sql kaynağımıza bağlantı kurmamızı sağlayacak baglanti nesnesi türetildi->
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLSERVER2017EXP;Initial Catalog=PersonelBilgiSistemi;Integrated Security=True");        

        private void btnList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//personel bilgilerini listeler
        {
            
                listFrm = new Frm_List();//listFrm nesnesi Frm_List sınıfından türetildi ve yapıcı metot oluşturuldu
                listFrm.MdiParent = this;//listFrm nesnesinden gelen form değerini mdi üzerinde açar
                listFrm.Show();
            
        }
        //btnList_ItemClick metoduyla sağlanan özellikler aynı şekilde aşağıdaki butonlara tanımlanmıştır.
        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                adFrm = new Frm_Add();
                adFrm.MdiParent = this;
                adFrm.Show();

        }

        private void btnUpdate_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                updateFrm = new Frm_Update();
                updateFrm.MdiParent = this;
                updateFrm.Show();
        }

        private void btnDel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
                deleteFrm = new Frm_Delete();
                deleteFrm.MdiParent = this;
                deleteFrm.Show();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)//uygulamadan çıkış
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak istediğinizden emin misiniz?", "", MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if(sonuc == DialogResult.OK)
            {
                Application.Exit();
            }
            
        }

        private void btnHome_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {            
            Frm_Web webFrm = new Frm_Web();
            webFrm.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                logoFrm = new Frm_Logo();
                logoFrm.MdiParent = this;
                logoFrm.Show();
        }
    }
}
