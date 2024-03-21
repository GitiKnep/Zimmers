using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class unavailableDateForService : GeneralRow
    {
        public int codeUnavailableDateForService { get; set; }
        public int codeZimmerService { get; set; }
        public DateTime unavailableFromDate { get; set; }
        public DateTime unavailableUntil { get; set; }

        public unavailableDateForService() : base()
        {

        }
        public unavailableDateForService(DataRow row) : base(row)
        {

        }
        public zimmerService ThisZimmerService
        {
            get { return MyDB.zimmerService.GetList().FirstOrDefault(x => x.codeZimmerService == this.codeZimmerService); }
        }

        public override void FillDataRow()
        {
            row["codeUnavailableDateForService"] = this.codeUnavailableDateForService;
            row["codeZimmerService"] = this.codeZimmerService;
            row["unavailableFromDate"] = this.unavailableFromDate;
            row["unavailableUntil"] = this.unavailableUntil;

        }


        public override void FillFields()
        {

            this.codeUnavailableDateForService = Convert.ToInt32(row["codeUnavailableDateForService"]);
            this.codeZimmerService = Convert.ToInt32(row["codeZimmerService"]);
            this.unavailableFromDate = Convert.ToDateTime(row["unavailableFromDate"]);
            this.unavailableUntil =Convert.ToDateTime (row["unavailableUntil"]);

        }
    }
    }
