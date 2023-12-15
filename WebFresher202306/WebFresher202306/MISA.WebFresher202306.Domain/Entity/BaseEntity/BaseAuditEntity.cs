namespace WebFresher202306.Domain
{
    /// <summary>
    /// thực thể truy vết
    /// </summary>
    /// author: Trương Mạnh Quang (16/8/2023)
    public abstract class BaseAuditEntity
    {
        /// <summary>
        /// người tạo
        /// </summary>
        public string? CreatedBy { get; set; }

        /// <summary>
        /// ngày tạo
        /// </summary>
        public DateTime? CreatedDate { get; set; }

        /// <summary>
        /// người sửa
        /// </summary>
        public string? ModifiedBy { get; set; }

        /// <summary>
        /// ngày sửa
        /// </summary>
        public DateTime? ModifiedDate { get; set; }
    }
}
