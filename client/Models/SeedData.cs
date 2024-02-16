using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using client.Data;
using System;
using System.Linq;

namespace client.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new BetaxeContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<BetaxeContext>>()))
        {
            // Look for any versements.
            if (context.Versement.Any())
            {
                return;   // DB has been seeded
            }
            context.Versement.AddRange(
                new Versement
                {
                    Price = 45.000M,
                    ReleaseDate = DateTime.Parse("2024-2-16"),
                    IsChecked = true
                }
            );
            context.SaveChanges();
        }
    }
}