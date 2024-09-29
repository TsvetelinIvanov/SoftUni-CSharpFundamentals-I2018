using System;
using System.Text;

public class Book
{
    private const int TitleMinLength = 3;

    private string author;
    private string title;
    private decimal price;

    public Book(string author, string title, decimal price)
    {
        this.Author = author;
        this.Title = title;
        this.Price = price;
    }

    public string Author
    {
        get { return this.author; }
        set
        {
            string[] authorNames = value.Split();
            if (authorNames.Length == 2 && char.IsDigit(authorNames[1][0]))
            {
                throw new ArgumentException("Author not valid!");
            }

            this.author = value;
        }
    }

    public string Title
    {
        get { return this.title; }
        set
        {
            if (value.Length < TitleMinLength)
            {
                throw new ArgumentException("Title not valid!");
            }

            this.title = value;
        }
    }

    public virtual decimal Price
    {
        get { return this.price; }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException("Price not valid!");
            }

            this.price = value;
        }
    }

    public override string ToString()
    {
        StringBuilder bookInfoBuilder = new StringBuilder();
        bookInfoBuilder.AppendLine($"Type: {this.GetType().Name}")
        .AppendLine($"Title: {this.Title}")
        .AppendLine($"Author: {this.Author}")
        .AppendLine($"Price: {this.Price:f2}");
        
        string bookInfo = bookInfoBuilder.ToString().TrimEnd();

        return bookInfo;
    }
}
