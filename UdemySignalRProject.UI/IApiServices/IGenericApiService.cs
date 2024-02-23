namespace UdemySignalRProject.UI.IApiServices
{
    public interface IGenericApiService<CreateDto,UpdateDto,ResultDto> 
        where CreateDto : class
        where UpdateDto : class
        where ResultDto : class
    {
        Task<List<ResultDto>> GetListAsync(string controllerName);
        Task<List<ResultDto>> GetListAsync(string controllerName,string actionName);
        Task<HttpResponseMessage> CrateAsync(CreateDto entity, string controllerName);

        Task<HttpResponseMessage> UpdateAsync(UpdateDto entity, string controllerName);
        Task<HttpResponseMessage> DeleteAsync( int id, string controllerName);
        Task<HttpResponseMessage> DeleteAsync( string id, string controllerName);
        Task<ResultDto> GetByIdAsync(int id, string controllerName);
        Task<UpdateDto> UpdateGetByIdAsync(int id, string controllerName);
        Task<UpdateDto> UpdateGetByIdAsync(string id, string controllerName);
    }
}
