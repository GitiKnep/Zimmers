using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{

    public class serviceOrderTable : GeneralTable
    {
        public serviceOrderTable() : base("serviceOrder")
        {
            foreach (DataRow item in base.table.Rows)
            {
                list.Add(new serviceOrder(item));
            }
        }

        public List<serviceOrder> GetList()
        {
            return list.ConvertAll(x => (serviceOrder)x);
        }
    }

}
