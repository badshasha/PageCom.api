using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using pageCom.api.Data.DataBase;

namespace pageCom.api.Data.ExtendClass;

public static class PageCom_api_infastructureExtender
{
    public static IServiceCollection PageComApiInfastructureExtenderInfo(this IServiceCollection service,IConfiguration configuration)
    {
        // database dependency injection
        service.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("defaultConnection"))); // todo need to change this code 
        return service;
    }
}