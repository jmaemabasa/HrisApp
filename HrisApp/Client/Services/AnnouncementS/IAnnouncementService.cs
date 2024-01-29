namespace HrisApp.Client.Services.AnnouncementS
{
    public interface IAnnouncementService
    {
        List<AnnouncementT> AnnouncementTs { get; set; }

        Task<List<AnnouncementT>> GetAnnouncementList();
        Task<List<AnnouncementT>> GetFilteredAnnouncementList();
        Task<AnnouncementT> GetSingleAnnouncement(int id);

        Task CreateAnnouncement(AnnouncementT obj);
        Task GetAnnouncement();
        Task UpdateAnnouncement(AnnouncementT obj);

    }
}
