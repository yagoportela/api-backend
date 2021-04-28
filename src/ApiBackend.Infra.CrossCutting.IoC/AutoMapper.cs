using AutoMapper;
using ApiBackend.Application.Params;
using ApiBackend.Domain.Commands;
using ApiBackend.Domain.Aggregate.Customer;

namespace ApiBackend.Infra.CrossCutting.IoC
{
    public class AutoMapper : Profile
    {
        public AutoMapper () {
            // CreateMap<CustomerModel, DTORegisterCustomer>()
            //     .ForMember(dest => dest.Email, opt => opt.MapFrom(src => Email.Value));
            #region parameters
            CreateMap<ParamRegisterRequest, ClientRegisterCommand>();
            #endregion

            #region aggregates
            CreateMap<ClientRegisterCommand, CustomerModelCreateDTO>();
            #endregion
        }
    }
}