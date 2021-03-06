﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieRentalApp.Models
{
    public class Director
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }
    }
}
