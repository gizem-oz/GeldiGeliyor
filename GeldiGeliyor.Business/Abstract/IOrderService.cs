using GeldiGeliyor.Business.Concrete.Dtos.OrderDtos;


namespace GeldiGeliyor.Business.Abstract
{
    public interface IOrderService
    {
        Task<OrderGetDto> GetOrderByIdAsync(int id);
        Task<List<OrderGetDto>> GetOrderAsync();
        Task<IResponseResult> OrderUpdateAsync(OrderUpdateDto orderUpdateDto);
        Task<IResponseResult> OrderAddAsync(OrderAddDto orderAddDto);
        Task<IResponseResult> OrderRemoveAsync(int id);
    }
}
