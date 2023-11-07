using dscc_web_app.Models;

namespace dscc_web_app.Services
{
    public class PostService : IPostService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public PostService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        private string ApiBaseUrl => _configuration.GetSection("ApiBaseUrl").Value;

        public async Task<IEnumerable<PostViewModel>> GetPostsAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<PostViewModel>>(ApiBaseUrl + "/api/posts");
            return response;
        }

        public async Task<PostViewModel> GetPostAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<PostViewModel>(ApiBaseUrl + $"/api/posts/{id}");
            return response;
        }

        public async Task<HttpResponseMessage> CreatePostAsync(PostViewModel post)
        {
            return await _httpClient.PostAsJsonAsync(ApiBaseUrl + "/api/posts", post);
        }

        public async Task<HttpResponseMessage> UpdatePostAsync(int id, PostViewModel post)
        {
            return await _httpClient.PutAsJsonAsync(ApiBaseUrl + $"/api/posts/{id}", post);
        }

        public async Task<HttpResponseMessage> DeletePostAsync(int id)
        {
            return await _httpClient.DeleteAsync(ApiBaseUrl + $"/api/posts/{id}");
        }
    }
}
