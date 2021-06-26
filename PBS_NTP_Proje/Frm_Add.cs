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
    public partial class Frm_Add : Form
    {
        public Frm_Add()
        {
            InitializeComponent();
        }
        //sql kaynağımıza bağlantı kurmamızı sağlayacak baglanti nesnesi oluşturuldu->
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLSERVER2017EXP;Initial Catalog=PersonelBilgiSistemi;Integrated Security=True");

        Personel prs = new Personel();
        Form1 frm = new Form1();
        Personel_DB dbPersonel = new Personel_DB();
        public void Listele()//veritabanında kayıtlı personel bilgilerini listeler
        {
            SqlDataAdapter da = new SqlDataAdapter("Select*From Tbl_Personal Order By Sicil", baglanti);//Tbl_Personal tablosundan sql sorgusu ile alacağımız verileri SqlDataAdapter sınıfından türettiğimiz da nesnesine atadık
            DataTable dt = new DataTable();//DataTable sınıfından dt isimli sanal bir tablo oluşturduk
            da.Fill(dt);//da nesnesi içriğini dt sanal tablo nesnesine aktardık
            gridControl1.DataSource = dt;//dt nesnesinin içeriğini gridkontrol1 datasource özelliğini kullanarak yansıttık
        }
        private void Frm_Add_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)//ekle butonuna tıklanması ile beraber textlere girilen değerler uygun formatlara dönüştürülerek personel sınıfından türettiğimiz prs nesnemizin özelliklerine atandı.
        {
            try
            {
                prs.SICIL = Convert.ToInt32(txtId.Text);
                prs.AD = txtName.Text.Trim();
                prs.SOYAD = txtSurname.Text.Trim() ;
                prs.CINSIYET = cmbGender.Text;
                prs.DOGTAR = Convert.ToDateTime(txtDate.Text);
                prs.DOGYERI = txtCountry.Text.Trim();
                dbPersonel.PersonelEkle(prs);
            }            
            catch (FormatException ) // Format Hatası olduğunda hata verir.
            {
                MessageBox.Show("Lütfen doğru formatta veri giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException ) //Değişken sınırları dışına çıktıgında hata verir
            {
                MessageBox.Show("Değişken sınırları dışına çıktınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) //tüm hataları denetler
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Listele();//kayıt işlemi tamamlandıktan sonra güncel personel listesini getirir
                MessageBox.Show("Kayıt Başarılı!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

           

                            
            
        }

        private void btnClear_Click_1(object sender, EventArgs e) //text'leri temizlemek için
        {
            txtId.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            cmbGender.Text = "";
            txtDate.Text = "";
            txtCountry.Text = "";
        }

        //sadece harf girişini sağlamak için ->
        private void txtName_Properties_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void txtCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            Listele();
        }


    }
}
