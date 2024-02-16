using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class SocialMediaApiService : GenericApiService<CreateSocialMediaDto, UpdateSocialMediaDto, ResultSocialMediaDto>, ISocialMediaApiService
    {
        public SocialMediaApiService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
