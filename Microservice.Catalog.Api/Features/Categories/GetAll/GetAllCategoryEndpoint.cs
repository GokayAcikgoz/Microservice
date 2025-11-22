namespace Microservice.Catalog.Api.Features.Categories.GetAll
{
    //refactoring
    public class GetAllCategoryQuery : IRequestByServiceResult<List<CategoryDto>>;
    
    
    //public class GetAllCategoryQuery : IRequest<ServiceResult<List<CategoryDto>>>;

    public class GetAllCategoryQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetAllCategoryQuery, ServiceResult<List<CategoryDto>>>
    {
        public async Task<ServiceResult<List<CategoryDto>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = await context.Categories.ToListAsync(cancellationToken);
            var categoriesAsDto = mapper.Map<List<CategoryDto>>(categories);

            return ServiceResult<List<CategoryDto>>.SuccessAsOkey(categoriesAsDto);
        }
    }




    public static class GetAllCategoryEndpoint
    {
        public static RouteGroupBuilder GetAllCategoryGroupItemEndpoint(this RouteGroupBuilder group)
        {
            group.MapGet("/", async (IMediator mediator) => (await mediator.Send(new GetAllCategoryQuery())).ToGenericResult());

            return group;
        }
    }
}
