using Core.Utilities.Security.JWT;

namespace Application.Features.Auth.Commands.IndividualRegister
{
	public class IndividualRegisterResponse
	{
		public int Id { get; set; }
		public DateTime CreatedDate { get; set; } 
		public DateTime? UpdatedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
		public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string IdentityNumber { get; set; }

        public AccessToken Token { get; set; }

    }
}
