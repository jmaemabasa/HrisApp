namespace HrisApp.Client.Pages.Assets.Consumables
{
#nullable disable

    public partial class ConsumableDetails : ComponentBase
    {
        [Parameter] public int Id { get; set; }

        private ConsumablesT obj = new();
        private List<AssetTypesT> TYPES = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();
        private List<AreaT> AREA = new();
        private List<UOMT> UOM = new();
        private List<ConsumableRemarksT> REMARKS = new();
        private List<Cons_TransactionT> TRANSACTIONS = new();

        private List<EmployeeT> TopTransEmployee = new();

        private int uomHolder = 0;
        private string ConsumableImageData { get; set; } = string.Format("images/asset-holder.jpg");
        private readonly string transactionFormat = "{first_item}-{last_item} of {all_items}";

        protected override async Task OnInitializedAsync()
        {
            TYPES = await AssetTypeService.GetObjList();
            CAT = await AssetCatService.GetObjList();
            SUBCAT = await AssetSubCatService.GetObjList();
            AREA = await AreaService.GetAreaList();
            UOM = await UOMService.GetObjList();
            await ConsTranSvc.GetObj();
            TRANSACTIONS = await ConsTranSvc.GetObjList();

        }

        protected override async Task OnParametersSetAsync()
        {
            obj = await ConsumablesService.GetSingleObj(Id);
            REMARKS = await ConsRemarksSvc.GetObjList(obj.AssetCode);


            TopTransEmployee = await ConsTranSvc.GetTopIssuedEmployees(obj.Id);

            uomHolder = obj.UOMId ?? 0;

            try
            {
                await DisplayConsImgFunc(obj.AssetCode);//image
            }
            catch (Exception)
            {
                ConsumableImageData = string.Format("images/asset-holder.jpg");
            }
        }

        public async Task RefreshTransaction()
        {
            obj = await ConsumablesService.GetSingleObj(Id);
            TRANSACTIONS = await ConsTranSvc.GetObjList();
        }

        private async Task SaveUpdate()
        {
            obj.UOMId = uomHolder;
            await ConsumablesService.UpdateObj(obj);
            await SaveRemarksTODB(obj.AssetCode);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);
            _toastService.ShowSuccess(obj.AssetCode + " Updated Successfully!");

            // Update the List using the StateService
            obj = await ConsumablesService.GetSingleObj(Id);
            REMARKS = await ConsRemarksSvc.GetObjList(obj.AssetCode);

            detailsPanelOpen = false;
        }

        #region FUNCTIONS

        private bool detailsPanelOpen, newTransactionOpen;
        private Anchor anchor;

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            detailsPanelOpen = (drawerx == "detailsPanelOpen");
            newTransactionOpen = (drawerx == "newTransactionOpen");
            this.anchor = anchor;
        }

        private async Task DisplayConsImgFunc(string jmcode)
        {
            var imagemodel = await ConsImgService.GetImageData(jmcode);
            if (imagemodel != null)
            {
                var base642 = Convert.ToBase64String(imagemodel);
                ConsumableImageData = string.Format("data:image/png;base64,{0}", base642);
            }
        }

        private async Task ShowTransactionDialog(int id)
        {
            await Task.Delay(0);
            var parameters = new DialogParameters<ViewTXNDialog>
            {
                { x => x.Id, id }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, NoHeader = true };
            DialogService.Show<ViewTXNDialog>("", parameters, options);
        }

        private void OpenAddTransDialog()
        {
            var parameters = new DialogParameters<AddConsTransactionDialog>
            {
                { x => x.ConsumableId, obj.Id },
                { x => x.OnAddSuccess, EventCallback.Factory.Create(this, RefreshTransaction) }
            };

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, NoHeader = true, DisableBackdropClick = true };
            DialogService.Show<AddConsTransactionDialog>("", parameters, options);
        }
        #endregion FUNCTIONS

        #region REMARKS
        private string newRemark = "";

        public async Task SaveRemarksTODB(string posCode)
        {
            var listApi = await ConsRemarksSvc.GetObjList(posCode);
            List<string> arrApi = new();

            var validRemark = REMARKS
               .Where(obj => !string.IsNullOrEmpty(obj.ConsumableCode))
               .ToList();

            var listOfValidRemarks = validRemark.OrderByDescending(obj => obj.VerifyId).ToList();

            if (listOfValidRemarks.Count == 0)
            {
                foreach (var item in listApi)
                {
                    await ConsRemarksSvc.DeleteAllObj(item.VerifyId);
                }
                return;
            }

            foreach (var pays in listApi)
            {
                var P = listOfValidRemarks.Where(p => p.VerifyId == pays.VerifyId).Count();

                if (P == 0)
                {
                    await ConsRemarksSvc.DeleteAllObj(pays.VerifyId);
                }
            }

            foreach (var item in listOfValidRemarks)
            {
                item.ConsumableCode = posCode;

                int isExistTech = await ConsRemarksSvc.GetExistObj(item.VerifyId);
                if (isExistTech == 0)
                {
                    await ConsRemarksSvc.CreateObj(item);
                }
                else
                {
                    await ConsRemarksSvc.UpdateObj(item);
                }
            }

            REMARKS.Clear();
        }

        public void AddNewRemark(string code, string newSkill)
        {
            var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            if (!string.IsNullOrEmpty(newRemark))
                REMARKS.Add(new ConsumableRemarksT { ConsumableCode = code, Remark = newSkill, VerifyId = verifyCode });
            newRemark = "";
        }

        public async Task CloseRemark(MudChip chip)
        {
            var confirmResult = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmation",
                Text = "Are you sure you remove this? You can't undo your action.",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No"
            });

            if (confirmResult.IsConfirmed)
            {

                var skillToRemove = REMARKS.FirstOrDefault(item => item.Remark == chip.Text);

                if (skillToRemove != null)
                {
                    REMARKS.Remove(skillToRemove);
                }
            }
        }
        #endregion

        #region MUD TABS / TAB PANEL

        private MudTabs Tabs;
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
                    builder.AddContent(6, "Consumable");
                    builder.CloseComponent();
                }
                else if (tabId == 1)
                {
                    builder.OpenComponent<MudIconButton>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(1));
                    builder.AddAttribute(2, "Icon", @Icons.Material.Outlined.Book);
                    builder.AddAttribute(3, "Size", Size.Small);
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(1));
                    builder.AddContent(6, "Transactions");
                    builder.CloseComponent();
                }
                else if (tabId == 2)
                {
                    builder.OpenComponent<MudIconButton>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(2));
                    builder.AddAttribute(2, "Icon", @Icons.Material.Rounded.StackedLineChart);
                    builder.AddAttribute(3, "Size", Size.Small);
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(2));
                    builder.AddContent(6, "Reports");
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


        #region FILTERS
        public string CmbStatusText = "All Types";

        public async Task SearchStatus(string type)
        {
            await Task.Delay(0);
            if (type.Equals("all"))
            {
                CmbStatusText = "All Status";

                TRANSACTIONS = ConsTranSvc.Cons_TransactionTs;
            }
            else
            {
                CmbStatusText = type;

                TRANSACTIONS = ConsTranSvc.Cons_TransactionTs.Where(e => e.Transact_Type.Equals(CmbStatusText)).ToList();
            }
        }
        #endregion
    }
}
