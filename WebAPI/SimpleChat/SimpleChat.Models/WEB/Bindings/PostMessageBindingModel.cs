namespace SimpleChat.Services.Models.Bindings
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PostMessageBindingModel
    {
        [Required]
        public string Content { get; set; }

        [Required]
        public int ChatId { get; set; }
    }
}