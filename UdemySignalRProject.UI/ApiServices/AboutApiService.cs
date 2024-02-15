using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class AboutApiService : GenericApiService<CreateAboutDto, UpdateAboutDto, ResultAboutDto>, IAboutApiService
    {
        public AboutApiService(HttpClient httpClient) : base(httpClient)
        {

        }
    }
}
