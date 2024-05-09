using System;
using System.ComponentModel.DataAnnotations;

namespace Eportfolio.Models
{
    public class MyMusic
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Url]
        public string YouTubeLink { get; set; }

        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
