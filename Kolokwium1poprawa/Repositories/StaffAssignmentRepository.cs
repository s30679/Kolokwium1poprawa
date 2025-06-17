using Kolokwium1poprawa.DTOs;
using Microsoft.Data.SqlClient;

namespace Kolokwium1poprawa.Repositories;

public class StaffAssignmentRepository : IStaffAssignmentRepository
{
    private readonly string _connectionString;
    public StaffAssignmentRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("db-mssql");
    }
    public async Task<List<StaffAssignmentsGetDTO>> GetStaffAssignmentsByProjectIdAsync(int projectId, CancellationToken cancellationToken)
    {
        var lista = new List<StaffAssignmentsGetDTO>();
        var con = new SqlConnection(_connectionString);
        con.OpenAsync();
        var cmd = new SqlCommand(@"SELECT s.FirstName, s.LastName, s.HireDate, sa.Role  
                FROM Preservation_Project p
                JOIN Staff_Assignment st ON p.ProjectId = st.ProjectId
                JOIN Staff s ON st.StaffId = p.StaffId
                WHERE r.ProjectId = @ProjectId", con);
        cmd.Parameters.AddWithValue("@ProjectId", projectId);
        using var reader = await cmd.ExecuteReaderAsync();
        while(await reader.ReadAsync())
        {
            lista.Add(new StaffAssignmentsGetDTO
            {
                firstName= reader.GetString(0),
                lastName = reader.GetString(1),
                hireDate = reader.GetDateTime(2),
                role = reader.GetString(3)
            });
        }
        return lista;
    }
}