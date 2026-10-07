using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using BL.Dtos;

namespace BL.Contracts
{
    public interface ICarrier : IGenericService<TbCarrier, CarrierDto>
    {
    }
}
