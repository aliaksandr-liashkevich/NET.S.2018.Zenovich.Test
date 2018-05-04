using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task5.Solution.Api;
using Task5.Solution.Factories;
using Task5.Solution.Html;
using Task5.Solution.LaTeX;

namespace Task5.Solution
{
    public class Client
    {
        private Dictionary<Type, IFactory<IConverter>> factories;

        public Client(string text, string url)
        {
            factories = new Dictionary<Type, IFactory<IConverter>>();

            HtmlFactory htmlFactory = new HtmlFactory();
            htmlFactory.Add(new HtmlBoldText()
            {
                Text = text
            });
            htmlFactory.Add(new HtmlHyperlink()
            {
                Text = text,
                Url = url
            });
            htmlFactory.Add(new HtmlPlainText()
            {
                Text = text
            });

            LaTeXFactory laTeXFactory = new LaTeXFactory();
            laTeXFactory.Add(new LaTeXBoldText()
            {
                Text = text
            });
            laTeXFactory.Add(new LaTeXHyperlink()
            {
                Text = text,
                Url = url
            });
            laTeXFactory.Add(new LaTeXPlainText()
            {
                Text = text
            });

            PlainTextFactory plainTextFactory = new PlainTextFactory();
            plainTextFactory.Add(new PlainText.PlainBoldText()
            {
                Text = text
            });
            plainTextFactory.Add(new PlainText.PlainHyperlink()
            {
                Text = text,
                Url = url
            });
            plainTextFactory.Add(new PlainText.PlainText()
            {
                Text = text
            });

            factories.Add(htmlFactory.GetType(), htmlFactory);
        }

        public string GetDocument(Type type)
        {
            var factory = factories.FirstOrDefault((f) => f.Key == type).Value;

            if (factory == null)
            {
                throw new ArgumentOutOfRangeException(nameof(type));
            }

            Document document = new Document(factory.Get());

            return document.GetBody();
        }
    }
}
