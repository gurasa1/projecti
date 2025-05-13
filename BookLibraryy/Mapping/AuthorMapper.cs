using BookLibraryy.DTO;
using BookLibraryy.Models;

namespace BookLibraryy.Mapping
{
    public static class AuthorMapper
    {
        public static AuthorReadDto ToDto(Author author)
        {
            return new AuthorReadDto
            {
                AuthorId = author.AuthorId,
                Name = author.Name
            };

        }
        public static Author ToEntity(AuthorCreate dto)
        {
            return new Author
            {
                Name = dto.Name
            };
        }
        public static void UpdateEntity(Author author, AuthorUpdate dto)
        {
            author.Name = dto.Name;
        }
    }
}
