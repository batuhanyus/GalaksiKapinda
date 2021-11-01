﻿using System;
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

            County c1 = new();
            c1.Name = "Kızılay";
            c1.City = city1;

            County c2 = new();
            c2.Name = "Ulus";
            c2.City = city1;

            County c3 = new();
            c3.Name = "Taksim";
            c3.City = city2;

            context.Cities.Add(city1);
            context.SaveChanges();
            context.Cities.Add(city2);
            context.SaveChanges();

            context.Counties.Add(c1);
            context.SaveChanges();
            context.Counties.Add(c2);
            context.SaveChanges();
            context.Counties.Add(c3);
            context.SaveChanges();

            Address address1 = new();
            address1.MemberID = 1;
            address1.City = city1;
            address1.County = c1;
            address1.AdressDetails = "Ankara-Kızılay adress.";
            address1.AdressNotes = "Some notes regarding Adress 1";

            Address address2 = new();
            address2.MemberID = 1;
            address2.City = city2;
            address2.County = c3;
            address2.AdressDetails = "İstanbul-Taksim adress.";
            address2.AdressNotes = "Some notes regarding Adress 2";

            context.Addresses.Add(address1);
            context.SaveChanges();
            context.Addresses.Add(address2);
            context.SaveChanges();
        }
    }
}
