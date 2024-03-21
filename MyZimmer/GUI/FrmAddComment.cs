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
    public partial class FrmAddComment : Form
    {
        rentZimmer rz;
        comment c;
        public FrmAddComment(rentZimmer rz1)
        {
            InitializeComponent();
            rz = rz1;
            c = new comment();
        }
        public void FillComment()
        {
            c.codeComment= MyDB.comment.GetList().OrderBy(x=>x.codeComment).Last().codeComment + 1;
            c.codeZimmer = rz.codeZimmer;
            c.dateOfComment = DateTime.Now.ToString();
            c.noteComment = richTextBox1.Text;
            c.ratingComment = Convert.ToInt32(label7.Text);
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if(richTextBox1==null||trackBar1==null)
            {
                MessageBox.Show("לא הזנת את כל הפרטים, אנא מלא גם דירוג וגם תיאור על מנת שנוכל להוסיף את תגובתך");

            }
            else
            {
                FillComment();
                MyDB.comment.AddItem(c);
                MyDB.comment.SaveChanges();
                MessageBox.Show(" חוות הדעת שלך נשמרה בהצלחה, תודה רבה על המשוב!");
                this.Close();
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label7.Text = trackBar1.Value.ToString();
        }
    }
}
