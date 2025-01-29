
using Microsoft.AspNetCore.Identity;

namespace GeldiGeliyor.Entities.Concrete
{
    public class AppUser:IdentityUser<int>
    {
        
        public Seller Seller { get; set; }
        public Customer Customer { get; set; }

        
    }
}
