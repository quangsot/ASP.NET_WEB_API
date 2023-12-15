using AutoMapper;
using WebFresher202306.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFresher202306.Application
{
    public abstract class ReadOnlyService<TEntity,TEntityDTO, TKey> : IReadOnlyService<TEntityDTO, TKey>
        where TEntityDTO : class
        where TEntity : IEntity<TKey>
    {
        protected readonly IReadOnlyRepository<TEntity, TKey> _readOnlyRepository;

        public ReadOnlyService(IReadOnlyRepository<TEntity, TKey> readOnlyRepository)
        {
            _readOnlyRepository = readOnlyRepository;
        }

        /// <summary>
        /// hàm lấy tất cả
        /// </summary>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<IEnumerable<TEntityDTO>> GetAllAsync()
        {
            var entities = await _readOnlyRepository.GetAllAsync();
            
            // map entity sang entityDTO
            var entitiesDTO = entities.Select(entity=> MapTEntityToTEntityDto(entity)).ToList();

            return entitiesDTO;
        }

        /// <summary>
        /// hàm lấy theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public async Task<TEntityDTO> GetByIdAsync(TKey id)
        {
            var entity = await _readOnlyRepository.GetByIdAsync(id);

            // map entity sang entityDTO
            var entityDTO = MapTEntityToTEntityDto(entity);

            return entityDTO;
        }

        /// <summary>
        /// hàm map entity sang entity dto
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// author: Trương Mạnh Quang (17/8/2023)
        public abstract TEntityDTO MapTEntityToTEntityDto(TEntity entity);
    }
}
