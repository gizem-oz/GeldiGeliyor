using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Entities.Concrete;
using GeldiGeliyor.Entities.Concrete.Enum;


public class PictureWithProductDto : IDto

{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string Image { get; set; }
    public DateTime DateTime { get; set; }
    public DateTime CreateDate { get; set; }
    public Status Status { get; set; }
    public Product Product { get; set; }

}
