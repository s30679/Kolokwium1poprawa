namespace Kolokwium1poprawa.Repositories;

public class Repository : IRepository
{
    private readonly string _connectionString;
    public Repository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db-mssql");
    }
}