using Microservice.Catalog.Api.Features.Categories;
using Microservice.Catalog.Api.Features.Courses;
using MongoDB.Driver;

namespace Microservice.Catalog.Api.Repositories
{
    public static class SeedData
    {
        public static async Task AddSeedDataExt(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            dbContext.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

            if (!dbContext.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new() { Id = NewId.NextSequentialGuid(), Name = "Development" },
                    new() { Id = NewId.NextSequentialGuid(), Name = "Business" },
                    new() { Id = NewId.NextSequentialGuid(), Name = "IT & Software" },
                    new() { Id = NewId.NextSequentialGuid(), Name = "Office Producivity" },
                    new() { Id = NewId.NextSequentialGuid(), Name = "Personal Development" }
                };

                dbContext.Categories.AddRange(categories);
                await dbContext.SaveChangesAsync();
            }


            if (!dbContext.Courses.Any())
            {
                var category = dbContext.Categories.FirstAsync();

                var randomUserId = NewId.NextGuid();

                List<Course> courses = new()
                {
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "Complete C# Masterclass",
                        Description= "Learn C# from scratch to advanced topics.",
                        Price = 100,
                        UserId = randomUserId,
                        Created = DateTime.UtcNow,
                        Feature = new Feature{ Duration = 10, Rating = 4, EducationFullName = "Ahmet Yıldız" },
                        CategoryId = category.Result.Id
                    },
                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "Business Analysis Fundamentals",
                        Description= "Understand the basics of business analysis.",
                        Price = 80,
                        UserId = randomUserId,
                        Created = DateTime.UtcNow,
                        Feature = new Feature{ Duration = 8, Rating = 4, EducationFullName = "Mehmet Demir" },
                        CategoryId = category.Result.Id
                    },

                    new()
                    {
                        Id = NewId.NextSequentialGuid(),
                        Name = "Mastering IT Infrastructure",
                        Description= "Comprehensive guide to IT infrastructure management.",
                        Price = 120,
                        UserId = randomUserId,
                        Created = DateTime.UtcNow,
                        Feature = new Feature{ Duration = 12, Rating = 5, EducationFullName = "Ayşe Kaya" },
                        CategoryId = category.Result.Id
                    }

                };

                dbContext.Courses.AddRange(courses);
                await dbContext.SaveChangesAsync();
            }

            
        }
    }
}
