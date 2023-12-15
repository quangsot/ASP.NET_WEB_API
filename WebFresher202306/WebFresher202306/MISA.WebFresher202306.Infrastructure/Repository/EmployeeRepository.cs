using Dapper;
using Microsoft.AspNetCore.Mvc;
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
    public class EmployeeRepository : CrudRepository<Employee, Guid> ,IEmployeeRepository
    {
        public EmployeeRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// hàm lọc danh sách nhân viên
        /// </summary>
        /// <param name="searchKey">từ khóa tìm kiếm</param>
        /// <param name="pageSize">kích thước trang</param>
        /// <param name="pageNum">số thứ tự trang</param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<FilterEmployee> FilterAsync(string? searchKey, int pageSize, int pageNum)
        {
            // chuẩn bị proc
            string procName = $"Proc_{TableName}_Filter";

            // chuẩn bị đầu vào
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("searchKey", searchKey, dbType: DbType.String);
            dynamicParameters.Add("pageNum", pageNum, dbType: DbType.Int64);
            dynamicParameters.Add("pageSize", pageSize, dbType: DbType.Int64);

            // thực hiện truy vấn
            var multi = await _unitOfWork.Connection.QueryMultipleAsync(procName, dynamicParameters, commandType: CommandType.StoredProcedure);

            if (multi is null) return default(FilterEmployee);
            else
            {
                return new FilterEmployee()
                {
                    TotalRecords = multi.Read<int>().SingleOrDefault(),
                    TotalPages = multi.Read<int>().SingleOrDefault(),
                    CurrentPage = multi.Read<int>().SingleOrDefault(),
                    CurrentRecords = multi.Read<int>().SingleOrDefault(),
                    Employees = multi.Read<Employee>().ToList(),
                };
            }
        }
        
        /// <summary>
        /// hàm sinh mã mới
        /// </summary>
        /// <returns>mã mới</returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<string> GetNewCodeAsync()
        {
            // chuẩn bị proc
            string procName = $"Proc_{TableName}_NewCode";

            // thực hiện try vấn
            var result = (List<string>)await _unitOfWork.Connection.QueryAsync<string>(procName, commandType: CommandType.StoredProcedure);

            string newCode = result.ToArray()[0];
            return newCode;
        }

        /// <summary>
        /// hàm sinh mã tiếp theo
        /// </summary>
        /// <returns>mã tiếp theo</returns>
        /// author: Trương Mạnh Quang (30/8/2023)
        public async Task<string> GetNextCodeAsync(string oldCode)
        {
            // chuẩn bị proc
            string procName = $"Proc_{TableName}_NextCode";

            // chuẩn bị đầu vào
            DynamicParameters dynamicParameters = new();
            dynamicParameters.Add("code", oldCode);

            // thực hiện try vấn
            var result = (List<string>)await _unitOfWork.Connection.QueryAsync<string>(procName,dynamicParameters, commandType: CommandType.StoredProcedure);

            string nextCode = result.ToArray()[0];
            return nextCode;
        }
    }
}
