using MediatR;
using Microservice.Shared;

namespace Microservice.Catalog.Api.Features.Categories.Create
{
    //Immutable nesne için kullanılır. İçeriği değiştirilemez nesnedir.

    //refactoring
    public record CreateCategoryCommand(string Name) : IRequestByServiceResult<CreateCategoryResponse>;


    //public record CreateCategoryCommand(string Name) : IRequest<ServiceResult<CreateCategoryResponse>>;

    //yukarıdaki ile aynıdır. Inıt bir kere oluşturulunca bir daha değiştirme yapamassın inmutable yani.
    //public record x
    //{
    //    public string Name { get; init; }
    //    public x(string name)
    //    {
    //        Name = name;
    //    }
    //}



}
