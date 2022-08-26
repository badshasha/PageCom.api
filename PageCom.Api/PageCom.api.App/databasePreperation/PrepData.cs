using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using pageCom.api.Data;
using PageCome.Api.Demain;

namespace PageCom.api.App.databasePreperation;

public class PrepData
{
    public static async void DataBaseCreate(IApplicationBuilder app)
    {
        using (var serviceScope = app.ApplicationServices.CreateScope())
        {
            await SeedInformation(serviceScope.ServiceProvider.GetService<ApplicationDbContext>()!);
        }
    }

    private static async Task SeedInformation(ApplicationDbContext context)
    {
        Console.WriteLine("appling migrations");
        context.Database.Migrate();

        if (!context.Books.Any())
        {
            Console.WriteLine("writing data -- into database");
            await context.Books.AddRangeAsync(
                new Book()
                {
                    Name = "load of the ring",
                    Description = "story about friendship and team work",
                    Price = 100
                },
                new Book()
                {
                    Name = "harry potter",
                    Description = "brings you into magical world",
                    Price = 150
                }
                
                
                );
            await context.SaveChangesAsync();

        }
        else
        {
            Console.WriteLine("system update to date[+]");
        }
    }
}