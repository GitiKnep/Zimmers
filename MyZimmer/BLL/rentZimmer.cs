using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class rentZimmer : GeneralRow
    {
        public int codeRentZimmer { get; set; }
        public int codeTenant { get; set; }
        public int codeZimmer { get; set; }
        public DateTime dateFrom { get; set; }
        public DateTime dateTo { get; set; }
        public int totalPrice { get; set; }
        public int debtPrice { get; set; }

        public rentZimmer() : base()
        {

        }
        public rentZimmer(DataRow row) : base(row)
        {

        }
        
        public zimmer ThisZimmer
        {
            get { return MyDB.zimmer.GetList().FirstOrDefault(x => x.codeZimmer == this.codeZimmer); }
        }
        public tenant ThisTenant
        {
            get { return MyDB.tenant.GetList().FirstOrDefault(x => x.codeTenant == this.codeTenant); }
        }


        public override void FillDataRow()
        {
            row["codeRentZimmer"] = this.codeRentZimmer;
            row["codeTenant"] = this.codeTenant;
            row["codeZimmer"] = this.codeZimmer;
            row["dateFrom"] = this.dateFrom;
            row["dateTo"] = this.dateTo;
            row["totalPrice"] = this.totalPrice;
            row["debtPrice"] = this.debtPrice;

        }


        public override void FillFields()
        {

            this.codeRentZimmer = Convert.ToInt32(row["codeRentZimmer"]);
            this.codeTenant = Convert.ToInt32(row["codeTenant"]);
            this.codeZimmer = Convert.ToInt32(row["codeZimmer"]);
            this.dateFrom = Convert.ToDateTime(row["dateFrom"]);
            this.dateTo = Convert.ToDateTime(row["dateTo"]);
            this.totalPrice = Convert.ToInt32(row["totalPrice"]);
            this.debtPrice = Convert.ToInt32(row["debtPrice"]);

        }

    }
}
