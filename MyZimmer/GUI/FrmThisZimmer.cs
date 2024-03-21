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
    
    public partial class FrmThisZimmer : Form
    {
        zimmer z;
        tenant t;
        rentZimmer rz;
        List<string> lst;
        List<string> lst1;
        int sum = 0;
        int cnt = 0;
        int cnt1 = 0;
        double avg ;
        bool flag;
        bool flag1=true;
        bool flag2=true;
        int num1, num2,num3,num4;
        bool flag3 = true;
        public FrmThisZimmer(zimmer z1, tenant t1)
        {
            InitializeComponent();
            z = z1;
            t = t1;
            num1 = 0;
            num2 = 0;
            num3 = 0;
            rz = new rentZimmer();
            flag = true;
            lst = new List<string>();
            lst1 = new List<string>();
            foreach (var item in MyDB.pictureZimmer.GetList())
            {
                
                if (item.codeZimmer == z1.codeZimmer)
                {
                    flowLayoutPanel1.BackgroundImage = null; 
                    UCPicture f = new UCPicture(item);
                    flowLayoutPanel1.Controls.Add(f);
                }

            }
            label1.Text = z.nameZimmer;
            label9.Text +=" "+ z.ThisCity.ThisArea.nameArea;
            label10.Text +=" "+ z.ThisCity.nameCity;
            label11.Text +=" "+ z.streetZimmer + " " + z.numberOfHouseZimmer;
            label12.Text +=" "+ z.numberOfBedZimmer.ToString();
            label13.Text +=" "+ z.priceNightZimmer.ToString()+"ש'ח";
            listBox1.Items.Clear();
            listBox1.Visible = false;
            label8.Visible = false;
            label7.Text += " " + z.ThisRenting.TelRenting.ToString();
            foreach (var item in MyDB.includeMyZimmer.GetList().Where(x=>x.codeZimmer==z.codeZimmer).Select(x=>x.ThisIncludeIn.descriptionInclude))
            {
                lst.Add(item);
                flag1 = false;
            }
            if(flag1==false)
            {
                foreach (var item in lst)
                {
                    label14.Text += item + ",";
                }
            }
            else
            {
                label14.Visible = false;
            }
            
            foreach (var item in MyDB.zimmerService.GetList().Where(x=>x.codeZimmer==z.codeZimmer).Select(x=>x.ThisService.nameService))
            {
                lst1.Add(item);
                flag2 = false;
            }
            if(flag2==false)
            {
                foreach (var item in lst1)
                {
                    label16.Text += item + ",";
                }
            }
            else
            {
                label16.Visible = false;
            }
            foreach (var item in MyDB.comment.GetList().Where(x=>x.codeZimmer==z.codeZimmer).Select(x=>x.ratingComment))
            {
                sum += Convert.ToInt32(item);
                cnt++;
            }
            if(sum==0)
            {
                label3.Text = "לא דורג עדיין";
            }
            else
            {
                avg = (double)sum / cnt;
                label3.Text = (avg).ToString() + " " + "כוכבים";
            }
            
        }
        
        public void FillOrder()
        {
            rz.codeRentZimmer=  MyDB.rentZimmer.GetList().OrderBy(x => x.codeRentZimmer).Last().codeRentZimmer + 1;
            rz.codeTenant = t.codeTenant;
            rz.codeZimmer = z.codeZimmer;
            rz.dateFrom = dateTimePicker1.Value;
            rz.dateTo = dateTimePicker2.Value;
            num1 = Convert.ToInt32(dateTimePicker1.Value.DayOfYear);
            num2 = Convert.ToInt32(dateTimePicker2.Value.DayOfYear);
            num3 = z.priceNightZimmer;
            num4 = Convert.ToInt32(textBox1.Text);
            rz.totalPrice = (num3 * (num2 - num1))*num4;
            rz.debtPrice= (num3 * (num2 - num1))*num4;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.IsNumberChar(e.KeyChar);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flag3 = true;
            errorProvider1.Clear();
            if (textBox1.Text == "")
            {
                MessageBox.Show("לא הזנת מספר נופשים אנא הזן ");
            }
            else
            {
                if (!Validation.IsNum(textBox1.Text))
                { errorProvider1.SetError(textBox1, "מספר הנופשים אינו תקין"); flag3 = false; }
                if (flag3)
                {
                    if (dateTimePicker1.Value == DateTime.Now || dateTimePicker2.Value == DateTime.Now)
                    {
                        MessageBox.Show("לא הזנת תאריך לצימר, אנא הזן על מנת שנוכל להזמין עבורך את הצימר ");
                    }
                    if (dateTimePicker2.Value < dateTimePicker1.Value)
                    {
                        MessageBox.Show("התאריך שהזנת אינו הגיוני, אנא הזן מחדש ");
                    }
                    else
                    {
                        foreach (var item1 in MyDB.rentZimmer.GetList().Where(x => x.codeZimmer == z.codeZimmer))
                        {
                            if (item1.dateFrom >= dateTimePicker1.Value && item1.dateTo <= dateTimePicker2.Value)
                            {
                                flag = false;
                            }
                        }
                        if (flag == true)
                        {
                            FillOrder();
                            MyDB.rentZimmer.AddItem(rz);
                            MyDB.rentZimmer.SaveChanges();
                            MessageBox.Show("הזמנתך נקלטה הנך מעובר לדף תשלומים!");
                            FrmPayment fep = new FrmPayment(rz, t);
                            fep.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("התאריך שהזנת אינו זמין בצימר זה אנא בחר תאריך אחר ");
                        }
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in MyDB.comment.GetList().Where(x => x.codeZimmer == z.codeZimmer))
            {
                listBox1.Items.Add(item.noteComment);
                listBox1.Items.Add(item.dateOfComment);
                cnt1++;
            }
            if (cnt==0)
            {
                label8.Visible = true;
            }
            else
            {
                listBox1.Visible = true;
            }
            
        }
    }
}
