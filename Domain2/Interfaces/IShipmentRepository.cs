namespace Domain2.Interfaces;

public interface IShipmentRepository
{
    ICollection<Shipment> GetShipments();
    Shipment GetShipment(int id);
    bool ShipmentExists(int id);
    bool CreateShipment(Shipment shipment);
    bool UpdateShipment(Shipment shipment);
    bool DeleteShipment(Shipment shipment);
    bool Save();
}