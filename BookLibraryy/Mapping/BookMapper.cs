using BookLibraryy.DTO;
using BookLibraryy.Models;

namespace BookLibraryy.Mapping
{
    public class BookMapper
    {
        public static BookReadDto ReadDto(Book book)
        {
            return new BookReadDto
            {
                Id = book.Id,
                Title = book.Title,
                Year = book.Year,
                AuthorName = book.Author?.Name,
                GenreName = book.Genre?.Name,
            };

        }
        public static Book ToEntity(BookCreate dto)
        {
            return new Book
            {
                Title = dto.Title,
                Year = dto.Year,
                GenreId = dto.GenreId,
                AuthorId = dto.AuthorId,
            };
        }
        public static void UpdateEntity(Book book, BookUpdate dto)
        {
            book.Title = dto.Title;
            book.Year = dto.Year;
            book.GenreId = dto.GenreId;
            book.AuthorId = dto.AuthorId;
        }
    }
}
