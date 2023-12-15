using WebFresher202306.Domain;
using WebFresher202306.Domain.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Reflection;

namespace WebFresher202306.Application
{
    public abstract class CrudService<TEntity, TEntityDTO, TKey, TEntityCreateDTO, TEntityUpdateDTO>
        : ReadOnlyService<TEntity, TEntityDTO, TKey>, ICrudService<TEntityDTO, TKey, TEntityCreateDTO, TEntityUpdateDTO>
        where TEntity : IEntity<TKey>
        where TEntityDTO : class
        where TEntityCreateDTO : class
        where TEntityUpdateDTO : class
    {
        protected readonly ICrudRepository<TEntity, TKey> _crudRepository;
        public CrudService(ICrudRepository<TEntity, TKey> crudRepository) : base(crudRepository)
        {
            _crudRepository = crudRepository;
        }

        /// <summary>
        /// hàm kiểm tra trùng mã
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="ResponseException"></exception>
        /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<ErrorCode> CheckDuplicateCodeAsync(string code)
        {
            // kiểm tra mã hợp lệ không
            if (code.Length > 20)
            {
                throw new BadRequestException(ErrorCode.InvalidCode, MISAResource.ResourceManager.GetString("ErrorEmployeeCodeTooLong") ?? "");
            }
            //mã phải kết thúc bằng số
            else if (!int.TryParse(code[^1].ToString(), out _))
            {
                throw new BadRequestException(ErrorCode.InvalidCode, MISAResource.ResourceManager.GetString("ErrorEmployeeCodeNotEndByNumber") ?? "");
            }
            else
            {
                var result = await _crudRepository.CheckDuplicateCodeAsync(code);

                if (result) return ErrorCode.DuplicateCode;
                else return ErrorCode.Valid;
            }
        }

        /// <summary>
        /// hàm thêm mới
        /// </summary>
        /// <param name="entityCreateDTO"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<TEntityDTO> CreateAsync(TEntityCreateDTO entityCreateDTO)
        {
            // map entityCreateDTO sang entity
            var entity = MapEntityCreateDtoToEntity(entityCreateDTO);

            string code = GetEntityCode(entity);
            // check trùng mã
            if (await CheckDuplicateCodeAsync(code) == ErrorCode.DuplicateCode)
            {
                throw new ConflictException(ErrorCode.DuplicateCode, MISAResource.ResourceManager.GetString("DuplicateCode") ?? "");
            }

            // check constrain
            var errorCode = await CheckValidConstraint(entity);
            if (errorCode == ErrorCode.InvalidDepartment)
            {
                throw new BadRequestException(errorCode, MISAResource.ResourceManager.GetString("InvalidDepartment") ?? "");
            }
            else if(errorCode == ErrorCode.InvalidPosition)
            {
                throw new BadRequestException(errorCode, MISAResource.ResourceManager.GetString("InvalidPosition") ?? "");
            }

            // audit
            if (entity is BaseAuditEntity auditEntity)
            {
                auditEntity.CreatedBy = "Trương Mạnh Quang";
                auditEntity.CreatedDate = DateTime.Now;
            }
            // thêm
            var newEntity = await _crudRepository.CreateAsync(entity);

            // map entity sang entityDTO
            var newEntityDTO = MapTEntityToTEntityDto(newEntity);

            return newEntityDTO;
        }

        /// <summary>
        /// hàm xóa 1 thực thể
        /// </summary>
        /// <param name="id"></param>
        /// <returns>số lượng bị xóa</returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<int> DeleteAsync(TKey id)
        {
            // lấy entity
            var entity = await _crudRepository.GetByIdAsync(id);

            // kiểm tra
            if (entity is null) return 0;

            // xóa
            var result = await _crudRepository.DeleteAsync(entity);

            return result;
        }

        /// <summary>
        /// hàm xóa nhiều thực thể
        /// </summary>
        /// <param name="ids"></param>
        /// <returns>số lượng bị xóa</returns>
        /// /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<int> DeleteManyAsync(List<TKey> ids)
        {
            // lấy danh sách entity
            var entities = await _crudRepository.GetByIdsAsync(ids);
            Console.WriteLine(entities);
            // xóa
            var result = await _crudRepository.DeleteManyAsync(entities);

            return result;
        }

        /// <summary>
        /// hàm cập nhật
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entityUpdateDTO"></param>
        /// <returns>thực thể được cập nhật</returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<TEntityDTO> UpdateAsync(TKey id, TEntityUpdateDTO entityUpdateDTO)
        {
            // kiểm tra có tồn tại không
            var entity = await _crudRepository.GetByIdAsync(id) 
                ?? throw new NoContentException(ErrorCode.EmployeeIsNotExist, MISAResource.ResourceManager.GetString("NoContent") ?? "");

            // map entityUpdateDTO sang entity
            var entityUpdate = MapEntityUpdateDtoToEntity(id, entityUpdateDTO);

            // kiểm tra sự khác biệt
            if (entity.Equals(entityUpdate))
            {
                throw new BadRequestException(ErrorCode.EmployeeIsNotExist, MISAResource.ResourceManager.GetString("DataNotChange") ?? "");
            }

            string code = GetEntityCode(entity);
            // check trùng mã
            if (GetEntityCode(entityUpdate) != code)
            {
                if (await CheckDuplicateCodeAsync(GetEntityCode(entityUpdate)) == ErrorCode.DuplicateCode)
                {
                    throw new ConflictException(ErrorCode.DuplicateCode, MISAResource.ResourceManager.GetString("DuplicateCode") ?? "");
                }
            }

            // check constrain
            var errorCode = await CheckValidConstraint(entityUpdate);
            if (errorCode == ErrorCode.InvalidDepartment)
            {
                throw new BadRequestException(errorCode, MISAResource.ResourceManager.GetString("InvalidDepartment") ?? "");
            }
            else if (errorCode == ErrorCode.InvalidPosition)
            {
                throw new BadRequestException(errorCode, MISAResource.ResourceManager.GetString("InvalidPosition") ?? "");
            }

            // cập nhật
            var newEntity = await _crudRepository.UpdateAsync(entityUpdate);

            if (entity is BaseAuditEntity auditEntity)
            {
                auditEntity.ModifiedBy = "Trương Mạnh Quang";
                auditEntity.ModifiedDate = DateTime.Now;
            }

            // map entity sang entityDTO
            var newEntityDTO = MapTEntityToTEntityDto(newEntity);

            return newEntityDTO;
        }

        /// <summary>
        /// hàm map entity create sang entity
        /// </summary>
        /// <param name="entityInsertDto"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public abstract TEntity MapEntityCreateDtoToEntity(TEntityCreateDTO entityInsertDto);

        /// <summary>
        /// hàm map entity update sang entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entityUpdateDto"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public abstract TEntity MapEntityUpdateDtoToEntity(TKey id, TEntityUpdateDTO entityUpdateDto);

        /// <summary>
        /// hàm kiểm tra ràng buộc của thực thể
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (19/8/2023)
        public abstract Task<ErrorCode> CheckValidConstraint(TEntity entity);

        /// <summary>
        /// lấy mã entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (19/8/2023)
        public abstract string GetEntityCode(TEntity entity);
    }
}
