using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Domain.Tests
{
    [TestFixture]
    public class EmployeeManagerTests
    {
        /// <summary>
        /// hàm test phòng ban không tồn tại
        /// </summary>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (27/8/2023)
        [Test]
        public async Task CheckValidConstraint_DepartmentNotExist_ErrorCode()
        {
            // arrange
            Guid departmentIdTest = new("3c075c8b-6a5a-47a8-8fbe-efac7116b6b8");
            Guid positionIdTest = new("4d503e48-81e2-424f-b189-a5d7cd4de479");

            DepartmentRepoFakeGetByIdNull departmentRepositoryFake = new();
            PositionRepositoryFake positionRepositoryFake = new();

            EmployeeManager employeeManager = new(departmentRepositoryFake, positionRepositoryFake);

            // act
            var result = await employeeManager.CheckValidConstraint(departmentIdTest, positionIdTest);
            var expectedResult = ErrorCode.InvalidDepartment;

            // assert
            Assert.Multiple(() =>
            {
                Assert.That(departmentRepositoryFake.CountCall, Is.EqualTo(1));
                Assert.That(result, Is.EqualTo(expectedResult));
            });
        }

        /// <summary>
        /// hàm test phòng ban tồn tại và chức danh không tồn tại
        /// </summary>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (27/8/2023)
        [Test]
        public async Task CheckValidConstraint_DepartmentExist_PositionNotExist_ErrorCode()
        {
            // arrange
            Guid departmentIdTest = new("3c075c8b-6a5a-47a8-8fbe-efac7116b6b8");
            Guid positionIdTest = new("4d503e48-81e2-424f-b189-a5d7cd4de479");

            DepartmentRepoFakeGetByIdNotNull departmentRepositoryFake = new();
            PositionRepoFakeGetByIdNull positionRepositoryFake = new();

            EmployeeManager employeeManager = new(departmentRepositoryFake, positionRepositoryFake);

            // act
            var result = await employeeManager.CheckValidConstraint(departmentIdTest, positionIdTest);
            var expectedResult = ErrorCode.InvalidPosition;
            
            // assert
            Assert.Multiple(() =>
            {
                Assert.That(departmentRepositoryFake.CountCall, Is.EqualTo(1));
                Assert.That(positionRepositoryFake.CountCall, Is.EqualTo(1));
                Assert.That(result, Is.EqualTo(expectedResult));
            });
        }

        /// <summary>
        /// hàm test phòng ban tồn tại và chức danh tồn tại
        /// </summary>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (27/8/2023)
        [Test]
        public async Task CheckValidConstraint_DepartmentExist_PositionExist_ErrorCode()
        {
            // arrange
            Guid departmentIdTest = new("3c075c8b-6a5a-47a8-8fbe-efac7116b6b8");
            Guid positionIdTest = new("4d503e48-81e2-424f-b189-a5d7cd4de479");

            DepartmentRepoFakeGetByIdNotNull departmentRepositoryFake = new();
            PositionRepoFakeGetByIdNotNull positionRepositoryFake = new();

            EmployeeManager employeeManager = new(departmentRepositoryFake, positionRepositoryFake);

            // act
            var result = await employeeManager.CheckValidConstraint(departmentIdTest, positionIdTest);
            var expectedResult = ErrorCode.Valid;
            
            // assert
            Assert.Multiple(() =>
            {
                Assert.That(departmentRepositoryFake.CountCall, Is.EqualTo(1));
                Assert.That(positionRepositoryFake.CountCall, Is.EqualTo(1));
                Assert.That(result, Is.EqualTo(expectedResult));
            });
        }
    }
}
