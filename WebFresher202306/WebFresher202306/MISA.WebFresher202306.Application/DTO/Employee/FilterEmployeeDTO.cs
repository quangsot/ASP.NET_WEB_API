using WebFresher202306.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    public class FilterEmployeeDTO
    {
        /// <summary>
        /// tổng số bản ghi
        /// </summary>
        public long TotalRecords { get; set; } = 0;

        /// <summary>
        /// tổng số trang
        /// </summary>
        public long TotalPages { get; set; } = 0;

        /// <summary>
        /// trang hiện tại
        /// </summary>
        public long CurrentPage { get; set; } = 0;

        /// <summary>
        /// số bản ghi hiện tại
        /// </summary>
        public long CurrentRecords { get; set; } = 0;

        /// <summary>
        /// danh sách nhân viên được lọc
        /// </summary>
        public IEnumerable<EmployeeDTO>? Employees { get; set; } = Enumerable.Empty<EmployeeDTO>();
    }
}
