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
    public partial class UCZimmer : UserControl
    {
        zimmer z;
        tenant t;
        int sum=0;
        int cnt=0;
        public UCZimmer(zimmer z1,tenant t1)
        {
            InitializeComponent();
            z = z1;
            t = t1;
            foreach (var item in MyDB.pictureZimmer.GetList())
            {
                if(item.codeZimmer==z.codeZimmer)
                {
                    UCPicture f = new UCPicture(item);
                    flowLayoutPanel1.Controls.Add(f);
                }  
            }
            labelName.Text = z.nameZimmer;
            label2.Text +=" "+ z.ThisCity.nameCity;
            label3.Text +=" "+ z.numberOfBedZimmer.ToString();
            label4.Text +=" "+ z.priceNightZimmer.ToString();
            foreach (var item in MyDB.comment.GetList().Where(x=>x.codeZimmer==z.codeZimmer).Select(x=>x.ratingComment))
            {
                sum += Convert.ToInt32(item);
                cnt++;
            }
            if(sum==0)
            {
                label5.Text="עדיין לא דורג";
            }
            else
            {
                label5.Text += " " + (double)sum / cnt + " " + "כוכבים";
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmThisZimmer ftz = new FrmThisZimmer(z,t);
            ftz.Show();
            
           
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
