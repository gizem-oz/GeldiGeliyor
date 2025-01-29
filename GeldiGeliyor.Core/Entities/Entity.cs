using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.Core.Entities
{
    public abstract class Entity : IEntity
    {
        public DateTime CreateDate { get; set ; } =DateTime.Now;
        public DateTime UpdateDate { get ; set ; }=DateTime.Now;
        public DateTime? DeleteDate { get; set; } = null;
    }
}
