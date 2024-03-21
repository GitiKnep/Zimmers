using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class area : GeneralRow
    {
        public int codeArea { get; set; }
        public string nameArea { get; set; }
        
        public area() : base()
        {

        }
        public area(DataRow row) : base(row)
        {

        }


        public override void FillDataRow()
        {
            row["codeArea"] = this.codeArea;
            row["nameArea"] = this.nameArea;
           
        }


        public override void FillFields()
        {

            this.codeArea = Convert.ToInt32(row["codeArea"]);
            this.nameArea = row["nameArea"].ToString();
           
        }
     
    }
}
