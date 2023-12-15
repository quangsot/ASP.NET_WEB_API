using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Domain.Tests
{
    public class PositionRepositoryFake : IPositionRepository
    {
        public int CountCall { get; set; } = 0;
        public Task<IEnumerable<Position>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public virtual Task<Position?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Position>> GetByIdsAsync(List<Guid> ids)
        {
            throw new NotImplementedException();
        }
    }
}
