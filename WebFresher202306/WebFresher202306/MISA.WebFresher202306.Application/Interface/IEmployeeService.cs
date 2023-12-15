using WebFresher202306.Domain;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    /// <summary>
    /// author: Trương Mạnh Quang (15/8/2023)
    /// </summary>
    public interface IEmployeeService : ICrudService<EmployeeDTO,Guid,EmployeeCreate,EmployeeUpdate>
    {
        /// <summary>
        /// hàm lọc danh sách nhân viên
        /// </summary>
        /// <param name="searchKey"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNum"></param>
        /// <returns>đối tượng filter</returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<FilterEmployeeDTO> FilterAsync(string? searchKey, int pageSize, int pageNum);

        /// <summary>
        /// hàm lấy mã mới
        /// </summary>
        /// <returns>mã mới</returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<string> GetNewCodeAsync();

        /// <summary>
        /// hàm sinh mã mới tiếp theo
        /// </summary>
        /// <returns>mã mới</returns>
        /// author: Trương Mạnh Quang (30/8/2023)
        Task<string> GetNextCodeAsync(string oldCode);

        /// <summary>
        /// hàm xuất file excel
        /// </summary>
        /// <param name="searchKey">từ khóa tìm kiếm</param>
        /// <returns>excel package</returns>
        /// author: Trương Mạnh Quang (21/8/2023)
        Task<ExcelPackage> ExportExcelAsync(string? searchKey);
    }
}
