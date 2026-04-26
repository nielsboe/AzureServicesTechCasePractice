using Domain;

namespace Application.Interfaces;

public interface IGetAllOrders
{
    public Task<ICollection<Order>> All();
}