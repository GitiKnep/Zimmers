using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{

    public class serviceTable : GeneralTable
    {
        public serviceTable() : base("service")
        {
            foreach (DataRow item in base.table.Rows)
            {
                list.Add(new service(item));
            }
        }

        public List<service> GetList()
        {
            return list.ConvertAll(x => (service)x);
        }
    }

}
