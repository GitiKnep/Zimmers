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
    public partial class FrmAddService : Form
    {
        zimmer z;
       List<zimmerService> lstzs;
        zimmerService zs;
        renting re;
        unavailableDateForService udfs;
        bool flag = true;
        int code = 0;
        bool flag1 = true;
        public FrmAddService(zimmer z1,renting re1)
        {
            InitializeComponent();
            z = z1;
           udfs = new unavailableDateForService();
            foreach (var item in MyDB.zimmerService.GetList().Where(x=>x.codeZimmer==z.codeZimmer))
            {
                if(item.codeService==0)
                {
                    checkBox1.Checked = true;
                }
                if (item.codeService == 1)
                {
                    checkBox2.Checked = true;
                }
                if (item.codeService == 2)
                {
                    checkBox3.Checked = true;
                }
                if (item.codeService == 3)
                {
                    checkBox4.Checked = true;
                }
                if (item.codeService == 4)
                {
                    checkBox5.Checked = true;
                }
                if (item.codeService == 5)
                {
                    checkBox6.Checked = true;
                }
            }
            lstzs = new List<zimmerService>();
            zs = new zimmerService();
            re = re1;

        }
        
        public void FillService()
        {
            flag = true;
            code = MyDB.zimmerService.GetList().OrderBy(x=>x.codeZimmerService).Last().codeZimmerService+1;

            if (checkBox1.Checked == true)
            {
                foreach (var item in MyDB.zimmerService.GetList().Where(x => x.codeZimmer == z.codeZimmer))
                {
                    if (checkBox1.Text == item.ThisService.nameService)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    zs.codeZimmerService = code;
                    zs.codeService = 0;
                    zs.codeZimmer = z.codeZimmer;
                    lstzs.Add(zs);
                    code++;
                }
            }
            else
            {
                foreach (var item in MyDB.zimmerService.GetList().Where(x => x.codeZimmer == z.codeZimmer))
                {
                    if (checkBox1.Text == item.ThisService.nameService)
                    {
                        MyDB.zimmerService.DeleteItem(item);
                    }
                }
            }
            if (checkBox2.Checked == true)
            {
                zs = new zimmerService();
                flag = true;
                foreach (var item in MyDB.zimmerService.GetList().Where(x => x.codeZimmer == z.codeZimmer))
                {
                    if (checkBox2.Text == item.ThisService.nameService)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    zs.codeZimmerService = code;
                    zs.codeService = 1;
                    zs.codeZimmer = z.codeZimmer;
                    lstzs.Add(zs);
                    code++;
                }
            }
            else
            {
                foreach (var item in MyDB.zimmerService.GetList().Where(x => x.codeZimmer == z.codeZimmer))
                {
                    if (checkBox2.Text == item.ThisService.nameService)
                    {
                        MyDB.zimmerService.DeleteItem(item);
                    }
                }
            }
            if (checkBox3.Checked == true)
            {
                zs = new zimmerService();
                flag = true;
                foreach (var item in MyDB.zimmerService.GetList().Where(x => x.codeZimmer == z.codeZimmer))
                {
                    if (checkBox3.Text == item.ThisService.nameService)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    zs.codeZimmerService = code;
                    zs.codeService = 2;
                    zs.codeZimmer = z.codeZimmer;
                    lstzs.Add(zs);
                    code++;
                }
            }
            else
            {
                foreach (var item in MyDB.zimmerService.GetList().Where(x => x.codeZimmer == z.codeZimmer))
                {
                    if (checkBox3.Text == item.ThisService.nameService)
                    {
                        MyDB.zimmerService.DeleteItem(item);
                    }
                }
            }
            if (checkBox4.Checked == true)
            {
                zs = new zimmerService();
                flag = true;
                foreach (var item in MyDB.zimmerService.GetList().Where(x => x.codeZimmer == z.codeZimmer))
                {
                    if (checkBox4.Text == item.ThisService.nameService)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    zs.codeZimmerService = code;
                    zs.codeService = 3;
                    zs.codeZimmer = z.codeZimmer;
                    lstzs.Add(zs);
                    code++;
                }
            }
            else
            {
                foreach (var item in MyDB.zimmerService.GetList().Where(x => x.codeZimmer == z.codeZimmer))
                {
                    if (checkBox4.Text == item.ThisService.nameService)
                    {
                        MyDB.zimmerService.DeleteItem(item);
                    }
                }
            }
            if (checkBox5.Checked == true)
            {
                zs = new zimmerService();
                flag = true;
                foreach (var item in MyDB.zimmerService.GetList().Where(x => x.codeZimmer == z.codeZimmer))
                {
                    if (checkBox5.Text == item.ThisService.nameService)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    zs.codeZimmerService = code;
                    zs.codeService = 4;
                    zs.codeZimmer = z.codeZimmer;
                    lstzs.Add(zs);
                    code++;
                }
            }
            else
            {
                foreach (var item in MyDB.zimmerService.GetList().Where(x => x.codeZimmer == z.codeZimmer))
                {
                    if (checkBox5.Text == item.ThisService.nameService)
                    {
                        MyDB.zimmerService.DeleteItem(item);
                    }
                }
            }
            if (checkBox6.Checked == true)
            {
                zs = new zimmerService();
                flag = true;
                foreach (var item in MyDB.zimmerService.GetList().Where(x => x.codeZimmer == z.codeZimmer))
                {
                    if (checkBox6.Text == item.ThisService.nameService)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    zs.codeZimmerService = code;
                    zs.codeService = 5;
                    zs.codeZimmer = z.codeZimmer;
                    lstzs.Add(zs);
                    code++;
                }
            }
            else
            {
                foreach (var item in MyDB.zimmerService.GetList().Where(x => x.codeZimmer == z.codeZimmer))
                {
                    if (checkBox6.Text == item.ThisService.nameService)
                    {
                        MyDB.zimmerService.DeleteItem(item);
                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
           
                FillService();
                foreach (var item in lstzs)
                {
                    MyDB.zimmerService.AddItem(item);
                }
                MyDB.zimmerService.SaveChanges();
                MessageBox.Show("השירות/ים עודכן/ו בהצלחה");
               
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmRenting fr = new FrmRenting(re);
            fr.Show();
            this.Close();
        }


        private void FrmAddService_Load(object sender, EventArgs e)
        {

        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            flag1 = true;
            foreach (RadioButton item in groupBox1.Controls)
            {
                if(item.Checked==true)
                {
                    foreach (var item1 in MyDB.zimmerService.GetList().Where(x=>x.codeZimmer==z.codeZimmer).Select(x=>x.ThisService.nameService))
                    {
                        if(item1==item.Text)
                        {
                            flag1 = false;
                        }
                    }
                    if (flag1 == false)
                    {
                        if (dateTimePicker2.Value < dateTimePicker1.Value)
                        {
                            MessageBox.Show("התאריכים שהקשת אינם הגיוניים, אנא הקש שוב");
                        }
                        else
                        {
                            if (dateTimePicker1.Value < DateTime.Now)
                            {
                                MessageBox.Show("התאריך שהקשת כבר עבר, אנא הקש תאריך רלוונטי");
                            }
                            else
                            {
                                udfs.codeUnavailableDateForService = MyDB.unavailableDateForService.GetList().OrderBy(x => x.codeUnavailableDateForService).Last().codeUnavailableDateForService + 1;
                                udfs.codeZimmerService = zs.codeZimmerService;
                                udfs.unavailableFromDate = dateTimePicker1.Value;
                                udfs.unavailableUntil = dateTimePicker2.Value;
                                MessageBox.Show("התאריכים נקלטו בהצלחה");
                                item.Checked = false;
                            }
                        }
                        
                    }
                    else
                        MessageBox.Show("שירות זה אינו קיים בצימר");
                }
            }
            
        }

        
    }
}
