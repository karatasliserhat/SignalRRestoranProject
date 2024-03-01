using UdemySignalRProject.UI.Dtos;

namespace UdemySignalRProject.UI.IApiServices
{
    public interface IBookingApiService : IGenericApiService<CreateBookingDto, UpdateBookingDto, ResultBookingDto>
    {
        Task<HttpResponseMessage> BookingStatusApproved(string controllerName, string actionName, string id);
        Task<HttpResponseMessage> BookingStatusCancelled(string controllerName, string actionName, string id);
    }
}

