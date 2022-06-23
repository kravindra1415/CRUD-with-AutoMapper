using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Models.Services
{
    public class UserService : IUserService
    {
        private readonly UserManagementContext _context;
        private readonly IMapper _mapper;

        public UserService(UserManagementContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //here we take data from datamodel to our viewmodel
        public async Task<List<UserViewModel>> GetAllAsync()
        {
            var users = await _context.Users.Include("DepartmentRef").ToListAsync();

            var userViewModel = users
                .Select(u => _mapper.Map<UserViewModel>(u)).ToList();

            return userViewModel;
        }

        public async Task<UserViewModel> GetByIdAsync(int id)
        {
            var user = await _context.Users.Include("DepartmentRef").SingleAsync(u => u.Id == id);

            var userViewModel = _mapper.Map<UserViewModel>(user);

            return userViewModel;
        }

        public async Task UpdateAsync(UserViewModel userViewModel)
        {
            var userToUpdate = await _context.Users.SingleAsync(u => u.Id == userViewModel.Id);

            userToUpdate.FirstName = userViewModel.FirstName;
            userToUpdate.LastName = userViewModel.LastName;
            userToUpdate.DateOfBirth = userViewModel.DateOfBirth;
            userToUpdate.Pan = userViewModel.Pan;
            userToUpdate.Address = userViewModel.Address;
            userToUpdate.Gender = userViewModel.Gender;
            userToUpdate.MobileNumber = userViewModel.MobileNumber;
            userToUpdate.Email = userViewModel.Email;
            userToUpdate.Comments = userViewModel.Comments;
            userToUpdate.DepartmentRefId = userViewModel.DepartmentRefId;

            _context.Users.Update(userToUpdate);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var userToDelete = await _context.Users.Include("DepartmentRef").SingleAsync(u => u.Id == id);

            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task CreateAsync(UserViewModel userViewModel)
        {
            var userToAdd = _mapper.Map<User>(userViewModel);

            await _context.Users.AddAsync(userToAdd);
            await _context.SaveChangesAsync();
        }
    }

}
