using Core.Entities;

namespace Domain.Entities
{
	public class Brand : Entity<int>
	{
        public string Name { get; set; }
        public int ModelId { get; set; }

        public virtual Model Model { get; set; }
    }
}
