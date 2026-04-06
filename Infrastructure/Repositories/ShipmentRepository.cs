using Domain;
using Application.Data;

namespace Application.Repositories;

public class ShipmentRepository(DataContext context) : IShipmentRepository
{
    private readonly DataContext _context = context;

    public bool ShipmentExists(int id)
    {
        return _context.Shipments.Any(p => p.Id == id);
    }

    public ICollection<Shipment> GetShipments()
    {
        return _context.Shipments.OrderBy(p => p.Id).ToList();
    }

    public Shipment GetShipment(int id)
    {
        return _context.Shipments.FirstOrDefault(p => p.Id == id) ?? throw new Exception("Shipment not found");
    }

    public bool CreateShipment(Shipment shipment)
    {
        _context.Shipments.Add(shipment);
        return Save();
    }

    public bool UpdateShipment(Shipment shipment)
    {
        _context.Shipments.Update(shipment);
        return Save();
    }

    public bool DeleteShipment(Shipment shipment)
    {
        _context.Shipments.Remove(shipment);
        return Save();
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0;
    }
}