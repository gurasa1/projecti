using BookLibraryy.IRepository;
using BookLibraryy.Models;
using BookLibraryy.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenericRepository<Genre> _genreRepository;

        public GenresController(IGenericRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        // GET: api/genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GenreReadDto>>> GetGenres()
        {
            var genres = await _genreRepository.GetAllAsync();
            var dtoList = genres.Select(GenreMapper.ToReadDto);
            return Ok(dtoList);
        }

        // GET: api/genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GenreReadDto>> GetGenre(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null) return NotFound();

            return Ok(GenreMapper.ToReadDto(genre));
        }

        // POST: api/genres
        [HttpPost]
        public async Task<ActionResult<GenreReadDto>> CreateGenre(GenreCreateDto dto)
        {
            var genre = GenreMapper.ToEntity(dto);
            await _genreRepository.AddAsync(genre);
            var resultDto = GenreMapper.ToReadDto(genre);
            return CreatedAtAction(nameof(GetGenre), new { id = genre.Id }, resultDto);
        }

        // PUT: api/genres/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGenre(int id, GenreUpdate dto)
        {
            var existing = await _genreRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            GenreMapper.UpdateEntity(existing, dto);
            await _genreRepository.UpdateAsync(existing);

            return NoContent();
        }

        // DELETE: api/genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenre(int id)
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            if (genre == null) return NotFound();

            await _genreRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}