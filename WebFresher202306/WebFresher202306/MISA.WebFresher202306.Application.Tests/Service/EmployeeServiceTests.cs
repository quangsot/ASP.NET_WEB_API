using AutoMapper;
using WebFresher202306.Domain;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application.Tests
{
    [TestFixture]
    public class EmployeeServiceTests
    {
        private EmployeeService _employeeService { get; set; }
        private IEmployeeRepository _employeeRepository { get; set; }

        private IMapper _mapper { get; set; }

        private IEmployeeManager _employeeManager { get; set; }

        [SetUp]
        public void SetUp()
        {
            _employeeRepository = Substitute.For<IEmployeeRepository>();
            _mapper = Substitute.For<IMapper>();
            _employeeManager = Substitute.For<IEmployeeManager>();
            _employeeService = new EmployeeService(_employeeRepository, _employeeManager, _mapper);
        }
        //======= Test DuplicateCode =======//

        /// <summary>
        /// hàm test code dài quá 20 kí tự 
        /// </summary>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (28/8/2023)
        [Test]
        public async Task CheckDuplicateCodeAsync_InValidCode_Exception()
        {
            // arrange
            string code = "codeLong_12345678901234567890";

            // act

            // assert
            Assert.ThrowsAsync<BadRequestException>(async () =>
            {
                await _employeeService.CheckDuplicateCodeAsync(code);
            });
        }

        /// <summary>
        /// hàm test code bị trùng
        /// </summary>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (28/8/2023)
        [Test]
        public async Task CheckDuplicateCodeAsync_DuplicateCode_ErrorCode()
        {
            // arrange
            string code = "codeShort_12345";
            _employeeRepository.CheckDuplicateCodeAsync(code).Returns(true);

            var expectedResult = ErrorCode.DuplicateCode;
            // act
            var result = await _employeeService.CheckDuplicateCodeAsync(code);

            // assert
            Assert.That(result,Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// hàm test code không bị trùng
        /// </summary>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (28/8/2023)
        [Test]
        public async Task CheckDuplicateCodeAsync_NotDuplicateCode_ErrorCode()
        {
            // arrange
            string code = "codeShort_12345";
            _employeeRepository.CheckDuplicateCodeAsync(code).Returns(false);

            var expectedResult = ErrorCode.Valid;
            // act
            var result = await _employeeService.CheckDuplicateCodeAsync(code);

            // assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        //======= Test Update =======//

        /// <summary>
        /// hàm test cập nhật nhân viên không tồn tại trong hệ thống
        /// </summary>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (28/8/2023)
        [Test]
        public async Task UpdateAsync_EmployeeNotExist_Exception()
        {
            // arrange
            var id = Guid.NewGuid();
            var employeeUpdate = new EmployeeUpdate();

            _employeeRepository.GetByIdAsync(id).ReturnsNull();

            // act

            // assert
            Assert.ThrowsAsync<NoContentException>(async () => 
            { 
                await _employeeService.UpdateAsync(id, employeeUpdate); 
            });

        }

        /// <summary>
        /// hàm test cập nhật thành công
        /// </summary>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (28/8/2023)
        [Test]
        public async Task UpdateAsync_EmployeeExist_EmployeeDTO()
        {
            var idUpdate = Guid.NewGuid();
            var idExist = Guid.NewGuid();
            var entityUpdate = new EmployeeUpdate();

            var existingEntity = new Employee { EmployeeId = idExist };
            var updatedEntity = new Employee { EmployeeId = idUpdate };
            var entityDTO = new EmployeeDTO { EmployeeId = idUpdate };

            _employeeRepository.GetByIdAsync(idExist).Returns(existingEntity);
            _employeeRepository.UpdateAsync(Arg.Any<Employee>()).Returns(updatedEntity);

            _employeeService.MapEntityUpdateDtoToEntity(idUpdate, Arg.Any<EmployeeUpdate>()).Returns(updatedEntity);
            
            _employeeService.CheckValidConstraint(Arg.Any<Employee>()).Returns(ErrorCode.Valid);

            _employeeService.MapTEntityToTEntityDto(updatedEntity).Returns(entityDTO);
            // Act
            var result = await _employeeService.UpdateAsync(idUpdate, entityUpdate);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result.EmployeeId, Is.EqualTo(entityDTO.EmployeeId));
        }

        //======= Test Create =======//

        /// <summary>
        /// hàm test tạo thành công
        /// </summary>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (28/8/2023)
        [Test]
        public async Task CreateAsync_CreateSucess_EmployeeDTO()
        {
            // arrange
            EmployeeCreate employeeCreate = new();
            Employee employee = new();
            EmployeeDTO employeeDTO = new();

            _employeeService.MapEntityCreateDtoToEntity(employeeCreate).Returns(employee);

            _employeeService.CheckDuplicateCodeAsync(Arg.Any<string>()).Returns(ErrorCode.Valid);
            
            _employeeService.CheckValidConstraint(employee).Returns(ErrorCode.Valid);

            _employeeRepository.CreateAsync(employee).Returns(employee);
            
            _employeeService.MapTEntityToTEntityDto(employee).Returns(employeeDTO);

            var expectedResult = employeeDTO;

            // act
            var result = await _employeeService.CreateAsync(employeeCreate);

            // assert
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// hàm test tạo bị trùng mã
        /// </summary>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (28/8/2023)
        [Test]
        public async Task CreateAsync_DuplicateCode_Exception()
        {
            // arrange
            EmployeeCreate employeeCreate = new();
            Employee employee = new();

            _employeeService.MapEntityCreateDtoToEntity(employeeCreate).Returns(employee);
            
            _employeeService.CheckDuplicateCodeAsync(Arg.Any<string>()).Returns(ErrorCode.DuplicateCode);
            // act

            // assert
            Assert.ThrowsAsync<ConflictException>(async () =>
            {
                await _employeeService.CreateAsync(employeeCreate);
            });
        }
    }

}

