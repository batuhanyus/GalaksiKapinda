using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.DataAccess;
using Galaxy.Entities.Location;

namespace Galaxy.Root.Genesis
{
    class LocationWorks
    {
        internal void Run(GalaxyDbContext context)
        {
            City city1 = new();
            city1.Name = "Ankara";

            City city2 = new();
            city2.Name = "İstanbul";

            County c1 = new();
            c1.Name = "Kızılay";
            c1.City = city1;

            County c2 = new();
            c1.Name = "Ulus";
            c1.City = city1;

            County c3 = new();
            c1.Name = "Taksim";
            c1.City = city2;

            context.Cities.Add(city1);
            context.Cities.Add(city2);

            context.Counties.Add(c1);
            context.Counties.Add(c2);
            context.Counties.Add(c3);

            context.SaveChanges();

            Address address1 = new();
            address1.MemberID = 0;
            address1.City = city1;
            address1.County = c1;
            address1.AdressDetails = "Ankara-Kızılay adress.";
            address1.AdressNotes = "Some notes regarding Adress 1";

            Address address2 = new();
            address1.MemberID = 0;
            address1.City = city2;
            address1.County = c3;
            address1.AdressDetails = "İstanbul-Taksim adress.";
            address1.AdressNotes = "Some notes regarding Adress 2";

            context.Addresses.Add(address1);
            context.Addresses.Add(address2);

            context.SaveChanges();
        }
    }
}
