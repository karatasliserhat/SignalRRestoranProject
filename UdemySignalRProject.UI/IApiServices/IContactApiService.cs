using UdemySignalRProject.UI.Dtos;

namespace UdemySignalRProject.UI.IApiServices
{
    public interface IContactApiService:IGenericApiService<CreateContactDto,UpdateContactDto,ResultContactDto>
    {
    }
}
