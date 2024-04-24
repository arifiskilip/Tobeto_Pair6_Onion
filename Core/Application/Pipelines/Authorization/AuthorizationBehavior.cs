using Core.CrossCuttingConcers.Exceptions.Types;
using Core.Extensions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;

namespace Core.Application.Pipelines.Authorization
{
	public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>, ISecuredRequest
	{
		private readonly IHttpContextAccessor _httpContextAccessor;

		public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		async Task<TResponse> IPipelineBehavior<TRequest, TResponse>.Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
		{
			if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
			{
				throw new AuthorizationException("Lütfen sisteme giriş yapınız.");
			}
			List<string>? roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
			bool isNotMatchedARoleClaimWithRequestRoles =
	   roleClaims.FirstOrDefault(roleClaim => request.RequiredRoles.Any(role => role == roleClaim)).IsNullOrEmpty();
			if (!isNotMatchedARoleClaimWithRequestRoles) throw new AuthorizationException("Yetkiniz yok.");
			TResponse response = await next();
			return response;
		}
	}
}
