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
       // book repository
        service.AddScoped<IBookRepository, BookRepository>();

        // database dependency injection
       service.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
          configuration.GetConnectionString("DefaultConnection")
      )); // todo need to change this code 
        return service;
    }
}