using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{

    public class zimmerServiceTable : GeneralTable
    {
        public zimmerServiceTable() : base("zimmerService")
        {
            foreach (DataRow item in base.table.Rows)
            {
                list.Add(new zimmerService(item));
            }
        }

        public List<zimmerService> GetList()
        {
            return list.ConvertAll(x => (zimmerService)x);
        }
    }

}
