﻿using CocktailMagician.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CocktailMagician.Services.Contracts
{
    public interface IBarService
    {
        Task<ICollection<BarDTO>> GetAllBarsAsync(string sortMethod = "default");
        Task<BarDTO> GetBarAsync(int id);
        Task<BarDTO> CreateBarAsync(BarDTO barDTO);
        Task<BarDTO> UpdateBarAsync(int id, BarDTO barDTO);
        Task<bool> DeleteBarAsync(int id);
        Task<ICollection<BarDTO>> FilterBarsAsync(string filter);
    }
}
