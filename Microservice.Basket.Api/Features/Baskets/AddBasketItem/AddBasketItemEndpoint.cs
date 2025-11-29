using MediatR;
using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;

namespace Microservice.Basket.Api.Features.Baskets.AddBasketItem
{
    public static class AddBasketItemEndpoint
    {
        public static RouteGroupBuilder AddBasketItemGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapPost("/item", async (AddBasketItemCommand command, IMediator mediator) => (await mediator.Send(command)
            ).ToGenericResult()).WithName("CreateCategory").MapToApiVersion(1, 0).AddEndpointFilter<ValidationFilter<AddBasketItemCommandValidator>>();

            return group;
        }
    }
}
