﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.Entity;

namespace Galaxy.Entities
{
    public sealed class User: BaseEntity
    {
        public string Mail { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        /// <summary>
        /// 0=Member 1=Deliverer, 2=Packager, 3=Admin
        /// </summary>
        public int UserType { get; set; }

        //Member related.
        public bool IsMailVerified { get; set; }

        //Employee related.
        public DateTime BirthDate { get; set; }
        public long Phone { get; set; }
        public bool IsPasswordValid { get; set; }
    }
}