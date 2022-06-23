using WebApplication1.Models.ViewModel;

namespace WebApplication1.Models.Services
{
    public interface IDepartmentService
    {
        Task<List<DepartmentViewModel>> GetAllAsync();
        Task<DepartmentViewModel> GetByIdAsync(int id);
        Task UpdateAsync(DepartmentViewModel departmentViewModel);
        Task DeleteAsync(int id);
        Task CreateAsync(DepartmentViewModel departmentViewModel);
    }
}