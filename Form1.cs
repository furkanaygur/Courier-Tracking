using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Recognition; // Konuşmayı, Sesi kullanmak tanımak için gerekli kütüphaneler
using System.Speech.Synthesis;   // ---

namespace Gorsel_Programlama_Proje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SpeechRecognitionEngine motor = new SpeechRecognitionEngine(); // Erişim ve işlem içi konuşma tanıma yönetmek için araçlar sağlar.
        bool izin = true; // bool sadece true ve false olur 1 kere merhaba komudu algılamak için kullandım
        private void groupBox1_Enter(object sender, EventArgs e)
        {
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false; // picturebox ı görünümü kapattım
            ses_ayar();// fonksiyonu çalıştır
            motor.RecognizeAsync(RecognizeMode.Multiple); // Bir veya daha fazla uyumsuz konuşma tanıma işlemini gerçekleştirir.
        }

        void ses_ayar()
        {
            
            Choices secenek = new Choices(); // secenek adında Choices değişkeni oluşturdum
            secenek.Add(new string[] { "Merhaba","deneme"}); // secenek e dizi halinde string veriler ekledim 
            Grammar grammer = new Grammar(new GrammarBuilder(secenek)); // secenekleri dil bilgisi ögesi olarak ekledim
            try
            {
             motor.LoadGrammar(grammer); // dil bilgisi ögelerini yükledi
             motor.SetInputToDefaultAudioDevice(); // Birincil mikrofonu seçer
             motor.SpeechRecognized += ses_tanima; // sesi yazıya döndürür
            
            }
            catch 
            {
                
                return;
            }
           
        }

        void ses_tanima(object sender, SpeechRecognizedEventArgs e) // ses tanıma diye fonksiyon oluşturduk
        {
            if (izin == true) 
            { 
            if (e.Result.Text!="Merhaba") // merhaba dışında bir şey söylenirse hata veriyor
            {
                MessageBox.Show("Yanlış Komut Tekrar Deneyiniz!");
            }
            else {  
                Form2 frm2 = new Form2(); // form2 ye geçiyor
                frm2.Show();
                this.Hide();
                izin = false;
            }
               
            }
        }

    }
}
