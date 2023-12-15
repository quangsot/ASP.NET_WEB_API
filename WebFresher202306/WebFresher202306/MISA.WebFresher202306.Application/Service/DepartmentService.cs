using AutoMapper;
using WebFresher202306.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    public class DepartmentService : ReadOnlyService<Department, DepartmentDTO, Guid>, IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper) : base(departmentRepository)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public override DepartmentDTO MapTEntityToTEntityDto(Department entity)
        {
            var entityDTO = _mapper.Map<Department, DepartmentDTO>(entity);
            return entityDTO;
        }
    }
}
