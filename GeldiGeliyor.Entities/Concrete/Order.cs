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
    public class Order:Entity, IMasterBase
    {
        public Order()
        {
            Status = Status.IsActive;
            OrderDetails= new List<OrderDetail>();

        }
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate{ get; set; }
        public DateTime DeliveryDate{ get; set; }
        public Status  Status{ get; set; }

        public Customer Customer { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }



    }
}
