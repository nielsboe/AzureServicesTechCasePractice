namespace Domain2.Interfaces;

public interface IShipmentRepository
{
    ICollection<Shipment> GetShipments();
    Shipment GetShipment(int id);
    bool ShipmentExists(int id);
    bool Save();
}