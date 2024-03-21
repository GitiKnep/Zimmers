using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyZimmer.BLL;

namespace MyZimmer.GUI
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }
       

        private void btnTenant_Click(object sender, EventArgs e)
        {
            FrmEnteranceTenant fe = new FrmEnteranceTenant();
            fe.Show();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnRenting_Click(object sender, EventArgs e)
        {
            FrmEnteranceRenting fer = new FrmEnteranceRenting();
            fer.Show();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            FrmAbout frab = new FrmAbout();
            frab.Show();
        }
    }
}
