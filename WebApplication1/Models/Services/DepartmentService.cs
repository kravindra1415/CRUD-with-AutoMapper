using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Models.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly UserManagementContext _context;
        private readonly IMapper _mapper;

        public DepartmentService(UserManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<DepartmentViewModel>> GetAllAsync()
        {
            // EF returns List of DataModel
            var departments = await _context.Departments.ToListAsync();

            // Create a copy of the DataModel into the ViewModel

            //var departmentsViewModel = new List<DepartmentViewModel>();

            //foreach (var department in departments)
            //{
            //    var departmentModel = new DepartmentViewModel
            //    {
            //        Id = department.Id,
            //        Name = department.Name,
            //        Description = department.Description
            //    };

            //    var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);
            //    departmentsViewModel.Add(departmentViewModel);
            //}

            var departmetnsViewModel = departments
                .Select(d => _mapper.Map<DepartmentViewModel>(d)).ToList();

            // return List of ViewModel
            return departmetnsViewModel;
        }

        public async Task<DepartmentViewModel> GetByIdAsync(int id)
        {
            var department = await _context.Departments.SingleAsync(d => d.Id == id);

            var departmentViewModel = _mapper.Map<DepartmentViewModel>(department);
            return departmentViewModel;
        }

        public async Task UpdateAsync(DepartmentViewModel departmentViewModel)
        {
            var departmentToUpdate = await _context.Departments.SingleAsync(d => d.Id == departmentViewModel.Id);

            departmentToUpdate.Name = departmentViewModel.Name;
            departmentToUpdate.Description = departmentViewModel.Description;

            _context.Departments.Update(departmentToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var departmentToDelete = await _context.Departments.SingleAsync(d => d.Id == id);

            _context.Departments.Remove(departmentToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(DepartmentViewModel departmentViewModel)
        {
            var departmetnToAdd = _mapper.Map<Department>(departmentViewModel);

            await _context.Departments.AddAsync(departmetnToAdd);
            await _context.SaveChangesAsync();
        }

    }
}
