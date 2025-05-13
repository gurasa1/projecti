using BookLibraryy.Models;
using BookLibraryy.DTO;

public static class GenreMapper
{
    public static GenreReadDto ToReadDto(Genre genre)
    {
        return new GenreReadDto
        {
            Id = genre.Id,
            Name = genre.Name,
            Description = genre.Description
        };
    }

    public static Genre ToEntity(GenreCreateDto dto)
    {
        return new Genre
        {
            Name = dto.Name,
            Description = dto.Description
        };
    }

    public static void UpdateEntity(Genre genre, GenreUpdate dto)
    {
        genre.Name = dto.Name;
        genre.Description = dto.Description;
    }
}