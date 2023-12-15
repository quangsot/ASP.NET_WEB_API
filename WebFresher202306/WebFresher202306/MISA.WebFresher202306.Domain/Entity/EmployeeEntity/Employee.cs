namespace WebFresher202306.Domain
{
    /// <summary>
    /// Thực thể nhân viên
    /// author: Trương Mạnh Quang (2/8/2023)
    /// </summary>
    public class Employee : BaseAuditEntity, IEntity<Guid>
    {
        /// <summary>
        /// id nhân viên
        /// </summary>
        public Guid EmployeeId { get; set; }

        /// <summary>
        /// mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// tên nhân viên
        /// </summary>
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
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// tên phòng ban
        /// </summary>
        public string? DepartmentName { get; set; }

        /// <summary>
        /// mã chức danh
        /// </summary>
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

        public Guid GetId()
        {
            return EmployeeId;
        }

        public void SetId(Guid id)
        {
            EmployeeId = id;
        }
    }
}
