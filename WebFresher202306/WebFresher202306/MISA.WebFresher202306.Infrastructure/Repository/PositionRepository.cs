using WebFresher202306.Application;
using WebFresher202306.Domain;

namespace WebFresher202306.Infrastructure
{
    public class PositionRepository : ReadOnlyRepository<Position, Guid>, IPositionRepository
    {
        public PositionRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
