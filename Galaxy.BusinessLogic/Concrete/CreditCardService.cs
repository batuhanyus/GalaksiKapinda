using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.DataAccess.Abstract;
using Galaxy.DataAccess.Concrete;
using Galaxy.Entities;

namespace Galaxy.BusinessLogic.Concrete
{
    public class CreditCardService : ICreditCardService
    {
        ICreditCardRepository creditCardRepository;

        public CreditCardService(ICreditCardRepository repository)
        {
            creditCardRepository = repository;
        }

        public int Delete(CreditCard entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<CreditCard> GetAll()
        {
            throw new NotImplementedException();
        }

        public CreditCard GetByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public CreditCard GetCardByOwner(int ownerID)
{
            return creditCardRepository.GetAll().Where(a => a.MemberID == ownerID).SingleOrDefault();
        }

        public int Insert(CreditCard entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CreditCard entity)
        {
            throw new NotImplementedException();
        }

        public int Update(CreditCard oldEntity, CreditCard newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
