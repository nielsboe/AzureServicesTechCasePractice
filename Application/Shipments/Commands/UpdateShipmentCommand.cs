using Domain;

namespace Application.Shipments.Commands;

public record UpdateShipmentCommand(Shipment shipment, CancellationToken cancellationToken);