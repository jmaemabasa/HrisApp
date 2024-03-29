﻿namespace HrisApp.Client.Services.MasterData.AreaService
{
    public interface IAreaService
    {
        List<AreaT> AreaTs { get; set; }
        Task<List<AreaT>> GetAreaList();
        Task<AreaT> GetSingleArea(int areaId);
        Task GetArea();
        Task CreateArea(string areaName);
        Task UpdateArea(AreaT area);
    }
}
