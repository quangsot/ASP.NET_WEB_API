using FluentValidation;
using WebFresher202306.Domain;
using System.Net;

namespace WebFresher202306.Application
{
    /// <summary>
    /// đối tượng quản lý nhân viên
    /// author: Trương Mạnh Quang (4/8/2023)
    /// </summary>
    public class EmployeeManagerValidate : IEmployeeManagerValidate
    {
        private readonly IValidator<EmployeeDTO> _validator;
        public EmployeeManagerValidate(IValidator<EmployeeDTO> validator)
        {
            _validator = validator;
        }

        public IValidator<EmployeeDTO> Validator => _validator;

        IValidator<EmployeeDTO> IEmployeeManagerValidate.Validator => throw new NotImplementedException();

        /// <summary>
        /// hàm validate nhân viên
        /// author: Trương Mạnh Quang (4/8/2023)
        /// </summary>
        /// <param name="employee">nhân viên</param>
        /// <returns></returns>
        /// <exception cref="ResponseException"></exception>
        public async Task ManageAsync(EmployeeDTO employee)
        {
            await _validator.ValidateAsync(employee);
        }
    }
}
