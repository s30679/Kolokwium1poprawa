using Kolokwium1poprawa.Repositories;
using Kolokwium1poprawa.Services;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Kolokwium1poprawa;

public class Program
{
    public static void Main(string[] args)
    {
        //http://localhost:5215/swagger/index.html
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        
        //Rejestrowanie zależności
        builder.Services.AddScoped<IProjectService, ProjectService>();
        builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
        builder.Services.AddScoped<IStaffAssignmentRepository, StaffAssignmentRepository>();
        builder.Services.AddScoped<IArtifactRepository, ArtifactRepository>();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1",new OpenApiInfo
            {
                Title = "Kolokwium1poprawa",
                Version = "v1",
                Description = "Kolokwium1poprawa",
                Contact = new OpenApiContact
                {
                    Name = "API Support",
                    Email = "support@example.com",
                    Url = new Uri("https://example.com/support")
                },
                License = new OpenApiLicense
                {
                    Name = "MIT License",
                    Url = new Uri("https://opensource.org/licenses/MIT")
                }
            });
        });
        
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }
        
        app.UseGlobalExceptionHandlingMiddleware();
        
        app.UseSwagger();
        
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "Kolokwium1poprawa");
            c.DocExpansion(DocExpansion.List);
            c.DefaultModelsExpandDepth(0);
            c.DisplayRequestDuration();
            c.EnableFilter();
        });
        
        app.UseHttpsRedirection();

        app.UseAuthorization();
        app.MapControllers();
        
        app.Run();
    }
}