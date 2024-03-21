using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MyZimmer.BLL
{
    public abstract class GeneralRow
    {
        public DataRow row;

        public GeneralRow()
        {

        }

        public GeneralRow(DataRow row)
        {
            this.row = row;
            FillFields();
        }
       public abstract void FillFields();

        public abstract void FillDataRow();
    }
}
