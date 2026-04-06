namespace Domain2.Interfaces;

public interface IServiceBusSenderClient
{
    Task Send<T>(T topic, string task);
}