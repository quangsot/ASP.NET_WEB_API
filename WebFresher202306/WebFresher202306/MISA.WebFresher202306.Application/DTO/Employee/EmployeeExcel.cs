using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    /// <summary>
    /// DTO nhân viên xuất excel
    /// </summary>
    /// author: Trương Mạnh Quang (20/8/2023)
    public class EmployeeExcel
    {
        /// <summary>
        /// mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// tên nhân viên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// tên giới tính
        /// </summary>
        public string? GenderName { get; set; }

        /// <summary>
        /// ngày sinh nhân viên
        /// </summary>
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// mã số căn cước công dân
        /// </summary>
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// nơi cấp căn cước công dân
        /// </summary>
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// thời gian cấp căn cước công dân
        /// </summary>
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// tên phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }

        /// <summary>
        /// tên chức danh
        /// </summary>
        public string? PositionName { get; set; }

        /// <summary>
        /// địa chỉ
        /// </summary>
        public string? Address { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// số điện thoại cố định
        /// </summary>
        public string? LandlinePhone { get; set; }

        /// <summary>
        /// email
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// tài khoản ngân hàng
        /// </summary>
        public string? BankAccount { get; set; }

        /// <summary>
        /// tên ngân hàng
        /// </summary>
        public string? BankName { get; set; }

        /// <summary>
        /// địa chỉ ngân hàng
        /// </summary>
        public string? BankAddress { get; set; }
    }
}
