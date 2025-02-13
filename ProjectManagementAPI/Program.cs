using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using MongoDB.Driver;
using ProjectManagementApplication.IRepository;
using ProjectManagementApplication.IService;
using ProjectManagementApplication.Repositories;
using ProjectManagementApplication.Service;
using ProjectManagementInfrastructure.Repositories;
using System.Reflection;
using System.Threading.Tasks;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add authentication
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

        builder.Services.AddAuthorization();
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var mongoSettings = builder.Configuration.GetSection("MongoDB");
        var mongoClient = new MongoClient(mongoSettings["ConnectionString"]);
        var mongoDatabase = mongoClient.GetDatabase(mongoSettings["DatabaseName"]);
        builder.Services.AddSingleton<IMongoDatabase>(mongoDatabase);

        // Register services
        builder.Services.AddScoped<IProjectService, ProjectService>();
        builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<IClientService, ClientService>();

        builder.Services.AddScoped<ITeamRepository, TeamRepository>();
        builder.Services.AddScoped<ITeamService, TeamService>();

        builder.Services.AddScoped<MongoDbSeeder>();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigins", policy =>
            {
                policy.WithOrigins("http://localhost:3000")
                      .AllowAnyHeader()
                      .AllowAnyMethod();
            });
        });

        var app = builder.Build();

        using (var scope = app.Services.CreateScope())
        {
            var seeder = scope.ServiceProvider.GetRequiredService<MongoDbSeeder>();
            await seeder.SeedAsync();
        }

        app.UseCors("AllowSpecificOrigins");

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}
