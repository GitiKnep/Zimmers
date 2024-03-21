using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{

    public class includeInZimmerTable : GeneralTable
    {
        public includeInZimmerTable() : base("includeInZimmer")
        {
            foreach (DataRow item in base.table.Rows)
            {
                list.Add(new includeInZimmer(item));
            }
        }

        public List<includeInZimmer> GetList()
        {
            return list.ConvertAll(x => (includeInZimmer)x);
        }
    }

}
