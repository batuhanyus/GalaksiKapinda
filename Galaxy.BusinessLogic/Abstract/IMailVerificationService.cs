﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Entities;
using Galaxy.Entities.Location;
namespace Galaxy.BusinessLogic.Abstract
{
    public interface IMailVerificationService : IService<MailVerification>
    {
        MailVerification GetByCode(string code);
    }
}
