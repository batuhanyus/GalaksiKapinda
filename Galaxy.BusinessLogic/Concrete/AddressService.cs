using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.BusinessLogic.Abstract;
using Galaxy.DataAccess.Abstract;
using Galaxy.Entities.Location;

namespace Galaxy.BusinessLogic.Concrete
{
    public class AddressService : IAddressService
    {
        IAddressRepository addressRepository;

        public AddressService(IAddressRepository repository)
        {
            addressRepository = repository;
        }

        public int Delete(Address entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Address> GetAll()
        {
            throw new NotImplementedException();
        }

        public Address GetByID(int entityID)
        {
            try
            {
                return addressRepository.GetAll().Where(a => a.ID == entityID).Single();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Address GetByIDByOwner(int userID, int ID)
        {
            try
            {
                return addressRepository.GetAll().Where(a => a.MemberID == userID && a.ID == ID).Single();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ICollection<Address> GetByOwner(int userID)
        {
            return addressRepository.GetAll().Where(a => a.MemberID == userID).ToList();
        }

        public int Insert(Address entity)
        {
            //Validation
            if (entity.MemberID == 0)
                return 0;
            if (entity.CityID == 0)
                return 0;
            if (entity.CountyID == 0)
                return 0;
            if (entity.Name == null || entity.Name == string.Empty)
                return 0;
            

            return addressRepository.Insert(entity);
        }

        public int Update(Address oldEntity, Address newEntity)
        {
            //Validation
            if (newEntity.MemberID == 0)
                return 0;
            if (newEntity.CityID == 0)
                return 0;
            if (newEntity.CountyID == 0)
                return 0;
            if (newEntity.Name == null || newEntity.Name == string.Empty)
                return 0;

            return addressRepository.Update(oldEntity, newEntity);
        }
    }
}
