using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Domain
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IPositionRepository _positionRepository;

        public EmployeeManager(IDepartmentRepository departmentRepository, IPositionRepository positionRepository)
        {
            _departmentRepository = departmentRepository;
            _positionRepository = positionRepository;
        }

        /// <summary>
        /// hàm kiểm tra ràng buộc
        /// </summary>
        /// <param name="departmentId">mã phòng ban</param>
        /// <param name="positionId">mã chức danh</param>
        /// <returns>mã lỗi</returns>
        /// author: Trương Mạnh Quang
        public async Task<ErrorCode> CheckValidConstraint(Guid departmentId, Guid positionId)
        {
            var department = await _departmentRepository.GetByIdAsync(departmentId);

            if (department == null) { return  ErrorCode.InvalidDepartment; }

            var position = await _positionRepository.GetByIdAsync(positionId);

            if(position == null) { return ErrorCode.InvalidPosition; }

            return ErrorCode.Valid;
        }
    }
}
