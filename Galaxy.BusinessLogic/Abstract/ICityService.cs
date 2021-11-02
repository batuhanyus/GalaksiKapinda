using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.Entities.Location;

namespace Galaxy.BusinessLogic.Abstract
{
    public interface ICityService : IService<City>
    {
        City GetCityByName(string name);
    }
}
