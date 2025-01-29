using GeldiGeliyor.Core.Entities;
using GeldiGeliyor.Entities.Abstract;
using GeldiGeliyor.Entities.Concrete.Enum;
namespace GeldiGeliyor.Entities.Concrete
{
    public partial class City: Entity, IMasterBase
    {
        public City()
        {
            Status = Status.IsActive;
            Customers= new List<Customer> ();
        }
    }
    public partial class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  Status Status{ get; set; }
    }

    public partial class City
    {
        public ICollection<Customer> Customers { get; set; }
    }
}
