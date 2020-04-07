using AutoMapper;
using DAL_Test_Task.Entities;
using DAL_Test_Task.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Existek_WPF_Test_Task.AutoMapperProfiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Person, Customer>().ReverseMap();
            CreateMap<Country, Customer>()
                .ForMember(dest => dest.CountryTxt1, opt => opt.MapFrom(src => src.Txt1))
                .ForMember(dest => dest.CountryTxt2, opt => opt.MapFrom(src => src.Txt2))
                .ForMember(dest => dest.CountryTxt3, opt => opt.MapFrom(src => src.Txt3))
                .ForMember(dest => dest.CountryTxt4, opt => opt.MapFrom(src => src.Txt4)).ReverseMap();
            CreateMap<Greeting, Customer>()
                .ForMember(dest => dest.GreetingTxt1, opt => opt.MapFrom(src => src.Txt1))
                .ForMember(dest => dest.GreetingTxt2, opt => opt.MapFrom(src => src.Txt2))
                .ForMember(dest => dest.GreetingTxt3, opt => opt.MapFrom(src => src.Txt3))
                .ForMember(dest => dest.GreetingTxt4, opt => opt.MapFrom(src => src.Txt4)).ReverseMap();
            CreateMap<PersonContact, CustomerContact>()
                .ForMember(dest => dest.ContactTxt, opt => opt.MapFrom(src => src.Txt))
                .ForMember(dest => dest.ContactType, opt => opt.MapFrom(src => src.ContactTypeId)).ReverseMap();
            CreateMap<IEnumerable<Person>, IEnumerable<Customer>>().ReverseMap();
            CreateMap<IEnumerable<Greeting>, IEnumerable<Customer>>().ReverseMap();
            CreateMap<IEnumerable<Country>, IEnumerable<Customer>>().ReverseMap();
            CreateMap<IEnumerable<PersonContact>, IEnumerable<CustomerContact>>().ReverseMap();
        }
    }
}
