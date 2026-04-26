using Domain;

namespace Application.Shipments.Commands;

public record CreateShipmentCommand(Shipment shipment, CancellationToken cancellationToken);