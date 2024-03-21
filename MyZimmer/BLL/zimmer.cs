using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class zimmer : GeneralRow
    {
        public int codeZimmer { get; set; }
        public int codeRenting { get; set; }
        public string streetZimmer { get; set; }
        public int numberOfHouseZimmer { get; set; }
        public int codeCity { get; set; }
        public int priceNightZimmer { get; set; }
        public int numberOfBedZimmer { get; set; }
        public string nameZimmer { get; set; }
        public bool status { get; set; }


        public zimmer() : base()
        {

        }
        public zimmer(DataRow row) : base(row)
        {

        }
        public city ThisCity
        {
            get { return MyDB.city.GetList().FirstOrDefault(x => x.codeCity == this.codeCity); }
        }
        public renting ThisRenting
        {
            get { return MyDB.renting.GetList().FirstOrDefault(x => x.codeRenting == this.codeRenting); }
        }


        public override void FillDataRow()
        {
            row["codeZimmer"] = this.codeZimmer;
            row["codeRenting"] = this.codeRenting;
            row["streetZimmer"] = this.streetZimmer;
            row["numberOfHouseZimmer"] = this.numberOfHouseZimmer;
            row["codeCity"] = this.codeCity;
            row["priceNightZimmer"] = this.priceNightZimmer;
            row["numberOfBedZimmer"] = this.numberOfBedZimmer;
            row["nameZimmer"] = this.nameZimmer;
            row["status"] = this.status;
            
        }


        public override void FillFields()
        {

            this.codeZimmer = Convert.ToInt32(row["codeZimmer"]);
            this.codeRenting = Convert.ToInt32(row["codeRenting"]);
            this.streetZimmer = row["streetZimmer"].ToString();
            this.numberOfHouseZimmer = Convert.ToInt32(row["numberOfHouseZimmer"]);
            this.codeCity = Convert.ToInt32(row["codeCity"]);
            this.priceNightZimmer = Convert.ToInt32(row["priceNightZimmer"]);
            this.numberOfBedZimmer = Convert.ToInt32(row["numberOfBedZimmer"]);
            this.nameZimmer = row["nameZimmer"].ToString();
            this.status = Convert.ToBoolean(row["status"]);


        }

    }
}
