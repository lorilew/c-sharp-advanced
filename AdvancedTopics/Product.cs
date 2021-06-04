using System.Collections;
using System.Collections.Generic;

namespace AdvancedTopics
{
    public class Product
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
    public class Book: Product
    {
        public string ISBN { get; set; }
    }

    public class ProductFactory<TBook> where TBook : Book, new()
    {
        public TBook Create()
        {
            return new TBook()
            {
                ISBN = "1234567890"
            };
            
        }
    }

    public class BookRepository
    {
        public IEnumerable<Book> GetBooks()
        {
            return new List<Book>()
            {
                new() {Title = "Name of the Wind", Price = 9.99M},
                new() {Title = "The Potter's Bible", Price = 28.50M},
                new() {Title = "the Pig Book", Price = 2.99M},
                new() {Title = "Harry Potter and the Philosopher's Stone", Price = 4.99M},
                new() {Title = "The Wizard of Oz", Price = 8.99M},
                new() {Title = "1984 Limited Edition", Price = 59.00M},
            };
        }
    }
}