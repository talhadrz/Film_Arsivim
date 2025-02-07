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
using NAudio.CoreAudioApi;
using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.WinForms;
using NAudio.CoreAudioApi.Interfaces;
namespace Film_Arsivim
{
    public partial class FAVORİLERİM : Form
    {
        public FAVORİLERİM()
        {
            InitializeComponent();
        }
        SqlCommand komut = new SqlCommand();
        List<int> ID = new List<int>();
        List<string> LINK = new List<string>();
        List<Color> colors = new List<Color>();
        Random rnd = new Random();
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-4ROLKKOD;initial Catalog=FilmArsivim;integrated Security=True;");
     

        void Filmler()
        {
            // Veri tabanındaki film ad, kategori ve ıd sini tablo olarak çeker
            IdDuzelt();
            IdLınk();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,AD,KATEGORI from TBLFILMLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        void IdLınk()
        {
            // Veri tabanındaki ıd ve link'ini ıd ve link listelerine ekledi
            baglanti.Open();
            komut.CommandText = "select ID,LINK from TBLFILMLER";
            SqlDataReader dr = komut.ExecuteReader();
            ID.Clear();
            LINK.Clear();
            while (dr.Read())
            {
                ID.Add(int.Parse(dr[0].ToString()));
                LINK.Add(dr[1].ToString());
            }
            baglanti.Close();
        }
        void IdDuzelt()
        {
            // Veri tabanındaki id'leri birden son sayıya kadar sıralamasını düzeltir
            baglanti.Open();
            komut.CommandText = "ALTER TABLE TBLFILMLER DROP COLUMN ID";
            komut.ExecuteNonQuery();
            komut.CommandText = "ALTER TABLE TBLFILMLER ADD ID INT IDENTITY(1,1)";
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            komut.Connection = baglanti;
            Filmler();
            renkEkle();
            SesCubuguAyarla();
            web1.Source = new Uri("https://www.youtube.com/");
        }

        private void SesCubuguAyarla()
        {
            // Bilgisayarın ses seviyesini ses çubuğuna atar
            int ses = Ses.Value;
            var sesi = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            Ses.Value = (int)(sesi.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
        }

        private void renkEkle()
        {
            // Tüm renkleri colors listesine ekler
            foreach (var renk in Enum.GetValues(typeof(KnownColor)))
            {
                Color color = Color.FromKnownColor((KnownColor)renk);
                colors.Add(color);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            // veri tabanına yeni bir video adı kategorisi ve url'si ni ekler
            baglanti.Open();
            komut.CommandText = "insert into TBLFILMLER (AD,KATEGORI,LINK) values (@ad,@kategori,@link) ";
            komut.Parameters.AddWithValue("@ad", txtFilmAd.Text);
            komut.Parameters.AddWithValue("@kategori", txtKategori.Text);
            komut.Parameters.AddWithValue("@link", txtLink.Text);
            try
            {
                komut.ExecuteNonQuery();
                MessageBox.Show("Film Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Film Eklenmedi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            baglanti.Close();
            Filmler();
            txtFilmAd.Text = null;
            txtKategori.Text = null;
            txtLink.Text = null;
        }

        private async void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Seçilen videonun url'si ne ulaşıp video'yu web aracında açar
            try
            {
                int secilen = dataGridView1.SelectedCells[0].RowIndex;
                int id = int.Parse(dataGridView1.Rows[secilen].Cells[0].Value.ToString());

                for (int i = 0; i < ID.Count; i++)
                {
                    if (ID[i] == id)
                    {
                        web1.Source = new Uri(LINK[i]);
                        break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Bu video url'si ne ulaşılamadı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ben Talha Durmaz Bu Projeyi 04/02/2025 Tarihinde Yazptım", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRenkDegis_Click(object sender, EventArgs e)
        {
            // Burda renkleri 
            int sıra = rnd.Next(0, colors.Count);
            this.BackColor = colors[sıra];
        }

        private async void btnTamEkran_Click(object sender, EventArgs e)
        {
            // Tam ekran için video'yu ikinci form'a yansıtıp form'lar arası geçiş yapar
            Tam_Ekran frmTamEk = new Tam_Ekran();
            frmTamEk.web2.Source = web1.Source;
            frmTamEk.Show();
            await Task.Delay(1000);
            videOynat(frmTamEk.web2);
            videDur(web1);
            this.Hide();
        }


        void videDur(WebView2 web)
        {
            // web aracındaki oynatmayı durdurur
            web.ExecuteScriptAsync("document.querySelector('video').pause();");
        }
        void videOynat(WebView2 web)
        {
            // web aracındaki oynatmayı oynatır
            web.ExecuteScriptAsync("document.querySelector('video').play();");
        }
        void İleriGeri(char krt)
        {
            // Veri tabanındaki video'lar arasında ileri geri gezinti yapmamızı sağlar
            string link = web1.Source.ToString();
            for (int i = 0; i < LINK.Count; i++)
            {
                if (LINK[i] == link)
                {
                    web1.Source = new Uri(LINK[krt == '+' ? (i < (LINK.Count - 1) ? i + 1 : 0) : (i > 0 ? i - 1 : (LINK.Count - 1))]);
                    break;
                }
                else
                    MessageBox.Show("Bu Url veri tabanında bulunamadı!", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            İleriGeri('-');
        }

        private void btnİleri_Click(object sender, EventArgs e)
        {
            İleriGeri('+');
        }

        private void btnPlayStop_Click(object sender, EventArgs e)
        {
            // web aracındaki video oynatımınu durdurup devam ettirir
            if (btnPlayStop.Text == "Play")
            {
                btnPlayStop.Text = "Stop";
                videOynat(web1);
            }
            else
            {
                btnPlayStop.Text = "Play";
                videDur(web1);
            }
        }

        private void btnSes_Click(object sender, EventArgs e)
        {
            // web aracının ses kaynağını açar kapatır
            if (btnSes.Text == "Ses Aç")
            {
                btnSes.Text = "Ses Kapat";
                web1.ExecuteScriptAsync("document.querySelector('video').muted = false;");
            }
            else
            {
                btnSes.Text = "Ses Aç";
                web1.ExecuteScriptAsync("document.querySelector('video').muted = true;");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ad kısmına yazılan id'ye sahip olan satırı siler
            int id = int.Parse(txtFilmAd.Text);
            baglanti.Open();
            komut.CommandText = "delete from TBLFILMLER where ID=@id";
            komut.Parameters.AddWithValue("@id", id);
            try
            {
                komut.ExecuteNonQuery();
                MessageBox.Show("Film Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Film Silinmedi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            baglanti.Close();
            Filmler();
            txtFilmAd.Text = null;
        }

        private async void btnLinkGetir_Click(object sender, EventArgs e)
        {
            // Sayfanın Linkini Getirir
            txtLink.Text = web1.Source.ToString();
            // Sayfadaki Videonun Adını Alma
            string FilmAd = (await web1.ExecuteScriptAsync("document.title")).Trim('"');
            FilmAd = System.Text.RegularExpressions.Regex.Replace(FilmAd, @"^\(\d+\)\s*", "").Replace(" - YouTube", "");
            txtFilmAd.Text = FilmAd;
        }

        private void Ses_Scroll(object sender, ScrollEventArgs e)
        {
            // Ses çubuğunda değişiklik olunca çubuktaki değeri bilgisayarın ses seviyesine uygular
            var sesi = new MMDeviceEnumerator().GetDefaultAudioEndpoint(DataFlow.Render, Role.Multimedia);
            int ses = Ses.Value;
            sesi.AudioEndpointVolume.MasterVolumeLevelScalar = ses / 100f;
        }
    }
}
