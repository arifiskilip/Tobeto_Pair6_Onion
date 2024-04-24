namespace Core.DataAccess.Paging
{
	public class PaginatedList<T> : IPaginatedList<T>
	{

		public List<T> Items { get; set; }
		public PaginationInfo Pagination { get; set; }

		private PaginatedList(List<T> items, int pageIndex, int pageSize,IQueryable<T> source)
		{
			Items = items;
			Pagination = new PaginationInfo
			{
				PageIndex = pageIndex,
				PageSize = pageSize,
				TotalItems = source.Count(),
				TotalPages = (int)Math.Ceiling(source.Count() / (double)pageSize)
			};
		}

		public static PaginatedList<T> Create(IQueryable<T> source, int pageIndex, int pageSize)
		{
			var items = source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
			return new PaginatedList<T>(items, pageIndex, pageSize,source);
		}
	}
}