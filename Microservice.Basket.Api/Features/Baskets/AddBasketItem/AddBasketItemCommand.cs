using Microservice.Shared;

namespace Microservice.Basket.Api.Features.Baskets.AddBasketItem
{
    //Bunları zaten courseda tutuyoruz ama burada tekrar tutmamızın sebebi, mikroservi
    //slerin birbirinden bağımsız çalışması gerektiği boşuna course mikroservisine istek atmaya gerek yok. Couplingi azaltmak için.
    public record AddBasketItemCommand(Guid CourseId, string CourseName, decimal CoursePrice, string? ImageUrl):IRequestByServiceResult;

}
