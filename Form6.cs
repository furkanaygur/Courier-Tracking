using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Gorsel_Programlama_Proje
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        public StringBuilder add = new StringBuilder("http://www.google.com/maps?q=");  // stringbuilder metinsel ifadeleri birleştirmek için kullanılan bir sınıftır.

        public void VeriYolla(string il, string ilce, string Mahalle, string Sokak) // diğer formdan gelen verileri almak için fonksiyon oluşturduk
        {
            label1.Text = il; // labelin textine gelen değerleri atadım
            label1.Text += " ";
            label1.Text += ilce;
            label1.Text += " ";
            label1.Text += Mahalle;
            label1.Text += " ";
            label1.Text += Sokak;

        } 
        private void Form6_Load(object sender, EventArgs e)
        {
          
            add.Append(label1.Text); // label1 textin de ki değerleri ekledim
            webBrowser1.Navigate(add.ToString()); // web browserea değerleri ekleyip çalıştırdım

        }
    }
}
