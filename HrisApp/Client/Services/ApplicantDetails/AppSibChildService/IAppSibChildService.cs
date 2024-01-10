namespace HrisApp.Client.Services.ApplicantDetails.AppSibChildService
{
    public interface IAppSibChildService
    {
        List<App_SiblingT> App_SiblingTs { get; set; }
        Task<List<App_SiblingT>> GetSiblinglist(string verCode);
        Task<string> CreateSibling(App_SiblingT train);
        Task UpdateSibling(App_SiblingT train);
        Task DeleteSibling(int id);

        List<App_ChildrenT> App_ChildrenTs { get; set; }
        Task<List<App_ChildrenT>> GetChildrenlist(string verCode);
        Task<string> CreateChildren(App_ChildrenT train);
        Task UpdateChildren(App_ChildrenT train);
        Task DeleteChildren(int id);
    }
}
