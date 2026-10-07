using BL.Contracts;
using DAL.Contracts;
using Domains;
using AutoMapper;

using System;
using System.Collections.Generic;

namespace BL.Services
{
    public class GenericService<T, DTO> : IGenericService<T, DTO>where T : BaseTable
    {
        private readonly ITableRepository<T> _repository;
        private readonly IMapper _mapper;
        public GenericService(ITableRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IEnumerable<DTO> GetAll()
        {
            var list = _repository.GetAll();
            return _mapper.Map<IEnumerable<T>, IEnumerable<DTO>>(list);
        }       

        public DTO? GetById(Guid id)
        {
            var entity = _repository.GetById(id);
            return _mapper.Map<T, DTO>(entity);
        }

        public bool Add(DTO entity, Guid userId)
        {
            var mappedEntity = _mapper.Map<DTO, T>(entity);
            mappedEntity.CreatedBy = userId;
            return _repository.Add(mappedEntity);
        }

        public bool Update(DTO entity, Guid userId)
        {
            var mappedEntity = _mapper.Map<DTO, T>(entity);
            mappedEntity.UpdatedBy = userId;
            return _repository.Update(mappedEntity);
        }


        public bool ChangeStatus(Guid id, Guid userId,int status = 1)
        {
            return _repository.ChangeStatus(id, status);
        }
    }
}