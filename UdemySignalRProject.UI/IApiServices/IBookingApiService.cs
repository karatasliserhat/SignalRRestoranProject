using UdemySignalRProject.UI.Dtos;

namespace UdemySignalRProject.UI.IApiServices
{
    public interface IBookingApiService : IGenericApiService<CreateBookingDto, UpdateBookingDto, ResultBookingDto>
    {
    }
}
