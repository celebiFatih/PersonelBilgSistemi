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
using DevExpress.XtraEditors;

namespace PBS_NTP_Proje
{
    public partial class Frm_Update : Form
    {
        public Frm_Update()
        {
            InitializeComponent();
        }
        //sql kaynağımıza bağlantı kurmamızı sağlayacak baglanti nesnesi, 
        //Personel sınıfından prs nesnesi, Personel_DB sınıfından dbPersonel oluşturuldu->
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLSERVER2017EXP;Initial Catalog=PersonelBilgiSistemi;Integrated Security=True");
        Personel prs = new Personel();
        Personel_DB dbPersonel = new Personel_DB();

        public void Listele()//veritabanında kayıtlı personel bilgilerini listeler
        {
            SqlDataAdapter da = new SqlDataAdapter("Select*From Tbl_Personal Order By Sicil", baglanti);//Tbl_Personal tablosundan sql sorgusu ile alacağımız verileri SqlDataAdapter sınıfından türettiğimiz da nesnesine atadık
            DataTable dt = new DataTable();//DataTable sınıfından dt isimli sanal bir tablo oluşturduk
            da.Fill(dt);//da nesnesi içriğini dt sanal tablo nesnesine aktardık
            gridControl1.DataSource = dt;//dt nesnesinin içeriğini gridkontrol1 datasource özelliğini kullanarak yansıttık
        }

        //gridView aracının FocusedRowChanged Event'i kullanılarak seçilen listeden üzerine tıklanan personelin bilgileri ilgili textedit'lere aktarıldı
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);//DataRow dan türetilen dr nesnesi GridWiew içerisinde GetDataRow metodu ile satırın verilerini alır.
            if (dr != null)//seçilen satırda veri varsa
            {
                txtId.Text = dr[0].ToString();//dr'den gelen 0. parametre yani ilk okunan veri txtId isimli textedit'in text'ine atandı...
                txtName.Text = dr[1].ToString();
                txtSurname.Text = dr[2].ToString();
                cmbGender.Text = dr[3].ToString();
                txtDate.Text = dr[4].ToString();
                txtCountry.Text = dr[5].ToString();
            }
        }

        private void btnList_Click(object sender, EventArgs e)//mevcut personel listesini List() metodunu çağırarak getirir
        {
            Listele();
        }

        private void btnClear_Click(object sender, EventArgs e)//text'leri temizlemek için
        {
            txtId.Text = "";
            txtName.Text = "";
            txtSurname.Text = "";
            cmbGender.Text = "";
            txtDate.Text = "";
            txtCountry.Text = "";
        }
        //Güncelle butonuna tıklanması ile beraber textlere girilen değerler uygun formatlara dönüştürülerek personel sınıfından türettiğimiz prs nesnemizin özelliklerine atandı.
        //Personel_DB sınıfından türetilen dbPersonel özelliğinin PErsonelGuncelle metoduna prs nesnesi gönderilerek ilgili kayıtların güncellenme işlemi gerçekleşti
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                prs.SICIL = Convert.ToInt32(txtId.Text);
                prs.AD = txtName.Text.Trim();
                prs.SOYAD = txtSurname.Text.Trim();
                prs.CINSIYET = cmbGender.Text;
                prs.DOGTAR = Convert.ToDateTime(txtDate.Text);
                prs.DOGYERI = txtCountry.Text.Trim();
                dbPersonel.PersonelGuncelle(prs);
            }
            catch (FormatException ) // Format Hatası olduğunda hata verir.
            {
                MessageBox.Show("Lütfen doğru formatta veri giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException ) //Değişken sınırları dışına çıktıgında hata verir
            {
                MessageBox.Show("Değişken sınırları dışına çıktınız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex) //Geri kalan tüm hataları denetler
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Listele();//güncelleme işlemi tamamlandıktan sonra güncel personel listesini getirir

                MessageBox.Show("Güncelleme Başarılı", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            

        }

        private void btnFind_Click(object sender, EventArgs e)//sicili girilen personel bilgilerini getirir
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Personal Where Sicil=@sicil", baglanti);//Tbl_Personal tablosunun Sicil alanı verisinin sicil parametresi olan komut nesnesi türettik
            komut.Parameters.AddWithValue("@sicil", txtId.Text);//sicil parametresine txtId'nin text alanına girilen değer atandı            
            
            SqlDataReader dr = komut.ExecuteReader();//datareader sınıfındean türetilen dr nesnesi ile Execute edilen komut nesnesi bilgileri okunuyor
            if (dr.Read())//dr nesnesi okunuyorsa okunan alan bilgilerini ilgili texteditlere gönderdi
            {
                txtId.Text = dr["Sicil"].ToString();
                txtName.Text = dr["Ad"].ToString();
                txtSurname.Text = dr["Soyad"].ToString();
                cmbGender.Text = dr["Cinsiyet"].ToString();
                txtDate.Text = dr["DogumTarihi"].ToString();
                txtCountry.Text = dr["DogumYeri"].ToString();
            }
            else
                MessageBox.Show("Personel Bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            baglanti.Close();
        }

        private void Frm_Update_Load(object sender, EventArgs e)
        {

        }
    }
}
