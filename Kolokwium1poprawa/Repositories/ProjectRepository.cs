using Kolokwium1poprawa.Models;
using Microsoft.Data.SqlClient;

namespace Kolokwium1poprawa.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly string _connectionString;
    public ProjectRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db-mssql");
    }

    public async Task<PreservationProject> GetProjectByIdAsync(CancellationToken cancellationToken, int id)
    {
        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();
        var cmd = new SqlCommand("SELECT ProjectId, Objective, StartDate, EndDate, ArtifactId FROM Preservation_Project WHERE ProjectId = @Id", con);
        cmd.Parameters.AddWithValue("@Id", id);
        using var reader = await cmd.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new PreservationProject()
            {
                ProjectId = reader.GetInt32(0),
                Objective = reader.GetString(1),
                StartDate = reader.GetDateTime(2),
                EndDate = reader.GetDateTime(3),
                ArtifactId = reader.GetInt32(4)
            };
        }
        return null;
    }
    public async Task<bool> IfProjectExistsAsync(int id,CancellationToken cancellationToken)
    {
        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync(cancellationToken);
        var cmd = new SqlCommand("select 1 from Preservation_Project where ProjectId = @id", con);
        cmd.Parameters.AddWithValue("@id", id);
        var wynik = await cmd.ExecuteScalarAsync(cancellationToken);
        if (wynik != null)
        {
            return true;
        }
        return false;
    }
    public async Task CreateProject(PreservationProject project, CancellationToken cancellationToken)
    {
        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();
        var cmd = new SqlCommand("INSERT INTO Preservation_Project (ProjectId, ArtifactId, StartDate, EndDate, Objective) VALUES (@ProjectId, @ArtifactId, @StartDate, @EndDate, @Objective)", con);
        cmd.Parameters.AddWithValue("@ProjectId", project.ProjectId);
        cmd.Parameters.AddWithValue("@ArtifactId", project.ArtifactId);
        cmd.Parameters.AddWithValue("@StartDate", project.StartDate);
        cmd.Parameters.AddWithValue("@EndDate", project.EndDate);
        cmd.Parameters.AddWithValue("@Objective", project.Objective);
        await cmd.ExecuteScalarAsync(cancellationToken);
    }
}