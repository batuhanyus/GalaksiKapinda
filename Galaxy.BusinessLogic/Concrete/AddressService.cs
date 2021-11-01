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
            return addressRepository.GetAll().Where(a => a.ID == entityID).SingleOrDefault();
        }

        public Address GetByIDByOwner(int userID, int ID)
        {
            return addressRepository.GetAll().Where(a => a.MemberID == userID && a.ID == ID).SingleOrDefault();
        }

        public ICollection<Address> GetByOwner(int userID)
        {
            return addressRepository.GetAll().Where(a => a.MemberID == userID).ToList();
        }

        public int Insert(Address entity)
        {
            return addressRepository.Insert(entity);
        }

        public int Update(Address oldEntity, Address newEntity)
        {
            return addressRepository.Update(oldEntity, newEntity);
        }
    }
}
