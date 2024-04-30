using System;
using System.ComponentModel.DataAnnotations;

namespace Eportfolio.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tytuł jest wymagany.")]
        [StringLength(100, ErrorMessage = "Tytuł nie może być dłuższy niż 100 znaków.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Treść jest wymagana.")]
        public string Content { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedAt { get; set; }
    }
}
