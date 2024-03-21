using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{

    public class rentZimmerTable : GeneralTable
    {
        public rentZimmerTable() : base("rentZimmer")
        {
            foreach (DataRow item in base.table.Rows)
            {
                list.Add(new rentZimmer(item));
            }
        }

        public List<rentZimmer> GetList()
        {
            return list.ConvertAll(x => (rentZimmer)x);
        }
    }

}
