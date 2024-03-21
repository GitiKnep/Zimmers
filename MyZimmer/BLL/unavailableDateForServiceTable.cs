using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{

    public class unavailableDateForServiceTable : GeneralTable
    {
        public unavailableDateForServiceTable() : base("unavailableDateForService")
        {
            foreach (DataRow item in base.table.Rows)
            {
                list.Add(new unavailableDateForService(item));
            }
        }

        public List<unavailableDateForService> GetList()
        {
            return list.ConvertAll(x => (unavailableDateForService)x);
        }
    }

}
