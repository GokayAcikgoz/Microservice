using AutoMapper;
using MediatR;
using Microservice.Catalog.Api.Features.Categories.Dtos;
using Microservice.Catalog.Api.Features.Categories.GetAll;
using Microservice.Catalog.Api.Repositories;
using Microservice.Shared;
using Microservice.Shared.Extensions;
using System.Net;

namespace Microservice.Catalog.Api.Features.Categories.GetById
{
    public record GetCategoryByIdQuery(Guid Id) : IRequest<ServiceResult<CategoryDto>>;


    public class GetCategoryByIdQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetCategoryByIdQuery, ServiceResult<CategoryDto>>
    {
        public async Task<ServiceResult<CategoryDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var hasCategory = await context.Categories.FindAsync(request.Id, cancellationToken);

            if (hasCategory is null)
            {
                return ServiceResult<CategoryDto>.Error("Category Not Found", $"Category with id '{request.Id}' was not found.", HttpStatusCode.NotFound);
            }

            var categoryDto = mapper.Map<CategoryDto>(hasCategory);
            return ServiceResult<CategoryDto>.SuccessAsOkey(categoryDto);
        }
    }




    public static class GetCategoryByIdEnpoint
    {
        public static RouteGroupBuilder GetCategoryByIdGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/{id:guid}", async (IMediator mediator, Guid id) => (await mediator.Send(new GetCategoryByIdQuery(id))).ToGenericResult());

            return group;
        }
    }
}
