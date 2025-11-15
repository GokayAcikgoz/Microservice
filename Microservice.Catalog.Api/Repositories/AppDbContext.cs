using Microservice.Catalog.Api.Features.Categories;
using Microservice.Catalog.Api.Features.Courses;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Reflection;

namespace Microservice.Catalog.Api.Repositories
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Category> Categories { get; set; }



        public static AppDbContext Create(IMongoDatabase database)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>().UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName);

            return new AppDbContext(optionsBuilder.Options);
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            ////Collection(tablo ismi) - document(satır ismi) - field (satır ismi)
            //modelBuilder.Entity<Course>().ToCollection("courses");
            //modelBuilder.Entity<Course>().HasKey(x => x.Id);
            //modelBuilder.Entity<Course>().Property(x => x.Id).ValueGeneratedNever(); //id yi biz belirleyeceğiz. db belirlemesin.
            //modelBuilder.Entity<Course>().Property(x => x.Name).HasElementName("name").HasMaxLength(100); //field ismi name olacak küçük harf. max uzunluk 100 olacak.
            //modelBuilder.Entity<Course>().Property(x => x.Description).HasElementName("description").HasMaxLength(1000);
            //modelBuilder.Entity<Course>().Property(x => x.Created).HasElementName("created");
            //modelBuilder.Entity<Course>().Property(x => x.UserId).HasElementName("userId");
            //modelBuilder.Entity<Course>().Property(x => x.Picture).HasElementName("picture");
            //modelBuilder.Entity<Course>().Property(x => x.CategoryId).HasElementName("categoryId");
            //modelBuilder.Entity<Course>().Ignore(x => x.Category); //ilişkiyi kurmayacağız. category ı ignore ettik. field olarak eklenmeyecek. biz ayrı collection da tutacağız.

            ////owned type. Feature için ayrı bir tablo oluşturulmaz. Course tablosunun içinde tutulur. ef core un bir özelliği.
            //modelBuilder.Entity<Course>().OwnsOne(c => c.Feature, feature =>
            //{
            //    feature.HasElementName("feature"); //field ismi feature olacak küçük harf.
            //    feature.Property(f => f.Duration).HasElementName("duration");
            //    feature.Property(f => f.Rating).HasElementName("rating");
            //    feature.Property(f => f.EducationFullName).HasElementName("educationFullName").HasMaxLength(100);
            //});

            //modelBuilder.Entity<Category>().ToCollection("categories");
            //modelBuilder.Entity<Category>().HasKey(x => x.Id);
            //modelBuilder.Entity<Category>().Property(x => x.Id).ValueGeneratedNever(); //id yi biz belirleyeceğiz. db belirlemesin.
            //modelBuilder.Entity<Category>().Ignore(x => x.Courses); //ilişkiyi kurmayacağız. course u ignore ettik. field olarak eklenmeyecek. biz ayrı collection da tutacağız.



        }
    }
}
