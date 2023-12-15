using AutoMapper;
using WebFresher202306.Domain;
using WebFresher202306.Domain.Resource;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    public class EmployeeService : CrudService<Employee, EmployeeDTO, Guid, EmployeeCreate, EmployeeUpdate>, IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeManager _employeeManager;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IEmployeeManager employeeManager, IMapper mapper) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _employeeManager = employeeManager;
            _mapper = mapper;
        }

        /// <summary>
        /// hàm lọc nhân viên
        /// </summary>
        /// <param name="searchKey"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17//8/2023)
        public async Task<FilterEmployeeDTO> FilterAsync(string? searchKey, int pageSize, int pageNum)
        {
            if (pageSize <= 0) pageSize = 1;
            if (pageNum <= 0) pageNum = 10;
            var searchKeyValidated = AddEscapeCharacters(searchKey);
            var result = await _employeeRepository.FilterAsync(searchKeyValidated, pageSize, pageNum);

            var filterEmployeeDTO = _mapper.Map<FilterEmployee, FilterEmployeeDTO>(result);

            return filterEmployeeDTO;
        }

        /// <summary>
        /// hàm sử lý các từ có ký tự đặc biệt
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (8/9/2023)
        public static string AddEscapeCharacters(string input)
        {
            if (input is null) return "";
            // Danh sách các ký tự đặc biệt cần được thêm dấu '\'
            char[] specialChars = { '\'', '"', ';', '-', '(', ')', '*', '+', '=', '!', '<', '>', '&', '|', '^', '~', '?', '[', ']', '{', '}', ':' };

            StringBuilder result = new();

            foreach (char c in input)
            {
                if (Array.IndexOf(specialChars, c) != -1)
                {
                    // Nếu ký tự c là một ký tự đặc biệt, thêm dấu '\' vào trước nó
                    result.Append('\\');
                }

                // Thêm ký tự c vào kết quả
                result.Append(c);
            }

            return result.ToString();
        }

        /// <summary>
        /// hàm lấy mã mới
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<string> GetNewCodeAsync()
        {
            var code = await _employeeRepository.GetNewCodeAsync();
            if(code == "-1")
            {
                throw new BadRequestException(ErrorCode.InvalidCode, MISAResource.ResourceManager.GetString("CodeLimit") ?? "");
            }
            else
            {
                return code;
            }
        }

        /// <summary>
        /// hàm sinh mã mới tiếp theo
        /// </summary>
        /// <returns>mã mới</returns>
        /// author: Trương Mạnh Quang (30/8/2023)
        public async Task<string> GetNextCodeAsync(string oldCode)
        {
            // mã dài quá 20 kí tự
            if (oldCode.Length > 20)
            {
                throw new BadRequestException(ErrorCode.InvalidCode, MISAResource.ResourceManager.GetString("ErrorEmployeeCodeTooLong") ?? "");
            }

            //mã phải kết thúc bằng số
            if (!int.TryParse(oldCode[^1].ToString(), out _))
            {
                throw new BadRequestException(ErrorCode.InvalidCode, MISAResource.ResourceManager.GetString("ErrorEmployeeCodeNotEndByNumber") ?? "");
            }

            // kiểm tra giới hạn của code  
            if (IsLimitCode(oldCode))
            {
                throw new BadRequestException(ErrorCode.InvalidCode, MISAResource.ResourceManager.GetString("CodeLimit") ?? "");
            }

            return await _employeeRepository.GetNextCodeAsync(oldCode);
        }

        /// <summary>
        /// hàm kiểm tra code đã đến giới hạn chưa
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (7/9/2023)
        public static bool IsLimitCode(string code)
        {
            if (code.Length > 20) return true;
            else if (code.Length == 20)
            {
                string strNum = "";
                for (int i = code.Length - 1; i >= 0; i--)
                {
                    if (int.TryParse(code[i].ToString(), out _))
                    {
                        strNum += code[i];
                    }
                    else break;
                }

                string strCheck = new('9', strNum.Length);
                if (strNum.Equals(strCheck))
                {
                    return true;
                }
                else return false;
            }
            else return false;
        }

        /// <summary>
        /// hàm map entity create sang entity
        /// </summary>
        /// <param name="entityInsertDto"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public override Employee MapEntityCreateDtoToEntity(EmployeeCreate entityCreateDTO)
        {
            var entity = _mapper.Map<EmployeeCreate, Employee>(entityCreateDTO);
            entity.EmployeeId = Guid.NewGuid();
            return entity;
        }

        /// <summary>
        /// hàm map entity update sang entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entityUpdateDto"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public override Employee MapEntityUpdateDtoToEntity(Guid id, EmployeeUpdate entityUpdateDTO)
        {
            var entity = _mapper.Map<EmployeeUpdate, Employee>(entityUpdateDTO);
            entity.EmployeeId = id;
            return entity;
        }

        /// <summary>
        /// hàm map entity sang entity dto
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public override EmployeeDTO MapTEntityToTEntityDto(Employee entity)
        {
            var entityDTO = _mapper.Map<Employee, EmployeeDTO>(entity);
            return entityDTO;
        }

        /// <summary>
        /// hàm kiểm tra ràng buộc của thực thể
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (19/8/2023)
        public override async Task<ErrorCode> CheckValidConstraint(Employee entity)
        {
            if (entity.DepartmentId == Guid.Empty) return ErrorCode.InvalidDepartment;
            if (entity.PositionId == Guid.Empty) return ErrorCode.InvalidPosition;
            return await _employeeManager.CheckValidConstraint(entity.DepartmentId, entity.PositionId);
        }

        /// <summary>
        /// lấy mã entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (19/8/2023)
        public override string GetEntityCode(Employee entity)
        {
            return entity.EmployeeCode;
        }

        /// <summary>
        /// hàm xuất file excel
        /// </summary>
        /// <param name="searchKey">từ khóa tìm kiếm</param>
        /// <returns>excel package</returns>
        /// author: Trương Mạnh Quang (21/8/2023)
        public async Task<ExcelPackage> ExportExcelAsync(string? searchKey)
        {
            List<Employee> result;
            if (searchKey == null)
            {
                var employees = await _readOnlyRepository.GetAllAsync();
                result = employees.ToList();
            }
            else
            {
                var paging = await _employeeRepository.FilterAsync(searchKey, 0, 0);
                result = paging.Employees.ToList();
            }

            var employeesExcel = result.Select(e => _mapper.Map<Employee, EmployeeExcel>(e)).ToList();

            string templateFilePath = MISAResource.ResourceManager.GetString("TemplateExcelFilePath") ?? "";

            FileInfo file = new(templateFilePath);

            if (!file.Exists)
            {
                throw new Exception("Không tìm thấy path file excel mẫu");
            }

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;


            ExcelPackage excelPackage = new(file);

            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets["Employee"];

            int rowNumber = 5;

            foreach (var employee in employeesExcel)
            {
                // đánh số thứ tự cho từng record
                worksheet.Cells[$"A{rowNumber}"].Value = rowNumber - 4;
                // thêm viền cho ô
                worksheet.Cells[$"A{rowNumber}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);

                var properties = typeof(EmployeeExcel).GetProperties();
                // Duyệt qua từng thuộc tính của dữ liệu
                foreach (var property in properties)
                {
                    // Tìm defineName dựa trên tên thuộc tính
                    var defineNames = worksheet.Names;
                    var defineName = defineNames[property.Name];
                    if (defineName != null)
                    {
                        // Lấy cột của ô tương ứng với defineName
                        var columnNumber = defineName.Start.Column;

                        // Gán giá trị thuộc tính vào ô tương ứng
                        worksheet.Cells[rowNumber, columnNumber].Value = property.GetValue(employee);

                        // thêm viền cho từng ô
                        worksheet.Cells[rowNumber, columnNumber].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                    }
                }
                rowNumber++; // Tăng số dòng sau khi thêm dữ liệu
            }
            return excelPackage;
        }
    }
}
