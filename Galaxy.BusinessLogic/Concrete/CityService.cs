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
            return cityRepository.GetAll();
        }

        public City GetByID(int entityID)
        {
            return cityRepository.GetByID(entityID);
        }

        public City GetCityByName(string name)
        {
            try
            {
                return cityRepository.GetAll().Where(a => a.Name == name).Single();
            }
            catch (Exception)
            {

                throw;
            }
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
