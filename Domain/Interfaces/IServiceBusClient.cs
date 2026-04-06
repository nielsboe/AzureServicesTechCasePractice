namespace Domain.Interfaces;

public interface IServiceBusSenderClient
{
    Task Post<T>(T topic, string task);
}