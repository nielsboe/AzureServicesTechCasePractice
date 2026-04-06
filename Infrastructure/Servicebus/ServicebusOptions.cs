namespace Infrastructure.Servicebus;
public class ServicebusOptions
{
    public const string SectionName = "Database";
    public required string ConnectionString { get; set; }
}
