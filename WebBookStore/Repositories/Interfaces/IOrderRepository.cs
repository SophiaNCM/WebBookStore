using WebBookStore.Models;

namespace WebBookStore.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        void AddOrder(Orders order);
    }
}
