﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.Model.UserTypes
{
    public sealed class Member : BaseUser
    {
        public bool IsMailVerified { get; set; }
    }
}