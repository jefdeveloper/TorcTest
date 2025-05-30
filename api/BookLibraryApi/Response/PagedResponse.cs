namespace BookLibraryApi.Response
{
    public class PagedResponse<T> where T : class
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<T>? ResponseList { get; set; }
    }
}
