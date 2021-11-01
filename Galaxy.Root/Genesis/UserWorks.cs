using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Galaxy.DataAccess;
using Galaxy.Entities.UserTypes;

namespace Galaxy.Root.Genesis
{
    class UserWorks
    {
        internal void Run(GalaxyDbContext context)
        {
            Employee admin = new();
            admin.UserType = 3;
            admin.BirthDate = DateTime.Now;
            admin.Mail = "admin@gk.com";
            admin.Name = "Mr.";
            admin.Surname = "Admin";
            admin.Password = "admin";
            admin.Phone = 5399522131;

            Employee packager1 = new();
            packager1.UserType = 2;
            packager1.BirthDate = DateTime.Now;
            packager1.Mail = "packager1@gk.com";
            packager1.Name = "Packager";
            packager1.Surname = "1";
            packager1.Password = "packager1";
            packager1.Phone = 5399522131;

            Employee deliverer1 = new();
            deliverer1.UserType = 1;
            deliverer1.BirthDate = DateTime.Now;
            deliverer1.Mail = "deliverer1@gk.com";
            deliverer1.Name = "Deliverer";
            deliverer1.Surname = "1";
            deliverer1.Password = "deliverer1";
            deliverer1.Phone = 5399522131;

            Employee deliverer2 = new();
            deliverer2.UserType = 1;
            deliverer2.BirthDate = DateTime.Now;
            deliverer2.Mail = "deliverer2@gk.com";
            deliverer2.Name = "Deliverer";
            deliverer2.Surname = "2";
            deliverer2.Password = "deliverer2";
            deliverer2.Phone = 5399522131;            

            context.Employees.Add(admin);
            context.SaveChanges();
            context.Employees.Add(packager1);
            context.SaveChanges();
            context.Employees.Add(deliverer1);
            context.SaveChanges();
            context.Employees.Add(deliverer2);
            context.SaveChanges();

            Member member1 = new();
            member1.IsMailVerified = true;
            member1.UserType = 0;
            member1.Mail = "member1@gk.com";
            member1.Name = "Member";
            member1.Surname = "1";
            member1.Password = "member1";

            context.Members.Add(member1);
            context.SaveChanges();            
        }
    }
}
