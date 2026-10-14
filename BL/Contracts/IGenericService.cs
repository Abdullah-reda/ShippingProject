using BL.Dtos.Base;
using Domains;
using System;
using System.Collections.Generic;

namespace BL.Contracts
{
    public interface IGenericService<T, DTO>
    where T : BaseTable
    where DTO : BaseDto
    {
        IEnumerable<DTO> GetAll();

        DTO? GetById(Guid id);

        bool Add(DTO entity, Guid userId);

        bool Update(DTO entity, Guid userId);

        bool ChangeStatus(Guid id, Guid userId, int status = 1);
    }
}