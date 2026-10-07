using System;
using System.Collections.Generic;
using System.Text;
using Domains;
using DAL.Contracts;
using BL.Contracts;
using BL.Dtos;
using AutoMapper;

namespace BL.Services
{
    public class PaymentMethodService : GenericService<TbPaymentMethod, PaymentMethodDto>, IPaymentMethod
    {
       public PaymentMethodService(ITableRepository<TbPaymentMethod> repository, IMapper mapper) : base(repository, mapper)
       {

       }   
    }
}
