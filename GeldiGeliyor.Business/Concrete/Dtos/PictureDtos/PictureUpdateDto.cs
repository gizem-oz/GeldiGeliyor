using GeldiGeliyor.Business.Abstract;
using System;

public class PictureUpdateDto : IDto

{
    
    public int ProductId { get; set; }
    public string Image { get; set; }
    public DateTime DateTime { get; set; } 
}
