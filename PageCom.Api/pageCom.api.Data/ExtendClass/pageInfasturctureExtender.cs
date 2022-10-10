using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PageCom.Api.Application.Contract.BookContract;
using pageCom.api.Data.Repository.BookRepositoryImplimentation;

namespace pageCom.api.Data.ExtendClass;

public static class PageCom_api_infastructureExtender
{
    public static IServiceCollection PageComApiInfastructureExtenderInfo(this IServiceCollection service,IConfiguration configuration)
    {
        
        var HOST = Environment.GetEnvironmentVariable("HOST");
        var PORT = Environment.GetEnvironmentVariable("PORT");
        var USER = Environment.GetEnvironmentVariable("USER");
        var DATABASE = Environment.GetEnvironmentVariable("DATABASE");
        var PASSWORD = Environment.GetEnvironmentVariable("PASSWORD");

        var AZURE_ENVIRONMENT = Environment.GetEnvironmentVariable("AZURE") != null ;
        
        
        
       // book repository
        service.AddScoped<IBookRepository, BookRepository>();

        // database dependency injection
      //  service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
      //     configuration.GetConnectionString("DefaultConnection")
      // )); // todo need to change this code 
       
       
       if (HOST != null)
       {
           string connectionString;
           if (AZURE_ENVIRONMENT) // in the azure environment [  azure sql server  ]
           {
               connectionString =
                   $"Server=tcp:{HOST},{PORT};Initial Catalog={DATABASE};Persist Security Info=False;User ID={USER};Password={PASSWORD};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
               Console.WriteLine("azure connection establish");
           }
           else  // testing production environment [ with docker minikube and kind cluster  ]
           { 
               connectionString =
                   $"Data Source={HOST},{PORT};Initial Catalog={DATABASE};User ID={USER};Password={PASSWORD}";
               Console.WriteLine("local production enviroment establish");
           }

          
           Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
           Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
           Console.WriteLine(connectionString);
           service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
               connectionString
           ));
       }
       else
       {
           service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
               configuration.GetConnectionString("DefaultConnection")
           ));
       }
       
       
       
        return service;
    }
}