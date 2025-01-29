using AutoMapper;
using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.Dtos.OrderDetailDtos;
using GeldiGeliyor.Business.Concrete.ResultModels;
using GeldiGeliyor.Business.Validations;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Concrete
{
    public class OrderDetailManager(IOrderDetailDal orderDetailDal, IMapper mapper) : IOrderDetailService
    {
        OrderDetailValidator orderdetailValidator = new OrderDetailValidator();
        public async Task<List<OrderDetailGetDto>> GetOrderDetailAsync()
        {
            List<OrderDetailGetDto> orderDetailGetDtos = new List<OrderDetailGetDto>();
            IEnumerable<OrderDetail> orderDetails = await orderDetailDal.GetAllAsync();
            foreach (OrderDetail orderDetail in orderDetails)
            {
                orderDetailGetDtos.Add(mapper.Map<OrderDetailGetDto>(orderDetail));
               

            }
            return orderDetailGetDtos;
        }

        public async Task<OrderDetailGetDto> GetOrderDetailByIdAsync(int id)
        {
            OrderDetail orderDetail = await orderDetailDal.GetAsync(x => x.OrderId == id);
            OrderDetailGetDto orderDetailGetDto = new OrderDetailGetDto()
            {
                 Discount = orderDetail.Discount,
                  OrderId = orderDetail.OrderId,
                   Price = orderDetail.Price,
                    ProductId = orderDetail.ProductId,
                     Quantity = orderDetail.Quantity,

            };
            return orderDetailGetDto;
        }

        public async Task<OrderDetailWithProductDto> GetOrderDetailWithProductsAsync(int orderId)
        {
            OrderDetail orderDetail = await orderDetailDal.OrderDetailWithProduct(x => x.OrderId == orderId);
            return mapper.Map<OrderDetailWithProductDto>(orderDetail);


        }

        public async Task<List<OrderDetailWithProductDto>> GetOrderDetailWithProductsAsync()
        {
            List<OrderDetailWithProductDto> orderDetailWithProductDtos = new List<OrderDetailWithProductDto>();
            IEnumerable<OrderDetail> orderDetails = await orderDetailDal.GetAllAsync();
            foreach (OrderDetail orderDetail in orderDetails)
            {
                orderDetailWithProductDtos.Add(mapper.Map<OrderDetailWithProductDto>(orderDetail));

            }
            return orderDetailWithProductDtos;
        }

        public async Task<IResponseResult> OrderDetailAddAsync(OrderDetailAddDto orderDetailAddDto)
        {
            IResponseResult responseResult = new ResponseResult();
            try
            {
                OrderDetail orderDetail = mapper.Map<OrderDetail>(orderDetailAddDto);
                var result = orderdetailValidator.Validate(orderDetail);
                if (result.IsValid)
                    await orderDetailDal.AddAsync(orderDetail); 
                return responseResult;

            }
            catch (Exception ex)
            {
                responseResult.IsSuccessed = false;
                responseResult.Error = ex.Message;
                return responseResult;

            }

        }

        public async Task<IResponseResult> OrderDetailRemoveAsync(int id)
        {
            IResponseResult responseResult = new ResponseResult();
            try
            {
                OrderDetail orderDetail = await orderDetailDal.GetAsync(x => x.OrderId == id);
                await orderDetailDal.DeleteAsync(orderDetail);
                return responseResult;


            }
            catch (Exception ex)
            {
                responseResult.IsSuccessed = false;
                responseResult.Error = ex.Message;
                return responseResult;

            }
        }

        public async Task<IResponseResult> OrderDetailUpdateAsync(OrderDetailUpdateDto orderDetailUpdateDto)
        {
            IResponseResult responseResult = new ResponseResult();
            try
            {
                OrderDetail orderDetail = mapper.Map<OrderDetail>(orderDetailUpdateDto);
                await orderDetailDal.UpdateAsync(orderDetail);
                return responseResult;





            }
            catch (Exception ex)
            {
                responseResult.IsSuccessed = false;
                responseResult.Error = ex.Message;
                return responseResult;
            }
        }
    }
}