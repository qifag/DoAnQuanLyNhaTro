using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaTro
{
    public partial class frmLoading : Form
    {
        public frmLoading()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 10;
                lblPercent.Text = "Loading " + progressBar1.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                this.Hide();
                frmTrangChu tc = new frmTrangChu();
                tc.ShowDialog();
            }
        }

        private void formLoading_Load(object sender, EventArgs e)
        {
            pbxLogo.Load(@"Resources\THlogo.png"); //load logo vào pictureboxLogo
            this.BackgroundImage = Image.FromFile(@"Resources\home1.jpg"); //load hình back ground vào form
            timer1.Start();
        }
    }
}
