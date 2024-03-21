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
    public partial class FrmShowService : Form
    {
        renting re;
        
        public FrmShowService(renting re1)
        {
            InitializeComponent();
            
            re = re1;
            dataGridView1.DataSource=MyDB.serviceOrder.GetList().Select(x => new { x.ThisRentZimmer.ThisZimmer.nameZimmer, x.ThisService.nameService, x.dateOrder, x.hourOrder.Hour, x.specialRequests, x.amountService,  x.codeServiceOrder,x.ThisRentZimmer.ThisZimmer.codeRenting }).Where(x => x.codeRenting == re.codeRenting&&x.dateOrder>=DateTime.Now ).ToList();
            dataGridView1.Columns[0].HeaderText = "שם הצימר";
            dataGridView1.Columns[1].HeaderText = "שם השירות";
            dataGridView1.Columns[2].HeaderText = "תאריך השירות";
            dataGridView1.Columns[3].HeaderText = "שעת שירות";
            dataGridView1.Columns[4].HeaderText = "בקשות מיוחדות";
            dataGridView1.Columns[5].HeaderText = "מספר שירותים";
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            
        }
    }
}
