using Application.Services;
using Core.CrossCuttingConcers.Exceptions.Types;
using Core.Utilities.Security.Hashing;
using MediatR;

namespace Application.Features.Auth.Commands.Login
{
	public class LoginCommand : IRequest<LoginResponse>
	{
		public string Email { get; set; }
		public string Password { get; set; }



		public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponse>
		{
			private readonly IUserService _userService;
			private readonly IAuthService _authService;
			public LoginCommandHandler(IUserService userService, IAuthService authService)
			{
				_userService = userService;
				_authService = authService;
			}

			public async Task<LoginResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
			{
				var user = await _userService.GetByMailAsync(request.Email);
				if (!HashingHelper.VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
				{
					throw new AuthorizationException("Kullanıcı adı veya şifre hatalı!");
				}
				var token = await _authService.CreateAccessTokenAsync(user);
				return new()
				{
					User = user,
					Token = token
				};
			}
		}
	}
}
