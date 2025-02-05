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
using Microsoft.Web.WebView2.WinForms;

namespace Film_Arsivim
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            colors.Add(Color.Red);
            colors.Add(Color.Blue);
            colors.Add(Color.Yellow);
            colors.Add(Color.Green);
            colors.Add(Color.Purple);
            colors.Add(Color.Orange);
            colors.Add(Color.Pink);
            colors.Add(Color.Brown);
            colors.Add(Color.Gray);
            colors.Add(Color.Black);
            colors.Add(Color.White);
            colors.Add(Color.Cyan);
            colors.Add(Color.Magenta);
            colors.Add(Color.DarkBlue);
            colors.Add(Color.DarkRed);
            colors.Add(Color.DarkGreen);
            colors.Add(Color.DarkGray);
            colors.Add(Color.DarkOrange);
            colors.Add(Color.DarkViolet);
            colors.Add(Color.DarkCyan);
            colors.Add(Color.DarkMagenta);
            colors.Add(Color.LightBlue);
            colors.Add(Color.LightGreen);
            colors.Add(Color.LightGray);
            colors.Add(Color.LightCyan);
            colors.Add(Color.LightPink);
            colors.Add(Color.LightYellow);
            colors.Add(Color.LightSalmon);
            colors.Add(Color.LightSeaGreen);
            colors.Add(Color.LightSkyBlue);
            colors.Add(Color.LightSlateGray);
        }
        List<Color> colors = new List<Color>();
        Random rnd = new Random();
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-4ROLKKOD;initial Catalog=FilmArsivim;integrated Security=True;");
        void Filmler()
        {
            SqlDataAdapter da = new SqlDataAdapter("Select AD,KATEGORI,LINK from TBLFILMLER", baglanti);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Filmler(); 
            web1.Dock = DockStyle.Fill;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLFILMLER (AD,KATEGORI,LINK) values (@ad,@kategori,@link) ", baglanti);
            komut.Parameters.AddWithValue("@ad", txtFilmAd.Text);
            komut.Parameters.AddWithValue("@kategori", txtKategori.Text);
            komut.Parameters.AddWithValue("@link", txtLink.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Film Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Filmler();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            string link = dataGridView1.Rows[secilen].Cells[2].Value.ToString();

         
            web1.Source = new Uri(link);

        }

        private void btnHakkımızda_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ben Talha Durmaz Bu Projeyi 04/02/2025 Tarihinde Yazptım", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtLink.Text = web1.Source.ToString();
        }

        private void btnRenkDegis_Click(object sender, EventArgs e)
        {
            int sıra = rnd.Next(0, colors.Count);
            this.BackColor = colors[sıra];
        }

        private void btnTamEkran_Click(object sender, EventArgs e)
        {
            Tam_Ekran tamEkran = new Tam_Ekran(web1.Source.ToString());
            tamEkran.Visible = true;
            web1.ExecuteScriptAsync("document.querySelector('video').pause();");
            this.Hide();
        }
    }
}
