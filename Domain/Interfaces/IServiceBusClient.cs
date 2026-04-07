namespace Domain.Interfaces;

public interface IServiceBusSenderClient
{
    Task Send<T>(T topic, string task);
}