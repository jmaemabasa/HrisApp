namespace HrisApp.Client.Pages.Dialog.Assets.MainAsset
{
    public partial class UpdateMainAssetDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }
        [Parameter] public int Id { get; set; }

        private bool isUpdating = false;

        private AssetMasterT obj = new();
        private List<AssetTypesT> TYPES = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();

        public PatternMask MacAddMask = new("##:##:##:##:##:##")
        {
            MaskChars = new[] { new MaskChar('#', @"[0-9a-fA-F]") },
            CleanDelimiters = false,
            Transformation = AllUpperCase
        };

        public IMask ipv4Mask = RegexMask.IPv4();
        public IMask currMask = new RegexMask(@"^\$?[0-9,\.]*$");

        private static char AllUpperCase(char c) => c.ToString().ToUpperInvariant()[0];

        private void Cancel() => MudDialog?.Cancel();

        protected override async Task OnInitializedAsync()
        {
            TYPES = await AssetTypeService.GetObjList();
            CAT = await AssetCatService.GetObjList();
            SUBCAT = await AssetSubCatService.GetObjList();
        }

        protected override async Task OnParametersSetAsync()
        {
            //area = AreaService.AreaTs.Find(d => d.Id == Id);
            obj = await AssetMasterService.GetSingleObj((int)Id);
        }

        private async Task SaveUpdate()
        {
            await AssetMasterService.UpdateObj(obj);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

            _toastService.ShowSuccess(obj.WorksationName + " Updated Successfully!");

            // Update the List using the StateService
            StateService.SetState("AssetMasterList", await AssetMasterService.GetObjList());
            obj = await AssetMasterService.GetSingleObj((int)Id);
            isUpdating = false;
        }

        public void UpdateForm() => isUpdating = !isUpdating;
    }
}