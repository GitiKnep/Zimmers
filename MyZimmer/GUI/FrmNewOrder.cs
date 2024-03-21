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
    public partial class FrmNewOrder : Form
    {
        tenant t;
        List<zimmer> lst;
        List<zimmer> lst1;
        bool flag3 = true;
        public FrmNewOrder(tenant t1)
        {
            InitializeComponent();
            t = t1;
            
            lst = new List<zimmer>();
            lst1 = new List<zimmer>();
            foreach (var item in MyDB.zimmer.GetList())
            {
                UCZimmer uz = new UCZimmer(item, t);
                flowLayoutPanel1.Controls.Add(uz);
            }
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
        
        private void buildCatalog()
        {
         
            bool flag = true;
            bool flag1 = true;
            bool flag2 = true;
            
            foreach (var item in MyDB.zimmer.GetList())
            {
                flag = true;
                if (comboBox1.SelectedItem.ToString() == item.ThisCity.ThisArea.nameArea && (Convert.ToInt32(textBox1.Text)==item.numberOfBedZimmer|| Convert.ToInt32(textBox1.Text)+1==item.numberOfBedZimmer|| Convert.ToInt32(textBox1.Text) + 2 == item.numberOfBedZimmer) && item.priceNightZimmer >= Convert.ToInt32(textBox2.Text) && item.priceNightZimmer <= Convert.ToInt32(textBox3.Text)&&item.status==true)
                {
                    foreach (var item1 in MyDB.rentZimmer.GetList().Where(x => x.codeZimmer == item.codeZimmer))
                    {
                        if (item1.dateFrom >= dateTimePicker1.Value && item1.dateTo <= dateTimePicker2.Value)
                        {
                            flag = false;
                        }
                    }
                    if (flag)
                    {
                        lst.Add(item);
                    }

                }
            } 
            foreach (CheckBox item in flowLayoutPanel2.Controls)
            {
                if (item.Checked == true)
                {
                    flag1 = false;
                }
            }
            if (flag1 == true)
            {
                foreach (var item in lst)
                {

                    UCZimmer uz = new UCZimmer(item,t);
                    flowLayoutPanel1.Controls.Add(uz);

                }
               
            }
            else
            {
                foreach (var item in lst)
                {
                    foreach (CheckBox item2 in flowLayoutPanel2.Controls)
                    {
                        if (item2.Checked == true)
                        {
                            if (flag2 == true)
                            {
                                foreach (var item1 in MyDB.includeMyZimmer.GetList().Where(x => x.codeZimmer == item.codeZimmer && x.ThisIncludeIn.descriptionInclude == item2.Text))
                                {

                                    {
                                        lst1.Add(item);
                                        flag2 = false;
                                    }
                                }
                            }
                        }
                    }
                    flag = true;
                }
                foreach (var item in lst1)
                {

                    UCZimmer uz = new UCZimmer(item,t);
                    flowLayoutPanel1.Controls.Add(uz);

                }
                
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Text == "") || (textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
            {
                MessageBox.Show("לא הזנת נתון אחד או יותר אנא הזן אותו/אותם על מנת שנוכל להתאים עבורך צימר ");

            }
            else
            {
                flag3 = true;
                errorProvider1.Clear();
                if(!Validation.IsNum(textBox1.Text))
                { errorProvider1.SetError(textBox1, "מספר המיטות אינו תקין"); flag3 = false; }
                if(!Validation.IsNum(textBox2.Text))
                { errorProvider1.SetError(textBox2, "המחיר אינו תקין"); flag3 = false; }
                if (!Validation.IsNum(textBox3.Text))
                { errorProvider1.SetError(textBox3, "המחיר אינו תקין"); flag3 = false; }
                if (flag3)
                {

                    if (dateTimePicker1.Value > dateTimePicker2.Value)
                    {
                        MessageBox.Show("תאריך הכניסה שהקשת מתקיים לאחר תאריך היציאה אנא הקש תאריכים נכונים");
                    }
                    else
                    {
                        if (dateTimePicker1.Value < DateTime.Now)
                        {
                            MessageBox.Show("התאריך שהקשת שגוי אנא הקש תאריך שטרם היה");
                        }

                        else
                        {
                            flowLayoutPanel1.Controls.Clear();
                            buildCatalog();
                           
                        }
                    }
                }
            }
            
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void FrmNewOrder_Load(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmTenant frt = new FrmTenant(t);
            frt.Show();
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.IsNumberChar(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.IsNumberChar(e.KeyChar);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.IsNumberChar(e.KeyChar);
        }
    }
}
