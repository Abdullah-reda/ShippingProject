using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Domains;
using BL.Dtos;

namespace BL.Mapping
{
    public class MappingProfile : Profile  
    {
        public MappingProfile()
        {
            CreateMap<TbCarrier, CarrierDto>().ReverseMap();
            CreateMap<TbCity, CityDto>().ReverseMap();
            CreateMap<TbCountry, CountryDto>().ReverseMap();
            CreateMap<Log, LogDto>().ReverseMap();
            CreateMap<TbPaymentMethod, PaymentMethodDto>().ReverseMap();
            CreateMap<TbSetting, SettingDto>().ReverseMap();
            CreateMap<TbShippingType, ShippingTypeDto>().ReverseMap();
            CreateMap<TbShippment, ShippmentDto>().ReverseMap();
            CreateMap<TbShippmentStatus, ShippmentStatusDto>().ReverseMap();
            CreateMap<TbSubscriptionPackage, SubscriptionPackageDto>().ReverseMap();
            CreateMap<TbUserReceiver, UserReceiverDto>().ReverseMap();
            CreateMap<TbUserSebder, UserSebderDto>().ReverseMap();
            CreateMap<TbUserSubscription, UserSubscriptionDto>().ReverseMap();

        }
    }
}
