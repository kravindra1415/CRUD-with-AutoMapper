using AutoMapper;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Department, DepartmentViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();
        }
    }
}
