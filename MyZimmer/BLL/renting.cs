using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class renting : GeneralRow
    {
        public int codeRenting { get; set; }
        public string fNameRenting { get; set; }
        public string lNameRenting { get; set; }
        private string telRenting;
        public string TelRenting
        {
            get { return telRenting; }
            set
            {
                if (Validation.IsTel(value) || Validation.IsPelepon(value))
                    telRenting = value;
                else
                    throw new Exception("מספר הטלפון אינו תקין ");
            }
        }
        private string emailAddressRenting;
        public string EmailAddressRenting
        {
            get { return emailAddressRenting; }
            set
            {
                if (Validation.IsMail(value))
                    emailAddressRenting = value;
                else
                    throw new Exception("המייל שהוקש אינו תקין ");
            }
        }
        public string passwordRenting { get; set; }

        public renting() : base()
        {

        }
        public renting(DataRow row) : base(row)
        {

        }


        public override void FillDataRow()
        {
            row["codeRenting"] = this.codeRenting;
            row["fNameRenting"] = this.fNameRenting;
            row["lNameRenting"] = this.lNameRenting;
            row["telRenting"] = this.telRenting;
            row["emailAddressRenting"] = this.emailAddressRenting;
            row["passwordRenting"] = this.passwordRenting;

        }


        public override void FillFields()
        {

            this.codeRenting = Convert.ToInt32(row["codeRenting"]);
            this.fNameRenting = row["fNameRenting"].ToString();
            this.lNameRenting = row["lNameRenting"].ToString();
            this.telRenting = row["telRenting"].ToString();
            this.emailAddressRenting = row["emailAddressRenting"].ToString();
            this.passwordRenting = row["passwordRenting"].ToString();

        }
        

    }
}
