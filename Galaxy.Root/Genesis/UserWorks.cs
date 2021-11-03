using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Galaxy.DataAccess;
using Galaxy.Entities;

namespace Galaxy.Root.Genesis
{
    class UserWorks
    {
        internal void Run(GalaxyDbContext context)
        {
            User admin = new();
            admin.UserType = 4;
            admin.BirthDate = DateTime.Now;
            admin.Mail = "admin@gk.com";
            admin.Name = "Mr.";
            admin.Surname = "Admin";
            admin.Password = "admin";
            admin.Phone = 5399522131;
            admin.IsMailVerified = true;
            admin.IsPasswordValid = true;
            admin.IsActive = true;

            User packager1 = new();
            packager1.UserType = 3;
            packager1.BirthDate = DateTime.Now;
            packager1.Mail = "packager1@gk.com";
            packager1.Name = "Packager";
            packager1.Surname = "1";
            packager1.Password = "packager1";
            packager1.Phone = 5399522131;
            packager1.IsMailVerified = true;
            packager1.IsPasswordValid = true;
            packager1.IsActive = true;

            User deliverer1 = new();
            deliverer1.UserType = 2;
            deliverer1.BirthDate = DateTime.Now;
            deliverer1.Mail = "deliverer1@gk.com";
            deliverer1.Name = "Deliverer";
            deliverer1.Surname = "1";
            deliverer1.Password = "deliverer1";
            deliverer1.Phone = 5399522131;
            deliverer1.IsMailVerified = true;
            deliverer1.IsPasswordValid = true;
            deliverer1.IsActive = true;

            User deliverer2 = new();
            deliverer2.UserType = 2;
            deliverer2.BirthDate = DateTime.Now;
            deliverer2.Mail = "deliverer2@gk.com";
            deliverer2.Name = "Deliverer";
            deliverer2.Surname = "2";
            deliverer2.Password = "deliverer2";
            deliverer2.Phone = 5399522131;
            deliverer2.IsMailVerified = true;
            deliverer2.IsPasswordValid = false;
            deliverer2.IsActive = true;

            context.Users.Add(admin);
            context.SaveChanges();
            context.Users.Add(packager1);
            context.SaveChanges();
            context.Users.Add(deliverer1);
            context.SaveChanges();
            context.Users.Add(deliverer2);
            context.SaveChanges();

            User member1 = new();
            member1.IsMailVerified = true;
            member1.IsPasswordValid = true;
            member1.UserType = 1;
            member1.Mail = "member1@gk.com";
            member1.Name = "Member";
            member1.Surname = "1";
            member1.Password = "member1";
            member1.IsActive = true;

            context.Users.Add(member1);
            context.SaveChanges();            
        }
    }
}
