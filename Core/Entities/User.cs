namespace Core.Entities
{
	public class User : Entity<int>
	{
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
