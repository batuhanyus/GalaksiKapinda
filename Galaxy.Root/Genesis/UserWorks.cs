using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            admin.EmployeeType = 2;
            admin.BirthDate = DateTime.Now;
            admin.Mail = "admin@gk.com";
            admin.Name = "Mr.";
            admin.Surname = "Admin";
            admin.Password = "admin";
            admin.Phone = 5399522131;

            Employee packager1 = new();
            admin.EmployeeType = 1;
            admin.BirthDate = DateTime.Now;
            admin.Mail = "packager1@gk.com";
            admin.Name = "Packager";
            admin.Surname = "1";
            admin.Password = "packager1";
            admin.Phone = 5399522131;

            Employee deliverer1 = new();
            admin.EmployeeType = 0;
            admin.BirthDate = DateTime.Now;
            admin.Mail = "deliverer1@gk.com";
            admin.Name = "Deliverer";
            admin.Surname = "1";
            admin.Password = "deliverer1";
            admin.Phone = 5399522131;

            Employee deliverer2 = new();
            admin.EmployeeType = 0;
            admin.BirthDate = DateTime.Now;
            admin.Mail = "deliverer2@gk.com";
            admin.Name = "Deliverer";
            admin.Surname = "2";
            admin.Password = "deliverer2";
            admin.Phone = 5399522131;            

            context.Employees.Add(admin);
            context.Employees.Add(packager1);
            context.Employees.Add(deliverer1);
            context.Employees.Add(deliverer2);

            Member member1 = new();
            member1.IsMailVerified = true;
            member1.Mail = "member1@gk.com";
            member1.Name = "Member";
            member1.Surname = "1";
            member1.Password = "member1";

            context.Members.Add(member1);

            context.SaveChanges();
        }
    }
}
