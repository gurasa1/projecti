using Microsoft.AspNetCore.Mvc;
using BookLibraryy.IRepository;
using BookLibraryy.Models;
using BookLibraryy.DTO;
using BookLibraryy.Mapping;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IGenericRepository<Author> _repository;

        public AuthorsController(IGenericRepository<Author> repository)
        {
            _repository = repository;
        }

        // GET: api/authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorReadDto>>> GetAuthors()
        {
            var authors = await _repository.GetAllAsync();
            var dtoList = authors.Select(AuthorMapper.ToDto);
            return Ok(dtoList);
        }

        // GET: api/authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorReadDto>> GetAuthor(int id)
        {
            var author = await _repository.GetByIdAsync(id);
            if (author == null) return NotFound();

            return Ok(AuthorMapper.ToDto(author));
        }

        // POST: api/authors
        [HttpPost]
        public async Task<ActionResult<AuthorReadDto>> CreateAuthor(AuthorCreate dto)
        {
            var author = AuthorMapper.ToEntity(dto);
            await _repository.AddAsync(author);

            var resultDto = AuthorMapper.ToDto(author);
            return CreatedAtAction(nameof(GetAuthor), new { id = author.AuthorId }, resultDto);
        }

        // PUT: api/authors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(int id, AuthorUpdate dto)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            AuthorMapper.UpdateEntity(existing, dto);
            await _repository.UpdateAsync(existing);

            return NoContent();
        }

        // DELETE: api/authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}