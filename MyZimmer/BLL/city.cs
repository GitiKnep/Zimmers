using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class city : GeneralRow
    {
        public int codeCity { get; set; }
        public string nameCity { get; set; }
        public int codeArea { get; set; }

        public city() : base()
        {

        }
        public city(DataRow row) : base(row)
        {

        }
        public area ThisArea
        {
            get { return MyDB.area.GetList().FirstOrDefault(x => x.codeArea == this.codeArea); }
        }

        public override void FillDataRow()
        {
            row["codeCity"] = this.codeCity;
            row["nameCity"] = this.nameCity;
            row["codeArea"] = this.codeArea;

        }


        public override void FillFields()
        {

            this.codeCity = Convert.ToInt32(row["codeCity"]);
            this.nameCity = row["nameCity"].ToString();
            this.codeArea = Convert.ToInt32(row["codeArea"]);

        }

    }
}
