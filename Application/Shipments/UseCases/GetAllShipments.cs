using Application.Interfaces;
using Domain;

namespace Application.Shipments.UseCases
{
    internal class GetAllShipmentsById
    {
        private readonly IShipmentRepository _shipmentRepository;

        public GetAllShipmentsById(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        public async Task<ICollection<Shipment>> GetAllShipments(CancellationToken cancellationToken)
        {
            var shipments = await _shipmentRepository.All();

            return shipments.Select(s => new Shipment
            {
                Products = s.Products,
                ShipmentAddress = s.ShipmentAddress,
                ShipmentDate = s.ShipmentDate
            }).ToList();
        }
    }
}