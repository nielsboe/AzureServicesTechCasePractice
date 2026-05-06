namespace Application.Interfaces;

public interface IProductCommandHandler<TCommand>
{
    Task Handle(TCommand command);
}