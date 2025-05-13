using BookLibraryy.Database;
using BookLibraryy.IRepository;
using BookLibraryy.Models;

namespace BookLibraryy.Repository
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
