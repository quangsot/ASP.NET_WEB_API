using Dapper;
using Microsoft.VisualBasic;
using WebFresher202306.Application;
using WebFresher202306.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Infrastructure
{
    public abstract class CrudRepository<TEntity, TKey> : ReadOnlyRepository<TEntity, TKey>, ICrudRepository<TEntity, TKey> where TEntity : IEntity<TKey>
    {
        protected CrudRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        /// <summary>
        /// hàm thêm mới thực thể
        /// </summary>
        /// <param name="entity">thực thể</param>
        /// <returns>thực thể được thêm vào</returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            // chuẩn bị proc
            string procName = $"Proc_{TableName}_Insert";

            // chuẩn bị param
            DynamicParameters dynamicParameters = new();
            foreach (var prop in entity.GetType().GetProperties())
            {
                dynamicParameters.Add($"{prop.Name}", prop.GetValue(entity, null));
            }

            // thực thi truy vấn
            var result = await _unitOfWork.Connection.ExecuteAsync(procName, dynamicParameters, transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);

            // kiểm tra kết quả
            if (result > 0) return entity;
            else return default(TEntity);
        }
        /// <summary>
        /// hàm cập nhật thông tin thực thể
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ResponseException"></exception>
        /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            // chuẩn bị proc
            string procName = $"Proc_{TableName}_UpdateById";

            // chuẩn bị param
            DynamicParameters dynamicParameters = new();
            foreach (var prop in entity.GetType().GetProperties())
            {
                dynamicParameters.Add($"{prop.Name}", prop.GetValue(entity, null));
            }

            // thực hiện truy vấn
            var result = await _unitOfWork.Connection.ExecuteAsync(procName, dynamicParameters, transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);

            // kiểm tra kết quả
            if (result > 0) return entity;
            else return default(TEntity);
        }
        /// <summary>
        /// hàm xóa 1 thực thể
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="ResponseException"></exception>
        /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<int> DeleteAsync(TEntity entity)
        {
            // chuẩn bị tên proc
            var procName = $"Proc_{TableName}_DeleteById";

            // chuẩn bị param
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("id", entity.GetId());

            // thực hiện truy vấn
            var result = await _unitOfWork.Connection.ExecuteAsync(procName, dynamicParameters,transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);

            return result;
        }

        /// <summary>
        /// hàm xóa nhiều thực
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        /// <exception cref="ResponseException"></exception>
        /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<int> DeleteManyAsync(List<TEntity> entities)
        {
            //chuẩn bị proc
            string procName = $"Proc_{TableName}_DeleteByIds";

            //chuẩn bị param
            List<TKey> ids = entities.Select(entity => entity.GetId()).ToList();
            // xử lý mảng guid thành chuỗi
            string? stringIds = "";
            foreach (TKey id in ids)
            {
                stringIds += $"'{id}',";
            }
            stringIds = stringIds.Remove(stringIds.LastIndexOf(','));
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("@ids", stringIds);
            
            //thực hiện try vấn
            var result = await _unitOfWork.Connection.ExecuteAsync(procName, dynamicParameters, transaction: _unitOfWork.Transaction, commandType: CommandType.StoredProcedure);
            
            return result;

        }
        /// <summary>
        /// hàm kiểm tra trùng mã
        /// </summary>
        /// <param name="code">mã cần kiểm tra</param>
        /// <returns>true nếu trùng, false nếu không trùng</returns>
        /// author: Trương  Mạnh Quang (17/8/2023)
        public async Task<bool> CheckDuplicateCodeAsync(string code)
        {
            // chuẩn bị sql
            string sql = $"Select Count(*) From {TableName} Where {TableName}Code = @code;";

            // chuẩn bị param
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("code", code);

            // thực thi truy vấn
            var count = await _unitOfWork.Connection.QuerySingleOrDefaultAsync<int>(sql, dynamicParameters, transaction: _unitOfWork.Transaction);

            var result = count > 0;
            return result;
        }
    }
}
