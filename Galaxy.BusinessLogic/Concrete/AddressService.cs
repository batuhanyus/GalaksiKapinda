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
            throw new NotImplementedException();
        }

        public int Insert(Address entity)
        {
            throw new NotImplementedException();
        }

        public int Update(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}
