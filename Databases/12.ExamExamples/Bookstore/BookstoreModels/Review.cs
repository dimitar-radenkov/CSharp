namespace BookstoreModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Review
    {
        public int Id { get; set; }

        [Required]
        public DateTime CreationTime { get; set; }

        public string Content { get; set; }

        public int? AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
