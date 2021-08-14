using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._ArticlesV02
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                Article article = new Article(input[0], input[1], input[2]);
                articles.Add(article);
            }

            string filterText = Console.ReadLine();

            if (filterText == "title")
            {
                foreach (var article in articles.OrderBy(x => x.Title))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, article));
                }
            }
            else if (filterText == "content")
            {
                foreach (var article in articles.OrderBy(x => x.Content))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, article));
                }
            }
            else if (filterText == "author")
            {
                foreach (var article in articles.OrderBy(x => x.Author))
                {
                    Console.WriteLine(string.Join(Environment.NewLine, article));
                }
            }
        }
    }

    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
