using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    /// <summary>
    /// DTO phòng ban được trả về
    /// </summary>
    /// author: Trương Mạnh Quang (15/8/2023)
    public class DepartmentDTO
    {
        /// <summary>
        /// id phòng ban
        /// </summary>
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// mã phòng ban
        /// </summary>
        public string DepartmentCode { get; set; }

        /// <summary>
        /// tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }
    }
}
