using TaskOrm.Models;
using TaskOrm.Service;

namespace TaskOrm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bookService = new BookService();

            // CREATE
            bookService.Add(new Book { Name = "aaaa", Author ="bbb" });
            //var books =bookService.GetAll();
            //foreach (var b in books)
            //{
            //    Console.WriteLine($"{b.Id}: {b.Name} - {b.Author}");
            //}

            ////update
            //var bookToUpdate = bookService.GetById(1);
            //if (bookToUpdate != null)
            //{
            //    bookToUpdate.Name = "hahaha";
            //    bookService.Update(bookToUpdate);
            //}

            //bookService.Delete(1);

        }

    }
}
