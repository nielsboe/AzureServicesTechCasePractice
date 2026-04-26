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
            var shipments = await _shipmentRepository.All(cancellationToken);

            return shipments.Select(p => new Product
            {
                Name = p.Name,
                Description = p.Description,
                Price = p.Price
            }).ToList();
        }
    }
}