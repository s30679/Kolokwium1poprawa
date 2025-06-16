using Kolokwium1poprawa.Repositories;

namespace Kolokwium1poprawa.Services;

public class Service
{
    private readonly IRepository _warehouseRepository;
    private readonly string _connectionString;
    public Service(IRepository repository, IConfiguration configuration)
    {
        _warehouseRepository = repository;
        _connectionString = configuration.GetConnectionString("db-mssql");
    }
}