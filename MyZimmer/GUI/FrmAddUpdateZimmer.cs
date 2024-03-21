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
using System.IO;

namespace MyZimmer.GUI
{
    public partial class FrmAddUpdateZimmer : Form
    {
        zimmer z;
        FormStatus f;
        renting re;
        string imageFile;
        pictureZimmer picture;
        int num=1;
        includeMyZimmer incl;
        bool flag = true;
        public FrmAddUpdateZimmer(int i1,renting re1)
        {
            InitializeComponent();
            z = MyDB.zimmer.GetList().FirstOrDefault(x => x.codeZimmer == i1);
            f = FormStatus.update;
            re = re1;
            picture = new pictureZimmer();
            label1.Text = "עדכון צימר";
            label13.Text = re.fNameRenting;
            label14.Text = re.lNameRenting;
            groupBox1.Visible = true;
            pictureBox2.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            label2.Visible = false;
            label8.Visible = false;
            button5.Visible = false;
            FillTxt();
        }
        public FrmAddUpdateZimmer(renting re1)
        {
            InitializeComponent();
            f = FormStatus.add;
            re = re1;
            label13.Text = re.fNameRenting;
            label14.Text = re.lNameRenting;
            picture = new pictureZimmer();
            z = new zimmer();
            groupBox1.Visible = true;
            pictureBox2.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            label2.Visible = false;
            label8.Visible = false;
            button5.Visible = false;
            comboBox1.DataSource = MyDB.area.GetList().Select(x => x.nameArea).ToList();
            comboBox2.DataSource = MyDB.city.GetList().Select(x => x.nameCity).ToList();
        }
        public void FillTxt()
        {
            txtName.Text = z.nameZimmer;
            List<string> lstArea = MyDB.area.GetList().Select(x => x.nameArea).ToList();
            comboBox1.DataSource = lstArea;
            comboBox1.SelectedItem = MyDB.area.GetList().First(x => x.codeArea == z.ThisCity.codeArea).nameArea;
            List<string> lstCity = MyDB.city.GetList().Where(x=>x.ThisArea.nameArea==comboBox1.Text).Select(x => x.nameCity).ToList();
            comboBox2.DataSource = lstCity;
            comboBox2.SelectedItem = MyDB.city.GetList().First(x => x.codeCity == z.codeCity).nameCity;
            txtAdress.Text = z.streetZimmer;
            txtHouse.Text = z.numberOfHouseZimmer.ToString();
            txtBed.Text = z.numberOfBedZimmer.ToString();
            txtPrice.Text = z.priceNightZimmer.ToString();
            checkStatus.Checked = z.status;
            foreach (var item in MyDB.includeMyZimmer.GetList().Where(x=>x.codeZimmer==z.codeZimmer))
            {

                    if(item.codeInclude==0)
                    {
                        checkBox1.Checked = true;
                    }
                    if (item.codeInclude == 1)
                    {
                        checkBox2.Checked = true;
                    }
                    if (item.codeInclude == 3)
                    {
                        checkBox3.Checked = true;
                    }
                    if (item.codeInclude ==2)
                    {
                        checkBox4.Checked = true;
                    }
                    if (item.codeInclude == 4)
                    {
                        checkBox5.Checked = true;
                    }
                    if (item.codeInclude == 5)
                    {
                        checkBox6.Checked = true;
                    }
                    if (item.codeInclude == 6)
                    {
                        checkBox7.Checked = true;
                    }
                    if (item.codeInclude == 7)
                    {
                        checkBox8.Checked = true;
                    }
                    if (item.codeInclude == 8)
                    {
                        checkBox9.Checked = true;
                    }
                    if (item.codeInclude == 9)
                    {
                        checkBox10.Checked = true;
                    }
                
            }

        }

