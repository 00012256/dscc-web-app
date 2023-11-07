using dscc_web_app.Models;

namespace dscc_web_app.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public AuthorService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        private string ApiBaseUrl => _configuration.GetSection("ApiBaseUrl").Value;

        public async Task<IEnumerable<AuthorViewModel>> GetAuthorsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<AuthorViewModel>>(ApiBaseUrl + "/api/authors");
            return response;
        }

        public async Task<AuthorViewModel> GetAuthorAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<AuthorViewModel>(ApiBaseUrl + $"/api/authors/{id}");
            return response;
        }

        public async Task<HttpResponseMessage> CreateAuthorAsync(AuthorViewModel author)
        {
            return await _httpClient.PostAsJsonAsync(ApiBaseUrl + "/api/authors", author);
        }

        public async Task<HttpResponseMessage> UpdateAuthorAsync(int id, AuthorViewModel author)
        {
            return await _httpClient.PutAsJsonAsync(ApiBaseUrl + $"/api/authors/{id}", author);
        }

        public async Task<HttpResponseMessage> DeleteAuthorAsync(int id)
        {
            return await _httpClient.DeleteAsync(ApiBaseUrl + $"/api/authors/{id}");
        }
    }
}
