namespace Microservice.Catalog.Api.Features.Categories.Create
{
    public class CreateCategoryCommandHandler(AppDbContext context) : IRequestHandler<CreateCategoryCommand, ServiceResult<CreateCategoryResponse>>
    {
        public async Task<ServiceResult<CreateCategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            
            var existCategory = await context.Categories.AnyAsync(x => x.Name == request.Name, cancellationToken);

            if (existCategory)
            {
                return ServiceResult<CreateCategoryResponse>.Error("Category Name already exists.", $"The category name '{request.Name}' already exists", HttpStatusCode.BadRequest);
            }

            var category = new Category
            {
                Name = request.Name,
                Id = NewId.NextSequentialGuid(), // Indexleme performansı için sequential guid kullanıyoruz. Biribirne benzer ama farklı guid ler üretir.
            };  

            await context.Categories.AddAsync(category, cancellationToken); //canncellationToken ekledik. İptal edilebilir işlemler için. .net frameworukun kendisi fırlatıyor.
            //async metotlar exception fırlatmadan durmaz. kullanıcı tarayıcıyı açtı kapatırsa iptal edilebilir olması için.

            await context.SaveChangesAsync(cancellationToken);

            return ServiceResult<CreateCategoryResponse>.SuccessAsCreated(new CreateCategoryResponse(category.Id), "<empty>");
        }
    }
}
