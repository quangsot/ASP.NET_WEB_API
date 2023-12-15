using WebFresher202306.Application;
using WebFresher202306.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Net;

namespace WebFresher202306.Infrastructure
{
    public abstract class ReadOnlyRepository<TEntity, TKey> : IReadOnlyRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        /// <summary>
        /// author: Trương Mạnh Quang (16/8/2023)
        /// </summary>
        protected readonly IUnitOfWork _unitOfWork;
        protected virtual string TableName { get; set; } = typeof(TEntity).Name;
        protected ReadOnlyRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// hàm lấy tất cả thực thể
        /// </summary>
        /// <returns>danh sách thực thể</returns>
        /// author: Trương Mạnh Quang (16/8/2023)
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            // chuẩn bị proc
            string procName = $"Proc_{TableName}_GetAll";

            // thực thi truy vấn
            var result = await _unitOfWork.Connection.QueryAsync<TEntity>(sql: procName, transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// hàm lấy 1 thực thể theo id
        /// </summary>
        /// <param name="id">id thực thể</param>
        /// <returns>thực thể</returns>
        /// author: Trương Mạnh Quang (16/8/2023)
        public async Task<TEntity?> GetByIdAsync(TKey id)
        {
            // chuẩn bị proc
            string procName = $"Proc_{TableName}_GetById";

            // chuẩn bị param
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("id", id);

            // thực thi truy vấn
            var result = await _unitOfWork.Connection.QueryFirstOrDefaultAsync<TEntity>(procName, dynamicParameters, transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            
            return result;

        }

        /// <summary>
        /// hàm lấy theo danh sách id
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>danh sách thực thể</returns>
        public async Task<List<TEntity>> GetByIdsAsync(List<TKey> ids)
        {
            // chuẩn bị sql
            string sql = $"Select * From {TableName} Where {TableName}Id In @ids;";

            // chuẩn bị param
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("ids", ids);

            // thực hiện truy vấn
            var result = await _unitOfWork.Connection.QueryAsync<TEntity>(sql, dynamicParameters, transaction: _unitOfWork.Transaction);

            return result.ToList();
        }
    }
}
