using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

            City city3 = new();
            city3.Name = "Tatooine";

            County c1 = new();
            c1.Name = "Kızılay";
            c1.CityID = 1;

            County c2 = new();
            c2.Name = "Ulus";
            c2.CityID = 1;

            County c3 = new();
            c3.Name = "Taksim";
            c3.CityID = 2;

            County c4 = new();
            c4.Name = "Kadıköy";
            c4.CityID = 2;

            County c5 = new();
            c5.Name = "Mos Eisley";
            c5.CityID = 3;

            context.Cities.Add(city1);
            context.SaveChanges();
            context.Cities.Add(city2);
            context.SaveChanges();
            context.Cities.Add(city3);
            context.SaveChanges();

            context.Counties.Add(c1);
            context.SaveChanges();
            context.Counties.Add(c2);
            context.SaveChanges();
            context.Counties.Add(c3);
            context.SaveChanges();
            context.Counties.Add(c4);
            context.SaveChanges();

            Address address1 = new();
            address1.MemberID = 1;
            address1.CityID = 1;
            address1.CountyID = 1;
            address1.AdressDetails = "Ankara-Kızılay address.";
            address1.AdressNotes = "Some notes regarding Address 1";
            address1.Name = "MyAddress1";

            Address address2 = new();
            address2.MemberID = 1;
            address2.CityID = 2;
            address2.CountyID = 3;
            address2.AdressDetails = "İstanbul-Taksim address.";
            address2.AdressNotes = "Some notes regarding Address 2";
            address2.Name = "MyAddress1";

            context.Addresses.Add(address1);
            context.SaveChanges();
            context.Addresses.Add(address2);
            context.SaveChanges();
        }
    }
}
