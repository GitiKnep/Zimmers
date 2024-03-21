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
    public partial class FrmPayment : Form
    {
        rentZimmer rz;
        tenant t;
        bool flag = true;
        DateTime date1;
        public FrmPayment(rentZimmer rz1,tenant t1)
        {
            InitializeComponent();
            rz = rz1;
            t = t1;
            label2.Text += " " + rz.debtPrice.ToString();
            date1 = new DateTime();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            flag = true;
            errorProvider1.Clear();
            if(!Validation.IsNum(textBox1.Text))
            { errorProvider1.SetError(textBox1, "מספר האשראי אינו תקין"); flag = false; } 
            if((!(textBox3.Text[2]=='/'))||!(textBox3.Text.Length==7))
            { errorProvider1.SetError(textBox3, "התוקף אינו תקין"); flag = false; }
            else
            {
                try { date1 = Convert.ToDateTime(textBox3.Text); }
                catch { errorProvider1.SetError(textBox3, "התוקף אינו תקין"); flag = false; }
                if (date1<DateTime.Today)
                { errorProvider1.SetError(textBox3, "התוקף אינו תקין"); flag = false; }
            }
            if(!Validation.IsNum(textBox2.Text)||!(textBox2.Text.Length==3))
            { errorProvider1.SetError(textBox2, "קוד האבטחה אינו תקין");flag = false; }
            if (flag)
            {
                FillRent();
                MyDB.rentZimmer.UpdateItem(rz);
                MyDB.rentZimmer.SaveChanges();
                MessageBox.Show("התשלום הועבר בהצלחה, תודה ובהנאה!");
                FrmTenant frt = new FrmTenant(t);
                frt.Show();
                this.Close();
            }
        }
        public void FillRent()
        {
            rz.codeRentZimmer = rz.codeRentZimmer;
            rz.codeTenant = rz.codeTenant;
            rz.codeZimmer = rz.codeZimmer;
            rz.dateFrom = rz.dateFrom;
            rz.dateTo = rz.dateTo;
            rz.totalPrice = rz.totalPrice;
            rz.debtPrice = 0;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
