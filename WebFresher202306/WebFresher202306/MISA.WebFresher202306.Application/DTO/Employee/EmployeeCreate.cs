using WebFresher202306.Domain;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace WebFresher202306.Application
{
    /// <summary>
    /// Thực thể để tạo nhân viên
    /// author: Trương Mạnh Quang (6/8/2023)
    /// </summary>
    public class EmployeeCreate
    {
        /// <summary>
        /// mã nhân viên
        /// </summary>
        [Required(ErrorMessage = "Mã nhân viên không được để trống.")]
        [MaxLength(20,ErrorMessage = "Mã nhân viên không được vượt quá 20 kí tự")]
        [RegularExpression(@".+[0-9]+$", ErrorMessage = "Mã nhân viên phải kết thúc bằng số.")]
        public string EmployeeCode { get; set; }

        /// <summary>
        /// tên nhân viên
        /// </summary>
        [Required(ErrorMessage = "Tên nhân viên không được để trống.")]
        [MaxLength(100, ErrorMessage = "Tên nhân viên không được vượt quá 100 kí tự")]
        public string FullName { get; set; }

        /// <summary>
        /// mã giới tính {0:Nam,1:Nữ,2:Chưa xác định}
        /// </summary>
        [AllowNull]
        public byte? Gender { get; set; }
        /// <summary>
        /// tên giới tính
        /// </summary>
        [AllowNull]
        public string? GenderName { get; set; }

        /// <summary>
        /// ngày sinh nhân viên
        /// </summary>
        [AllowNull]
        [MisaDate(ErrorMessage = "Ngày sinh không được lớn hơn ngày hiện tại.")]
        public DateTime? DateOfBirth { get; set; }

        /// <summary>
        /// mã số căn cước công dân
        /// </summary>
        [AllowNull]
        [MaxLength(25, ErrorMessage = "Số căn cước không được vượt quá 25 kí tự")]
        public string? IdentityNumber { get; set; }

        /// <summary>
        /// nơi cấp căn cước công dân
        /// </summary>
        [AllowNull]
        public string? IdentityPlace { get; set; }

        /// <summary>
        /// thời gian cấp căn cước công dân
        /// </summary>
        [AllowNull]
        [MisaDate(ErrorMessage = "Ngày cấp không được lớn hơn ngày hiện tại.")]
        public DateTime? IdentityDate { get; set; }

        /// <summary>
        /// mã phòng ban
        /// </summary>
        [Required(ErrorMessage = "Phòng ban không được để trống.")]
        public Nullable<Guid> DepartmentId { get; set; }

        /// <summary>
        /// mã chức danh
        /// </summary>
        [Required(ErrorMessage = "Chức danh không được để trống.")]
        public Nullable<Guid> PositionId { get; set; }

        /// <summary>
        /// địa chỉ
        /// </summary>
        [AllowNull]
        public string? Address { get; set; }

        /// <summary>
        /// số điện thoại
        /// </summary>
        [AllowNull]
        [MaxLength(50,ErrorMessage = "Số điện thoại không được vượt quá 50 kí tự")]
        [RegularExpression(@"^\d{1,50}$", ErrorMessage = "Số điện thoại không đúng định dạng.")]
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// số điện thoại cố định
        /// </summary>
        [AllowNull]
        public string? LandlinePhone { get; set; }

        /// <summary>
        /// email
        /// </summary>
        [AllowNull]
        [MaxLength(50,ErrorMessage = "Email không được vượt quá 50 kí tự.")]
        [Email(ErrorMessage = "Email không đúng định dạng")]
        public string? Email { get; set; }

        /// <summary>
        /// tài khoản ngân hàng
        /// </summary>
        [AllowNull]
        public string? BankAccount { get; set; }

        /// <summary>
        /// tên ngân hàng
        /// </summary>
        [AllowNull]
        public string? BankName { get; set; }

        /// <summary>
        /// địa chỉ ngân hàng
        /// </summary>
        [AllowNull]
        public string? BankAddress { get; set; }

    }

}
