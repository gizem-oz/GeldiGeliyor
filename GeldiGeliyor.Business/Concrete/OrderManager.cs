using AutoMapper;
using GeldiGeliyor.Business.Abstract;
using GeldiGeliyor.Business.Concrete.Dtos.OrderDtos;
using GeldiGeliyor.Business.Concrete.ResultModels;
using GeldiGeliyor.Business.Validations;
using GeldiGeliyor.DataAccess.Abstract;
using GeldiGeliyor.Entities.Concrete;

namespace GeldiGeliyor.Business.Concrete
{
    public class OrderManager(IOrderDal orderDal,IProductDal productDal, IMapper mapper) : IOrderService
    {
        OrderValidator orderValidator = new OrderValidator();
        public async Task<List<OrderGetDto>> GetOrderAsync()
        {
            List<OrderGetDto> orderGetDtos = new List<OrderGetDto>();
            IEnumerable<Order> orders = await orderDal.GetAllAsync();
            foreach (Order order in orders)
                orderGetDtos.Add(mapper.Map<OrderGetDto>(order));
            return orderGetDtos;
        }

        public async Task<OrderGetDto> GetOrderByIdAsync(int id)
        {
            Order order = await orderDal.GetAsync(x => x.Id == id);
            OrderGetDto orderGetDto = new OrderGetDto()
            {
                 CreateDate =order.CreateDate,
                  CustomerId = order.CustomerId,
                   DeliveryDate = order.DeliveryDate,
                    Id = order.Id,
                      OrderDate=order.OrderDate,
                       UpdateDate =order.UpdateDate,
            };
            return orderGetDto;
        }

        public async Task<IResponseResult> OrderAddAsync(OrderAddDto orderAddDto)
        {
            IResponseResult responseResult = new ResponseResult();
            try
            {
                Order order = mapper.Map<Order>(orderAddDto);
                OrderDetail orderDetail = mapper.Map<OrderDetail>(orderAddDto);
                order.OrderDetails = new List<OrderDetail>() { orderDetail };
                var result = orderValidator.Validate(order);
                if (result.IsValid)
                    order.OrderDetails.Add(orderDetail);
                await orderDal.AddAsync(order);
                Product product = await productDal.GetAsync(x => x.Id == orderAddDto.ProductId);
                product.StockAmount -= orderAddDto.Quantity;
                await productDal.UpdateAsync(product);
                return responseResult;
            }
            catch (Exception ex)
            {
                responseResult.Error = ex.Message;
                responseResult.IsSuccessed = false;
                return responseResult;
            }
        }

        public async Task<IResponseResult> OrderRemoveAsync(int id)
        {
            IResponseResult responseResult = new ResponseResult();
            try
            {
                Order order = await orderDal.GetAsync(x => x.Id == id);
                await orderDal.DeleteAsync(order);
                return responseResult;
            }
            catch (Exception ex)
            {
                responseResult.IsSuccessed = false;
                responseResult.Error = ex.Message;
                return responseResult;
            }
        }

        public async Task<IResponseResult> OrderUpdateAsync(OrderUpdateDto orderUpdateDto)
        {
            IResponseResult responseResult = new ResponseResult();
            try
            {
                Order order = mapper.Map<Order>(orderUpdateDto);
                await orderDal.UpdateAsync(order);
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
