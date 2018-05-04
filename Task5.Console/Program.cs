using Task5.Solution;
using Task5.Solution.Factories;

namespace Task5.Console
{
    using System.Collections.Generic;
    using System;
    using Task5;

    class Program
    {
        static void Main(string[] args)
        {
            string text = "google.com", url = "https://www.google.by/";

            Client client = new Client(text, url);

            var html = client.GetDocument(typeof(HtmlFactory));
            var plaint = client.GetDocument(typeof(PlainTextFactory));
            var latex = client.GetDocument(typeof(LaTeXFactory));

            Console.WriteLine(html);

            Console.WriteLine(plaint);

            Console.WriteLine(latex);

            Console.ReadKey();
        }
    }
}
