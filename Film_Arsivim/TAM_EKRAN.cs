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
        public Tam_Ekran()
        {
            InitializeComponent();
        }
        private void Tam_Ekran_Load(object sender, EventArgs e)
        {
            this.Controls.Add(web2);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            FAVORİLERİM frm = new FAVORİLERİM();
            frm.Show();
            frm.web1.Source = web2.Source;
            this.Close();
        }
    }
}
