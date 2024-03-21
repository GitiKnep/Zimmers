using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{

    public class zimmerTable : GeneralTable
    {
        public zimmerTable() : base("zimmer")
        {
            foreach (DataRow item in base.table.Rows)
            {
                list.Add(new zimmer(item));
            }
        }

        public List<zimmer> GetList()
        {
            return list.ConvertAll(x => (zimmer)x);
        }
    }

}

