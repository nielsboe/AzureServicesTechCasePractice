namespace Infrastructure.Servicebus;
public class ServicebusOptions
{
    public const string SectionName = "Servicebus";
    public required string ConnectionString { get; set; }
}
