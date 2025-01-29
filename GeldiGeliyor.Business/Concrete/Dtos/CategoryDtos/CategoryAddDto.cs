using GeldiGeliyor.Business.Abstract;


namespace GeldiGeliyor.Business.Concrete.Dtos.CategoryDtos
{
    public class CategoryAddDto : IDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
