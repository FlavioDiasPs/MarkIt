using Dapper;
using MarkIt.Core.Entities;
using MarkIt.Core.Interfaces.DbContext;
using MarkIt.Core.Interfaces.Repositories;
using MarkIt.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MarkIt.Infra.Data.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {        
        public ProductRepository(IDbContext context) : base(context)
        {            
        }
    }
}
