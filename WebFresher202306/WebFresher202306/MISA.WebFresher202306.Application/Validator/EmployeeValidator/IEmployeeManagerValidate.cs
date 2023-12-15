using FluentValidation;

namespace WebFresher202306.Application
{
    /// <summary>
    /// interface quản lý nhân viên
    /// author: Trương Mạnh Quang (4/8/2023)
    /// </summary>
    public interface IEmployeeManagerValidate
    {
        /// <summary>
        /// interface validate nhân viên
        /// author: Trương Mạnh Quang (4/8/2023)
        /// </summary>
        IValidator<EmployeeDTO> Validator { get; }

        /// <summary>
        /// hàm validate nhân viên
        /// author: Trương Mạnh Quang (4/8/2023)
        /// </summary>
        /// <param name="employee">nhân viên</param>
        Task ManageAsync(EmployeeDTO employee);
    }
}