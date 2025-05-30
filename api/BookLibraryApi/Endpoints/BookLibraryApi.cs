using BookLibraryApi.Infra;
using BookLibraryApi.Request;
using BookLibraryApi.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookLibraryApi.Endpoints
{
    public static class BookLibraryApi
    {
        internal static async Task<IResult> GetBooks(
            [FromServices] IDbContextFactory<BookLibraryContext> dbContextFactory,
            [AsParameters] GetBooksRequest request,
            [FromQuery] int? page = 1,
            [FromQuery] int? pageSize = 10)
        {
            using var dbContext = dbContextFactory.CreateDbContext();
            pageSize ??= 10;
            page ??= 1;

            var skipAmount = pageSize * (page - 1);

            var queryable = dbContext.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(request.Title))
                queryable = queryable.Where(b => b.Title.ToLower().Contains(request.Title.ToLower()));
            if (!string.IsNullOrWhiteSpace(request.Authors))
                queryable = queryable.Where(b => b.FirstName.ToLower().Contains(request.Authors.ToLower()) || b.LastName.ToLower().Contains(request.Authors.ToLower()));
            if (!string.IsNullOrWhiteSpace(request.Category))
                queryable = queryable.Where(b => b.Category != null && b.Category.ToLower().Contains(request.Category.ToLower()));
            if (!string.IsNullOrWhiteSpace(request.Type))
                queryable = queryable.Where(b => b.Type != null && b.Type.ToLower().Contains(request.Type.ToLower()));
            if (!string.IsNullOrWhiteSpace(request.Isbn))
                queryable = queryable.Where(b => b.Isbn != null && b.Isbn.ToLower().Contains(request.Isbn.ToLower()));
            if (request.TotalCopies.HasValue)
                queryable = queryable.Where(b => b.TotalCopies == request.TotalCopies);
            if (request.CopiesInUse.HasValue)
                queryable = queryable.Where(b => b.CopiesInUse == request.CopiesInUse);

            var results = await queryable
                .OrderBy(b => b.Title)
                .Skip(skipAmount ?? 0) 
                .Take(pageSize.Value)
                .Select(book => new BookResponse(
                    book.Title,
                    book.FirstName,
                    book.LastName,
                    book.TotalCopies,
                    book.CopiesInUse,
                    book.Type,
                    book.Isbn,
                    book.Category
                ))
                .ToListAsync();

            var totalNumberOfRecords = await queryable.CountAsync();
            var totalPageCount = (int)Math.Ceiling((double)totalNumberOfRecords / pageSize.Value);

            return TypedResults.Ok(new PagedResponse<BookResponse>()
            {
                PageNumber = page.Value,
                PageSize = pageSize.Value,
                ResponseList = results,
                TotalPages = totalPageCount,
                TotalItems = totalNumberOfRecords
            });
        }
    }
}
