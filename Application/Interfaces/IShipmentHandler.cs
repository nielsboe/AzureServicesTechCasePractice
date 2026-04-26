using Application.Shipments.Commands;

namespace Application.Interfaces;

public interface IShipmentHandler
{
    Task<int> Create(CreateShipmentCommand createShipmentCommand);
    Task Update(UpdateShipmentCommand updateShipmentCommand);
    Task Delete(DeleteShipmentCommand deleteShipmentCommand);
}
