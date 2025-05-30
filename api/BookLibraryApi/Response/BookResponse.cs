namespace BookLibraryApi.Response
{
    public class BookResponse(string title, string firstName, string lastName, int totalCopies, int copiesInUse, string? type, string? isbn, string? category)
    {
        public string Title { get; set; } = title;

        public string FirstName { get; set; } = firstName;

        public string LastName { get; set; } = lastName;

        public int TotalCopies { get; set; } = totalCopies;

        public int CopiesInUse { get; set; } = copiesInUse;

        public string? Type { get; set; } = type;

        public string? Isbn { get; set; } = isbn;

        public string? Category { get; set; } = category;
    }
}
