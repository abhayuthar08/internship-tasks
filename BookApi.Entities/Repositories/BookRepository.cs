//using BookApi.Entities.Context;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BookApi.Entities.Repositories
//{
//    internal class BookRepository(BookDbContext bookDbContext)
//    {
//        private readonly _dbContext = bookDbContext;
//    }
//}


using BookApi.Entities.Context;

namespace BookApi.Entities.Repositories
{
    internal class BookRepository
    {
        private readonly BookDbContext _dbContext;

        public BookRepository(BookDbContext bookDbContext)
        {
            _dbContext = bookDbContext;
        }

        // Add your methods here, for example:
        // public IEnumerable<Book> GetAllBooks() => _dbContext.Books.ToList();
    }
}
