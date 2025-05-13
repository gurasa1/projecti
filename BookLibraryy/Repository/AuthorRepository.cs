using BookLibraryy.Database;
using BookLibraryy.IRepository;
using BookLibraryy.Models;
namespace BookLibraryy.Repository
{
    public class AuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
