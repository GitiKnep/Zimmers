using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class service : GeneralRow
    {
        public int codeService { get; set; }
        public string nameService { get; set; }
        public string descriptionService { get; set; }
        public int priceService { get; set; }

        public service() : base()
        {

        }
        public service(DataRow row) : base(row)
        {

        }


        public override void FillDataRow()
        {
            row["codeService"] = this.codeService;
            row["nameService"] = this.nameService;
            row["descriptionService"] = this.descriptionService;
            row["priceService"] = this.priceService;

        }


        public override void FillFields()
        {

            this.codeService = Convert.ToInt32(row["codeService"]);
            this.nameService = row["nameService"].ToString();
            this.descriptionService = row["descriptionService"].ToString();
            this.priceService = Convert.ToInt32(row["priceService"]);

        }

    }
}
