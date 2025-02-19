using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PublicationYear = table.Column<int>(type: "int", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    ViewsCount = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorName", "IsDeleted", "PublicationYear", "Title", "ViewsCount" },
                values: new object[,]
                {
                    { 1, "F. Scott Fitzgerald", false, 1925, "The Great Gatsby", 150 },
                    { 2, "George Orwell", false, 1949, "1984", 200 },
                    { 3, "Jane Austen", false, 1813, "Pride and Prejudice", 180 },
                    { 4, "Harper Lee", false, 1960, "To Kill a Mockingbird", 170 },
                    { 5, "J.D. Salinger", false, 1951, "The Catcher in the Rye", 130 },
                    { 6, "Gabriel García Márquez", false, 1967, "One Hundred Years of Solitude", 140 },
                    { 7, "Aldous Huxley", false, 1932, "Brave New World", 160 },
                    { 8, "J.R.R. Tolkien", false, 1954, "The Lord of the Rings", 250 },
                    { 9, "Charlotte Brontë", false, 1847, "Jane Eyre", 120 },
                    { 10, "Fyodor Dostoevsky", false, 1866, "Crime and Punishment", 110 },
                    { 11, "J.R.R. Tolkien", false, 1937, "The Hobbit", 230 },
                    { 12, "Miguel de Cervantes", false, 1605, "Don Quixote", 90 },
                    { 13, "Dante Alighieri", false, 1320, "The Divine Comedy", 80 },
                    { 14, "Fyodor Dostoevsky", false, 1880, "The Brothers Karamazov", 100 },
                    { 15, "Emily Brontë", false, 1847, "Wuthering Heights", 140 },
                    { 16, "Homer", false, -800, "The Odyssey", 70 },
                    { 17, "Oscar Wilde", false, 1890, "The Picture of Dorian Gray", 160 },
                    { 18, "Leo Tolstoy", false, 1869, "War and Peace", 120 },
                    { 19, "Alexandre Dumas", false, 1844, "The Count of Monte Cristo", 150 },
                    { 20, "Leo Tolstoy", false, 1877, "Anna Karenina", 140 },
                    { 21, "Victor Hugo", false, 1862, "Les Misérables", 130 },
                    { 22, "Homer", false, -760, "The Iliad", 60 },
                    { 23, "Mary Shelley", false, 1818, "Frankenstein", 170 },
                    { 24, "Geoffrey Chaucer", false, 1392, "The Canterbury Tales", 50 },
                    { 25, "Herman Melville", false, 1851, "Moby-Dick", 140 },
                    { 26, "Charles Dickens", false, 1837, "Oliver Twist", 120 },
                    { 27, "Bram Stoker", false, 1897, "Dracula", 180 },
                    { 28, "Alexandre Dumas", false, 1844, "The Three Musketeers", 130 },
                    { 29, "Charles Dickens", false, 1861, "Great Expectations", 140 },
                    { 30, "Arthur Conan Doyle", false, 1892, "The Adventures of Sherlock Holmes", 190 }
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
