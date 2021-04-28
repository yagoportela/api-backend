using System.Threading.Tasks;
using ApiBackend.Application.Params;
using ApiBackend.Domain.Commands;
using ApiBackend.Application.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiBackend.Application.Apis.ApiCustomer
{
    public class ApplicationCustomerServices : IApplicationCustomersHandler
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ApplicationCustomerServices(IMapper mapper,
                                           IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public Task<IActionResult> HandleWithReturn(object command)
        {
            switch(command){
                case ParamRegisterRequest paramClienteCadastro:
                    return Handler(paramClienteCadastro);
                default:
                    return null;
           }
        }

        private async Task<IActionResult> Handler(ParamRegisterRequest paramClienteCadastro)
        {
            var filterMap = _mapper.Map<ClientRegisterCommand>(paramClienteCadastro);
            await _mediator.Send(filterMap);
            
            return new CreatedAtRouteResult("ObterCliente", filterMap.Id);
        }


    }
}