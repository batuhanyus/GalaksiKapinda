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
            try
            {
                return creditCardRepository.GetAll().Where(a => a.ID == entityID).Single();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CreditCard GetByIDByOwner(int userID, int iD)
        {
            try
            {
                return creditCardRepository.GetAll().Where(a => a.MemberID == userID && a.ID == iD).Single();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public CreditCard GetCardByOwner(int ownerID)
        {
            try
            {
                return creditCardRepository.GetAll().Where(a => a.MemberID == ownerID).Single();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Insert(CreditCard entity)
        {
            if (creditCardRepository.GetAll().Where(a => a.CardHolderName == entity.CardHolderName && a.CardNumber == entity.CardNumber).ToList().Count > 0)
                return 0;
            if (entity.CardNumber < 1000000000000000)
                return 0;
            if (entity.CardHolderName == null || entity.CardHolderName == string.Empty)
                return 0;
            if (entity.CVC < 100)
                return 0;
            if (entity.ExpireDate.Year < DateTime.Now.Year)
                return 0;

            return creditCardRepository.Insert(entity);

            
        }

        public int Update(CreditCard oldEntity, CreditCard newEntity)
        {
            if (creditCardRepository.GetAll().Where(a => a.CardHolderName == newEntity.CardHolderName && a.CardNumber == newEntity.CardNumber).ToList().Count > 0)
                return 0;
            if (newEntity.CardNumber < 1000000000000000)
                return 0;
            if (newEntity.CardHolderName == null || newEntity.CardHolderName == string.Empty)
                return 0;
            if (newEntity.CVC < 100)
                return 0;
            if (newEntity.ExpireDate.Year < DateTime.Now.Year)
                return 0;

            return creditCardRepository.Update(oldEntity, newEntity);
        }
    }
}
