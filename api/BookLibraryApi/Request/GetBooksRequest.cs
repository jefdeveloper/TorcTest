namespace BookLibraryApi.Request
{
    public class GetBooksRequest
    {
        public string? Title { get; set; }

        public string? Authors { get; set; }

        public string? Category { get; set; }

        public string? Type { get; set; }

        public string? Isbn { get; set; }

        public int? TotalCopies { get; set; }

        public int? CopiesInUse { get; set; }
    }
}
