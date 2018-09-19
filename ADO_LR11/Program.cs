using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADO_LR11
{
    static class Program
    {
        static void AddAuthor(Authors author)
        {
            using (PublishingHouseEntities db = new PublishingHouseEntities())
            {
                db.Authors.Add(author);
                db.SaveChanges();
                MessageBox.Show("Author added!");
            }
        }

        static void GetAllAuthors()
        {
            using (PublishingHouseEntities db = new PublishingHouseEntities())
            {
                var authors = db.Authors.Where(a=>a.LastName.StartsWith("N")).ToList();

                foreach (var item in authors)
                {
                    MessageBox.Show(item.LastName + " " + item.FirstName);
                }
            }
        }

        static Authors GetAuthorByName(string firstName)
        {
            using (PublishingHouseEntities db = new PublishingHouseEntities())
            {
                var author = (from a in db.Authors
                              where a.FirstName == firstName
                              select a).FirstOrDefault();

                return author;
            }

        }

        static void AddTheme(Themes theme)
        {
            using (PublishingHouseEntities db = new PublishingHouseEntities())
            {
                Themes themeCurr = db.Themes.Where(p => p.NameTheme == theme.NameTheme).FirstOrDefault();
                if (themeCurr == null)
                {
                    db.Themes.Add(theme);
                    db.SaveChanges();
                    MessageBox.Show("New theme added: "+theme.NameTheme);
                }
            }
        }

        static void AddBooks(Books book)
        {
            using (PublishingHouseEntities db = new PublishingHouseEntities())
            {
                Books bookCurr = db.Books.Where(b => b.NameBook == book.NameBook).FirstOrDefault();
                if (bookCurr == null)
                {
                    db.Books.Add(book);
                    db.SaveChanges();
                    MessageBox.Show("New book added: " + book.NameBook);
                }
            }
        }

        static void Init()
        {
            Authors author = new Authors { FirstName = "Ray", LastName = "Bradbury", ID_COUNTRY = 3 };
            AddAuthor(author);
            author = new Authors { FirstName = "Hay", LastName = "Harrison", ID_COUNTRY = 2 };
            AddAuthor(author);
            author = new Authors { FirstName = "Jon", LastName = "Ford", ID_COUNTRY = 1 };
            AddAuthor(author);

            Themes theme = new Themes { NameTheme = "Pithon"};
            AddTheme(theme);
            theme = new Themes { NameTheme = "Java" };
            AddTheme(theme);

            Books book = new Books { NameBook = "First steps on Java", ID_AUTHOR = 12, ID_THEME = 7, Pages = 777, DateOfPublish = new DateTime(2018, 05, 15), Price = new decimal(55.67), DrowingOfBook = 57000, QuantityBooks = 50 };
            AddBooks(book);
        }

        static void GetAllBooks()
        {
            using (PublishingHouseEntities db = new PublishingHouseEntities())
            {
                var books = db.Books.OrderBy(b => b.NameBook).ToList();

                foreach (var item in books)
                {
                    MessageBox.Show($"Book: {item.NameBook}, Author: {item.Authors.LastName}, Theme: {item.Themes.NameTheme}, Price: {item.Price}");
                }
            }
        }


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Authors author = new Authors { FirstName = "Izya", LastName = "Vasilyev", ID_COUNTRY = 5};
            //AddAuthor(author);
            //GetAllAuthors();
            //Authors author = GetAuthorByName("Izya");
            //if (author != null)
            //    MessageBox.Show(author.LastName + " " + author.FirstName);
            //else
            //    MessageBox.Show("Автора с таким именем нет!");

            Init();
            GetAllBooks();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
