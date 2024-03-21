using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class includeInZimmer : GeneralRow
    {
        public int codeInclude { get; set; }
        public string descriptionInclude { get; set; }

        public includeInZimmer() : base()
        {

        }
        public includeInZimmer(DataRow row) : base(row)
        {

        }


        public override void FillDataRow()
        {
            row["codeInclude"] = this.codeInclude;
            row["descriptionInclude"] = this.descriptionInclude;

        }


        public override void FillFields()
        {

            this.codeInclude = Convert.ToInt32(row["codeInclude"]);
            this.descriptionInclude = row["descriptionInclude"].ToString();

        }

    }
}

