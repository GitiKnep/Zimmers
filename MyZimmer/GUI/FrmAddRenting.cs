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
    public partial class FrmAddRenting : Form
    {
        renting re;
        FormStatus f;
        bool flag = true;
        
        public FrmAddRenting()
        {
            InitializeComponent();
            re = new renting();
            f = FormStatus.add;
        }
        public FrmAddRenting(renting r1)
        {
            InitializeComponent();
            f = FormStatus.update;
            label1.Text = "עדכון";
            re = r1;
            FillTxt();

        }
        public void FillTxt()
        {
            txtFName.Text = re.fNameRenting;
            txtLName.Text = re.lNameRenting;
            txtTel.Text = re.TelRenting;
            txtMail.Text = re.EmailAddressRenting;
            txtPassword.Text = re.passwordRenting;
        }

        
        public void FillRenting()
        {
            if (f == FormStatus.add)
                re.codeRenting = MyDB.renting.GetList().OrderBy(x=>x.codeRenting).Last().codeRenting + 1;
            else
                re.codeRenting = re.codeRenting;
            re.fNameRenting = txtFName.Text;
            re.lNameRenting = txtLName.Text;
            re.TelRenting = txtTel.Text; 
            re.EmailAddressRenting = txtMail.Text;
            re.passwordRenting = txtPassword.Text;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            if (f == FormStatus.add)
            {
                if (txtFName.Text == "" || txtLName.Text == "" || txtMail.Text == "" || txtTel.Text == ""||txtPassword.Text =="")
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
                    if (flag)
                    {
                        foreach (var item in MyDB.renting.GetList())
                        {
                            if (item.TelRenting == txtTel.Text)
                            {
                                MessageBox.Show("מספר טלפון זה כבר קיים במערכת הנך מוחזר למסך הכניסה ");
                                this.Close();
                                FrmEnteranceRenting fre = new FrmEnteranceRenting();
                                fre.Show();
                                this.Close();
                            }

                        }
                        FillRenting();
                        MyDB.renting.AddItem(re);
                        MyDB.renting.SaveChanges();
                        MessageBox.Show("לקוח חדש התווסף בהצלחה!");
                        FrmRenting fr = new FrmRenting(re);
                        fr.Show();
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
                    if (!Validation.IsPelepon(txtTel.Text) && !Validation.IsTel(txtTel.Text))
                    { errorProvider1.SetError(txtTel, "מספר הטלפון אינו תקין"); flag = false; }
                    if (!Validation.IsMail(txtMail.Text))
                    { errorProvider1.SetError(txtMail, "כתובת המייל אינה תקינה"); flag = false; }
                    if (flag)
                    {
                        FillRenting();
                        MyDB.renting.UpdateItem(re);
                        MyDB.renting.SaveChanges();
                        MessageBox.Show("השינויים נשמרו בהצלחה!");
                        FrmRenting fr = new FrmRenting(re);
                        fr.Show();
                        this.Close();
                    }
                    
                    
                }
            }           
            
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
