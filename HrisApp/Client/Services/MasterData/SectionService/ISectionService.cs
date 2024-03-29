﻿namespace HrisApp.Client.Services.MasterData.SectionService
{
    public interface ISectionService
    {
        List<SectionT> SectionTs { get; set; }

        Task<List<SectionT>> GetSectionList();
        //Task<List<SectionT>> GetSectByDepartment(int deptId);
        Task GetSectByDepartment(int deptId);
        Task GetSectByDivision(int divId);
        Task<SectionT> GetSingleSection(int id);
        Task GetSection();

        Task CreateSection(string sectName, int divId, int deptId);
        Task UpdateSection(SectionT section);
    }
}
