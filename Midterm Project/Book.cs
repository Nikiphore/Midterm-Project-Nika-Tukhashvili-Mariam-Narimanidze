using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Project
{
    internal class Book //ვქმნით კლასს
    {
        //ვქმნით ფროფერთის
        public string Title { get; set; }
        public string Author { get; set; }
        public int ReleaseYear { get; set; }
        public Book() //კონსტრუქტორი
        {
            Title = "N/A";
            Author = "N/A";
        }

        public Book(string title, string author, int releaseYear) //კონსტრუქტორი
        {
            Title = title;
            Author = author;
            ReleaseYear = releaseYear;
        }

        public override string ToString() //ფუნქცია ობიექტის გამოსატანად
        {
            return $"title: {Title}, author: {Author}, year: {ReleaseYear}";
        }
    }
}