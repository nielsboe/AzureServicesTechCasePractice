using DataAccessLayer.Data;
using InventoryAPI.Models;
using ShippingAPI.Models;

namespace DataAccessLayer.Repositories
{
    public class ShipmentRepository
    {
        private readonly DataContext _context;
        public ShipmentRepository(DataContext context)
        {
            _context = context;
        }

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
            return _context.Shipments.Where(p => p.Id == id).FirstOrDefault();
        }

        public bool CreateShipment(Shipment shipment)
        {
            _context.Add(shipment);

            return Save();
        }

        public bool UpdateShipment(Shipment shipment)
        {
            _context.Update(shipment);
            return Save();
        }

        public bool DeleteShipment(Shipment shipment)
        {
            _context.Remove(shipment);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
