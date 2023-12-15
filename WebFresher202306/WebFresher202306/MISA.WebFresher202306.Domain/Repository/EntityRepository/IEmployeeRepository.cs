namespace WebFresher202306.Domain
{
    public interface IEmployeeRepository : ICrudRepository<Employee,Guid>
    {

        /// <summary>
        /// hàm lọc danh sách nhân viên
        /// </summary>
        /// <param name="searchKey"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNum"></param>
        /// <returns>đối tượng filter</returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<FilterEmployee> FilterAsync(string? searchKey, int pageSize, int pageNum);

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

    }
}
