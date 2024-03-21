using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
  
        public class tenantTable : GeneralTable
        {
            public tenantTable() : base("tenant")
            {
                foreach (DataRow item in base.table.Rows)
                {
                    list.Add(new tenant(item));
                }
            }

            public List<tenant> GetList()
            {
                return list.ConvertAll(x => (tenant)x);
            }
        }
    
}
