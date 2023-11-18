namespace HrisApp.Client.GlobalService
{
    public interface IMainsService
    {
        HttpClient Get_Http();
        Task Set_Http();
    }
}
