using Microservice.Catalog.Api.Features.Courses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace Microservice.Catalog.Api.Repositories
{
    public class CourseEntityConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            //Collection(tablo ismi) - document(satır ismi) - field (satır ismi)
            builder.ToCollection("courses");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever(); //id yi biz belirleyeceğiz. db belirlemesin.
            builder.Property(x => x.Name).HasElementName("name").HasMaxLength(100); //field ismi name olacak küçük harf. max uzunluk 100 olacak.
            builder.Property(x => x.Description).HasElementName("description").HasMaxLength(1000);
            builder.Property(x => x.Created).HasElementName("created");
            builder.Property(x => x.UserId).HasElementName("userId");
            builder.Property(x => x.ImageUrl).HasElementName("imageUrl").HasMaxLength(200);
            builder.Property(x => x.CategoryId).HasElementName("categoryId");
            builder.Ignore(x => x.Category); //ilişkiyi kurmayacağız. category ı ignore ettik. field olarak eklenmeyecek. biz ayrı collection da tutacağız.

            //owned type. Feature için ayrı bir tablo oluşturulmaz. Course tablosunun içinde tutulur. ef core un bir özelliği.
            builder.OwnsOne(c => c.Feature, feature =>
            {
                feature.HasElementName("feature"); //field ismi feature olacak küçük harf.
                feature.Property(f => f.Duration).HasElementName("duration");
                feature.Property(f => f.Rating).HasElementName("rating");
                feature.Property(f => f.EducationFullName).HasElementName("educationFullName").HasMaxLength(100);
            });
        }
    }
}
