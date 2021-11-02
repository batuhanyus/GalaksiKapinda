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
            return creditCardRepository.GetAll().ToList();
        }

        public CreditCard GetByID(int entityID)
        {
            return creditCardRepository.GetAll().Where(a => a.ID == entityID).SingleOrDefault();
        }

        public CreditCard GetByIDByOwner(int userID, int iD)
        {
            return creditCardRepository.GetAll().Where(a => a.MemberID == userID && a.ID == iD).SingleOrDefault();
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
            return creditCardRepository.Update(oldEntity, newEntity);
        }
    }
}
