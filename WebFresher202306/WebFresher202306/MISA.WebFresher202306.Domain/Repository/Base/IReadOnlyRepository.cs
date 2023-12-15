namespace WebFresher202306.Domain
{
    public interface IReadOnlyRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        /// <summary>
        /// hàm lấy tất cả nhân viên
        /// </summary>
        /// <returns>danh sách nhân viên</returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<IEnumerable<TEntity>> GetAllAsync();

        /// <summary>
        /// hàm lấy nhân viên theo id
        /// </summary>
        /// <param name="id">id nhân viên</param>
        /// <returns>nhân viên</returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<TEntity?> GetByIdAsync(TKey id);

        /// <summary>
        /// hàm lấy nhiều thực thể theo danh sách id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        Task<List<TEntity>> GetByIdsAsync(List<TKey> ids);
    }
}
