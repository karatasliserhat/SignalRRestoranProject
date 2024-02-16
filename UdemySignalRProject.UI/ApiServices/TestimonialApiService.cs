using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class TestimonialApiService : GenericApiService<CreateTestimonialDto, UpdateTestimonialDto, ResultTestimonialDto>, ITestimonialApiService
    {
        public TestimonialApiService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
