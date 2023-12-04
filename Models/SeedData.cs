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
            using (var context = new MvcSongContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcSongContext>>()))
            {
                
                if (context.Song.Any())
                {
                    return;   
                }

                context.Song.AddRange(

                    new Song{
                       Title="Shape of You",
                       ReleaseDate=DateTime.Parse("01/06/2017"),
                       Genre="Pop",
                       Price=1.29M,
                       Rating=3M,
                       Director="Jason Koenig"
                    },
                    new Song{
                       Title="Bohemian Rhapsody",
                       ReleaseDate=DateTime.Parse("10/31/1975"),
                       Genre="Rock",
                       Price=0.99M,
                       Rating=5M,
                       Director="Bryan Singer"
                    },
                    new Song{
                       Title="Sicko Mode",
                       ReleaseDate=DateTime.Parse("08/21/2018"),
                       Genre="Hip Hop",
                       Price=1.29M,
                       Rating=4.2M,
                       Director="Travis Scott"
                    },
                    new Song {
                        Title="Rolling Stone",
                       ReleaseDate=DateTime.Parse("09/22/2017"),
                       Genre="Jazz",
                       Price=1.30M,
                       Rating=4.5M,
                       Director="Charlie Watts"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}