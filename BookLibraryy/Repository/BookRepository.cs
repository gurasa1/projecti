using BookLibraryy.Database;
using BookLibraryy.IRepository;
using BookLibraryy.Models;
using BookLibraryy.Repository;

public class BookRepository : GenericRepository<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }
}