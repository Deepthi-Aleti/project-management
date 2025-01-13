using System.Configuration;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Identity.Web;
using ProjectManagementApplication.Abstractions;
using ProjectManagementApplication.IRepository;
using ProjectManagementApplication.IService;
using ProjectManagementApplication.Repositories;
using ProjectManagementApplication.Service;
using ProjectManagementInfrastructure;
using ProjectManagementInfrastructure.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(builder.Configuration.GetSection("AzureAd"));

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        ConfigureServices(builder);
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigins", policy =>
            {
                policy.WithOrigins("http://localhost:3000") // Allowed origins
                      .AllowAnyHeader() // Allow all headers
                      .AllowAnyMethod(); // Allow all HTTP methods
            });
        });
        builder.Services.AddScoped<IProjectService, ProjectService>();
        builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

        builder.Services.AddScoped<IClientRepository, ClientRepository>();
        builder.Services.AddScoped<IClientService, ClientService>();

        builder.Services.AddScoped<ITeamRepository, TeamRepository>();
        builder.Services.AddScoped<ITeamService, TeamService>();

        //RegisterScopedServices(builder.Services);
        var app = builder.Build();
            app.UseCors("AllowSpecificOrigins");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void RegisterScopedServices(IServiceCollection serviceCollection)
    {
        var instances = Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(IScopedLifestyle).IsAssignableFrom(t));

        foreach (var item in instances)
        {
            serviceCollection.AddScoped(item);
        }

    }
    public IConfiguration Configuration { get; }

    public Program(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public static void ConfigureServices(WebApplicationBuilder builder)
    {
        
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
    }
}