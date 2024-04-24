namespace Core.Entities
{
	public class OperationClaim : Entity<int>
	{
        public string Name { get; set; }

        public ICollection<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
