using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Linq;

namespace Jasleen.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SongContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<SongContext>>()))
            {
                // Look for any movies.
                if (context.Song.Any())
                {
                    return;   // DB has been seeded
                }

                context.Song.AddRange(
                    new Song
                    {
                        Brand = "Song Brand 1",
                        Release_Date = "2022-01-15",
                        Singer = "Singer 1",
                        Production_Company = 1000000.50,
                        Lyrics = 350,
                        Director = 50000.75m
                    },
                new Song
                {
                    Brand = "Song Brand 2",
                    Release_Date = "2022-03-20",
                    Singer = "Singer 2",
                    Production_Company = 800000.75,
                    Lyrics = 400,
                    Director = 75000.25m
                },
                new Song
                {
                    Brand = "Song Brand 3",
                    Release_Date = "2022-06-10",
                    Singer = "Singer 3",
                    Production_Company = 1200000.00,
                    Lyrics = 420,
                    Director = 90000.00m
                },
                new Song
                {
                    Brand = "Song Brand 4",
                    Release_Date = "2022-09-05",
                    Singer = "Singer 4",
                    Production_Company = 1500000.25,
                    Lyrics = 380,
                    Director = 60000.50m
                }
                );
                context.SaveChanges();
            }
        }
    }
}