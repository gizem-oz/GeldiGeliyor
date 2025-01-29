using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Entities.Concrete;
using GeldiGeliyor.Entities.Concrete.Enum;
using System;
using System.Collections.Generic;


namespace GeldiGeliyor.Business.Concrete.Dtos.ProductDtos
{
    public class ProductGetDto : IDto
    {
        public ProductGetDto()
        {
            Pictures = new List<Picture>();
        }
        public int Id { get; set; }
        
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public decimal Price { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<Picture> Pictures { get; set; }
        public Seller Seller { get; set; }//mapping id sorun yaratır mı?
        //seller's properties
        public int SellerId { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public Status SellerStatus { get; set; }
        public Category Category { get; set; }//mapping id sorun yaratır mı?

        //category's properties
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public Status CategoryStatus { get; set; }
        //api de sıkıntı yaşamamak için category ve seller nesnelerinin (ham) propertyleri buraya eklenmiştir.
    }
}