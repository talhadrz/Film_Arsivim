using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace Film_Arsivim
{
    public partial class Tam_Ekran : Form
    {       
        WebView2 web = new WebView2();
        public Tam_Ekran(string url)
        {
            InitializeComponent();
            web.Source = new Uri(url);
        }
        private void Tam_Ekran_Load(object sender, EventArgs e)
        {
            web.Dock = DockStyle.Fill;
            this.Controls.Add(web);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            frm.web1.Source = web.Source;
            this.Close();
        }
    }
}
