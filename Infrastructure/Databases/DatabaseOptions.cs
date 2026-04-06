namespace Infrastructure.Databases;

internal class DatabaseOptions
{
    public const string SectionName = "Database";
    public required string ConnectionString { get; set; }
}
