using MusicShopManager.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MusicShopManager.Models
{
    public class MusicShop : IMusicShop
    {
        private string name;
        private IList<IArticle> articles;

        public MusicShop(string name)
        {
            this.Name = name;
            this.Articles = new List<IArticle>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("The name of a music shop is required.");
                }

                this.name = value;
            }
        }

        public IList<IArticle> Articles
        {
            get { return this.articles; }
            private set { this.articles = value; }
        }

        public void AddArticle(IArticle article)
        {
            this.Articles.Add(article);
        }

        public void RemoveArticle(IArticle article)
        {
            this.Articles.Remove(article);
        }

        public string ListArticles()
        {
            StringBuilder musicShopBuilder = new StringBuilder();
            musicShopBuilder.AppendFormat("{0} {1} {0}", new string('=', 5), this.Name)
                .AppendLine();
            if (!this.Articles.Any())
            {
                musicShopBuilder.AppendLine("The shop is empty. Come back soon.");
                return musicShopBuilder.ToString();
            }

            IEnumerable<IArticle> micriphones = this.Articles.Where(a => a is Microphone);
            musicShopBuilder.Append(this.PrintArticles(micriphones, "Microphones"));

            IEnumerable<IArticle> drums = this.Articles.Where(a => a is Drums);
            musicShopBuilder.Append(this.PrintArticles(drums, "Drums"));

            IEnumerable<IArticle> electricGuitars = this.Articles.Where(a => a is ElectricGuitar);
            musicShopBuilder.Append(this.PrintArticles(electricGuitars, "Electric guitars"));

            IEnumerable<IArticle> acousticGuitars = this.Articles.Where(a => a is AcousticGuitar);
            musicShopBuilder.Append(this.PrintArticles(acousticGuitars, "Acoustic guitars"));

            IEnumerable<IArticle> bassGuitars = this.Articles.Where(a => a is BassGuitar);
            musicShopBuilder.Append(this.PrintArticles(bassGuitars, "Bass guitars"));           

            return musicShopBuilder.ToString();
        }

        private string PrintArticles(IEnumerable<IArticle> articles, string title)
        {
            if (articles.Count() == 0)
            {
                return string.Empty;
            }
            
            articles = articles.OrderBy(a => a.Make + " " + a.Model);
            StringBuilder articlesAsStringBuilder = new StringBuilder();
            articlesAsStringBuilder.AppendFormat("{0} {1} {0}", new string('-', 5), title)
                .AppendLine();
            foreach (IArticle article in articles)
            {
                //articlesAsStringBuilder.Append(article.ToString());
                articlesAsStringBuilder.Append(article);
            }

            return articlesAsStringBuilder.ToString();
        }
    }
}