﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CocktailMagician.Web.Models
{
    public class EditBarCocktailsViewModel
    {
        public EditBarCocktailsViewModel()
        {

        }
        public IEnumerable<int> SelectedCocktails { get; set; }
        public IEnumerable<SelectListItem> Cocktails { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public double AverageRating { get; set; }
    }
}