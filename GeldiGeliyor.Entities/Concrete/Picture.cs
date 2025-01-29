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
    public class Picture : Entity, IMasterBase
    {
        public Picture()
        {
            Status = Status.IsActive;

        }
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Image { get; set; }
        public Status Status { get; set; }



        public Product Product { get; set; }
    }
}
