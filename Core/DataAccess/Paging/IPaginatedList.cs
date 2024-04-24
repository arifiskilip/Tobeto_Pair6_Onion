namespace Core.DataAccess.Paging
{
	public interface IPaginatedList<T>
	{
		public List<T> Items { get; set; }
		public PaginationInfo Pagination { get; set; }
	}
}
