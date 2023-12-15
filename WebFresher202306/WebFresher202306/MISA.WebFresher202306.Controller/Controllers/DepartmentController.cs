using Microsoft.AspNetCore.Mvc;
using WebFresher202306.Application;

namespace WebFresher202306.Controllers
{
    /// <summary>
    /// author: Trương Mạnh Quang (9/8/2023)
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    public class DepartmentController : ReadOnlyController<DepartmentDTO, Guid>
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService) : base(departmentService)
        {
            _departmentService = departmentService;
        }
    }
}
