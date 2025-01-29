using AutoMapper;
using GeldiGeliyor.Business.Concrete.Dtos.CategoryDtos;
using GeldiGeliyor.Business.Concrete.Dtos.OrderDetailDtos;
using GeldiGeliyor.Business.Concrete.Dtos.OrderDtos;
using GeldiGeliyor.Business.Concrete.Dtos.ProductDtos;
using GeldiGeliyor.Business.Concrete.Dtos.SellerDtos;
using GeldiGeliyor.Business.Concrete.Dtos.UserDtos;
using GeldiGeliyor.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeldiGeliyor.Business.Concrete.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            this.CreateMap<Category, CategoryAddDto>().ReverseMap();
            this.CreateMap<Category, CategoryGetDto>().ReverseMap();
            this.CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            this.CreateMap<Category, CategoryWithProductsGetDto>().ReverseMap();
            this.CreateMap<OrderDetail, OrderDetailAddDto>().ReverseMap();
            this.CreateMap<OrderDetail, OrderDetailGetDto>().ReverseMap();
            this.CreateMap<OrderDetail, OrderDetailUpdateDto>().ReverseMap();
            this.CreateMap<OrderDetail, OrderDetailWithProductDto>().ReverseMap();
            this.CreateMap<Order, OrderAddDto>().ReverseMap();
            this.CreateMap<Order, OrderGetDto>().ReverseMap();
            this.CreateMap<Order, OrderUpdateDto>().ReverseMap();
            this.CreateMap<Picture, PictureAddDto>().ReverseMap();
            this.CreateMap<Picture, PictureGetDto>().ReverseMap();
            this.CreateMap<Picture, PictureUpdateDto>().ReverseMap();
            this.CreateMap<Picture, PictureWithProductDto>().ReverseMap();
            this.CreateMap<Product,ProductAddDto>().ReverseMap();
            this.CreateMap<Product,ProductGetDto>().ReverseMap();
            this.CreateMap<Product,ProductUpdateDto>().ReverseMap();
            this.CreateMap<Product,ProductSellerDto>().ReverseMap();
            this.CreateMap<Seller,SellerWithProductGetDto>().ReverseMap();
            this.CreateMap<Seller,SellerGetDto>().ReverseMap();
            this.CreateMap<Seller,SellerAddDto>().ReverseMap();
            this.CreateMap<AppUser,SellerAddDto>().ReverseMap();
            this.CreateMap<Seller,SellerUpdateDto>().ReverseMap();          
            this.CreateMap<AppUser,CustomerAddDto>().ReverseMap();          
            this.CreateMap<Customer,CustomerAddDto>().ReverseMap();
            this.CreateMap<Customer,CustomerGetDto>().ReverseMap();
            this.CreateMap<Customer,CustomerUpdateDto>().ReverseMap();

        }
    }
}
