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
    public partial class FrmServiceOrder : Form
    {
        rentZimmer rz;
        serviceOrder so;
        tenant t;
        bool flag = true;
        bool flag1 = true;
        int price = 0;   
        public FrmServiceOrder(rentZimmer rz1,tenant t1)
        {
            InitializeComponent();
            rz = rz1;
            t = t1;
            so = new serviceOrder();
            label17.Visible = false;
            numericUpDown1.Visible = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;
            radioButton6.Enabled = false;
            foreach (var item1 in MyDB.zimmerService.GetList().Where(x => x.codeZimmer == rz.codeZimmer))
            {
               foreach (RadioButton item in groupBox1.Controls)
               {
                    if (item.Text == item1.ThisService.nameService)
                    {
                        item.Enabled = true;
                    }
               }
            }
            

        }
        public void Cheack1()
        {
            if (Convert.ToInt32(dateTimePicker2.Value.Hour) > 10 || Convert.ToInt32(dateTimePicker2.Value.Hour) <8)
            {
                flag = false;
            }
        }
        public void Cheack2()
        {
            if (Convert.ToInt32(dateTimePicker2.Value.Hour) > 16 || Convert.ToInt32(dateTimePicker2.Value.Hour) < 12)
            {
                flag = false;
            }
        }
        public void Cheack3()
        {
            if (Convert.ToInt32(dateTimePicker2.Value.Hour) > 21 || Convert.ToInt32(dateTimePicker2.Value.Hour) <19)
            {
                flag = false;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label17.Visible = true;
            numericUpDown1.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label17.Visible = true;
            numericUpDown1.Visible = true;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label17.Visible = true;
            numericUpDown1.Visible = true;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label17.Visible = false;
            numericUpDown1.Visible = false;
            numericUpDown1.Value = 1;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            label17.Visible = false;
            numericUpDown1.Visible = false;
            numericUpDown1.Value = 1;     
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            label17.Visible = false;
            numericUpDown1.Visible = false;
            numericUpDown1.Value = 1;
        }
        public void FillService()
        {            
            foreach (RadioButton item in groupBox1.Controls)
            {
                if(item.Checked==true)
                {
                    so.codeServiceOrder= MyDB.serviceOrder.GetList().OrderBy(x => x.codeServiceOrder).Last().codeServiceOrder + 1;
                    so.codeRentZimmer = rz.codeRentZimmer;
                    so.codeService = MyDB.service.GetList().FirstOrDefault(x => x.nameService == item.Text).codeService;
                    so.dateOrder = dateTimePicker1.Value.Date;
                    so.hourOrder = dateTimePicker2.Value;
                    so.amountService = Convert.ToInt32(numericUpDown1.Value);
                    so.specialRequests = textBox1.Text;
                    price= Convert.ToInt32(MyDB.service.GetList().FirstOrDefault(x => x.nameService == item.Text).priceService);
                    rz.debtPrice += price * Convert.ToInt32(numericUpDown1.Value);
                    rz.totalPrice+= price * Convert.ToInt32(numericUpDown1.Value);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (RadioButton item in groupBox1.Controls)
            {
                if(item.Checked==true)
                {
                    flag1 = false;
                    foreach (var item1 in MyDB.unavailableDateForService.GetList().Where(x => x.ThisZimmerService.ThisService.nameService==item.Text))
                    {
                        if(dateTimePicker1.Value.Date>item1.unavailableFromDate.Date&&dateTimePicker1.Value.Date<item1.unavailableUntil.Date)
                        {
                            MessageBox.Show("אנו מצטערים, אך בעל הצימר סימן תאריך זה כתאריך לא זמין לשירות");
                        }
                    }

                }
            }
            if (flag1 == true)
            {
                MessageBox.Show("לא סימנת שירות רצוי");
            }
            else
            {
                if (dateTimePicker1.Value.Date < DateTime.Now.Date || (dateTimePicker1.Value.Date == DateTime.Now.Date && dateTimePicker1.Value.Hour < DateTime.Now.Hour))
                {
                    MessageBox.Show("התאריך שהקשת כבר עבר, אנא הקש תאריך נכון");
                }
                else
                {
                    if (dateTimePicker1.Value.Date > rz.dateTo.Date || dateTimePicker1.Value.Date < rz.dateFrom.Date)
                    {
                        MessageBox.Show("התאריך שהקשת אינו בזמן שהותך בצימר, אנא הקש תאריך נכון ");
                    }
                    else
                    {
                        flag = true;
                        if (radioButton1.Checked == true)
                        {
                            Cheack1();
                        }
                        if (radioButton2.Checked == true)
                        {
                            Cheack2();
                        }
                        if (radioButton3.Checked == true)
                        {
                            Cheack3();
                        }
                        if (flag == false)
                        {
                            MessageBox.Show("השעה שהקשת אינה בשעות קבלת הארוחה, אנא הקש שעה לפי השעות הרשומות בתפריט");
                        }
                        else
                        {
                            if (numericUpDown1.Value == 0)
                            {
                                MessageBox.Show("לא הקשת מספר מנות,אנא הקש");
                            }
                            else
                            {
                                FillService();
                                MyDB.serviceOrder.AddItem(so);
                                MyDB.serviceOrder.SaveChanges();
                                MessageBox.Show("בקשת השירות שלך התקבלה בהצלחה! בהמשך בעל הבית יצור עימך קשר לתיאום פרטים ואת התשלום תוכל לשלם לאחר קבלת השירות בדף הפירוטים של ההזמנה");
                                FrmTenant frmt = new FrmTenant(t);
                                frmt.Show();
                                this.Close();
                            }
                        }

                    }
                } 
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmTenant frt = new FrmTenant(t);
            frt.Show();
            this.Close();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmDetailsOfOrders faoo = new FrmDetailsOfOrders(rz.codeRentZimmer, t);
            faoo.Show();
            this.Close();

        }
    }
}
