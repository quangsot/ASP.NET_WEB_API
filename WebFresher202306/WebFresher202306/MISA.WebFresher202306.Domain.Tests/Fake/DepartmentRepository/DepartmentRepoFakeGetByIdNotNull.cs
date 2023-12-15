using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Domain.Tests
{
    public  class DepartmentRepoFakeGetByIdNotNull : DepartmentRepositoryFake
    {
        public override Task<Department?> GetByIdAsync(Guid id)
        {
            CountCall++;
            Department department = new();
            return Task.FromResult<Department?>(department);
        }
    }
}
