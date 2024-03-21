using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class comment : GeneralRow
    {
        public int codeComment{ get; set; }
        public int codeZimmer{ get; set; }
        public string dateOfComment { get; set; }
        public int ratingComment { get; set; }
        public string noteComment { get; set; }
     
        public comment() : base()
        {

        }
        public comment(DataRow row) : base(row)
        {

        }


        public override void FillDataRow()
        {
            row["codeComment"] = this.codeComment;
            row["codeZimmer"] = this.codeZimmer;
            row["dateOfComment"] = this.dateOfComment;
            row["ratingComment"] = this.ratingComment;
            row["noteComment"] = this.noteComment;

        }


        public override void FillFields()
        {

            this.codeComment = Convert.ToInt32(row["codeComment"]);
            this.codeZimmer = Convert.ToInt32(row["codeZimmer"]);
            this.dateOfComment = row["dateOfComment"].ToString();
            this.ratingComment = Convert.ToInt32(row["ratingComment"]);
            this.noteComment = row["noteComment"].ToString();
          
        }
        
    }
}
