using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;  // baglanti için gerekli kütüphaneler 
using System.Data.SqlClient; // ----

namespace Gorsel_Programlama_Proje
{
    public partial class Form2 : Form
    {
       
        
        
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-GLI2B5L\SQLEXPRESS;Initial Catalog=KuryeTakip;Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            listele(" Select * from kuryeler");
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ReadOnly = true;
           
        }
        public void listele(string veriler)
        {
            SqlDataAdapter da = new SqlDataAdapter(veriler, baglanti); // Select sorgusu ile verileri DataSet ya da DataTable' a doldurmak için baglantı yaptık
            DataSet ds = new DataSet(); // data set oluşturduk
            da.Fill(ds); // dataSeti doldurduk
            dataGridView1.DataSource = ds.Tables[0];//veri tabanında ki kayıtları datagridview de gösteriyoruz

        }

        private void btnKurye_Click(object sender, EventArgs e)
        {
            Form4 frm4 = new Form4(); // diğer forma geçiyoruz
            frm4.Show();
            this.Hide();
        }

     

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 frm8 = new Form8();// diğer forma geçiyoruz
            frm8.Show();
            
        }

   
       
    }
}
