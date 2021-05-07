using AutoMapper;
using ApiBackend.Application.Params;
using ApiBackend.Domain.Commands.RegisterCustomer;
using ApiBackend.Domain.Aggregate.Customer;

namespace ApiBackend.Infra.CrossCutting.IoC
{
    public class AutoMapper : Profile
    {
        public AutoMapper () {
            // CreateMap<CustomerModel, DTORegisterCustomer>()
            //     .ForMember(dest => dest.Email, opt => opt.MapFrom(src => Email.Value));
            #region parameters
            CreateMap<ParamRegisterRequest, RegisterCustormerRequest>();
            #endregion

            #region aggregates
            CreateMap<RegisterCustormerRequest, CustomerModelCreateDTO>();
            #endregion
        }
    }
}