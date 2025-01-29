using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Entities.Concrete.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.Business.Concrete.Dtos.CategoryDtos
{
    public class CategoryGetDto:IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; } 
        public DateTime CreateDate { get; set; }
        public DateTime DeleteDate { get; set; }
        public Status Status{ get; set; }
    }
}
