using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.Core.Entities
{
    public interface IEntity
    {
        DateTime CreateDate { get; set; }
        DateTime UpdateDate { get; set; }
        DateTime? DeleteDate { get; set; }
    }
}
