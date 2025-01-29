using GeldiGeliyor.Core.Entities;
using GeldiGeliyor.Entities.Abstract;
using GeldiGeliyor.Entities.Concrete.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.Entities.Concrete
{
    public class Product : Entity, IMasterBase
    {
        public Product()
        {
            Status = Status.IsActive;
            OrderDetails = new List<OrderDetail>();
        }
        public Product(int sellerId, int categoryId, string name, string description, int stockAmount, decimal price, List<OrderDetail> orderDetails = null)
        {
            this.SellerId = sellerId;
            this.CategoryId = categoryId;
            this.Name = name;
            this.Description = description;
            this.StockAmount = stockAmount;
            this.Price = price;
            this.OrderDetails = orderDetails;
            Status = Status.IsActive;
        }

        public int Id { get; set; }
        public int SellerId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockAmount { get; set; }
        public decimal Price { get; set; }
        public Status Status { get; set; }

        //relational properties

        public Seller Seller { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
        public ICollection<Picture> Pictures { get; set; }

    }
}
