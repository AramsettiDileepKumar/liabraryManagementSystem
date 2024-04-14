using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace liabraryManagementSystem
{
    public class Library
    {
        public List<Book> books = new List<Book>();
        public Dictionary<Book, User> borrowedBooks = new Dictionary<Book, User>();
        public object lockObject = new object();
        public void AddBook(Book book)
        {
            books.Add(book);
            
        }
        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }
        public void BorrowBook(Book book, User user)
        {
            lock (lockObject)
            {
                if (books.Contains(book))
                {
                    books.Remove(book);
                    borrowedBooks.Add(book, user);
                    Console.WriteLine($"{user.Name} borrowed {book.Title}"); 
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Book is not available");
                    Thread.Sleep(1000);
                }
            }
        }
        public void ReturnBook(Book book, User user)
        {
            lock (lockObject)
            {
                if (borrowedBooks.ContainsKey(book))
                {
                    borrowedBooks.Remove(book);
                    books.Add(book);
                    Console.WriteLine($"{user.Name} returned {book.Title}");
                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Invalid book or user");
                    Thread.Sleep(1000);
                }
            }

        }
        public  List<Book> SearchBooksByAuthor(string author)
        {
            return books.Where(b => b.Author.Equals(author)).ToList();
        }
        public  List<Book> SearchBooksByTitle(string title)
        {
            return books.Where(b => b.Title.Contains(title)).ToList();
        }
    }
}
