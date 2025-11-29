using Asp.Versioning.Builder;
using Microservice.Basket.Api.Features.Baskets.AddBasketItem;

namespace Microservice.Basket.Api.Features.Baskets
{
    public static class BasketEndpointExt
    {
        public static void AddBasketGroupEndpointExt(this WebApplication app, ApiVersionSet apiVersionSet)
        {
            app.MapGroup("api/v{apiVersionSet}/baskets")
                .WithApiVersionSet(apiVersionSet)
                .WithTags("Baskets")
                .AddBasketItemGroupItemEndpoint();
        }
    }
}
