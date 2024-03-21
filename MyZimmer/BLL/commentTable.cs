using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{

    public class commentTable : GeneralTable
    {
        public commentTable() : base("comment")
        {
            foreach (DataRow item in base.table.Rows)
            {
                list.Add(new comment(item));
            }
        }

        public List<comment> GetList()
        {
            return list.ConvertAll(x => (comment)x);
        }
    }

}
