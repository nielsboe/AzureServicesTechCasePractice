using Domain;

namespace DataAccessLayer.Interfaces;

public interface IShipmentRepository
{
    ICollection<Shipment> GetShipments();
    Shipment GetShipment(int id);
    bool ShipmentExists(int id);
    bool CreateShipment(ShipmentDTO shipment);
    bool UpdateShipment(ShipmentDTO shipment);
    bool DeleteShipment(ShipmentDTO shipment);
    bool Save();
}