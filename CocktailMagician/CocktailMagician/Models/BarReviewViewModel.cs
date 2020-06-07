﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class BarReviewViewModel
    {
        public BarReviewViewModel()
        {

        }
        [Required]
        [Range(0, 5, ErrorMessage = "Raitig is between 0-5")]
        public double Rating { get; set; }
        [MaxLength(500, ErrorMessage = "Use maximum 500 chars for your comment")]
        public string Comment { get; set; }
        public int BarId { get; set; }
        public string BarName { get; set; }
        public int AuthorId { get; set; }
        public string Author { get; set; }
    }
}
