using FluentValidation;

namespace WebFresher202306.Application
{
    /// <summary>
    /// đối tượng validate cho nhân viên
    /// author: Trương Mạnh Quang (4/8/2023)
    /// </summary>
    public class EmployeeValidator : AbstractValidator<EmployeeDTO>
    {
        public EmployeeValidator()
        {
            RuleFor(employee => employee.EmployeeCode)
                .NotNull().NotEmpty().WithMessage("Mã nhân viên không được để trống.")
                .Length(0, 20).WithMessage("Mã nhân viên không được dài quá 20 kí tự.");
            RuleFor(employee => employee.DepartmentId).NotNull().NotEmpty().WithMessage("Mã phòng ban không được để trống.");
            RuleFor(employee => employee.PositionId).NotNull().NotEmpty().WithMessage("Mã chức danh không được để trống.");
            RuleFor(employee => employee.Email).EmailAddress().WithMessage("Email không đúng định dạng.");
            RuleFor(employee => employee.PhoneNumber).MinimumLength(10).WithMessage("Số điện thoại không đúng định dạng.");
        }
    }
}
