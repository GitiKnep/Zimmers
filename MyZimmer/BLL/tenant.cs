using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public class tenant : GeneralRow
    {
        public int codeTenant { get; set; }
        public string fNameTenant { get; set; }
        public string lNameTenant { get; set; }
        private string telTenant;
        public string TelTenant
        {
            get { return telTenant; }
            set
            {
                if (Validation.IsTel(value)|| Validation.IsPelepon(value))
                    telTenant = value;
                else
                    throw new Exception("מספר הטלפון אינו תקין ");
            }
        }
        private string emailAddressTenant;
        public string EmailAddressTenant
        {
            get { return emailAddressTenant; }
            set
            {
                if (Validation.IsMail(value))
                    emailAddressTenant = value;
                else
                    throw new Exception("המייל שהוקש אינו תקין ");
            }
        }
        public string passwordTenant { get; set; }

        public tenant() : base()
        {

        }
        public tenant(DataRow row) : base(row)
        {

        }

       
        public override void FillDataRow()
        {
            row["codeTenant"] = this.codeTenant;
            row["fNameTenant"] = this.fNameTenant;
            row["lNameTenant"] = this.lNameTenant;
            row["telTenant"] = this.telTenant;
            row["emailAddressTenant"] = this.emailAddressTenant;
            row["passwordTenant"] = this.passwordTenant;
           
        }

       
        public override void FillFields()
        {
           
            this.codeTenant = Convert.ToInt32(row["codeTenant"]);
            this.fNameTenant = row["fNameTenant"].ToString();
            this.lNameTenant = row["lNameTenant"].ToString();
            this.telTenant = row["telTenant"].ToString();
            this.emailAddressTenant = row["emailAddressTenant"].ToString();
            this.passwordTenant = row["passwordTenant"].ToString();
            

        }
       
    }
}
