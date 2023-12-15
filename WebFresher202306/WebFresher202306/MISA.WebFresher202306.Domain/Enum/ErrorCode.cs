namespace WebFresher202306.Domain
{
    /// <summary>
    /// mã lỗi nội bộ
    /// </summary>
    /// author: Trương Mạnh Quang (17/8/2023)
    public enum ErrorCode
    {
        /// <summary>
        /// hợp lệ
        /// </summary>
        Valid = -1,
        /// <summary>
        /// vui lòng liên hệ MISA để được hỗ trợ
        /// </summary>
        NoError = 0,
        /// <summary>
        /// trùng mã
        /// </summary>
        DuplicateCode = 1,
        /// <summary>
        /// mã không được vượt quá 20 kí tự
        /// </summary>
        InvalidCode = 2,
        /// <summary>
        /// đầu vào không hợp lệ
        /// </summary>
        InvalidInput = 3,
        /// <summary>
        /// Phòng ban không hợp lệ
        /// </summary>
        InvalidDepartment = 4,
        /// <summary>
        /// chức danh không hợp lệ
        /// </summary>
        InvalidPosition = 5,
        /// <summary>
        /// nhân viên không tồn tại
        /// </summary>
        EmployeeIsNotExist = 6,
    }
}
