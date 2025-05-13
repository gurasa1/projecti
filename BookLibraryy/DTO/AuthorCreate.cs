namespace BookLibraryy.DTO
{

    public class AuthorCreate
    {
        public string Name { get; set; }
    }
    public class AuthorDelete
    {
        public int Id { get; set; }
    }
    public class AuthorUpdate
    {
        public string Name { get; set; }
    }
    public class AuthorReadDto
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public List<BookReadDto> bookReadDtos { get; set; }
    }
}
