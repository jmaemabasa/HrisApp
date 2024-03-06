namespace HrisApp.Client.Pages.Assets
{
    public partial class AccessoryDetails : ComponentBase
    {
        [Parameter] public int Id { get; set; }

        private AssetAccessoryT obj = new();
        private List<AssetTypesT> TYPES = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();
        private List<AssetStatusT> STATUS = new();
        private List<AssetAccessHistoryT> ACCHISTORY = new();

        private string MainAssetImage { get; set; } = string.Empty;

        private string infoFormat = "{first_item}-{last_item} of {all_items}";

        protected override async Task OnInitializedAsync()
        {
            TYPES = await AssetTypeService.GetObjList();
            CAT = await AssetCatService.GetObjList();
            SUBCAT = await AssetSubCatService.GetObjList();
            ACCHISTORY = await AssetAccHistorySvc.GetObjList();
            await StaticService.GetAssetStatus();
            STATUS = StaticService.AssetStatusTs;
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                obj = await AssetAccService.GetSingleObj(Id);

                await LoadMainAssetImg(obj.MainAsset!.JMCode);
            }
            catch (Exception)
            {
                //Console.WriteLine("aaaa " + ex);
                //Console.WriteLine("aaaa " + ex.Message);
                MainAssetImage = string.Format("images/asset-holder.jpg");
            }
        }

        private async Task SaveUpdate()
        {
            if (obj.AssetStatusId == 2 || obj.AssetStatusId == 1)
            {
                obj.StatusDate = null;
            }
            await AssetAccService.UpdateObj(obj);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

            _toastService.ShowSuccess(obj.AssetCode + " Updated Successfully!");
            await ReloadObjects();
        }

        private async Task LoadMainAssetImg(string jmcode)
        {
            var imagemodel = await AssetImageService.GetImageData(jmcode);
            Console.WriteLine("aaaa " + imagemodel.ToString());
            if (imagemodel != null)
            {
                var base642 = Convert.ToBase64String(imagemodel);
                MainAssetImage = string.Format("data:image/png;base64,{0}", base642);
            }
        }

        public async Task ReloadObjects()
        {
            // Update the List using the StateService
            StateService.SetState("AssetAccList", await AssetAccService.GetObjList());
            obj = await AssetAccService.GetSingleObj((int)Id);
            leftPanelOpen = false; detailsPanelOpen = false;
        }

        private Anchor anchor;
        private bool leftPanelOpen, detailsPanelOpen;

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            this.anchor = anchor;
            leftPanelOpen = (drawerx == "leftPanelOpen");
            detailsPanelOpen = (drawerx == "detailsPanelOpen");
        }

        #region MUD TABS / TAB PANEL

        private MudTabs? Tabs { get; set; }
        private int activeIndex;

        private RenderFragment TabHeader(int tabId)
        {
            return builder =>
            {
                if (tabId == 0)
                {
                    builder.OpenComponent<MudIconButton>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(0));
                    builder.AddAttribute(2, "Icon", @Icons.Material.Rounded.Devices);
                    builder.AddAttribute(3, "Size", Size.Small);
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(0));
                    builder.AddContent(6, "Accessory");
                    builder.CloseComponent();
                }
                else if (tabId == 1)
                {
                    builder.OpenComponent<MudIconButton>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(2));
                    builder.AddAttribute(2, "Icon", @Icons.Material.Outlined.AssignmentInd);
                    builder.AddAttribute(3, "Size", Size.Small);
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(1));
                    builder.AddContent(6, "Assigned To");
                    builder.CloseComponent();
                }
                else if (tabId == 2)
                {
                    builder.OpenComponent<MudIconButton>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(2));
                    builder.AddAttribute(2, "Icon", @Icons.Material.Outlined.AssignmentInd);
                    builder.AddAttribute(3, "Size", Size.Small);
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(2));
                    builder.AddContent(6, "Assigned To");
                    builder.CloseComponent();
                }
                else if (tabId == 3)
                {
                    builder.OpenComponent<MudIconButton>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(3));
                    builder.AddAttribute(2, "Icon", @Icons.Material.Rounded.Build);
                    builder.AddAttribute(3, "Size", Size.Small);
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(3));
                    builder.AddContent(6, "Maintenance");
                    builder.CloseComponent();
                }
                else if (tabId == 4)
                {
                    builder.OpenComponent<MudIconButton>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(4));
                    builder.AddAttribute(2, "Icon", @Icons.Material.Outlined.Image);
                    builder.AddAttribute(3, "Size", Size.Small);
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(4));
                    builder.AddContent(6, "Gallery");
                    builder.CloseComponent();
                }
                else if (tabId == 5)
                {
                    builder.OpenComponent<MudChip>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(5));
                    builder.AddAttribute(3, "Text", $"{tabId + 1}");
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(5));
                    builder.AddContent(6, "Attendance");
                    builder.CloseComponent();
                }
            };
        }

        private string GetTabChipClass(int tabId)
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

        private string GetTabTextClass(int tabId)
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

        #endregion MUD TABS / TAB PANEL
    }
}