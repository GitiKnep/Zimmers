using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class zimmerService : GeneralRow
    {
        public int codeZimmerService { get; set; }
        public int codeService { get; set; }
        public int codeZimmer { get; set; }


        public zimmerService() : base()
        {

        }
        public zimmerService(DataRow row) : base(row)
        {

        }
        public service ThisService
        {
            get { return MyDB.service.GetList().FirstOrDefault(x => x.codeService == this.codeService); }
        }

        public override void FillDataRow()
        {
            row["codeZimmerService"] = this.codeZimmerService;
            row["codeService"] = this.codeService;
            row["codeZimmer"] = this.codeZimmer;

        }


        public override void FillFields()
        {

            this.codeZimmerService = Convert.ToInt32(row["codeZimmerService"]);
            this.codeService = Convert.ToInt32(row["codeService"]);
            this.codeZimmer = Convert.ToInt32(row["codeZimmer"]);
            
        }

    }
}