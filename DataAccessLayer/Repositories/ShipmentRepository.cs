using DataAccessLayer.Data;
using DataAccessLayer.Interfaces;
using Domain;
using MapsterMapper;

namespace DataAccessLayer.Repositories
{
    public class ShipmentRepository : IShipmentRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapsterMapper;

        public ShipmentRepository(DataContext context, IMapper mapsterMapper)
        {
            _mapsterMapper = mapsterMapper;
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

        public bool CreateShipment(ShipmentDTO shipmentDto)
        {
            var shipment = _mapsterMapper.Map<Shipment>(shipmentDto);
            _context.Shipments.Add(shipment);
            return Save();
        }

        public bool UpdateShipment(ShipmentDTO shipmentDto)
        {
            var shipment = _mapsterMapper.Map<Shipment>(shipmentDto);
            _context.Shipments.Update(shipment);
            return Save();
        }

        public bool DeleteShipment(ShipmentDTO shipmentDto)
        {
            var shipment = _mapsterMapper.Map<Shipment>(shipmentDto);
            _context.Shipments.Remove(shipment);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
