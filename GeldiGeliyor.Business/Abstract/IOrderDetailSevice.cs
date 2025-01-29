using GeldiGeliyor.Business.Concrete.Dtos.CategoryDtos;
using GeldiGeliyor.Business.Concrete.Dtos.OrderDetailDtos;

namespace GeldiGeliyor.Business.Abstract
{
    public interface IOrderDetailService
    {
        Task<OrderDetailGetDto> GetOrderDetailByIdAsync(int id);
        Task<List<OrderDetailGetDto>> GetOrderDetailAsync();
        Task<OrderDetailWithProductDto> GetOrderDetailWithProductsAsync(int orderId);
        Task<List<OrderDetailWithProductDto>> GetOrderDetailWithProductsAsync();
        Task<IResponseResult> OrderDetailUpdateAsync(OrderDetailUpdateDto orderDetailUpdateDto);
        Task<IResponseResult> OrderDetailAddAsync(OrderDetailAddDto orderDetailAddDto);
        Task<IResponseResult> OrderDetailRemoveAsync(int id);
    }
}