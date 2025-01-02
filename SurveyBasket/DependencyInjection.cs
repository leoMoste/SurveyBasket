using MapsterMapper;
using SurveyBasket.Persistence;
using System.Reflection;
namespace SurveyBasket;

public static class DependencyInjection
{
    public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration)
    {

        // Add services to the container.
        services.AddControllers();

        var connectionString = configuration 
          .GetConnectionString("DefaultConnection") ??
          throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));

        services
            .AddSwaggerServices()
            .AddMapsterServices()
            .AddFluentValidation();

        services.AddScoped<IPollService, PollService>();

        return services;
    }

    public static IServiceCollection AddSwaggerServices(this IServiceCollection services)
    {
        // Add Swagger services
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }

    public static IServiceCollection AddMapsterServices(this IServiceCollection services)
    {
        // Add Mapster
        var mappingConfig = TypeAdapterConfig.GlobalSettings;
        mappingConfig.Scan(Assembly.GetExecutingAssembly());
        services.AddSingleton<IMapper>(new Mapper(mappingConfig));


        return services;
    }

    public static IServiceCollection AddFluentValidation(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation().AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }

}
