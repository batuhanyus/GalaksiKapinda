using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaxy.DataAccess;

namespace Galaxy.Root.Genesis
{
    public class Genesis
    {
        GalaxyDbContext context;

        public void SeedTheGalaxy()
        {
            context = new();

            ProductWorks pw = new ProductWorks();
            pw.Run(context);
        }
    }
}
