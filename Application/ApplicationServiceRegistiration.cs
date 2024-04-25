using Application.Features;
using Application.Features.Auth.Rules;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
	public static class ApplicationServiceRegistiration
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			//Autom Mapper
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			//Fluent Validation
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
			//MediatR
			services.AddMediatR(config => {
				config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
				config.AddOpenBehavior(typeof(AuthorizationBehavior<,>));
				config.AddOpenBehavior(typeof(ValidationBehavior<,>));
			});

			services.AddScoped(typeof(BrandBusinessRules));
			services.AddScoped(typeof(ModelBusinessRules));
			services.AddScoped(typeof(IndividualBusinessRuless));
			services.AddScoped(typeof(CorporateBusinessRuless));
			return services;
		}
	}
}
