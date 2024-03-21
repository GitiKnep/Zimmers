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
    public partial class FrmRenting : Form
    {
        renting re;
        bool flag;
        zimmer z;
        bool flag1 = true;
        bool flag2 = true;
        public FrmRenting(renting re1)
        {
            InitializeComponent();
            this.re = re1;
            label1.Text = "שלום" + " "+re.fNameRenting + " " + re.lNameRenting;
            dataGridView1.DataSource = MyDB.zimmer.GetList().Select(x => new {x.codeRenting,x.nameZimmer,x.ThisCity.ThisArea.nameArea,x.ThisCity.nameCity,x.streetZimmer,x.numberOfHouseZimmer,x.numberOfBedZimmer,x.priceNightZimmer,x.status,x.codeZimmer }).Where(x => x.codeRenting == re.codeRenting).ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "שם הצימר";
            dataGridView1.Columns[2].HeaderText = "אזור המיקום";
            dataGridView1.Columns[3].HeaderText = "עיר";
            dataGridView1.Columns[4].HeaderText = "רחוב";
            dataGridView1.Columns[5].HeaderText = "מספר בית";
            dataGridView1.Columns[6].HeaderText = "מספר מיטות";
            dataGridView1.Columns[7].HeaderText = "מחיר ללילה";
            dataGridView1.Columns[8].HeaderText = "סטטוס: פעיל/לא פעיל";
            dataGridView1.Columns[9].Visible = false;
            flag = false;
            z = new zimmer();
        }

        private void FrmRenting_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAddRenting fa = new FrmAddRenting(re);
            fa.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           FrmAddUpdateZimmer fauz = new FrmAddUpdateZimmer(Convert.ToInt32(dataGridView1.CurrentRow.Cells[9].Value),re);
            fauz.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmAddUpdateZimmer fau = new FrmAddUpdateZimmer(re);
            fau.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            foreach (var item in MyDB.rentZimmer.GetList())
            {
                
                if(item.codeZimmer== Convert.ToInt32(dataGridView1.CurrentRow.Cells[9].Value))
                {
                    flag = true;
                }
     
            }
            if(flag==true)
            {
                FrmShowOrders fso = new FrmShowOrders(Convert.ToInt32(dataGridView1.CurrentRow.Cells[9].Value), re);
                fso.Show();
            }
            else
            {
                MessageBox.Show("אין הזמנות בהסטוריה של צימר זה");
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmShowService fss = new FrmShowService(re);
            fss.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            flag2 = true;
            foreach (var item in MyDB.zimmer.GetList())
            {
                if(item.codeRenting==re.codeRenting)
                {
                    flag2 = false;
                }
            }
            if(flag2==false)
            {
                MessageBox.Show("לא ניתן למחוק משתמש לפני מחיקת כל הצימרים שבבעלותו. אנא מחק את כל הצימרים שבבעלותך ורק לאחר מכן מחק את המשתמש");
            }
            else
            {
                DialogResult r = MessageBox.Show("האם אתה בטוח שברצונך להסיר את המשתמש שלך? במקרה זה כל נתוניך ימחקו", "מחיקת המשתמש", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    MyDB.renting.DeleteItem(re);
                    MyDB.renting.SaveChanges();
                    MessageBox.Show("המשתמש נמחק בהצלחה");
                    MainPage mapa = new MainPage();
                    mapa.Show();
                    this.Close();
                }
            }
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            flag1 = true;
            z = MyDB.zimmer.GetList().First(x => x.codeZimmer == Convert.ToInt32(dataGridView1.CurrentRow.Cells["codeZimmer"].Value));
            foreach (var item in MyDB.rentZimmer.GetList().Where(x=>x.codeZimmer==z.codeZimmer).Select(x=>x.dateTo))
            {
                if(item>DateTime.Now)
                {
                    flag1 = false;
                }
            }
            if(flag1==false)
            {
                DialogResult r1 = MessageBox.Show("הצימר שנבחר הוא:" + z.nameZimmer + " " + " אין אפשרות להסיר צימר זה משום שהוא הוזמן. על כן הנך יכול לסמן את הצימר כלא זמין ולאחר סיום ההזמנה האחרונה תוכל להסירו, האם הנך רוצה לסמנו כלא זמין?", "מחיקת הצימר", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r1 == DialogResult.Yes)
                {
                    z.status = false;
                }
            }
            else
            {
                DialogResult r = MessageBox.Show("הצימר שנבחר הוא:" + z.nameZimmer + " " + " האם אתה בטוח שברצונך להסירו?", "מחיקת הצימר", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    MyDB.zimmer.DeleteItem(z);
                    MyDB.zimmer.SaveChanges();
                    MessageBox.Show("הצימר הוסר בהצלחה");
                    dataGridView1.DataSource = MyDB.zimmer.GetList().Select(x => new { x.codeRenting, x.nameZimmer, x.ThisCity.ThisArea.nameArea, x.ThisCity.nameCity, x.streetZimmer, x.numberOfHouseZimmer, x.numberOfBedZimmer, x.priceNightZimmer, x.status, x.codeZimmer }).Where(x => x.codeRenting == re.codeRenting).ToList();
                }
            }
            
        }
    }
}
