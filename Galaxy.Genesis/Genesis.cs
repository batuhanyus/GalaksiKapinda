using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.DataAccess;

namespace Galaxy.Genesis
{
    public class Genesis
    {
        public void SeedTheGalaxy(GalaxyDbContext context)
        {
            ProductWorks pw = new ProductWorks();
            pw.Run(context);
        }
    }
}
