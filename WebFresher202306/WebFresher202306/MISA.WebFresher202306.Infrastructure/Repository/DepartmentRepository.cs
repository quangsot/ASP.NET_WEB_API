using Dapper;
using WebFresher202306.Application;
using WebFresher202306.Domain;

namespace WebFresher202306.Infrastructure
{
    public class DepartmentRepository : ReadOnlyRepository<Department, Guid>, IDepartmentRepository
    {
        public new string TableName = "Department";
        public DepartmentRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
