using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Entities;

namespace Galaxy.BusinessLogic.Abstract
{
    public interface ICreditCardService : IService<CreditCard>
    {
        CreditCard GetCardByOwner(int ownerID);
        CreditCard GetByIDByOwner(int userID, int iD);
    }
}
