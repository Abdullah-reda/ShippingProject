using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Mapping
{
    public class AutoMapper : IMapper
    {
        private readonly IMapper _Mapper;
        AutoMapper(IMapper Mapper)
        {
            _Mapper = Mapper;
        }
        public TDestination Map<TSource, TDestination>()
        {
            return _Mapper.Map<TSource, TDestination>();
        }
    }
}
