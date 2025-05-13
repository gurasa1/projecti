using BookLibraryy.IRepository;
using BookLibraryy.Models;
using BookLibraryy.DTO;
using Microsoft.AspNetCore.Mvc;
using BookLibraryy.Mapping;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IGenericRepository<Book> _bookRepository;

        public BooksController(IGenericRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: api/books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookReadDto>>> GetBooks()
        {
            var books = await _bookRepository.GetAllAsync();
            var dtoList = books.Select(BookMapper.ReadDto);
            return Ok(dtoList);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<BookReadDto>> GetBook(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) return NotFound();

            return Ok(BookMapper.ReadDto(book));
        }

        // POST: api/books
        [HttpPost]
        public async Task<ActionResult<BookReadDto>> CreateBook(BookCreate dto)
        {
            var book = BookMapper.ToEntity(dto);
            await _bookRepository.AddAsync(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, BookMapper.ReadDto(book));
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, BookUpdate dto)
        {
            var existing = await _bookRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            BookMapper.UpdateEntity(existing, dto);
            await _bookRepository.UpdateAsync(existing);
            return NoContent();
        }

        // DELETE: api/books/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var existing = await _bookRepository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _bookRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}