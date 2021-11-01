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

            ProductWorks pw = new();
            pw.Run(context);

            UserWorks uw = new();
            uw.Run(context);

            LocationWorks lw = new();
            lw.Run(context);

            OrderWorks ow = new();
            ow.Run(context);

            CardWorks cw = new();
            cw.Run(context);
        }
    }
}
