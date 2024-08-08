using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Juice_World.Data;
using System;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
					Description = "A tropical delight with a mango twist! Smooth, sweet, and full of sunshine in a bottle.",
					ReleaseDate = DateTime.Parse("2024-7-15"),
					Type = "Fruit",
					Price = 7.49M,
					ImageUrl = "Mystic Mango.png"
				},
				#endregion

				#region Citrus Celestial
				new Juice
				{
					Title = "Citrus Celestial",
					Description = "Blast off with this zesty blend of oranges, lemons, and limes. A heavenly burst of citrus flavor!",
					ReleaseDate = DateTime.Parse("2024-6-22"),
					Type = "Fruit",
					Price = 6.49M,
					ImageUrl = "Citrus Celestial.png"
				},
				#endregion

				#region Zesty Zucchini
				new Juice
				{
					Title = "Zesty Zucchini",
					Description = "A surprisingly refreshing veggie juice with a hint of spice. Crunchy, zesty, and utterly unique!",
					ReleaseDate = DateTime.Parse("2024-5-30"),
					Type = "Veggie",
					Price = 5.79M,
					ImageUrl = "Zesty Zucchini.png"
				},
				#endregion

				#region Berry Bliss
				new Juice
				{
					Title = "Berry Bliss",
					Description = "Dive into a berry paradise with this sweet and tangy mix of strawberries, blueberries, and raspberries.",
					ReleaseDate = DateTime.Parse("2024-4-10"),
					Type = "Fruit",
					Price = 6.99M,
					ImageUrl = "Berry Bliss.png"
				},
				#endregion

				#region Sweet Spinach
				new Juice
				{
					Title = "Sweet Spinach",
					Description = "Don’t let the name fool you—this spinach juice is surprisingly sweet with a hint of natural goodness.",
					ReleaseDate = DateTime.Parse("2024-3-25"),
					Type = "Veggie",
					Price = 5.89M,
					ImageUrl = "Sweet Spinach.png"
				},
				#endregion

				#region Tropical Tango
				new Juice
				{
					Title = "Tropical Tango",
					Description = "A dance of pineapple, mango, and passion fruit. This tropical blend will have your taste buds twirling!",
					ReleaseDate = DateTime.Parse("2024-2-5"),
					Type = "Fruit",
					Price = 7.19M,
					ImageUrl = "Tropical Tango.png"
				},
				#endregion

				#region Crunchy Cucumber
				new Juice
				{
					Title = "Crunchy Cucumber",
					Description = "Cool, crisp, and refreshingly light. This cucumber juice is a perfect pick-me-up for any time of day.",
					ReleaseDate = DateTime.Parse("2024-1-18"),
					Type = "Veggie",
					Price = 5.59M,
					ImageUrl = "Crunchy Cucumber.png"
				},
				#endregion

				#region Radiant Raspberry
				new Juice
				{
					Title = "Radiant Raspberry",
					Description = "Bursting with vibrant raspberry flavor and a touch of sweetness. This juice is pure, radiant bliss.",
					ReleaseDate = DateTime.Parse("2023-12-10"),
					Type = "Fruit",
					Price = 6.89M,
					ImageUrl = "Radiant Raspberry.png"
				},
				#endregion

				#region Peppery Parsley
				new Juice
				{
					Title = "Peppery Parsley",
					Description = "A bold, peppery kick meets the fresh taste of parsley. Ideal for those who like their juice with a bit of attitude!",
					ReleaseDate = DateTime.Parse("2023-11-20"),
					Type = "Veggie",
					Price = 5.99M,
					ImageUrl = "Peppery Parsley.png"
				},
				#endregion

				#region Gleaming Grapefruit
				new Juice
				{
					Title = "Gleaming Grapefruit",
					Description = "Bright and tangy, with a refreshing twist of grapefruit. This juice is like a burst of sunshine in every sip.",
					ReleaseDate = DateTime.Parse("2023-10-7"),
					Type = "Fruit",
					Price = 7.29M,
					ImageUrl = "Gleaming Grapefruit.png"
				}
				#endregion
				);
                context.SaveChanges();

				#region Clean Up The Items Directory
				if (Directory.Exists("wwwroot/images/items")) DeleteDirectory("wwwroot/images/items");
				Directory.CreateDirectory("wwwroot/images/items");
				#endregion

				#region Copy Seeded Image To Images
				foreach (var item in context.Juice!)
                {
					string fileToCopy = "wwwroot/images/seeded items/" + item.ImageUrl;
					string destinationDirectory = "wwwroot/images/items/" + Path.GetFileName(fileToCopy);

					if (!File.Exists(destinationDirectory)) File.Copy(fileToCopy, destinationDirectory);
                }
                #endregion
            }
        }
		public static void DeleteDirectory(string target_dir)
		{
			string[] files = Directory.GetFiles(target_dir);
			string[] dirs = Directory.GetDirectories(target_dir);

			System.Diagnostics.Debug.WriteLine("AAAAAAAAAAAAAAAAAAAAa");
			foreach (string file in files)
			{
				File.SetAttributes(file, FileAttributes.Normal);
				File.Delete(file);
			}

			foreach (string dir in dirs)
			{
				DeleteDirectory(dir);
			}

			Directory.Delete(target_dir, false);
		}
	}
}
