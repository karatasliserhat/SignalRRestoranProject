using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class FeatureApiService : GenericApiService<CreateFeatureDto, UpdateFeatureDto, ResultFeatureDto>, IFeatureApiService
    {
        public FeatureApiService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
