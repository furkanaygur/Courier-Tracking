using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Gorsel_Programlama_Proje
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string id;
        public void VeriYolla(string Alici_ID) // yeni fonksiyon oluşturdum
        {
           id = Alici_ID; // Diğer formdan aldığım değeri id değişkenine tanımladım
        } 
        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'KuryeTakipDataSet.Alicilar' table. You can move, or remove it, as needed.
            label1.Text = id; // id değişkenindeki veriyi label1.Text e atadım
            this.AlicilarTableAdapter.Fill(this.KuryeTakipDataSet.Alicilar, Convert.ToInt16(label1.Text)); // reportviewer a verileri doldurduk
            this.reportViewer1.RefreshReport(); // reportvieweri yeniliyor
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

      
    }
}
