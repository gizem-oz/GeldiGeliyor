using GeldiGeliyor.Core.DataAccess;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.DataAccess.Concrete.EFCore.Context;
using GeldiGeliyor.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.DataAccess.Concrete.EFCore
{
    public class SellerDal : RepositoryBase<Seller>, ISellerDal
    {
        public SellerDal(GeldiGeliyorDbContext context):base(context) 
        {
            
        }
        public async Task<List<Seller>> SellersWithProductAsync(Expression<Func<Seller, bool>> expression = null)
        {
            return expression != null ? await _set.Include(x => x.Products).Where(expression).ToListAsync() : await _set.Include(x => x.Products).ToListAsync();
        }

        public async Task<Seller> SellerWithProductAsync(Expression<Func<Seller, bool>> expression)
        {
            return await _set.Include(x=>x.Products).FirstOrDefaultAsync(expression);
        }
    }
}
