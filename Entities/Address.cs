using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public sealed class Address
    {
        public int AdressID { get; set; }
        public int UserID { get; set; }
        public int CityID { get; set; }
        public int CountyID { get; set; }
        public string AdressDetails { get; set; }
        public string AdressNotes { get; set; }
    }
}
