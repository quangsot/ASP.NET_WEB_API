using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    public interface IDepartmentService : IReadOnlyService<DepartmentDTO, Guid>
    {
    }
}
