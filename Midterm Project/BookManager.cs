using System.Threading.Channels;
using static System.Reflection.Metadata.BlobBuilder;

namespace Midterm_Project
{
    internal class BookManager //ვქმნით კლასს
    {
        private List<Book> _books = new List<Book>(); //წიგნების ლისტი

        public void AddBook(string title, string author, int releaseYear) //ფუნქცია ამატებს ახალ წიგნს
        {
            _books.Add(new Book(title, author, releaseYear));
            Console.WriteLine("book added!");
        }

        public void ShowBooks() //ფუნქციას გამოაქვს წიგნების სია
        {
            if (_books.Count == 0) //ვამოწმებთ ცარიელი ხომ არ არის სია
            {
                Console.WriteLine("list of books is empty.");
                return;
            }

            Console.WriteLine("list of books:");

            _books.ForEach(book => { Console.WriteLine(book); }); //ვიყენებთ ლამბდას სიის გამოსატანად

            //foreach (var item in _books)
            //{
            //    Console.WriteLine(item);
            //}
        }


        public void SearchBookByTitle(string title) //ვეძებთ სიაში წიგნს სათაურით
        {
            bool exists = false;
            foreach (var item in _books)
            {
                if (item.Title.Equals(title, StringComparison.OrdinalIgnoreCase)) //თუ დაემთხვა სათაური (არ ვაქცევთ ყურადღებას რომელ რეგისტრშია დაწერილი)
                {
                    Console.WriteLine($"book {title} found:");
                    Console.WriteLine(item);
                    exists = true;
                    break; //ერთს იპოვის და გაჩერდება
                }
            }
            if (!exists)
            {
                Console.WriteLine("book not found.");
            }
        }

        public void SearchBookByAuthor(string author) //ვეძებთ სიაში წიგნს ავტორით
        {
            bool exists = false;
            foreach (var item in _books)
            {
                if (item.Author.Equals(author, StringComparison.OrdinalIgnoreCase))//თუ დაემთხვა ავტორი (არ ვაქცევთ ყურადღებას რომელ რეგისტრშია დაწერილი)
                {
                    if (!exists)
                    {
                        Console.WriteLine($"books of {author}:");
                    }
                    Console.WriteLine(item);
                    exists = true;
                    //გამოიტანს რამდენიმე შედეგს არსებობის შემთხვევაში
                }
            }
            if (!exists)
            {
                Console.WriteLine("books not found.");
            }
        }

        public bool Exists(string title, string author, int year)
        {

            return _books.Find(obj => obj.Title == title && obj.Author == author && obj.ReleaseYear == year) != null; //აბრუნებს ბულს, ამოწმებს არსებობს თუ არა კონკრეტული წიგნი სიაში

        }

        public void Menu() //ვქმნით მენიუს
        {
            while (true)
            {
                Console.WriteLine($"1 - add book\n2 - show books\n3 - search book by title\n4 - search book by author\n5 - exit");
                string temp = Console.ReadLine(); //მომხმარებელი ირჩევს მოქმედებას
                if (temp == "1") //ვამატებთ წიგნს
                {
                    Console.Write("enter book title: ");
                    string title = Console.ReadLine();
                    Console.Write("enter book author: ");
                    string author = Console.ReadLine();
                    Console.Write("enter book release year: ");
                    int year;
                    while (!int.TryParse(Console.ReadLine(), out year) || year > DateTime.Now.Year) //ვამოწმებთ სწორად შეჰყავს თუ არა წელი,ინტ ტიპის თუა და მიმდინარე წელზე მეტი ხომ არაა
                    {
                        Console.Write("enter correct release year: ");
                    }
                    if (!Exists(title, author, year)) //თუ წიგნი არ არსებობს დავამატებთ
                    {
                        AddBook(title, author, year);
                    }
                    else
                    {
                        Console.WriteLine("book already exists!");
                    }

                }
                else if (temp == "2") //გამოგვაქვს სია
                {
                    ShowBooks();
                }
                else if (temp == "3") //ვეძებთ სათაურით
                {
                    Console.Write("enter book title: ");
                    string title = Console.ReadLine();
                    SearchBookByTitle(title);
                }
                else if (temp == "4") //ვეძებთ ავტორით
                {
                    Console.Write("enter book author: ");
                    string author = Console.ReadLine();
                    SearchBookByAuthor(author);
                }
                else if (temp == "5") //პროგრამა მთავრდება
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