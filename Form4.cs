using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;  // baglanti için gerekli kütüphaneler 
using System.Data.SqlClient;  // ----

namespace Gorsel_Programlama_Proje
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            listele("Select * from Kuryeler"); // listele fonksiyonunu çalıştırdım Kuryeler tablosunu sıraladım
        }
        public SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-GLI2B5L\SQLEXPRESS;Initial Catalog=KuryeTakip;Integrated Security=True"); // veritabanı bağlantısı yaptım yolunu gösterdim
        public void listele(string veriler) // listele adlı fonksiyon oluşturdum
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler,baglanti);  // Select sorgusu ile verileri DataSet ya da DataTable' a doldurmak için baglantı yaptık
            DataSet ds = new DataSet(); // data set oluşturduk
            da.Fill(ds);// dataSeti doldurduk
            dataGridView1.DataSource = ds.Tables[0];//veri tabanında ki kayıtları datagridview de gösteriyoruz

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
           
           try
            {
                
             
                if (textBox3.Text.Trim() == "") errorProvider1.SetError(textBox3, "Boş geçilmez"); // textboxların boş olup olmadığını kontrol ediyoruz
                else errorProvider1.SetError(textBox3, "");
                if (textBox4.Text.Trim() == "") errorProvider1.SetError(textBox4, "Boş geçilmez");
                else errorProvider1.SetError(textBox4, ""); 
                if (textBox6.Text.Trim() == "") errorProvider1.SetError(textBox6, "Boş geçilmez");
                else errorProvider1.SetError(textBox6, "");
                if (  textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "")
                {
                  baglanti.Open(); // baglantıyı açtık
            SqlCommand cmd = new SqlCommand("insert into Kuryeler(AdSoyad,Cikis,Giris,AracPlaka) VALUES (@AdSoyad,@Cikis,@Giris,@AracPlaka)",baglanti); // sql komutu oluşturuyoruz
            cmd.Parameters.AddWithValue("@AdSoyad", textBox3.Text); // parametreleri veritabanına ekliyoruz
            cmd.Parameters.AddWithValue("@Cikis", textBox4.Text);
            cmd.Parameters.AddWithValue("@Giris", textBox5.Text);
            cmd.Parameters.AddWithValue("@AracPlaka", textBox6.Text);
            cmd.ExecuteNonQuery(); // Bu metod geriye int olarak update, insert, delete olaylarından etkilenen satır sayısı döndürüyor.
                    listele("Select * from Kuryeler"); // Fonksiyonu çalıştırdık
            baglanti.Close(); // baglantıyı kapadık
                    MessageBox.Show("Kayıt İşlemi Tamamlandı ! "); // ekrana uyarı çıkardık
                }

            }
            catch
            {
                MessageBox.Show("Kayıt Zaten Bulunmakta"); // ekrana uyarı çıkardık
                baglanti.Close(); // bağlantıyı kapadık
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false; // kullanıcının datagridview e veri girmesini kapattık
            dataGridView1.AllowUserToDeleteRows = false;// kullanıcının datagridview e veri silmesini kapattık
            dataGridView1.ReadOnly = true;// kullanıcıya sadece okuma izni verdik
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 frm2= new Form2(); // yeni forma geçtik
            frm2.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "") errorProvider1.SetError(textBox2, "Boş geçilmez"); // textboxların boş olup olmadığını kontrol ediyoruz
            else errorProvider1.SetError(textBox2, "");
            if (textBox2.Text.Trim() != "")
            {
                baglanti.Open(); // bağlantıyı açtık
                SqlCommand cmd = new SqlCommand("Delete from Kuryeler where Kurye_ID=@Kurye_ID", baglanti); // yeni sql komudu oluşturduk
                cmd.Parameters.AddWithValue("@Kurye_ID", textBox2.Text); // parametreyi veri tabanına ekliyoruz
                cmd.ExecuteNonQuery();// Bu metod geriye int olarak update, insert, delete olaylarından etkilenen satır sayısı döndürüyor.
                listele("Select * from Kuryeler"); // fonksiyonu çalıştırdık
                baglanti.Close();//bağlantıyı kapadık
            }
          
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // datagirdview de kutucuuğa dokunduğunda yapılacaklar
        {
            
            int secilenalan = dataGridView1.SelectedCells[0].RowIndex; // seçilen satırın row index değerini aldık
            string Kurye_ID = dataGridView1.Rows[secilenalan].Cells[0].Value.ToString(); // sutün sutün değerleri gerekli değişkene tanımladım
            string AdSoyad  = dataGridView1.Rows[secilenalan].Cells[1].Value.ToString();
            string Cikis = dataGridView1.Rows[secilenalan].Cells[2].Value.ToString();
            string Giris = dataGridView1.Rows[secilenalan].Cells[3].Value.ToString();
            string AracPlaka = dataGridView1.Rows[secilenalan].Cells[4].Value.ToString();

            textBox1.Text = Kurye_ID; // değişkenleri textbox ın text değerine atadım tıkladığımda değerler textboxtda gözükmesini sağladım
            textBox3.Text = AdSoyad;
            textBox4.Text = Cikis;
            textBox5.Text = Giris;
            textBox6.Text = AracPlaka;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == "") errorProvider1.SetError(textBox3, "Boş geçilmez");  // textboxların boş olup olmadığını kontrol ediyoruz
            else errorProvider1.SetError(textBox3, "");
                if (textBox4.Text.Trim() == "") errorProvider1.SetError(textBox4, "Boş geçilmez");
                else errorProvider1.SetError(textBox4, "");
               
                if (textBox6.Text.Trim() == "") errorProvider1.SetError(textBox6, "Boş geçilmez");
                else errorProvider1.SetError(textBox6, "");
                if (textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "")
                {
                    baglanti.Open();// bağlantıyı açtık
                SqlCommand cmd = new SqlCommand("update Kuryeler set AdSoyad='" + textBox3.Text + "',Cikis='" + textBox4.Text + "',Giris='" + textBox5.Text + "',AracPlaka='" + textBox6.Text + "'where Kurye_ID='" + textBox1.Text + "'", baglanti); // yeni sql komudu oluşturduk
                cmd.ExecuteNonQuery();// Bu metod geriye int olarak update, insert, delete olaylarından etkilenen satır sayısı döndürüyor.
                listele("select * from Kuryeler");//fonksiyonu çalıştırdık
                    baglanti.Close();//baglantıyı kapadık
                }
        }
    }
}
