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
                    Description = "ද ලෝඩ් ඔෆ් ද රින්ග්ස් යනු පීටර් ජැක්සන් විසින් අධ්‍යක්ෂණය කරන ලද එපික් ෆැන්ටසි වික්‍රමාන්විත චිත්‍රපට තුනකින් සමන්විත වන අතර එය ජේ.ආර්.ආර්. ටොල්කියන් විසින් රචිත නවකතාව පාදක කර ගෙන ඇත",
                    Price = 100
                },
                new Book()
                {
                    Name = "harry potter",
                    Description = "හැරී පොටර්, ඉංග්‍රීසි ජාතික ලෙඛිකා ජේ. කේ. රෝලිංග් විසින් රචිත ෆැන්ටසි ගණයේ නවකතා ග්‍රන්ථ මාලාවකි.",
                    Price = 150
                }  ,
                new Book()
                {
                    Name = "St. Clare's",
                    Description = "ශාන්ත ක්ලෙයාර් යනු ඉංග්‍රීසි ළමා කතුවරුන් වන එනිඩ් බ්ලයිටන් සහ පැමෙලා කොක්ස් විසින් එම නම ඇති බෝඩිමක් ගැන ලියූ පොත් නවයකින් යුත් මාලාවකි. මෙම කතා මාලාවේ වීරවරියන් වන පැට්‍රීෂියා \"පැට්\" සහ ඉසබෙල් ඕ'සුලිවන් සෙන්ට් ක්ලෙයාර් හි පළමු වසරේ සිට අනුගමනය කරයි",
                    Price = 50
                }, new Book()
                {
                    Name = "Famous five",
                    Description = "එනිඩ් බ්ලයිටන් විසින් රචිත ළමා වික්‍රමාන්විත නවකතා සහ කෙටිකතා මාලාවකි. පළමු පොත, Five on a Treasure Island, 1942 දී ප්‍රකාශයට පත් කරන ලදී. නවකතා කුඩා ළමුන් පිරිසකගේ වික්‍රමාන්විතයන් දක්වයි",
                    Price = 80
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