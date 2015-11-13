namespace BookstoreConsoleClient
{
    using BookstoreData;
using BookstoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

    class Program
    {
        static string ParseFilePath = @"../../complex-books.xml";
        static string QuerysFilePath = @"../../reviews-queries.xml";
        static BookstoreContext bookstore = new BookstoreContext();

        /*static void SaveToFile(IEnumerable<object> reviewSet)
        {
            XmlTextWriter writer = new XmlTextWriter("../../reviews-search-results.xml", Encoding.UTF8);
            using (writer)
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("result-set");

                foreach (var review in reviewSet)
                {
                    writer.WriteStartElement("review");
                    writer.WriteElementString("date", review.Date.ToString("d-MMM-yyyy"));
                    writer.WriteElementString("content", review.Content);

                    writer.WriteStartElement("book");
                    writer.WriteElementString("title", review.Books.First().Title);
                    writer.WriteElementString("url", review.Books.First().Url);
                    writer.WriteEndElement();

                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndDocument();
                Console.WriteLine("Done !!");
            }
        }*/
        static void ParseXml()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(ParseFilePath);

            XmlNode root = xmlDocument.DocumentElement;

            foreach (XmlNode book in root)
            {
                var currentBook = new Book();

                if (book["title"] == null)
                {
                    throw new InvalidOperationException();
                }

                currentBook.Title = book["title"].InnerText;

                if (book["web-site"] != null)
                {
                    currentBook.WebSite = book["web-site"].InnerText;
                }

                if (book["price"] != null)
                {
                    currentBook.Price = decimal.Parse(book["price"].InnerText);
                }

                if (book["isbn"] != null)
                {
                    string isbn = book["isbn"].InnerText;
                    if (isbn.Length != 13)
                    {
                        throw new ArgumentException("wrong isbn length");
                    }

                    bool isbnExists =
                        (from b in bookstore.Books
                         where b.ISBN == isbn
                         select b).Any();

                    if (isbnExists)
                    {
                        throw new InvalidOperationException("isbn exists");
                    }

                    currentBook.ISBN = isbn;
                }

                if (book["authors"] != null)
                {
                    var authorsList = book["authors"].ChildNodes;
                    foreach (XmlNode listItem in authorsList)
                    {
                        string authorName = listItem.InnerText;
                        var author =
                            (from a in bookstore.Authors
                             where a.Name == authorName
                             select a).FirstOrDefault();

                        if (author == null)
                        {
                            author = new Author();
                            author.Name = authorName;
                        }

                        currentBook.Authors.Add(author);
                    }
                }

                if (book["reviews"] != null)
                {
                    var reviewsList = book["reviews"].ChildNodes;
                    foreach (XmlNode reviewItem in reviewsList)
                    {
                        Review review = new Review();
                        review.Content = reviewItem.InnerText.Trim();

                        if (reviewItem.Attributes["date"] != null)
                        {
                            review.CreationTime = DateTime.Parse(reviewItem.Attributes["date"].InnerText);
                        }
                        else
                        {
                            review.CreationTime = DateTime.Now;
                        }

                        if (reviewItem.Attributes["author"] != null)
                        {
                            string authorName = reviewItem.Attributes["author"].InnerText;
                            var author =
                                (from a in bookstore.Authors
                                 where a.Name == authorName
                                 select a).FirstOrDefault();

                            if (author == null)
                            {
                                author = new Author();
                                author.Name = authorName;
                            }

                            review.Author = author;
                        }

                        currentBook.Reviews.Add(review);
                    }
                }

                bookstore.Books.Add(currentBook);
                bookstore.SaveChanges();
            }
        }
        static void Main()
        {
            //bookstore.Books.Any();

            //ParseXml();

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(QuerysFilePath);

            var queries = xmlDocument.GetElementsByTagName("query");

            foreach (XmlNode query in queries)
            {
                var type = query.Attributes["type"].InnerText;

                if (type == "by-period")
                {
                    string startDate = query["start-date"].InnerText;
                    string endDate = query["end-date"].InnerText;

                    DateTime start = DateTime.Parse(startDate);
                    DateTime end = DateTime.Parse(endDate);

                    var reviewsSet =
                        (from r in bookstore.Reviews
                         where r.CreationTime >= start &&
                               r.CreationTime <= end
                         select new
                         {
                             Id = r.Id,
                             Date = r.CreationTime,
                             Content = r.Content,
                             Books =
                                 (from b in bookstore.Books
                                  where b.Reviews.Contains(r)
                                  select new
                                  {
                                      Title = b.Title,
                                      Url = b.WebSite
                                  }).ToList()
                         }).
                         ToList().
                         OrderBy(r => r.Date).
                         ThenBy(r => r.Content);
                }
                else if(type == "by-author")
                {
                    string authorName = query["author-name"].InnerText;

                    var resultSet =
                        (from r in bookstore.Reviews
                         where r.Author.Name == authorName
                         select new
                         {
                             Date = r.CreationTime,
                             Content = r.Content,
                             Books =
                                 (from b in bookstore.Books
                                  where b.Reviews.Contains(r)
                                  select b).ToList()
                         }).ToList().
                         OrderBy(r => r.Date).
                         ThenBy(r => r.Content);

                    foreach (var item in resultSet)
                    {
                        Console.WriteLine(item.Date.ToString());
                        Console.WriteLine(item.Content);
                        Console.WriteLine();
                        Console.WriteLine(item.Books.First().Title);
                        Console.WriteLine(item.Books.First().ISBN);
                        Console.WriteLine(item.Books.First().WebSite);
                    }
                }
            }
        }
    }
}
