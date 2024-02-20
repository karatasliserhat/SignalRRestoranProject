using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class SliderApiService : GenericApiService<CreateSliderDto, UpdateSliderDto, ResultSlidereDto>,ISliderApiService
    {
        public SliderApiService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
