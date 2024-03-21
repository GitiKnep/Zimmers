using System;
using System.Collections.Generic; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyZimmer.BLL
{
    enum FormStatus { add, update };
    public static class MyDB
    {
        public static areaTable area = new areaTable();
        public static cityTable city = new cityTable();
        public static commentTable comment = new commentTable();
        public static includeInZimmerTable includeInZimmer = new includeInZimmerTable();
        public static includeMyZimmerTable includeMyZimmer = new includeMyZimmerTable();
        public static rentingTable renting = new rentingTable();
        public static rentZimmerTable rentZimmer = new rentZimmerTable();
        public static tenantTable tenant = new tenantTable();
        public static zimmerTable zimmer = new zimmerTable();
        public static pictureZimmerTable pictureZimmer = new pictureZimmerTable();
        public static serviceTable service = new serviceTable();
        public static serviceOrderTable serviceOrder = new serviceOrderTable();
        public static zimmerServiceTable zimmerService = new zimmerServiceTable();
        public static unavailableDateForServiceTable unavailableDateForService = new unavailableDateForServiceTable();

       
    }
}
