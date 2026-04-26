using Domain;

namespace Application.Interfaces;

public interface IGetAllShipments
{
    public Task<ICollection<Shipment>> All();
}
