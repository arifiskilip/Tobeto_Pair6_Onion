namespace Application.Features
{
	public class AddBrandResponse
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public int ModelId { get; set; }
        public string ModelName { get; set; }
		public DateTime CreatedDate { get; set; }
		public DateTime? UpdatedDate { get; set; }
		public DateTime? DeletedDate { get; set; }
	}
}
