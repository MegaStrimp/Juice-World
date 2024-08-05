using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Juice_World.Data;
using System;
using System.Linq;

namespace Juice_World.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Juice_WorldContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Juice_WorldContext>>()))
                {
                    // Look for any juices.
                    if (context.Juice.Any())
                    {
                        return;   // DB has already been seeded
                    }
                    context.Juice.AddRange(
                    #region Mystic Mango
                    new Juice
                    {
                        Title = "Mystic Mango",
                        ReleaseDate = DateTime.Parse("2024-7-15"),
                        Genre = "Fruit",
                        Rating = "E",
                        Price = 7.49M
                    },
                    #endregion

                    #region Citrus Celestial
                    new Juice
                    {
                        Title = "Citrus Celestial",
                        ReleaseDate = DateTime.Parse("2024-6-22"),
                        Genre = "Fruit",
                        Rating = "E",
                        Price = 6.49M
                    },
                    #endregion

                    #region Zesty Zucchini
                    new Juice
                    {
                        Title = "Zesty Zucchini",
                        ReleaseDate = DateTime.Parse("2024-5-30"),
                        Genre = "Veggie",
                        Rating = "E",
                        Price = 5.79M
                    },
                    #endregion

                    #region Berry Bliss
                    new Juice
                    {
                        Title = "Berry Bliss",
                        ReleaseDate = DateTime.Parse("2024-4-10"),
                        Genre = "Fruit",
                        Rating = "E",
                        Price = 6.99M
                    },
                    #endregion

                    #region Sweet Spinach
                    new Juice
                    {
                        Title = "Sweet Spinach",
                        ReleaseDate = DateTime.Parse("2024-3-25"),
                        Genre = "Veggie",
                        Rating = "E",
                        Price = 5.89M
                    },
                    #endregion

                    #region Tropical Tango
                    new Juice
                    {
                        Title = "Tropical Tango",
                        ReleaseDate = DateTime.Parse("2024-2-5"),
                        Genre = "Fruit",
                        Rating = "E",
                        Price = 7.19M
                    },
                    #endregion

                    #region Crunchy Cucumber
                    new Juice
                    {
                        Title = "Crunchy Cucumber",
                        ReleaseDate = DateTime.Parse("2024-1-18"),
                        Genre = "Veggie",
                        Rating = "E",
                        Price = 5.59M
                    },
                    #endregion

                    #region Radiant Raspberry
                    new Juice
                    {
                        Title = "Radiant Raspberry",
                        ReleaseDate = DateTime.Parse("2023-12-10"),
                        Genre = "Fruit",
                        Rating = "E",
                        Price = 6.89M
                    },
                    #endregion

                    #region Peppery Parsley
                    new Juice
                    {
                        Title = "Peppery Parsley",
                        ReleaseDate = DateTime.Parse("2023-11-20"),
                        Genre = "Veggie",
                        Rating = "E",
                        Price = 5.99M
                    },
                    #endregion

                    #region Gleaming Grapefruit
                    new Juice
                    {
                        Title = "Gleaming Grapefruit",
                        ReleaseDate = DateTime.Parse("2023-10-7"),
                        Genre = "Fruit",
                        Rating = "E",
                        Price = 7.29M
                    }
                    #endregion
                );
                context.SaveChanges();
            }
        }
    }
}
