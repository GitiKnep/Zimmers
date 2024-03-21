using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class serviceOrder : GeneralRow
    {
        public int codeServiceOrder { get; set; }
        public int codeService { get; set; }
        public int codeRentZimmer { get; set; }
        public DateTime dateOrder { get; set; }
        public DateTime hourOrder { get; set; }
        public string specialRequests { get; set; }
        public int amountService { get; set; }

        public serviceOrder() : base()
        {

        }
        public serviceOrder(DataRow row) : base(row)
        {

        }
        public rentZimmer ThisRentZimmer
        {
            get { return MyDB.rentZimmer.GetList().FirstOrDefault(x => x.codeRentZimmer == this.codeRentZimmer); }
        }
        public service ThisService
        {
            get { return MyDB.service.GetList().FirstOrDefault(x => x.codeService == this.codeService); }
        }
        public override void FillDataRow()
        {
            row["codeServiceOrder"] = this.codeServiceOrder;
            row["codeService"] = this.codeService;
            row["codeRentZimmer"] = this.codeRentZimmer;
            row["dateOrder"] = this.dateOrder;
            row["hourOrder"] = this.hourOrder;
            row["specialRequests"] = this.specialRequests;
            row["amountService"] = this.amountService;

        }


        public override void FillFields()
        {

            this.codeServiceOrder = Convert.ToInt32(row["codeServiceOrder"]);
            this.codeService = Convert.ToInt32(row["codeService"]);
            this.codeRentZimmer = Convert.ToInt32(row["codeRentZimmer"]);
            this.dateOrder = Convert.ToDateTime(row["dateOrder"]);
            this.hourOrder = Convert.ToDateTime( row["hourOrder"]);
            this.specialRequests = row["specialRequests"].ToString();
            this.amountService = Convert.ToInt32(row["amountService"]);

        }

    }
}
