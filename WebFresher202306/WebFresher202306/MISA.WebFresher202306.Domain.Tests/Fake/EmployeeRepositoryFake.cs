using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Domain.Tests
{
    public class EmployeeRepositoryFake : IEmployeeRepository
    {
        public Task<bool> CheckDuplicateCodeAsync(string code)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> CreateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(Employee entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteManyAsync(List<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public Task<FilterEmployee> FilterAsync(string? searchKey, int pageSize, int pageNum)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetByIdsAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNewCodeAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetNextCodeAsync(string oldCode)
        {
            throw new NotImplementedException();
        }

        public Task<Employee> UpdateAsync(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
