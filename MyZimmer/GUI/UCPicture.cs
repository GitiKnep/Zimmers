using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MyZimmer.BLL;

namespace MyZimmer.GUI
{
    public partial class UCPicture : UserControl
    {
        public UCPicture(pictureZimmer picture)
        {
            InitializeComponent();
            string a = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string b = Directory.GetParent(a).ToString();
            pictureBox1.Image = Image.FromFile(b + @"\Resources\" + picture.myPicture);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }
    }
}
