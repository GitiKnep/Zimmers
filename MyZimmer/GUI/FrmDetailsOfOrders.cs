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
    public partial class FrmDetailsOfOrders : Form
    {
        rentZimmer rz;
        tenant t;
        int num = 0;
        public FrmDetailsOfOrders(int i1,tenant t1)
        {
            InitializeComponent();
            rz = MyDB.rentZimmer.GetList().FirstOrDefault(x => x.codeRentZimmer == i1);
            t = t1;
            label3.Text +=" "+ rz.ThisZimmer.nameZimmer;
            label2.Text +=" "+ rz.ThisZimmer.ThisRenting.fNameRenting + " " + rz.ThisZimmer.ThisRenting.lNameRenting;
            label4.Text +=" "+ rz.dateFrom.ToShortDateString().ToString();
            label5.Text +=" "+ rz.dateTo.ToShortDateString().ToString();
            label6.Text +=" "+ rz.totalPrice.ToString();
            label14.Text = rz.debtPrice.ToString();
           
            if(Convert.ToInt32(label14.Text)<1)
            {
                button1.Enabled = false;
            }
            if(rz.dateTo<DateTime.Now)
            {
                button3.Enabled = false;
            }
            if(rz.dateFrom>DateTime.Now)
            {
                button2.Enabled = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmPayment fp = new FrmPayment(rz,t);
            fp.Show();
            this.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmAddComment fac = new FrmAddComment(rz);
            fac.Show ();
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmTenant fta = new FrmTenant(t);
            fta.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in MyDB.zimmerService.GetList())
            {
                if(item.codeZimmer==rz.codeZimmer)
                {
                    num++;
                }
            }
            if(num>0)
            {
                FrmServiceOrder frso = new FrmServiceOrder(rz,t);
                frso.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("אין שירותים זמינים בצימר זה");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(rz.dateTo<DateTime.Now||(rz.dateFrom<DateTime.Now&&rz.dateTo>DateTime.Now)||(Convert.ToInt32(DateTime.Now.Day-rz.dateFrom.Day)<=7))
            {
                MessageBox.Show("לא ניתן לבטל הזמנת צימר בזמן/אחרי/שבוע לפני- החופשה");
            }
            else
            {
                DialogResult r = MessageBox.Show("האם אתה בטוח שברצונך לבטל את הזמנת הצימר? במקרה של ביטול ינוקו מן ההחזר הכספי 5% על עוגמת נפש", "ביטול הזמנה", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    MyDB.rentZimmer.DeleteItem(rz);
                    MyDB.rentZimmer.SaveChanges();
                    MessageBox.Show("ההזמנה בוטלה בהצלחה");
                    FrmTenant frt = new FrmTenant(t);
                    frt.ShowDialog();
                    this.Close();
                }
            }
            
        }
    }
}
