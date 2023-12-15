using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Domain.Tests
{
    public class PositionRepoFakeGetByIdNotNull : PositionRepositoryFake
    {
        public override Task<Position?> GetByIdAsync(Guid id)
        {
            CountCall++;
            Position position = new();
            return Task.FromResult<Position?>(position);
        }
    }
}
