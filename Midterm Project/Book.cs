using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Project
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }
        public Book()
        {
            Title = "N/A";
            Author = "N/A";
        }

        public Book (string title, string author, int releaseYear)
        {
            Title = title;
            Author = author;
            ReleaseYear = releaseYear;
        }

        public override string ToString()
        {
            return $"title: {Title}, author: {Author}, year: {ReleaseYear}";
        }
    }
}
