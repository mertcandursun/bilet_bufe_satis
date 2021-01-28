using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace bilet_bufe_satis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MaximizeBox = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        public void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            StreamReader oku;

            //oku = File.OpenText("C:\\Users\\Mert\\Desktop\\konser_bufe_satisv1\\konserler.txt");
            oku = File.OpenText(dosyaGozatDiyalog.FileName);


            string yazi;
            while ((yazi = oku.ReadLine()) != null)
            {
                listBox1.Items.Add((yazi.ToString()));
            }

            oku.Close();
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = dosyaGozatDiyalog.ShowDialog(); // Show the dialog.
            
            if (result == DialogResult.OK) // Test result.
            {
                string file = dosyaGozatDiyalog.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double gisekdv,kdvtut;
            byte vipticket = 100 , yakinticket = 75, ortaticket = 50, ekoticket = 25;
            int bilettut;

            musteriInfolbl.Text = $"Ad Soyad : {isimBox.Text} Telefon Numarası : {noBox.Text}";
            eventInfolbl.Text = $"Etkinlik:  {listBox1.SelectedItem}";
            if (vipBilet.Checked == true)
            {
                ticketInfolbl.Text = $"Bilet türü : Vip Bilet (Loca) Bilet Adedi : {biletAdedi.Text}";
                giseTutarlbl.Text = vipticket.ToString();
                gisekdv = vipticket * 1.18;
                giseKdvlbl.Text = gisekdv.ToString();
                bilettut =+ vipticket;
                toplamtut += bilettut;
                topLbl.Text = toplamtut.ToString();
                kdvtut =+ gisekdv;
                toplamKdv += kdvtut;
                kdvToplbl.Text = toplamKdv.ToString();
            }
            else if (yakinBilet.Checked == true)
            {
                ticketInfolbl.Text = $"Bilet türü : Ön sıra // Bilet Adedi : {biletAdedi.Text}";
                giseTutarlbl.Text = yakinticket.ToString();
                gisekdv = yakinticket * 1.18;
                giseKdvlbl.Text = gisekdv.ToString();
                bilettut =+ yakinticket;
                toplamtut += bilettut;
                topLbl.Text = toplamtut.ToString();
                
            }
            else if (ortaBilet.Checked == true)
            {
                ticketInfolbl.Text = $"Bilet türü : Orta sıra // Bilet Adedi : {biletAdedi.Text}";
                giseTutarlbl.Text = ortaticket.ToString();
                gisekdv = ortaticket * 1.18;
                giseKdvlbl.Text = gisekdv.ToString();
                bilettut =+ ortaticket;
                toplamtut += bilettut;
                topLbl.Text = toplamtut.ToString();
            }
            else if (ekoBilet.Checked == true)
            {
                ticketInfolbl.Text = $"Bilet türü : Ekonomik/Öğrenci // Bilet Adedi : {biletAdedi.Text}";
                giseTutarlbl.Text = ekoticket.ToString();
                gisekdv = ekoticket * 1.18;
                giseKdvlbl.Text = gisekdv.ToString();
                bilettut =+ ekoticket;
                toplamtut += bilettut;
                topLbl.Text = toplamtut.ToString();
            }

            


        }

        private void vipBilet_CheckedChanged(object sender, EventArgs e)
        {
            if (vipBilet.Checked == true)
            {
                yakinBilet.Enabled = false;
                ortaBilet.Enabled = false;
                ekoBilet.Enabled = false;
            }
            else
            {
                yakinBilet.Enabled = true;
                ortaBilet.Enabled = true;
                ekoBilet.Enabled = true;
            }
        }

        private void yakinBilet_CheckedChanged(object sender, EventArgs e)
        {
            if (yakinBilet.Checked == true)
            {
                vipBilet.Enabled = false;
                ortaBilet.Enabled = false;
                ekoBilet.Enabled = false;
            }
            else
            {
                vipBilet.Enabled = true;
                ortaBilet.Enabled = true;
                ekoBilet.Enabled = true;
            }
        }

        private void ortaBilet_CheckedChanged(object sender, EventArgs e)
        {
            if (ortaBilet.Checked == true)
            {
                yakinBilet.Enabled = false;
                vipBilet.Enabled = false;
                ekoBilet.Enabled = false;
            }
            else
            {
                yakinBilet.Enabled = true;
                vipBilet.Enabled = true;
                ekoBilet.Enabled = true;
            }
        }

        private void ekoBilet_CheckedChanged(object sender, EventArgs e)
        {
            if (ekoBilet.Checked == true)
            {
                yakinBilet.Enabled = false;
                ortaBilet.Enabled = false;
                vipBilet.Enabled = false;
            }
            else
            {
                yakinBilet.Enabled = true;
                ortaBilet.Enabled = true;
                vipBilet.Enabled = true;
            }
        }
        Font baslik = new Font("Arial",12,FontStyle.Bold);
        Font yazi = new Font("Comic Sans MS",10);
        SolidBrush firca = new SolidBrush(Color.Black);
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            biletOnizleme.ShowDialog();

            topLbl.Text = " ";
            kdvToplbl.Text = " ";
        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void biletYazdir_PrintPage(object sender, PrintPageEventArgs e)
        {
            StringFormat sFormat = new StringFormat();
            sFormat.Alignment = StringAlignment.Near;
            e.Graphics.DrawString("Bilet Dökümü",baslik,firca,200,150);
            e.Graphics.DrawString(musteriInfolbl.Text,yazi,firca,175,200);
            e.Graphics.DrawString(eventInfolbl.Text,yazi,firca,175,250);
            e.Graphics.DrawString(ticketInfolbl.Text,yazi,firca,175,300);
            e.Graphics.DrawString($"Toplam tutar : {kdvToplbl.Text} ₺ ",yazi,firca,175,350);

            musteriInfolbl.Text = "Adı Soyadı : ";
            eventInfolbl.Text = "Etkinlik : ";
            ticketInfolbl.Text = "Bilet türü : ";
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            suBox.Clear();
            sogukBox.Clear();
            kolaBox.Clear();
            sodaBox.Clear();
            sandBox.Clear();
            hambBox.Clear();
            tostBox.Clear();
            patsoBox.Clear();
            simitBox.Clear();
            nescBox.Clear();
            churcBox.Clear();

            bufeTutarlbl.Text = " ";
            bufeKdvlbl.Text = " ";
        }

        public double toplamKdv = 0;
        public int toplamtut = 0;

        private void button1_Click(object sender, EventArgs e)
        {
            int bufetutar;
            bufetutar = Convert.ToInt32(suBox.Text) * 1;
            bufetutar = bufetutar + Convert.ToInt32(kolaBox.Text) * 3;
            bufetutar = bufetutar + Convert.ToInt32(sogukBox.Text) * 3;
            bufetutar = bufetutar + Convert.ToInt32(sodaBox.Text) * 2;
            bufetutar = bufetutar + Convert.ToInt32(sandBox.Text) * 3;
            bufetutar = bufetutar + Convert.ToInt32(hambBox.Text) * 5;
            bufetutar = bufetutar + Convert.ToInt32(tostBox.Text) * 4;
            bufetutar = bufetutar + Convert.ToInt32(patsoBox.Text) * 3;
            bufetutar = bufetutar + Convert.ToInt32(simitBox.Text) * 2;
            bufetutar = bufetutar + Convert.ToInt32(nescBox.Text) * 3;
            bufetutar = bufetutar + Convert.ToInt32(churcBox.Text) * 3;

            double bufekdv;
            bufekdv = bufetutar * 1.08;

            bufeTutarlbl.Text = Convert.ToString(bufetutar);
            bufeKdvlbl.Text = Convert.ToString(bufekdv);

            toplamtut =+ bufetutar;
            topLbl.Text = toplamtut.ToString();

            toplamKdv =+ bufekdv;
            kdvToplbl.Text = toplamKdv.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Lütfen 'göz at' butonu ile konser listesinin bulunduğu 'txt' dosyasını seçin ve ardından 'güncelle' butonuna basınız.");
            MessageBox.Show("Bilgisayarınızda konser listesi bulunan bir txt dosyası bulunmuyorsa oluşturunuz.");
        }

        public void button8_Click(object sender, EventArgs e)
        {
            vipBilet.CheckState = CheckState.Unchecked;
            yakinBilet.CheckState = CheckState.Unchecked;
            ortaBilet.CheckState = CheckState.Unchecked;
            ekoBilet.CheckState = CheckState.Unchecked;

            isimBox.Clear();
            noBox.Clear();
            biletAdedi.Text = 1.ToString();

            musteriInfolbl.Text = "Adı Soyadı : ";
            eventInfolbl.Text = "Etkinlik : ";
            ticketInfolbl.Text = "Bilet türü : ";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            giseTutarlbl.Text = " ";
            giseKdvlbl.Text = " ";
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            kdvToplbl.Text = " ";
            topLbl.Text = " ";
            toplamKdv = 0;
            toplamtut = 0;

        }
    }
}
