namespace BookstoreModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Book
    {
        private ICollection<Author> authors { get; set; }

        private ICollection<Review> reviews { get; set; }

        public Book()
        {
            this.authors = new HashSet<Author>();
            this.reviews = new HashSet<Review>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string ISBN { get; set; }

        public decimal Price { get; set; }

        public string WebSite { get; set; }

        public virtual ICollection<Author> Authors 
        {
            get { return this.authors; }
            set { this.authors = value; }
        }

        public virtual ICollection<Review> Reviews
        {
            get { return this.reviews; }
            set { this.reviews = value; }
        }
    }
}
