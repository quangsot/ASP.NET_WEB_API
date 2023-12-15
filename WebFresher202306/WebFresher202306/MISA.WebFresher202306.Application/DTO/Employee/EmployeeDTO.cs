using WebFresher202306.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    /// <summary>
    /// DTO nhân viên được trả về
    /// </summary>
    /// author: Trương Mạnh Quang (15/8/2023)
    public class EmployeeDTO
    {
        /// <summary>
        /// id nhân viên
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Id nhân viên không được để trống.")]
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// mã nhân viên
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã nhân viên không được để trống.")]
        [MaxLength(20, ErrorMessage = "Mã nhân viên không được vượt quá 20 kí tự")]
        [MisaCode(ErrorMessage = "Mã nhân viên phải kết thúc bằng số.")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// tên nhân viên
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Tên nhân viên không được để trống.")]
        public string FullName { get; set; }

        /// <summary>
        /// mã giới tính {0:Nam,1:Nữ,2:Chưa xác định}
        /// </summary>
        public byte? Gender { get; set; }
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
        /// mã phòng ban
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã phòng ban không được để trống.")]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// tên phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }

        /// <summary>
        /// mã chức danh
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Mã chức danh không được để trống.")]
        public Guid PositionId { get; set; }

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
        [Email(ErrorMessage = "Email không đúng định dạng")]
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
