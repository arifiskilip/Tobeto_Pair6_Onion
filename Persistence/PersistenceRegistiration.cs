using Application.Repositories;
using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;
using Persistence.Services;

namespace Persistence
{
	public static class PersistenceRegistiration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<CarRentalTobetoContext>(opt =>
			{
				opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
			});

			services.AddScoped<IBrandDal, BrandDal>();
			services.AddScoped<IBrandService, BrandManager>();


			services.AddScoped<IModelDal, ModelDal>();
			services.AddScoped<IModelService, ModelManager>();

			services.AddScoped<IUserDal, UserDal>();
			services.AddScoped<IUserService, UserManager>();

			services.AddScoped<IUserOperationClaimDal, UserOperationClaimDal>();
			services.AddScoped<IUserOperationClaimService, UserUserOperationClaimManager>();

			services.AddScoped<IAuthService, AuthManager>();
			services.AddScoped<IIndividualCustomerDal, IndividualCustomerDal>();
			services.AddScoped<ICorporateCustomerDal, CorporateCustomerDal>();

			return services;
		}
	}
}
