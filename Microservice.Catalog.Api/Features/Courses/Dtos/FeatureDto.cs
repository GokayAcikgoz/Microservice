namespace Microservice.Catalog.Api.Features.Courses.Dtos
{
    public class FeatureDto
    {
        public int Duration { get; set; }
        public float Rating { get; set; }
        public string EducationFullName { get; set; } = default!;
    }
}
