using Application.Features.Auth.Rules;
using Application.Repositories;
using Application.Services;
using AutoMapper;
using Core.Entities;
using Core.Entities.Enums;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.IndividualRegister
{
	public class IndividualRegisterCommand : IRequest<IndividualRegisterResponse>
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string IdentityNumber { get; set; }



		public class IndividualRegisterHandler : IRequestHandler<IndividualRegisterCommand, IndividualRegisterResponse>
		{
			private readonly IIndividualCustomerDal _ındividualCustomerDal;
			private readonly IAuthService _authService;
			private readonly IMapper _mapper;
			private readonly IndividualBusinessRuless _businessRuless;
			private readonly IUserOperationClaimService _userOperationClaimService;

			public IndividualRegisterHandler(IIndividualCustomerDal ındividualCustomerDal, IAuthService authService, IndividualBusinessRuless businessRuless, IMapper mapper, IUserOperationClaimService userOperationClaimService)
			{
				_ındividualCustomerDal = ındividualCustomerDal;
				_authService = authService;
				_businessRuless = businessRuless;
				_mapper = mapper;
				_userOperationClaimService = userOperationClaimService;
			}

			public async Task<IndividualRegisterResponse> Handle(IndividualRegisterCommand request, CancellationToken cancellationToken)
			{
				await _businessRuless.DuplicateEmailCheckAsync(request.Email);
				await _businessRuless.DuplicateIdentityNumberCheckAsync(request.IdentityNumber);

				byte[] passwordHash, passwordSalt;
				HashingHelper.CreatePasswordHash(request.Password,out passwordHash, out passwordSalt);

				IndividualCustomer customer = _mapper.Map<IndividualCustomer>(request);
				customer.PasswordHash = passwordHash;
				customer.PasswordSalt = passwordSalt;
				var addedCustomer = await _ındividualCustomerDal.AddAsync(customer);
				await _userOperationClaimService.AddRangeUserRoleAsync(new()
				{
					new(){ UserId = addedCustomer.Id, OperationClaimId = (int)OperationClaimEnum.Brand_Read},
					new(){ UserId = addedCustomer.Id, OperationClaimId = (int)OperationClaimEnum.Model_Read},
				});

				AccessToken token = await _authService.CreateAccessTokenAsync(addedCustomer);

				IndividualRegisterResponse response = _mapper.Map<IndividualRegisterResponse>(addedCustomer);
				response.Token = token;
				return response;
			}
		}
	}
}
