using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Entities.Concrete.Enum;

public class PictureGetDto : IDto

{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Image { get; set; }
    public Status Status { get; set; }

}
