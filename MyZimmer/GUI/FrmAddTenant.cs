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
    public partial class FrmAddTenant : Form
    {
        tenant t;
        FormStatus f;
        bool flag = true;
        public FrmAddTenant()
        {
            InitializeComponent();
            t = new tenant();
            f = FormStatus.add;
        }
        public FrmAddTenant(tenant t1)
        {
            InitializeComponent();
            f = FormStatus.update;
            label1.Text = "עדכון";
            t = t1;
            FillTxt();
            
        }
        public void FillTxt()
        {
            txtFName.Text = t.fNameTenant;
            txtLName.Text = t.lNameTenant;
            txtTel.Text = t.TelTenant;
            txtMail.Text = t.EmailAddressTenant;
            txtPassword.Text = t.passwordTenant;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (f == FormStatus.add)
            {
                if (txtFName.Text == "" || txtLName.Text == "" || txtMail.Text == "" || txtTel.Text == ""||txtPassword.Text=="")
                {
                    MessageBox.Show("לא הזנת את כל הפרטים, אנא מלא את כל הפרטים על מנת שנוכל ליצור עבורך לקוח חדש");

                }
                else
                {
                    flag = true;
                    errorProvider1.Clear();
                    if (!Validation.IsPelepon(txtTel.Text) && !Validation.IsTel(txtTel.Text))
                    { errorProvider1.SetError(txtTel, "מספר הטלפון אינו תקין"); flag = false; }
                    if (!Validation.IsMail(txtMail.Text))
                    { errorProvider1.SetError(txtMail, "כתובת המייל אינה תקינה"); flag = false; }
                    if (flag==true)
                    {
                        foreach (var item in MyDB.tenant.GetList())
                        {
                            if (item.TelTenant == txtTel.Text)
                            {
                                MessageBox.Show("מספר טלפון זה כבר קיים במערכת הנך מוחזר למסך הכניסה ");
                                this.Close();
                                FrmEnteranceTenant fte = new FrmEnteranceTenant();
                                fte.Show();
                                this.Close();
                            }

                        }
                        FillTenant();
                        MyDB.tenant.AddItem(t);
                        MyDB.tenant.SaveChanges();
                        MessageBox.Show("לקוח חדש התווסף בהצלחה!");
                        FrmTenant ft = new FrmTenant(t);
                        ft.Show();
                        this.Close();
                    }
                }
                    
            }
            if (f == FormStatus.update)
            {
                if (txtFName.Text == "" || txtLName.Text == "" || txtMail.Text == "" || txtTel.Text == ""||txtPassword.Text=="")
                {
                    MessageBox.Show("לא הזנת את כל הפרטים, אנא מלא את כל הפרטים על מנת שנוכל לעדכן את פרטייך כראוי");

                }
                else
                {
                    flag = true;
                    errorProvider1.Clear();
                    if (!Validation.IsPelepon(txtTel.Text)&& !Validation.IsTel(txtTel.Text))
                    { errorProvider1.SetError(txtTel, "מספר הטלפון אינו תקין"); flag = false; }
                    if (!Validation.IsMail(txtMail.Text))
                    { errorProvider1.SetError(txtMail, "כתובת המייל אינה תקינה"); flag = false; }
                    if (flag==true)
                    {
                        FillTenant();
                        MyDB.tenant.UpdateItem(t);
                        MyDB.tenant.SaveChanges();
                        MessageBox.Show("השינויים נשמרו בהצלחה!");
                        FrmTenant ft = new FrmTenant(t);
                        ft.Show();
                        this.Close();
                    }

                }
            }
           
        }
        public void FillTenant()
        {
            if (f == FormStatus.add)
                t.codeTenant = MyDB.tenant.GetList().OrderBy(x=>x.codeTenant).Last().codeTenant + 1;
            else
                t.codeTenant = t.codeTenant;
            t.fNameTenant = txtFName.Text;
            t.lNameTenant = txtLName.Text;
            t.TelTenant = txtTel.Text; 
             t.EmailAddressTenant = txtMail.Text; 
            t.passwordTenant = txtPassword.Text;
        }

        private void txtMail_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainPage mpa = new MainPage();
            mpa.Show();
            this.Close();
        }

        private void txtFName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.IsHebrewChar(e.KeyChar);
        }

        private void txtLName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.IsHebrewChar(e.KeyChar);
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.IsNumberChar(e.KeyChar);
        }
    }
}
