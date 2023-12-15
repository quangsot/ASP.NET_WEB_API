using WebFresher202306.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    /// <summary>
    /// interface crud
    /// </summary>
    /// <typeparam name="TEntityDTO"></typeparam>
    /// <typeparam name="Tkey"></typeparam>
    /// author: Trương Mạnh Quang (15/8/2023)
    public interface ICrudService<TEntityDTO, Tkey, TEntityCreateDTO, TEntityUpdateDTO> : IReadOnlyService<TEntityDTO, Tkey>
        where TEntityDTO : class
        where TEntityCreateDTO : class
        where TEntityUpdateDTO : class
    {
        /// <summary>
        /// hàm thêm mới
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<TEntityDTO> CreateAsync(TEntityCreateDTO entityCreateDTO);

        /// <summary>
        /// hàm cập nhật
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<TEntityDTO> UpdateAsync(Tkey id, TEntityUpdateDTO entityUpdateDTO);

        /// <summary>
        /// hàm xóa theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>số thực thể đã xóa</returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<int> DeleteAsync(Tkey id);

        /// <summary>
        /// hàm xóa nhiều theo danh sách id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>số thực thể đã xóa</returns>
        /// author: Trương Mạnh Quang (15/8/2023)
        Task<int> DeleteManyAsync(List<Tkey> ids);

        /// <summary>
        /// hàm kiểm tra trùng mã
        /// </summary>
        /// <param name="code"></param>
        /// <returns>true nếu trùng, false nếu không trùng</returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        Task<ErrorCode> CheckDuplicateCodeAsync(string code);
    }
}
