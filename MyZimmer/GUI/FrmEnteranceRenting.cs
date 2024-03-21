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
    public partial class FrmEnteranceRenting : Form
    {
        renting re;
        tenant t;
        bool flag = true;
        public FrmEnteranceRenting()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(txtPassword.Text==""||txtTel.Text=="")
            {
                MessageBox.Show("חסר נתון על מנת לאפשר כניסה, אנא הקש");
            }
            else
            {
            re = MyDB.renting.GetList().FirstOrDefault(x => x.TelRenting == txtTel.Text&&x.passwordRenting==txtPassword.Text);
                if (re != null)
                {
                    FrmRenting fr = new FrmRenting(re);
                    fr.Show();
                    this.Close();
                }
                else
                {
                    flag = true;
                    errorProvider1.Clear();
                    if (!Validation.IsPelepon(txtTel.Text)&&!Validation.IsTel(txtTel.Text))
                    { errorProvider1.SetError(txtTel, "מספר הטלפון אינו תקין"); flag = false; }
                    if(flag)
                    {
                        t = MyDB.tenant.GetList().FirstOrDefault(x => x.TelTenant == txtTel.Text && x.passwordTenant == txtPassword.Text);
                        if (t != null)
                        {
                            MessageBox.Show("מספר הטלפון והסיסמא שייכים ללקוח שוכר שכבר קיים במערכת, במידה והנך מעוניין להכנס כמשכיר הרשם מחדש גם כמשכיר בלחיצה על כפתור ההרשמה");
                            txtTel.Text = "";
                            txtPassword.Text = "";
                        }
                        else
                        {

                            MessageBox.Show("מספר הטלפון או הסיסמא אינם מופיעים במערכת, נא הקש שוב");
                            txtTel.Text = "";
                            txtPassword.Text = "";
                        }
                    }
                    
                }
                
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmAddRenting fad = new FrmAddRenting();
            fad.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.IsNumberChar(e.KeyChar);
        }
    }
}
