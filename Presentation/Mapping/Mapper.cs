using Domain;
using MapsterMapper;
using Presentation.DTO;

namespace Presentation.Mapping
{
    public class Mapper(IMapper mapsterMapper)
    {
        private readonly IMapper _mapper = mapsterMapper;
        public ProductDTO mapProductDTO(Product product)
        {
            
        }

        public OrderDTO mapOrderDTO(Order order)
        {
            return _mapper.Map<OrderDTO>(order);
        }

        public ShipmentDTO mapShipmentDTO(Shipment shipment)
        {
            return _mapper.Map<ShipmentDTO>(shipment);
        }
    }
}