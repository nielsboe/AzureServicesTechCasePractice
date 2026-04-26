namespace Application.Shipments.Commands;

public record DeleteShipmentCommand(int shipmentId, CancellationToken cancellationToken);