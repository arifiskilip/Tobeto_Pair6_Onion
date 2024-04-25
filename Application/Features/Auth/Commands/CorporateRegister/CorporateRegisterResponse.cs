using Core.Utilities.Security.JWT;

namespace Application.Features.Auth.Commands.CorporateRegister
{
	public class CorporateRegisterResponse
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string TaxNumber { get; set; }
		public string CompanyName { get; set; }
		public AccessToken Token { get; set; }
	}
}
