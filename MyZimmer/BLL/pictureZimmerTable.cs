using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{

    public class pictureZimmerTable : GeneralTable
    {
        public pictureZimmerTable() : base("pictureZimmer")
        {
            foreach (DataRow item in base.table.Rows)
            {
                list.Add(new pictureZimmer(item));
            }
        }

        public List<pictureZimmer> GetList()
        {
            return list.ConvertAll(x => (pictureZimmer)x);
        }
    }

}