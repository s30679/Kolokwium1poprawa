using Kolokwium1poprawa.DTOs;
using Kolokwium1poprawa.Models;
using Microsoft.Data.SqlClient;

namespace Kolokwium1poprawa.Repositories;

public class ArtifactRepository : IArtifactRepository
{
    private readonly string _connectionString;
    public ArtifactRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db-mssql");
    }

    public async Task<ArtifactGetDTO> GetArtifactByIdAsync(CancellationToken cancellationToken, int id)
    {
        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();
        var cmd = new SqlCommand(@"SELECT a.Name, a.OrginDate, a.InstitutionId, i.Name, i.FoundedYear 
            FROM Artifact a 
            JOIN Institution i ON i.InstitutionId = a.InstitutionId 
            WHERE ArtifactId = @Id", con);
        cmd.Parameters.AddWithValue("@Id", id);
        using var reader = await cmd.ExecuteReaderAsync();
        if (await reader.ReadAsync())
        {
            return new ArtifactGetDTO
            {
                name = reader.GetString(0),
                originDate = reader.GetDateTime(1),
                institution = new Institution
                {
                    institutionId = reader.GetInt32(2),
                    Name = reader.GetString(3),
                    FoundedYear = reader.GetInt32(4),
                }
            };
        }
        return null;
    }
    public async Task CreateArtifact(Artifact artifact, CancellationToken cancellationToken)
    {
        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();
        var cmd = new SqlCommand("INSERT INTO Artifacts (ArtifactId, Name, OriginDate, InstitutionId) VALUES (@ArtifactId, @Name, @OriginDate, @InstitutionId)", con);
        cmd.Parameters.AddWithValue("@ArtifactId", artifact.ArtifactId);
        cmd.Parameters.AddWithValue("@Name", artifact.Name);
        cmd.Parameters.AddWithValue("@OriginDate", artifact.OriginDate);
        cmd.Parameters.AddWithValue("@InstitutionId", artifact.InstitutionId);
        await cmd.ExecuteScalarAsync(cancellationToken);
    }
}