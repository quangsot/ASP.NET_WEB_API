using Microsoft.AspNetCore.Mvc;
using WebFresher202306.Application;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebFresher202306.Controllers
{
    /// <summary>
    /// author: Trương Mạnh Quang (4/8/2023)
    /// </summary>
    [Route("v1/api/[controller]")]
    [ApiController]
    public class EmployeesController : CrudController<EmployeeDTO,Guid,EmployeeCreate,EmployeeUpdate>
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }

        /// <summary>
        /// hàm phân trang nhân viên
        /// </summary>
        /// <param name="searchKey">từ khóa tìm kiếm</param>
        /// <param name="pageSize">kích thước trang</param>
        /// <param name="pageNum">số bản ghi</param>
        /// <returns>thông tin phân trang</returns>
        /// <exception cref="ResponseException"></exception>
        /// author: Trương Mạnh Quang (8/8/2023)
        [HttpGet("Filter")]
        public async Task<IActionResult> FilterAsync([FromQuery] string? searchKey = "", [FromQuery] int pageSize = 10, [FromQuery] int pageNum = 1)
        {
            var result = await _employeeService.FilterAsync(searchKey, pageSize, pageNum);

            return Ok(result);
        }


        /// <summary>
        /// hàm lấy mã nhân viên mới
        /// </summary>
        /// <returns></returns>
        /// <exception cref="ResponseException"></exception>
        /// author: Trương Mạnh Quang (8/8/2023)
        [HttpGet("NewCode")]
        public async Task<IActionResult> GetNewCodeAsync()
        {
            var result = await _employeeService.GetNewCodeAsync();

            return Ok(result);
        }
        
        /// <summary>
        /// hàm sinh mã mới tiếp theo
        /// </summary>
        /// <returns>mã mới</returns>
        /// author: Trương Mạnh Quang (30/8/2023)
        [HttpGet("NextCode")]
        public async Task<IActionResult> GetNextCodeAsync(string oldCode)
        {
            var nextCode = await _employeeService.GetNextCodeAsync(oldCode);
            return Ok(nextCode);
        }

        /// <summary>
        /// hàm xuất excel
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns>file excel</returns>
        /// author: Trương Mạnh Quang (20/8/2023)
        [HttpGet("Excel")]
        public async Task<IActionResult> ExportExcel(string? searchKey)
        {
            var excel = await _employeeService.ExportExcelAsync(searchKey);
            using (MemoryStream ms = new MemoryStream())
            {
                excel.SaveAs(ms);
                return File(ms.ToArray(), "application/vnd.openxalformats-officedocument.spreadsheetml.sheet","employee.xlsx");
            }
        }
    }
}
