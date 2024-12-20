﻿using GamesMarket.DataContext.Entities;

namespace GamesMarket.DataContext.Interfaces
{
    public interface IDeveloperRepository
    {
        Task<DeveloperEntity> CreateDeveper (Guid id, string name);
        Task<DeveloperEntity?> GetDeveper(Guid id);
        Task<List<DeveloperEntity>?> GetAllDevepers();
        Task<DeveloperEntity?> UpdateDeveper(Guid id, string name);
        Task<bool> DeleteDeveper(Guid id);
    }
}
