namespace WebFresher202306.Domain
{
    public interface ICrudRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {

        /// <summary>
        /// hàm thêm thực thể mới
        /// </summary>
        /// <param name="employee">thực thể</param>
        /// <returns>thực thể được thêm mới</returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<TEntity> CreateAsync(TEntity entity);

        /// <summary>
        /// hàm cập nhật thông tin thực thể
        /// </summary>
        /// <param name="employee">thục thể</param>
        /// <returns>thực thể được cập nhật</returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// hàm xóa 1 thực thể 
        /// </summary>
        /// <param name="id">id thực thể</param>
        /// <returns>số thực thể đã xóa</returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<int> DeleteAsync(TEntity entity);

        /// <summary>
        /// hàm xóa nhiều thực thể
        /// </summary>
        /// <param name="entities">danh sách thực thể</param>
        /// <returns>số thực thể đã xóa</returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<int> DeleteManyAsync(List<TEntity> entities);

        /// <summary>
        /// hàm kiểm tra trùng mã
        /// </summary>
        /// <param name="code"></param>
        /// <returns>true nếu trùng, false nếu không trùng</returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        Task<bool> CheckDuplicateCodeAsync(string code);
    }
}
