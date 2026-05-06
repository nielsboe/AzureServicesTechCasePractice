namespace Application.Interfaces;

public interface IShipmentCommandHandler<TCommand>
{
    Task Handle(TCommand command);
}