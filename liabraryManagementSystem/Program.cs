using liabraryManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Library library = new Library();

            Book book1 = new Book("Book1", "Author1", "ISBN1");
            Book book2 = new Book("Book2", "Author2", "ISBN2");
            Book book3 = new Book("Book3", "Author3", "ISBN3");
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            User user1 = new User("Dileep", 1);
            User user2 = new User("Kumar", 2);
            Thread borrowThread1 = new Thread(() => library.BorrowBook(book1, user1));
            Thread borrowThread2 = new Thread(() => library.BorrowBook(book2, user2));
            Thread borrowThread3 = new Thread(() => library.BorrowBook(book3, user1));

            Thread returnThread1 = new Thread(() => library.ReturnBook(book1, user1));
            Thread returnThread2 = new Thread(() => library.ReturnBook(book2, user2));
            Thread returnThread3 = new Thread(() => library.ReturnBook(book3, user1));


            borrowThread1.Start();
            borrowThread2.Start();
            borrowThread3.Start();

      
            borrowThread1.Join();
            borrowThread2.Join();
            borrowThread3.Join();

        
            returnThread1.Start();
            returnThread2.Start();
            returnThread3.Start();

          
            returnThread1.Join();
            returnThread2.Join();
            returnThread3.Join();

         
            Console.WriteLine("Available books in the library:");
            foreach (var book in library.books)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }

            Console.ReadKey();
        }
       
    }
}
