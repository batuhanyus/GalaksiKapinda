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
    public class CityService : ICityService
    {
        ICityRepository cityRepository;

        public CityService(ICityRepository repository)
        {
            cityRepository = repository;
        }

        public int Delete(City entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<City> GetAll()
        {
            throw new NotImplementedException();
        }

        public City GetByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public int Insert(City entity)
        {
            throw new NotImplementedException();
        }

        public int Update(City oldEntity, City newEntity)
        {
            throw new NotImplementedException();
        }
    }
}
