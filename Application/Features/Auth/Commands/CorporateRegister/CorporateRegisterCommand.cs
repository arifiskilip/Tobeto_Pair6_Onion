using Application.Features.Auth.Rules;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Core.Entities.Enums;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.CorporateRegister
{
	public class CorporateRegisterCommand : IRequest<CorporateRegisterResponse>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string TaxNumber { get; set; }
		public string CompanyName { get; set; }


		public class CorporateRegisterHandler : IRequestHandler<CorporateRegisterCommand, CorporateRegisterResponse>
		{
			private readonly ICorporateCustomerDal _corporateCustomerDal;
			private readonly IAuthService _authService;
			private readonly IMapper _mapper;
			private readonly CorporateBusinessRuless _businessRuless;
			private readonly IUserOperationClaimService _userOperationClaimService;

			public CorporateRegisterHandler(ICorporateCustomerDal corporateCustomerDal, IAuthService authService, IMapper mapper, CorporateBusinessRuless businessRuless, IUserOperationClaimService userOperationClaimService)
			{
				_corporateCustomerDal = corporateCustomerDal;
				_authService = authService;
				_mapper = mapper;
				_businessRuless = businessRuless;
				_userOperationClaimService = userOperationClaimService;
			}

			public async Task<CorporateRegisterResponse> Handle(CorporateRegisterCommand request, CancellationToken cancellationToken)
			{
				await _businessRuless.DuplicateEmailCheckAsync(request.Email);

				byte[] passwordHash, passwordSalt;
				HashingHelper.CreatePasswordHash(request.Password, out passwordHash, out passwordSalt);

				CorporateCustomer customer = _mapper.Map<CorporateCustomer>(request);
				customer.PasswordHash = passwordHash;
				customer.PasswordSalt = passwordSalt;
				var addedCustomer = await _corporateCustomerDal.AddAsync(customer);
				await _userOperationClaimService.AddRangeUserRoleAsync(new()
				{
					new(){ UserId = addedCustomer.Id, OperationClaimId = (int)OperationClaimEnum.Brand_Read},
					new(){ UserId = addedCustomer.Id, OperationClaimId = (int)OperationClaimEnum.Model_Read},
				});

				AccessToken token = await _authService.CreateAccessTokenAsync(addedCustomer);

				CorporateRegisterResponse response = _mapper.Map<CorporateRegisterResponse>(addedCustomer);
				response.Token = token;
				return response;
			}
		}
	}
}
