using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class ContactApiService : GenericApiService<CreateContactDto, UpdateContactDto, ResultContactDto>, IContactApiService
    {
        public ContactApiService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
