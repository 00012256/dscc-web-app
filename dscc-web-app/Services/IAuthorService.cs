using dscc_web_app.Models;

namespace dscc_web_app.Services
{
    public interface IAuthorService
    {
        Task<HttpResponseMessage> CreateAuthorAsync(AuthorViewModel author);
        Task<HttpResponseMessage> DeleteAuthorAsync(int id);
        Task<AuthorViewModel?> GetAuthorAsync(int id);
        Task<IEnumerable<AuthorViewModel>?> GetAuthorsAsync();
        Task<HttpResponseMessage> UpdateAuthorAsync(AuthorViewModel author);
    }
}