using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class includeMyZimmer : GeneralRow
    {
        public int codeIncludeMy { get; set; }
        public int codeZimmer { get; set; }
        public int codeInclude { get; set; }
        
        public includeMyZimmer() : base()
        {

        }
        public includeMyZimmer(DataRow row) : base(row)
        {

        }

        public includeInZimmer ThisIncludeIn
        {
            get { return MyDB.includeInZimmer.GetList().FirstOrDefault(x => x.codeInclude == this.codeInclude); }
        }
        public override void FillDataRow()
        {
            row["codeIncludeMy"] = this.codeIncludeMy;
            row["codeZimmer"] = this.codeZimmer;
            row["codeInclude"] = this.codeInclude;

        }


        public override void FillFields()
        {

            this.codeIncludeMy = Convert.ToInt32(row["codeIncludeMy"]);
            this.codeZimmer = Convert.ToInt32(row["codeZimmer"]);
            this.codeInclude = Convert.ToInt32(row["codeInclude"]);
           
        }

    }
}
