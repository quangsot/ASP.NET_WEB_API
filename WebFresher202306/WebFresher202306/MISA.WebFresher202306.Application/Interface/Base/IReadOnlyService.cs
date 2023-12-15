using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    /// <summary>
    /// author: Trương Mạnh Quang (15/8/2023)
    /// </summary>
    public interface IReadOnlyService<TEntityDTO, TKey> where TEntityDTO : class
    {
        /// <summary>
        /// hàm lấy tất cả nhân viên
        /// </summary>
        /// <returns>danh sách nhân viên</returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<IEnumerable<TEntityDTO>> GetAllAsync();

        /// <summary>
        /// hàm lấy nhân viên theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>nhân viên</returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<TEntityDTO> GetByIdAsync(TKey id);
    }
}
