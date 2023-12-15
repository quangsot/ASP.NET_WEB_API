using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Domain
{
    public interface IEmployeeManager
    {
        /// <summary>
        /// kiểm tra các ràng buộc
        /// </summary>
        /// <param name="departmentId">mã phòng ban</param>
        /// <param name="positionId">mã chức danh</param>
        /// <returns>mã lỗi</returns>
        /// author: Trương Mạnh Quang (19/8/2023)
        Task<ErrorCode> CheckValidConstraint(Guid departmentId, Guid positionId);
    }
}
