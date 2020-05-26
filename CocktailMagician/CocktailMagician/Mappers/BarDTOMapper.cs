﻿using CocktailMagician.Services.DTOs;
using CocktailMagician.Web.Mappers.Contracts;
using CocktailMagician.Web.Models;
using System.Linq;

namespace CocktailMagician.Web.Mappers
{
    public class BarDTOMapper : IBarDTOMApper
    {
        public BarDTOMapper()
        {

        }
        public BarViewModel MapToVMFromDTO(BarDTO barDTO)
        {
            if (barDTO == null)
            {
                return null;
            }

            var barVM = new BarViewModel
            {
                Name = barDTO.Name,
                AverageRating = barDTO.AverageRating,
                CityName = barDTO.CityName,
                Cocktails = barDTO.Cocktails.Select(c => new CocktailViewModel
                {
                    Name = c.Name,
                    AverageRating = c.AverageRating
                }).ToList(),
            };

            return barVM;
        }
        public BarDTO MapToDTOFromVM(BarViewModel barVM)
        {
            if (barVM == null)
            {
                return null;
            }
            var barDTO = new BarDTO
            {
                Name = barVM.Name,
                CityName = barVM.CityName,
                Address = barVM.Address,
                Phone = barVM.Phone
            };
            
            return barDTO;
        }
    }
}