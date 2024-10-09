using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDto>> GetAllCommentsAsync();
        Task CreateCommentAsync(CreateCommentDto createCommentDto);
        Task UpdateCommentAsync(UpdateCommentDto updateCommentDto);
        Task DeleteCommentAsync(string id);
        Task<ResultCommentDto> GetByIdCommentAsync(string id);
        Task<List<ResultCommentDto>> GetByProductIdCommentsAsync(string productId);
        Task<int> GetTotalCommentCount();
    }
}
