using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookLibraryApi.Infra.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    book_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    last_name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    total_copies = table.Column<int>(type: "int", nullable: false),
                    copies_in_use = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    isbn = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.book_id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "book_id", "category", "copies_in_use", "first_name", "isbn", "last_name", "title", "total_copies", "type" },
                values: new object[,]
                {
                    { 1, "Sci-Fi", 40, "Dan", "1234567898", "Brown", "The Da Vinci Code", 50, "Paperback" },
                    { 2, "Fiction", 35, "John", "1234567899", "Steinbeck", "The Grapes of Wrath", 50, "Hardcover" },
                    { 3, "Non-Fiction", 35, "Douglas", "1234567900", "Adams", "The Hitchhiker's Guide to the Galaxy", 50, "Paperback" },
                    { 4, "Fiction", 8, "Herman", "8901234567", "Melville", "Moby-Dick", 30, "Hardcover" },
                    { 5, "Non-Fiction", 0, "Harper", "9012345678", "Lee", "To Kill a Mockingbird", 20, "Paperback" },
                    { 6, "Non-Fiction", 1, "J.D.", "0123456789", "Salinger", "The Catcher in the Rye", 10, "Hardcover" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
