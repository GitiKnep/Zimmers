using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{

    public class rentingTable : GeneralTable
    {
        public rentingTable() : base("renting")
        {
            foreach (DataRow item in base.table.Rows)
            {
                list.Add(new renting(item));
            }
        }

        public List<renting> GetList()
        {
            return list.ConvertAll(x => (renting)x);
        }
    }

}
