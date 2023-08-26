using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Concrete
{
    public class Blog
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Title must be between 2 and 100 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "Content must be between 20 and 1000 characters.")]
        public string Content { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public bool Status { get; set; }

        [Required(ErrorMessage = "ImageUrl is required.")]
        public string ImageUrl { get; set; } = string.Empty;

        
        public string ThumbnailImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = "CategoryId is required.")]
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [Required(ErrorMessage = "WriterId is required.")]
        public Guid WriterId { get; set; }
        [ForeignKey("WriterId")]
        public Writer Writer { get; set; }

        public List<Comment> Comments { get; set; }
       
    }
}