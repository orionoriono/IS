using MusicEShop.Domain.DomainModels;

namespace MusicEShop.Repository.Interface
{
    public interface IOrderRepository 
    {
        List<Order> GetAllOrders();
        Order GetDetailsForOrder(BaseEntity id);
        List<Order> GetOrdersByUserId(string userId);
    }
}
