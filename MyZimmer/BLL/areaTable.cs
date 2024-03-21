using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{

    public class areaTable : GeneralTable
    {
        public areaTable() : base("area")
        {
            foreach (DataRow item in base.table.Rows)
            {
                list.Add(new area(item));
            }
        }

        public List<area> GetList()
        {
            return list.ConvertAll(x => (area)x);
        }
    }

}
