namespace Midterm_Project
{
    internal class BookManager
    {
        private List<Book> _books = new List<Book>();

        public void AddBook(string title, string author, int releaseYear)
        {
            _books.Add(new Book(title, author, releaseYear));
            Console.WriteLine("book added!");
        }

        public void ShowBooks()
        {
            if (_books.Count == 0)
            {
                Console.WriteLine("list of books is empty.");
                return;
            }

            Console.WriteLine("list of books:");

            _books.ForEach(book => { Console.WriteLine(book); });

            //foreach (var item in _books)
            //{
            //    Console.WriteLine(item);
            //}
        }


        public void SearchBookByTitle(string title)
        {
            bool exists = false;
            foreach (var item in _books)
            {
                if (item.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"book {title} found:");
                    Console.WriteLine(item);
                    exists = true;
                    break;
                }
            }
            if (!exists)
            {
                Console.WriteLine("book not found.");
            }
        }

        public void SearchBookByAuthor(string author)
        {
            bool exists = false;
            foreach (var item in _books)
            {
                if (item.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                {
                    if (!exists)
                    {
                        Console.WriteLine($"books of {author}:");
                    }
                    Console.WriteLine(item);
                    exists = true;
                }
            }
            if (!exists)
            {
                Console.WriteLine("books not found.");
            }
        }

        public bool Exists(string title, string author, int year)
        {
            //var temp = _books.Find(obj => obj.Title == title && obj.Author == author && obj.ReleaseYear == year);
            return _books.Find(obj => obj.Title == title && obj.Author == author && obj.ReleaseYear == year) != null;
            //return _books.Contains(new Book(title, author, year));
        }

        public void Menu()
        {
            while (true)
            {
                Console.WriteLine($"1 - add book\n2 - show books\n3 - search book by title\n4 - search book by author\n5 - exit");
                string temp = Console.ReadLine();
                if (temp == "1")
                {
                    Console.Write("enter book title: ");
                    string title = Console.ReadLine();
                    Console.Write("enter book author: ");
                    string author = Console.ReadLine();
                    Console.Write("enter book release year: ");
                    int year;
                    while (!int.TryParse(Console.ReadLine(), out year) || year > DateTime.Now.Year)
                    {
                        Console.Write("enter correct release year: ");
                    }
                    if (!Exists(title, author, year))
                    {
                        AddBook(title, author, year);
                    }
                    else
                    {
                        Console.WriteLine("book already exists!");
                    }

                }
                else if (temp == "2")
                {
                    ShowBooks();
                }
                else if (temp == "3")
                {
                    Console.Write("enter book title: ");
                    string title = Console.ReadLine();
                    SearchBookByTitle(title);
                }
                else if (temp == "4")
                {
                    Console.Write("enter book author: ");
                    string author = Console.ReadLine();
                    SearchBookByAuthor(author);
                }
                else if (temp == "5")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("incorrect input!");
                }
            }
        }



    }
}