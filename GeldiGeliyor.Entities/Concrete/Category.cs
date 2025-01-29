using GeldiGeliyor.Core.Entities;
using GeldiGeliyor.Entities.Abstract;
using GeldiGeliyor.Entities.Concrete.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.Entities.Concrete
{
    public class Category : Entity, IMasterBase
    {
        public Category()
        {
            Status = Status.IsActive;
            Products= new List<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }


        public ICollection<Product> Products { get; set; }
    }
}
