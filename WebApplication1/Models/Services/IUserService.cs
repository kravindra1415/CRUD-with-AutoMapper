using WebApplication1.Models.ViewModel;

namespace WebApplication1.Models.Services
{
    public interface IUserService
    {
        Task CreateAsync(UserViewModel userViewModel);
        Task<List<UserViewModel>> GetAllAsync();
        Task<UserViewModel> GetByIdAsync(int id);
        Task UpdateAsync(UserViewModel userViewModel);

        Task DeleteAsync(int id);
    }
}