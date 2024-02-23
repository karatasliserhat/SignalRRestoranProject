using UdemySignalRProject.UI.Dtos;
using UdemySignalRProject.UI.IApiServices;

namespace UdemySignalRProject.UI.ApiServices
{
    public class GenericApiService<CreateDto, UpdateDto, ResultDto> : IGenericApiService<CreateDto, UpdateDto, ResultDto>
        where CreateDto : class
        where UpdateDto : class
        where ResultDto : class
    {
        private readonly HttpClient _httpClient;

        public GenericApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultDto>> GetListAsync(string controllerName)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultDto>>(controllerName);

            return response;
        }
        public async Task<List<ResultDto>> GetListAsync(string controllerName,string actionName)
        {
            var response = await _httpClient.GetFromJsonAsync<List<ResultDto>>($"{ controllerName}/{actionName}");

            return response;
        }
        public async Task<HttpResponseMessage> CrateAsync(CreateDto entity, string controllerName)
        {
            var response = await _httpClient.PostAsJsonAsync<CreateDto>(controllerName, entity);
            return response;
        }

        public async Task<HttpResponseMessage> DeleteAsync(int id, string controllerName)
        {
            var response = await _httpClient.DeleteAsync($"{controllerName}/{id}");
            return response;
        }
        public async Task<HttpResponseMessage> DeleteAsync(string id, string controllerName)
        {
            var response = await _httpClient.DeleteAsync($"{controllerName}/{id}");
            return response;
        }
        public async Task<ResultDto> GetByIdAsync(int id, string controllerName)
        {
            var response = await _httpClient.GetFromJsonAsync<ResultDto>($"{controllerName}/{id}");

            return response;
        }



        public async Task<HttpResponseMessage> UpdateAsync(UpdateDto entity, string controllerName)
        {
            var response = await _httpClient.PutAsJsonAsync<UpdateDto>(controllerName, entity);
            return response;
        }

        public async Task<UpdateDto> UpdateGetByIdAsync(int id, string controllerName)
        {
            var response = await _httpClient.GetFromJsonAsync<UpdateDto>($"{controllerName}/{id}");

            return response;
        }
        public async Task<UpdateDto> UpdateGetByIdAsync(string id, string controllerName)
        {
            var response = await _httpClient.GetFromJsonAsync<UpdateDto>($"{controllerName}/{id}");

            return response;
        }
    }
}
