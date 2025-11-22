using MediatR;
using Microservice.Shared.Extensions;
using Microservice.Shared.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Catalog.Api.Features.Categories.Create
{
    public static class CreateCategoryEndpoint
    {
        public static RouteGroupBuilder CreateCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            //group.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) =>
            //{
            //    var result = await mediator.Send(command);

            //    return result.ToGenericResult();
            //});

            //return group;

            //Kısa hali
            group.MapPost("/", async (CreateCategoryCommand command, IMediator mediator) => (await mediator.Send(command)
            ).ToGenericResult()).AddEndpointFilter<ValidationFilter<CreateCategoryCommand>>();

            return group;
        }
    }
}
