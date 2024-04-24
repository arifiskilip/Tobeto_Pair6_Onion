using Core.Utilities.Security.JWT;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
	public static class CoreServiceRegistration
	{
		public static IServiceCollection AddCoreServices(this IServiceCollection services)
		{

			services.AddScoped<ITokenHelper, JwtHelper>();
			services.AddHttpContextAccessor();

			return services;
		}
	}
}
