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
    public class Customer:Entity, IMasterBase
    {
        public Customer()
        {
            Status = Status.IsActive;
            Orders= new List<Order>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public Status  Status{ get; set; }


        public City City { get; set; }
        public ICollection<Order> Orders { get; set; }
        public AppUser AppUser { get; set; }

    }
}
