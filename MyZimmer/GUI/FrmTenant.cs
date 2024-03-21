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
    public partial class FrmTenant : Form
    {
        tenant t;
        bool flag = true;
        public FrmTenant(tenant t1)
        {
            InitializeComponent();
            this.t = t1;
            label1.Text = "שלום" + " " + t.fNameTenant + " " + t.lNameTenant;
            dataGridView1.DataSource = MyDB.rentZimmer.GetList().Select(x => new { x.codeTenant, x.ThisZimmer.nameZimmer, x.ThisZimmer.ThisCity.nameCity,x.ThisZimmer.ThisRenting.fNameRenting,x.ThisZimmer.ThisRenting.lNameRenting, x.ThisZimmer.ThisRenting.TelRenting, x.ThisZimmer.priceNightZimmer, x.dateFrom.Date, x.dateTo, x.totalPrice,x.debtPrice, x.codeRentZimmer }).Where(x => x.codeTenant == t.codeTenant).ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "שם הצימר";
            dataGridView1.Columns[2].HeaderText = "עיר הצימר";
            dataGridView1.Columns[3].HeaderText = "שם המשכיר";
            dataGridView1.Columns[4].HeaderText = "שם משפחה";
            dataGridView1.Columns[5].HeaderText = "מספר טלפון של המשכיר";
            dataGridView1.Columns[6].HeaderText = "מחיר ללילה";
            dataGridView1.Columns[7].HeaderText = "מתאריך";
            dataGridView1.Columns[8].HeaderText = "עד תאריך";
            dataGridView1.Columns[9].HeaderText = "המחיר בסך הכל";
            dataGridView1.Columns[10].HeaderText = "מחיר חוב שלא שולם";
            dataGridView1.Columns[11].Visible = false;
            foreach (var item in MyDB.rentZimmer.GetList())
            {
                if(item.codeTenant==t.codeTenant)
                {
                    flag = false;
                }
            }
            if(flag==true)
            {
                button2.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmAddTenant fa = new FrmAddTenant(t);
            fa.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmNewOrder fn = new FrmNewOrder(t);
            fn.Show();
            this.Close();
        }

       
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmDetailsOfOrders fdoo = new FrmDetailsOfOrders(Convert.ToInt32(dataGridView1.CurrentRow.Cells[11].Value),t);
            fdoo.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("האם אתה בטוח שברצונך להסיר את המשתמש שלך? במקרה זה כל נתוניך ימחקו", "מחיקת המשתמש", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
            {
                MyDB.tenant.DeleteItem(t);
                MyDB.tenant.SaveChanges();
                this.Close();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }
    }
}
