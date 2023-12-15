namespace WebFresher202306.Domain
{
    /// <summary>
    /// thực thể phân trang
    /// </summary>
    /// author: Trương Mạnh Quang (15/8/2023)
    public class FilterEmployee
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
        public IEnumerable<Employee>? Employees { get; set; } = Enumerable.Empty<Employee>();
    }
}
