namespace Microservice.Catalog.Api.Features.Courses.Update
{
    public class UpdateCourseCommandValidator : AbstractValidator<UpdateCourseCommand>
    {
        public UpdateCourseCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("{PropertyName} is required")
               .MaximumLength(100).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("{PropertyName} is required")
                .MaximumLength(1000).WithMessage("{PropertyName} must not exceed {MaxLength} characters.");

            RuleFor(x => x.Price).GreaterThanOrEqualTo(0).WithMessage("{PropertyName} must be greater than or equal to {ComparisonValue}.");

            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("{PropertyName} is required");


        }
    }
}
