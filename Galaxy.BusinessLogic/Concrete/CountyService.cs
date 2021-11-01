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
    public class CountyService : ICountyService
    {
        ICountyRepository countyRepository;

        public CountyService(ICountyRepository repository)
        {
            countyRepository = repository;
        }

        public int Delete(County entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<County> GetAll()
        {
            throw new NotImplementedException();
        }

        public County GetByID(int entityID)
        {
            throw new NotImplementedException();
        }

        public int Insert(County entity)
        {
            throw new NotImplementedException();
        }

        public int Update(County entity)
        {
            throw new NotImplementedException();
        }
    }
}