        public void AddInclude()
        {
            int code;
            includeMyZimmer inc=new includeMyZimmer();
            foreach (CheckBox item in flowLayoutPanel1.Controls)
            {
                if(item.Checked==true)
                {
                    inc.codeIncludeMy = MyDB.includeMyZimmer.GetList().OrderBy(x => x.codeIncludeMy).Last().codeIncludeMy + 1;
                    code = MyDB.includeInZimmer.GetList().FirstOrDefault(x => x.descriptionInclude == item.Text).codeInclude;
                    inc.codeZimmer = z.codeZimmer;
                    inc.codeInclude= code;
                    MyDB.includeMyZimmer.AddItem(inc);
                    
                }
            }
            MyDB.includeMyZimmer.SaveChanges();
        }

        public void UpdateInclude()
        {
            int code;
            includeMyZimmer inc = new includeMyZimmer();
            foreach (CheckBox item in flowLayoutPanel1.Controls)
            {
                if (item.Checked == true)
                {
                    code = MyDB.includeInZimmer.GetList().FirstOrDefault(x => x.descriptionInclude == item.Text).codeInclude;
                    if (MyDB.includeMyZimmer.GetList().FirstOrDefault(x => x.codeInclude == code && x.codeZimmer == z.codeZimmer) == null)
                    {
                        inc.codeIncludeMy = MyDB.includeMyZimmer.GetList().OrderBy(x => x.codeIncludeMy).Last().codeIncludeMy + 1;
                        inc.codeZimmer = z.codeZimmer;
                        inc.codeInclude = code;
                        MyDB.includeMyZimmer.AddItem(inc);
                    }
                }
            }
            MyDB.includeMyZimmer.SaveChanges();
        }
      
        public void FillZimmer()
        {
            if (f == FormStatus.add)
                z.codeZimmer = MyDB.zimmer.GetList().Last().codeZimmer + 1;
            else
                z.codeZimmer = z.codeZimmer;
            z.nameZimmer = txtName.Text;
            z.codeRenting = re.codeRenting;
            z.codeCity = MyDB.city.GetList().First(x => x.nameCity == comboBox2.SelectedItem.ToString()).codeCity;
            z.ThisCity.codeArea = MyDB.area.GetList().First(x => x.nameArea == comboBox1.SelectedItem.ToString()).codeArea;
            z.streetZimmer = txtAdress.Text;
            z.numberOfHouseZimmer = Convert.ToInt32(txtHouse.Text);
            z.numberOfBedZimmer = Convert.ToInt32(txtBed.Text);
            z.priceNightZimmer = Convert.ToInt32(txtPrice.Text);
            z.status = checkStatus.Checked;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (f == FormStatus.add)
            {
                if (txtName.Text == "" || txtAdress.Text == "" || txtBed.Text == "" || comboBox2.Text == "" || txtHouse.Text == "" || txtPrice.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("לא הזנת את כל הפרטים, אנא מלא את כל הפרטים על מנת שנוכל ליצור עבורך צימר חדש");

                }
                else
                {
                    flag = true;
                    errorProvider1.Clear();
                    if (!Validation.IsNum(txtHouse.Text))
                    { errorProvider1.SetError(txtHouse, "מספר הבית אינו תקין"); flag = false; }
                    if (!Validation.IsNum(txtBed.Text))
                    { errorProvider1.SetError(txtBed, "מספר המיטות אינו תקין"); flag = false; }
                    if (!Validation.IsNum(txtPrice.Text))
                    { errorProvider1.SetError(txtPrice, "המחיר אינו תקין"); flag = false; }
                    if(flag)
                    {
                        FillZimmer();
                        MyDB.zimmer.AddItem(z);
                        MyDB.zimmer.SaveChanges();
                        AddInclude();
                        MessageBox.Show("פרטי הצימר נקלטו בהצלחה, הנך יכול במסך הבא להוסיף גם תמונות ושירותים");
                        groupBox1.Visible = false;
                        pictureBox2.Visible = true;
                        button2.Visible = true;
                        button3.Visible = true;
                        button4.Visible = true;
                        label2.Visible = true;
                        label8.Visible = true;
                        button5.Visible = true;
                    }
                    
                }
            }
            if (f == FormStatus.update)
            {
                if (txtName == null || txtAdress == null || txtBed == null || comboBox2 == null || txtHouse == null || txtPrice == null || comboBox1 == null)
                {
                    MessageBox.Show("לא הזנת את כל הפרטים, אנא מלא את כל הפרטים על מנת שנוכל לעדכן את פרטי הצימר כראוי");

                }
                else
                {
                    flag = true;
                    errorProvider1.Clear();
                    if (!Validation.IsNum(txtHouse.Text))
                    { errorProvider1.SetError(txtHouse, "מספר הבית אינו תקין"); flag = false; }
                    if (!Validation.IsNum(txtBed.Text))
                    { errorProvider1.SetError(txtBed, "מספר המיטות אינו תקין"); flag = false; }
                    if (!Validation.IsNum(txtPrice.Text))
                    { errorProvider1.SetError(txtPrice, "המחיר אינו תקין"); flag = false; }
                    if (flag)
                    {
                        FillZimmer();
                        MyDB.zimmer.UpdateItem(z);
                        MyDB.zimmer.SaveChanges();
                        UpdateInclude();
                        MessageBox.Show(" פרטי הצימר התעדכנו בהצלחה, הנך יכול במסך הבא לעדכן גם תמונות ושירותים. במידה ואינך מעונין בתמונה או בהוספת שירות לחץ על אישור ");
                        groupBox1.Visible = false;
                        pictureBox2.Visible = true;
                        button2.Visible = true;
                        button3.Visible = true;
                        button4.Visible = true;
                        label2.Visible = true;
                        label8.Visible = true;
                        button5.Visible = true;
                    }
                }
            }
        }

