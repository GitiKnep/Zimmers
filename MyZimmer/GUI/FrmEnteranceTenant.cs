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
    public partial class FrmEnteranceTenant : Form
    {
        tenant t;
        renting re;
        bool flag = true;
        public FrmEnteranceTenant()
        {
            InitializeComponent();
            t = null;
           
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" ||txtTel.Text=="")
            {
                MessageBox.Show("חסר נתון על מנת לאפשר כניסה, אנא הקש");
            }
            else
            {
                t = MyDB.tenant.GetList().FirstOrDefault(x => x.TelTenant == txtTel.Text && x.passwordTenant == txtPassword.Text);
                if (t != null)
                {
                    FrmTenant ft = new FrmTenant(t);
                    ft.Show();
                    this.Close();
                }
                else
                {
                    flag = true;
                    errorProvider1.Clear();
                    if (!Validation.IsPelepon(txtTel.Text) && !Validation.IsTel(txtTel.Text))
                    { errorProvider1.SetError(txtTel, "מספר הטלפון אינו תקין"); flag = false; }
                    if (flag)
                    {
                        re = MyDB.renting.GetList().FirstOrDefault(x => x.TelRenting == txtTel.Text && x.passwordRenting == txtPassword.Text);
                        if (re != null)
                        {
                            MessageBox.Show("מספר הטלפון והסמסימא שייכים ללקוח משכיר שכבר קיים במערכת, במידה והנך מעוניין להכנס כשוכר הרשם מחדש גם כשוכר בלחיצה על כפתור ההרשמה");
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
            
            FrmAddTenant fad = new FrmAddTenant();
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
