﻿using Core.Entities;

namespace Application.Services
{
	public interface IUserOperationClaimService
	{
		Task AddUserRoleAsync(UserOperationClaim userOperationClaim);
	}
}
