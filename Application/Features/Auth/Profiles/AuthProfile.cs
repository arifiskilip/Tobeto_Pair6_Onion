using Application.Features.Auth.Commands.CorporateRegister;
using Application.Features.Auth.Commands.IndividualRegister;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Auth.Profiles
{
	public class AuthProfile : Profile
	{
        public AuthProfile()
        {

			CreateMap<IndividualCustomer, IndividualRegisterCommand>().ReverseMap();
			CreateMap<IndividualCustomer, IndividualRegisterResponse>().ReverseMap();


			CreateMap<CorporateCustomer, CorporateRegisterCommand>().ReverseMap();
			CreateMap<CorporateCustomer, CorporateRegisterResponse>().ReverseMap();
		}
    }
}
