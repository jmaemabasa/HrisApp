namespace HrisApp.Client.Pages.Dialog.Assets.MainAsset
{
    public partial class AddMainAssetDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }

        private AssetMasterT obj = new();
        private List<AssetTypesT> TYPES = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();
        private List<AssetStatusT> ASSSTATUS = new();

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
            await StaticService.GetAssetStatus();
            ASSSTATUS = StaticService.AssetStatusTs;
            obj.AssetStatusId = 2;
            obj.StorageType = "SSD";
        }

        private async Task ConfirmCreate()
        {
            await OnGenerateCode();
            await AssetMasterService.CreateObj(obj);

            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

            MudDialog?.Close();
            _toastService.ShowSuccess(obj.WorksationName + " Created Successfully!");

            // Update the List using the StateService
            StateService.SetState("AssetMasterList", await AssetMasterService.GetObjList());
        }

        private async Task OnGenerateCode()
        {
            int lastCount = await AssetMasterService.GetLastCode(obj.TypeId, obj.CategoryId, obj.SubCategoryId) + 1;

            var typecode = TYPES.Where(e => e.Id == obj.TypeId).FirstOrDefault()!.AType_Code;
            var catcode = CAT.Where(e => e.Id == obj.CategoryId).FirstOrDefault()!.ACat_Code;
            var subcode = SUBCAT.Where(e => e.Id == obj.SubCategoryId).FirstOrDefault()!.ASubCat_Code;
            string rolesCode = lastCount.ToString().PadLeft(4, '0');
            obj.Code = $"{typecode}-{catcode}-{subcode}-{rolesCode}";
        }

        #region TABS

        public MudTabs? tabs;
        public int activeIndex;

        public RenderFragment tabHeader(int tabId)
        {
            return builder =>
            {
                if (tabId == 0)
                {
                    builder.OpenComponent<MudChip>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(0));
                    builder.AddAttribute(3, "Text", $"{tabId + 1}");
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(0));
                    builder.AddContent(6, "Device Info");
                    builder.CloseComponent();
                }
            };
        }

        public string GetTabChipClass(int tabId)
        {
            if (activeIndex > tabId)
            {
                if (tabId == 0)
                    return "mud-chip-after0";
                else if (tabId == 1)
                    return "mud-chip-after1";
                else if (tabId == 2)
                    return "mud-chip-after2";
                else if (tabId == 3)
                    return "mud-chip-after3";
                else
                    return "mud-chip-after";
            }
            else if (activeIndex == tabId)
            {
                return "mud-chip-active";
            }
            else
            {
                return "mud-chip-default";
            }
        }

        public string GetTabTextClass(int tabId)
        {
            if (activeIndex > tabId)
            {
                return "mud-text-after";
            }
            else if (activeIndex == tabId)
            {
                return "mud-text-active";
            }
            else
            {
                return "mud-text-default";
            }
        }

        #endregion TABS
    }
}