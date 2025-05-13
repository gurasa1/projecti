using BookLibraryy.Models;

namespace BookLibraryy.DTO
{
    public class BookCreate
    {
        public string Title { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
    }
    public class BookDelete
    {
        public int Id { get; set; }
    }
    public class BookUpdate
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public int GenreId { get; set; }
        public int AuthorId { get; set; }
    }
    public class BookReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string GenreName { get; set; }
        public string AuthorName { get; set; }
    }

}
