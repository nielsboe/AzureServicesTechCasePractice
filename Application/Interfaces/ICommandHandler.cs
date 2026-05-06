namespace Application.Interfaces;

public interface ICommandHandler<TCommand>
{
    Task Handle(TCommand command);
}

public interface ICommandHandler<TCommand, TResult>
{
    Task<TResult> Handle(TCommand command);
}