namespace BookLibraryy.DTO
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
    }
    public class GenreCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class GenreDelete
    {
        public int Id { get; set; }
    }
    public class GenreReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<BookReadDto> Books { get; set; }
    }
    public class GenreUpdate
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
