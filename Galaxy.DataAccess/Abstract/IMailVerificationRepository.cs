using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Core.DataAccess;
using Galaxy.Entities;
using Galaxy.Entities.Location;

namespace Galaxy.DataAccess.Abstract
{
    public interface IMailVerificationRepository : IRepository<MailVerification>
    {
    }
}