        private void FrmAddUpdateZimmer_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg; *.bmp;*.PNG;";
            openFileDialog1.ShowDialog();
            string a = Directory.GetParent(Directory.GetCurrentDirectory()).ToString();
            string b = Directory.GetParent(a).ToString();
            b = b + @"\Resources\";
            string s = openFileDialog1.SafeFileName;
            b += s;
            try { File.Copy(openFileDialog1.FileName, b); }
            catch { }
            imageFile = s;
            pictureBox2.Image = Image.FromFile(openFileDialog1.FileName);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.BackgroundImage = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            picture.codePicture = MyDB.pictureZimmer.GetList().Last().codePicture + 1;
            picture.codeZimmer = z.codeZimmer;
            picture.myPicture = imageFile;
            MyDB.pictureZimmer.AddItem(picture);
            MyDB.pictureZimmer.SaveChanges();
            MessageBox.Show("התמונה נוספה בהצלחה");
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            FrmAddService fras = new FrmAddService(z,re);
            fras.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (f == FormStatus.add)
            {
                MessageBox.Show("הצימר הוסף בהצלחה, הנך מוחזר למסך הראשי");
                
                FrmRenting fren = new FrmRenting(re);
                fren.Show();
                this.Close();


            }
            if (f == FormStatus.update)
            {
                MessageBox.Show("הצימר עודכן בהצלחה, הנך מוחזר למסך הראשי");
                
                FrmRenting fren = new FrmRenting(re);
                fren.Show();
                this.Close();
            }
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            FrmRenting fren = new FrmRenting(re);
            fren.Show();
            this.Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> lstCity = MyDB.city.GetList().Where(x => x.ThisArea.nameArea == comboBox1.Text).Select(x => x.nameCity).ToList();
            comboBox2.DataSource = lstCity;
            comboBox2.SelectedItem = MyDB.city.GetList().First(x => x.codeCity == z.codeCity).nameCity;
        }

        private void txtHouse_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtHouse_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.IsNumberChar(e.KeyChar);
        }

        private void txtBed_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.IsNumberChar(e.KeyChar);
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.IsNumberChar(e.KeyChar);
        }
    }
}
