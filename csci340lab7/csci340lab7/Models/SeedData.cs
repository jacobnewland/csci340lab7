#define Difficulty
#if Difficulty
#region snippet_1 
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using csci340lab7.Data;
using System;
using System.Linq;

namespace csci340lab7.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new csci340lab7Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<csci340lab7Context>>()))
            {
                // Look for any Trails.
                if (context.Trail.Any())
                {
                    return;   // DB has been seeded
                }

                context.Trail.AddRange(
                    new Trail
                    {
                        Name = "Ouachita Trail",
                        Location = "Arkansas",
                        Length = 300,
                        Difficulty = 6,
                    },

                     new Trail
                     {
                         Name = "John Muir Trail",
                         Location = "California",
                         Length = 225,
                         Difficulty = 9,
                     },

                     new Trail
                     {
                         Name = "Grand Canyon North Rim",
                         Location = "Arizona",
                         Length = 650,
                         Difficulty = 10,
                     },

                     new Trail
                     {
                         Name = "Across Colorado Trail",
                         Location = "Colorado",
                         Length = 550,
                         Difficulty = 7,
                     }
                );
                context.SaveChanges();
            }
        }
    }
}
#endregion
#endif