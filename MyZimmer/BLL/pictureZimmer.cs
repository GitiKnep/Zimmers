using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class pictureZimmer : GeneralRow
    {
        public int codePicture { get; set; }
        public string myPicture { get; set; }
        public int codeZimmer { get; set; }

        public pictureZimmer() : base()
        {

        }
        public pictureZimmer(DataRow row) : base(row)
        {

        }


        public override void FillDataRow()
        {
            row["codePicture"] = this.codePicture;
            row["myPicture"] = this.myPicture;
            row["codeZimmer"] = this.codeZimmer;

        }


        public override void FillFields()
        {

            this.codePicture = Convert.ToInt32(row["codePicture"]);
            this.myPicture = row["myPicture"].ToString();
            this.codeZimmer = Convert.ToInt32(row["codeZimmer"]);

        }

    }
}

