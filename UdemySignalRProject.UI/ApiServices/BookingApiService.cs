using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class BookingApiService : GenericApiService<CreateBookingDto, UpdateBookingDto, ResultBookingDto>, IBookingApiService
    {
        public BookingApiService(HttpClient httpClient) : base(httpClient)
        {
        }
    }
}
