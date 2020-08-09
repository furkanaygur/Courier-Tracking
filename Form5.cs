using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using System.IO;
using AForge; // telefon kamerasını programda göstermek için gerekli kütüphaneler 
using AForge.Video; //-- 
using AForge.Video.DirectShow;//-- 
using MessagingToolkit.QRCode.Codec.Data;//qr kod oluşturmak için gerekli kütüphane
using ZXing;//telefon kamerası ile qrcode u okutmak için gerekli olan kütüphaneler
using ZXing.Aztec; //--
using ZXing.QrCode; //--

namespace Gorsel_Programlama_Proje
{
    public partial class Form5 : Form
    {
        FilterInfoCollection  webcam; // bilgisayara kaç kamera bağlıysa onları tutan bir dizi.
        VideoCaptureDevice cam; // kamerayı tanımladık
        
        public Form5()
        {
            InitializeComponent();
        }
        QRCodeEncoder qrkod = new QRCodeEncoder(); // qrcode oluşturmak için değişken atadık
        Image resim; // qrcode u picturebox a atadığımız için resim değişkeni tanımladık

      
        private void Form5_Load(object sender, EventArgs e)
        {
            resim = qrkod.Encode("qrcode"); // qrcode oluşturduk
            pictureBox2.Image = resim; // qrcode u picturbox da görüntüledik

            webcam = new FilterInfoCollection(FilterCategory.VideoInputDevice); // bilgisayara bağlı olan kameraları filtereledik
            foreach (FilterInfo dev in webcam)
            {
                comboBox1.Items.Add(dev.Name); // bulduğu kameraları comboxa atadık

            }
            comboBox1.SelectedIndex = 0; // seçilen indexi 0 olarak tanımladık

            cam = new VideoCaptureDevice(webcam[comboBox1.SelectedIndex].MonikerString); // comboboxda seçilen kamerayı tanımladık
            cam.NewFrame += new NewFrameEventHandler(cam_NewCam); // Frame Frame atadık
            cam.Start(); // kamerayı başlattık.
        }
        private void cam_NewCam(object sender,NewFrameEventArgs eventArgs)
        {
            pictureBox1.Image = ((Bitmap)eventArgs.Frame.Clone()); // kamera görüntüsünü picturbox da gösteriyoruz
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
           BarcodeReader barkod = new BarcodeReader(); // qrcode okumak için okuyucu tanımladık
            if (pictureBox1.Image != null) // picturbox ın boş olup olmadığını kontrol ettik
            {
                Result res = barkod.Decode((Bitmap)pictureBox1.Image); // çözümlenen qr kodun sonucunu aldık
              
                try
                {
                    string dec = res.ToString().Trim(); // çözümlenen değeri string değere atadık
                  if (dec !="") // değerin boş olup olmadığını kontrol ettik
                        {
                        timer1.Stop(); // timeri durdurduk
                    
                       Form3 frm3 = new Form3(); // yeni form a geçttik
                        frm3.VeriYolla(id); // bu formda olan veriyi diğer forma aktardık
                        frm3.Show();
                        this.Hide();
                        
                    }
               
                }
                catch (Exception ex)
                {

                  
                }
                
             
            }   
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cam != null) // boş olup olmadığını kontrol ettik
            {
                if (cam.IsRunning==true) // kamera çalışıyor mu onu kontrol ettik
                {
                    cam.Stop(); // kamerayı durdurduk
                }
            }
        }
        string id; // id adında string değişkeni oluşturduk
        public void VeriYolla(string Alici_ID) // veriyolla adında fonksiyon oluşturduk
        {
            id = Alici_ID; // alici id değerini id ye atadım
        } 
    
        private void button1_Click_1(object sender, EventArgs e)
        {
            timer1.Enabled=true; // timer kullanabilirliğini true yaptık
            timer1.Start(); // timeri çalıştırdık
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

    }
}
