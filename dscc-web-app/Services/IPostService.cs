using dscc_web_app.Models;

namespace dscc_web_app.Services
{
    public interface IPostService
    {
        Task<HttpResponseMessage> CreatePostAsync(PostViewModel post);
        Task<HttpResponseMessage> DeletePostAsync(int id);
        Task<PostViewModel?> GetPostAsync(int id);
        Task<IEnumerable<PostViewModel>?> GetPostsAsync();
        Task<HttpResponseMessage> UpdatePostAsync(PostViewModel post);
    }
}