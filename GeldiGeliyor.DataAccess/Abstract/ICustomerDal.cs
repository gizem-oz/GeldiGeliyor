using GeldiGeliyor.Core.DataAccess;
using GeldiGeliyor.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.DataAccess.Abstract
{
    public interface ICustomerDal:IRepositoryBase<Customer>
    {
        Task< Customer> CustomerOrdersAsync(Expression<Func<Customer,bool>>expression);
        Task<List< Customer>> AllCustomerOrdersAsync(Expression<Func<Customer,bool>>expression=null);
    }
}
