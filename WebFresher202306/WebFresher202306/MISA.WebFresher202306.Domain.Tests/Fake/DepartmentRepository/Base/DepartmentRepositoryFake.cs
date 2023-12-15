using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Domain.Tests
{
    public class DepartmentRepositoryFake : IDepartmentRepository
    {
        public int CountCall { get; set; } = 0;
        public Task<IEnumerable<Department>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<Department?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Department>> GetByIdsAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }
    }
}
