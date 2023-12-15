using AutoMapper;
using WebFresher202306.Domain;
namespace WebFresher202306.Application
{
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {

            CreateMap<EmployeeCreate, Employee>().ReverseMap();
            CreateMap<EmployeeUpdate, Employee>().ReverseMap();

            CreateMap<Employee, EmployeeDTO>().ReverseMap();

            CreateMap<FilterEmployee, FilterEmployeeDTO>();

            CreateMap<Employee,EmployeeExcel>().ReverseMap();

        }
    }
}
