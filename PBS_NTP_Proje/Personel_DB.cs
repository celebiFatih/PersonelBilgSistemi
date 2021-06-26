using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace PBS_NTP_Proje
{
    class Personel_DB
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=.\SQLSERVER2017EXP;Initial Catalog=PersonelBilgiSistemi;Integrated Security=True");
        

        public List<Personel> Liste()
        {
            List<Personel> prs = new List<Personel>();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Personal", baglanti);
            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                Personel p = new Personel();
                p.SICIL = Convert.ToInt32(dr[0]);
                p.AD = dr[1].ToString();
                p.SOYAD = dr[2].ToString();
                p.CINSIYET = dr[3].ToString();
                p.DOGTAR = Convert.ToDateTime(dr[4]);
                p.DOGYERI = dr[5].ToString();

                prs.Add(p);
            }

            baglanti.Close();
            return prs;
        }
        public void PersonelEkle(Personel prs)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Insert Into Tbl_Personal(Sicil, Ad, Soyad, Cinsiyet, DogumTarihi, DogumYeri) values(@p1, @p2, @p3, @p4, @p5, @p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", prs.SICIL);
            komut.Parameters.AddWithValue("@p2", prs.AD);
            komut.Parameters.AddWithValue("@p3", prs.SOYAD);
            komut.Parameters.AddWithValue("@p4", prs.CINSIYET);
            komut.Parameters.AddWithValue("@p5", prs.DOGTAR);
            komut.Parameters.AddWithValue("@p6", prs.DOGYERI);

            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        public void PersonelGuncelle(Personel prs)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Tbl_Personal set Ad=@p2,Soyad=@p3,Cinsiyet=@p4,DogumTarihi=@p5,DogumYeri=@p6 where Sicil=@p7", baglanti);
            komut.Parameters.AddWithValue("@p7", prs.SICIL);
            komut.Parameters.AddWithValue("@p2", prs.AD);
            komut.Parameters.AddWithValue("@p3", prs.SOYAD);
            komut.Parameters.AddWithValue("@p4", prs.CINSIYET);
            komut.Parameters.AddWithValue("@p5", prs.DOGTAR);
            komut.Parameters.AddWithValue("@p6", prs.DOGYERI);
            

            komut.ExecuteNonQuery();
            baglanti.Close();
        }

        public void PersonelSil(Personel prs)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete From Tbl_Personal Where Sicil=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", prs.SICIL);


            komut.ExecuteNonQuery();
            baglanti.Close();
        }


    }
}
