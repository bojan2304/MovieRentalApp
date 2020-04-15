using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(255)]
        public string ShortDescription { get; set; }
        public string ImageUrl { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        public virtual Director Director { get; set; }
        public int DirectorId { get; set; }

        public virtual Customer Customer { get; set; }
        public int CustomerId { get; set; }
    }
}
