using Core.Entities;

namespace Domain.Entities
{
	public class Model : Entity<int>
	{
        public string Name { get; set; }


        public ICollection<Brand> Brands { get; set; }
    }
}
