using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace Gorsel_Programlama_Proje
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
            listele("Select * from Alicilar"); // listele fonksiyonunu çalıştırdım Kuryeler tablosunu sıraladım
            dataGridView1.AllowUserToAddRows = false; // kullanıcının datagridview e veri girmesini kapattık
            dataGridView1.AllowUserToDeleteRows = false; // kullanıcının datagridview e veri silmesini kapattık
            dataGridView1.ReadOnly = true; // kullanıcıya sadece okuma izni verdik
        }
        public SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-GLI2B5L\SQLEXPRESS;Initial Catalog=KuryeTakip;Integrated Security=True"); // veritabanı bağlantısı yaptım yolunu gösterdim

        public void listele(string veriler) // listele adlı fonksiyon oluşturdum
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti); // Select sorgusu ile verileri DataSet ya da DataTable' a doldurmak için baglantı yaptık
            DataSet ds = new DataSet(); // data set oluşturduk
            da.Fill(ds);// dataSeti doldurduk
            dataGridView1.DataSource = ds.Tables[0];//veri tabanında ki kayıtları datagridview de gösteriyoruz

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" &&  textBox7.Text.Trim() != "" && textBox8.Text.Trim() != "") // texboxların boş olup olmadığını baktık
            {
                Form6 frm6 = new Form6(); // yeni forma geçtik
                frm6.VeriYolla(il, ilce, Mahalle, Sokak); // form6 ya verileri yolladık
                frm6.Show();
            }
            else { MessageBox.Show("LÜTFEN KONUMUNU GÖRMEK İSTEDİĞİNİZ MÜŞTERİYİ SEÇİNİZ!"); //ekrana uyarı verdirdik 
        }}

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {


                if (textBox3.Text.Trim() == "") errorProvider1.SetError(textBox3, "Boş geçilmez"); // textboxların boş olup olmadığını kontrol ediyoruz
                else errorProvider1.SetError(textBox3, "");
                if (textBox4.Text.Trim() == "") errorProvider1.SetError(textBox4, "Boş geçilmez");
                else errorProvider1.SetError(textBox4, "");
                if (textBox5.Text.Trim() == "") errorProvider1.SetError(textBox5, "Boş geçilmez");
                else errorProvider1.SetError(textBox5, "");
                if (textBox6.Text.Trim() == "") errorProvider1.SetError(textBox6, "Boş geçilmez");
                else errorProvider1.SetError(textBox6, "");
                if (textBox7.Text.Trim() == "") errorProvider1.SetError(textBox7, "Boş geçilmez");
                else errorProvider1.SetError(textBox7, "");
                if (textBox8.Text.Trim() == "") errorProvider1.SetError(textBox8, "Boş geçilmez");
                else errorProvider1.SetError(textBox8, "");
                if (textBox9.Text.Trim() == "") errorProvider1.SetError(textBox9, "Boş geçilmez");
                else errorProvider1.SetError(textBox9, "");
                if (textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && textBox7.Text.Trim() != "" && textBox8.Text.Trim() != "" && textBox9.Text.Trim() != "" )
                {
                    baglanti.Open();// baglantıyı açtık
                    SqlCommand cmd = new SqlCommand("insert into Alicilar(AdSoyad,il,ilce,Mahalle,Sokak,Bina,GonderenAdSoyad) VALUES (@AdSoyad,@il,@ilce,@Mahalle,@Sokak,@Bina,@GonderenAdSoyad)", baglanti);  // sql komutu oluşturuyoruz
                    cmd.Parameters.AddWithValue("@AdSoyad", textBox3.Text); // parametreleri veritabanına ekliyoruz
                    cmd.Parameters.AddWithValue("@il", textBox4.Text);
                    cmd.Parameters.AddWithValue("@ilce", textBox5.Text);
                    cmd.Parameters.AddWithValue("@Mahalle", textBox6.Text);
                    cmd.Parameters.AddWithValue("@Sokak", textBox7.Text);
                    cmd.Parameters.AddWithValue("@Bina", textBox8.Text);
                    cmd.Parameters.AddWithValue("@GonderenAdSoyad", textBox9.Text);
                    cmd.ExecuteNonQuery();// Bu metod geriye int olarak update, insert, delete olaylarından etkilenen satır sayısı döndürüyor.
                    listele("Select * from Alicilar"); // Fonksiyonu çalıştırdık
                    baglanti.Close();//baglantıyı kapadık
                    MessageBox.Show("Kayıt İşlemi Tamamlandı ! ");// ekrana uyarı çıkardık
                }

            }
            catch
            {
                MessageBox.Show("Kayıt Zaten Bulunmakta"); // ekrana uyarı çıkardık
                baglanti.Close();//baglantıyı kapadık
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Trim() == "") errorProvider1.SetError(textBox3, "Boş geçilmez");   // textboxların boş olup olmadığını kontrol ediyoruz
            else errorProvider1.SetError(textBox3, "");
                if (textBox4.Text.Trim() == "") errorProvider1.SetError(textBox4, "Boş geçilmez");
                else errorProvider1.SetError(textBox4, ""); 
                if (textBox6.Text.Trim() == "") errorProvider1.SetError(textBox5, "Boş geçilmez");
                else errorProvider1.SetError(textBox5, "");
                if (textBox6.Text.Trim() == "") errorProvider1.SetError(textBox6, "Boş geçilmez");
                else errorProvider1.SetError(textBox6, "");
                if (textBox6.Text.Trim() == "") errorProvider1.SetError(textBox7, "Boş geçilmez");
                else errorProvider1.SetError(textBox7, "");
                if (textBox6.Text.Trim() == "") errorProvider1.SetError(textBox8, "Boş geçilmez");
                else errorProvider1.SetError(textBox8, "");
                if (textBox6.Text.Trim() == "") errorProvider1.SetError(textBox9, "Boş geçilmez");
                else errorProvider1.SetError(textBox9, "");
                if (textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "")
                {
                    baglanti.Open();// baglantıyı açtık
                SqlCommand cmd = new SqlCommand("update Alicilar set AdSoyad='" + textBox3.Text + "',il='" + textBox4.Text + "',ilce='" + textBox5.Text + "',Mahalle='" + textBox6.Text + "',Sokak='" + textBox7.Text + "',Bina='" + textBox8.Text + "',GonderenAdSoyad='" + textBox9.Text + "'where Alici_ID='" + textBox1.Text + "'", baglanti); // sql komutu oluşturuyoruz
                cmd.ExecuteNonQuery();// Bu metod geriye int olarak update, insert, delete olaylarından etkilenen satır sayısı döndürüyor.
                listele("select * from Alicilar"); // Fonksiyonu çalıştırdık
                baglanti.Close();//baglantıyı kapadık
            }
        }
        public int secilenalan;//değişken tanımladık
        public string Alici_ID,AdSoyad,il,ilce,Mahalle,Sokak,Bina,GonderenAdSoyad;//değişken tanımladık
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) // datagirdview de kutucuuğa dokunduğunda yapılacaklar
        {
          
            secilenalan = dataGridView1.SelectedCells[0].RowIndex;// seçilen satırın row index değerini aldık
            Alici_ID = dataGridView1.Rows[secilenalan].Cells[0].Value.ToString(); // sutün sutün değerleri gerekli değişkene tanımladım
            AdSoyad = dataGridView1.Rows[secilenalan].Cells[1].Value.ToString();
            il = dataGridView1.Rows[secilenalan].Cells[2].Value.ToString();
            ilce = dataGridView1.Rows[secilenalan].Cells[3].Value.ToString();
            Mahalle = dataGridView1.Rows[secilenalan].Cells[4].Value.ToString();
            Sokak = dataGridView1.Rows[secilenalan].Cells[5].Value.ToString();
            Bina = dataGridView1.Rows[secilenalan].Cells[6].Value.ToString();
            GonderenAdSoyad = dataGridView1.Rows[secilenalan].Cells[7].Value.ToString();

            textBox1.Text = Alici_ID;// değişkenleri textbox ın text değerine atadım tıkladığımda değerler textboxtda gözükmesini sağladım
            textBox3.Text = AdSoyad;
            textBox4.Text = il;
            textBox5.Text = ilce;
            textBox6.Text = Mahalle;
            textBox7.Text = Sokak;
            textBox8.Text = Bina;
            textBox9.Text = GonderenAdSoyad;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "") errorProvider1.SetError(textBox2, "Boş geçilmez"); // textboxların boş olup olmadığını kontrol ediyoruz
            else errorProvider1.SetError(textBox2, "");
            if (textBox2.Text.Trim() != "")
            {
                baglanti.Open();// baglantıyı açtık
                SqlCommand cmd = new SqlCommand("Delete from Alicilar where Alici_ID=@Alici_ID", baglanti); // sql komutu oluşturuyoruz
                cmd.Parameters.AddWithValue("@Alici_ID", textBox2.Text);// parametreleri veritabanına ekliyoruz
                cmd.ExecuteNonQuery();// Bu metod geriye int olarak update, insert, delete olaylarından etkilenen satır sayısı döndürüyor.
                listele("Select * from Alicilar");// Fonksiyonu çalıştırdık
                baglanti.Close();//baglantıyı kapadık
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Trim() != "" && textBox5.Text.Trim() != "" && textBox6.Text.Trim() != "" && textBox7.Text.Trim() != "" && textBox8.Text.Trim() != "") // textboxların boş olup olmadığını kontrol ediyoruz
            {
              Form5 frm5 = new Form5();// yeni forma geçtik
                frm5.VeriYolla(Alici_ID);// form5 e veri yolladık
            frm5.Show();
            }
            else { MessageBox.Show("LÜTFEN FATURASINI GÖRMEK İSTEDİĞİNİZ MÜŞTERİYİ SEÇİNİZ!"); //ekrana uyarı verdirdik 
            }
            
           
        }
    }
}
