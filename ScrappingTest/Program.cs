using System;
using CsvHelper;

using HtmlAgilityPack;

using ScrapySharp.Extensions;

using System.IO;

using System.Collections.Generic;

using System.Globalization;

namespace ScrappingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Send the request to the server
            HtmlWeb web = new HtmlWeb();

            HtmlDocument doc = web.Load("https://blog.hubspot.com/topic-learning-path/customer-retention");

            //Select a specific node from the HTML doc
            var Headers = doc.DocumentNode.CssSelect("h3.blog-card__content-title > a");

            //Extract the text and store it in a CSV file
            var titles = new List<Row>();

            foreach (var item in Headers)

            {

                titles.Add(new Row { Title = item.InnerText.Trim() });

            }

            using (var writer = new StreamWriter("hubspot.csv"))



            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))

            {

                csv.WriteRecords(titles);

            }
        }
        public class Row

        {

            public string Title { get; set; }

        }
    }
}
