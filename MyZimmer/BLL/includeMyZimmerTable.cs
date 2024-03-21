using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{

    public class includeMyZimmerTable : GeneralTable
    {
        public includeMyZimmerTable() : base("includeMyZimmer")
        {
            foreach (DataRow item in base.table.Rows)
            {
                list.Add(new includeMyZimmer(item));
            }
        }

        public List<includeMyZimmer> GetList()
        {
            return list.ConvertAll(x => (includeMyZimmer)x);
        }
    }

}
