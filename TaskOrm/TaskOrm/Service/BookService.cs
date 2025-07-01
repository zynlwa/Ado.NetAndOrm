using TaskOrm.Context;
using TaskOrm.Models;

namespace TaskOrm.Service
{
    public class BookService
    {
        private readonly AppDbContext _context;

        public BookService()
        {
            _context = new AppDbContext();
        }
        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public List<Book> GetAll()
        {
            return _context.Books.ToList();
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public void Update(Book book)
        {
            var existBook = _context.Books.Find(book.Id);
            if (existBook != null)
            {
                existBook.Name = book.Name;
                existBook.Author = book.Author;
                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
