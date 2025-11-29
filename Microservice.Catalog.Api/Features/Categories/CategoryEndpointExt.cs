using Asp.Versioning.Builder;
using Microservice.Catalog.Api.Features.Categories.Create;
using Microservice.Catalog.Api.Features.Categories.GetAll;
using Microservice.Catalog.Api.Features.Categories.GetById;

namespace Microservice.Catalog.Api.Features.Categories
{
    public static class CategoryEndpointExt
    {
        public static void AddCategoryGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{apiVersionSet}/categories")
                .WithApiVersionSet(apiVersionSet)
                .WithTags("Categories")
                .CreateCategoryGroupItemEndpoint()
                .GetAllCategoryGroupItemEndpoint()
                .GetCategoryByIdGroupItemEndpoint();
        }
    }
}
