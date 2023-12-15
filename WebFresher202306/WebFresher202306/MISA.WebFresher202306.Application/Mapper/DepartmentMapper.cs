using AutoMapper;
using WebFresher202306.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    public class DepartmentMapper : Profile
    {
        public DepartmentMapper()
        {
            CreateMap<DepartmentCreate, Department>().ReverseMap();
            CreateMap<DepartmentUpdate, Department>().ReverseMap();

            CreateMap<Department, DepartmentDTO>().ReverseMap();
        }
    }
}
