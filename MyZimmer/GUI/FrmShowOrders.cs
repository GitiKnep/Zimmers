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
    public partial class FrmShowOrders : Form
    {
        renting r;
        zimmer z;
        public FrmShowOrders(int i1, renting re1)
        {
            InitializeComponent();
            z = MyDB.zimmer.GetList().FirstOrDefault(x => x.codeZimmer == i1);
            r = re1;
            label1.Text = "הזמנות שבוצעו בצימר" + " " + z.nameZimmer;
            dataGridView1.DataSource = MyDB.rentZimmer.GetList().Select(x => new { x.ThisTenant.fNameTenant, x.ThisTenant.lNameTenant, x.ThisTenant.TelTenant, x.ThisTenant.EmailAddressTenant, x.dateFrom, x.dateTo, x.totalPrice, x.debtPrice, x.ThisZimmer.status,x.codeZimmer }).Where(x => x.codeZimmer == z.codeZimmer).ToList();
            
            dataGridView1.Columns[0].HeaderText = "השוכר-שם פרטי";
            dataGridView1.Columns[1].HeaderText ="השוכר-שם משפחה";
            dataGridView1.Columns[2].HeaderText = "השוכר-טלפון";
            dataGridView1.Columns[3].HeaderText = "השוכר-כתובת מייל";
            dataGridView1.Columns[4].HeaderText = "מתאריך";
            dataGridView1.Columns[5].HeaderText = "עד לתאריך";
            dataGridView1.Columns[6].HeaderText = "עלות";
            dataGridView1.Columns[7].HeaderText = "חוב-לא שולם";
            dataGridView1.Columns[8].HeaderText = "האם הצימר פעיל";
            dataGridView1.Columns[9].Visible = false;
        }

        
    }
}
