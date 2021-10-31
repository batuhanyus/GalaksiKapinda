﻿using Galaxy.Core.DataAccess.EF;
using Galaxy.DataAccess.Abstract;
using Galaxy.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxy.DataAccess.Concrete
{
    public class EFCategoryRepository : EFRepositoryBase<Category, GalaxyDbContext> ,ICategoryRepository
    {
    }
}
