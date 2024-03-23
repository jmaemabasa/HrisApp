using QRCoder;

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
        private List<EmployeeT> EMPLOYEE = new();

        private List<AssetAccessImageT> assetImgList = new();
        private List<AccessoryRemarksT> REMARKS = new();

        private string MainAssetImage { get; set; } = string.Format("images/asset-holder.jpg");

        private readonly string infoFormat = "{first_item}-{last_item} of {all_items}";
        public IMask currMask = new RegexMask(@"^\$?[0-9,\.]*$");

        private string AccessImageData { get; set; } = string.Format("images/asset-holder.jpg");
        public string QRIMAGE { get; set; } = string.Empty;
        private bool isLoadingPrintQR = false;

        protected override async Task OnInitializedAsync()
        {
            TYPES = await AssetTypeService.GetObjList();
            CAT = await AssetCatService.GetObjList();
            SUBCAT = await AssetSubCatService.GetObjList();
            ACCHISTORY = await AssetAccHistorySvc.GetObjList();
            await StaticService.GetAssetStatus();
            STATUS = StaticService.AssetStatusTs;
            EMPLOYEE = await EmployeeService.GetEmployeeList();
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                obj = await AssetAccService.GetSingleObj(Id);
                REMARKS = await AccRemarksService.GetObjList(obj.AssetCode);

                try
                {
                    await LoadAccessImg(obj.JMCode);//image
                }
                catch (Exception)
                {
                    AccessImageData = string.Format("images/asset-holder.jpg");
                }

                await GenerateQR(obj.Id);

                await AssAccImgSvc.GetAllImagesPerAss(obj.JMCode);
                assetImgList = AssAccImgSvc.AssetAccessImageTs;

                if (obj.MainAssetId != null)
                {
                    await LoadMainAssetImg(obj.MainAsset!.JMCode);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("aaaa " + ex);
                Console.WriteLine("aaaa " + ex.Message);
                AccessImageData = string.Format("images/asset-holder.jpg");
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
            await SaveRemarksTODB(obj.AssetCode);

            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

            _toastService.ShowSuccess("Updated Successfully!");
            await ReloadObjects();
        }

        #region REMARKS

        private string newRemark = "";

        public async Task SaveRemarksTODB(string posCode)
        {
            var listApi = await AccRemarksService.GetObjList(posCode);
            List<string> arrApi = new();

            var validRemark = REMARKS
               .Where(obj => !string.IsNullOrEmpty(obj.AccAssetCode))
               .ToList();

            var listOfValidRemarks = validRemark.OrderByDescending(obj => obj.VerifyId).ToList();

            if (listOfValidRemarks.Count == 0)
            {
                foreach (var item in listApi)
                {
                    await AccRemarksService.DeleteAllObj(item.VerifyId);
                }
                return;
            }

            foreach (var pays in listApi)
            {
                var P = listOfValidRemarks.Where(p => p.VerifyId == pays.VerifyId).Count();

                if (P == 0)
                {
                    await AccRemarksService.DeleteAllObj(pays.VerifyId);
                }
            }

            foreach (var item in listOfValidRemarks)
            {
                item.AccAssetCode = posCode;

                int isExistTech = await AccRemarksService.GetExistObj(item.VerifyId);
                if (isExistTech == 0)
                {
                    await AccRemarksService.CreateObj(item);
                }
                else
                {
                    await AccRemarksService.UpdateObj(item);
                }
            }

            REMARKS.Clear();
        }

        public void AddNewRemark(string code, string newSkill)
        {
            var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            if (!string.IsNullOrEmpty(newRemark))
                REMARKS.Add(new AccessoryRemarksT { AccAssetCode = code, Remark = newSkill, VerifyId = verifyCode });
            newRemark = "";
            //Console.WriteLine(verifyCode);
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

        #endregion REMARKS

        #region PANEL IMAGE LIST / TABLE

        private async void RefreshPdfFileList()
        {
            try
            {
                await AssAccImgSvc.GetAllImagesPerAss(obj.JMCode);
                assetImgList = AssAccImgSvc.AssetAccessImageTs;

                await LoadAccessImg(obj.JMCode);//image
                StateHasChanged();
            }
            catch (Exception)
            {
                AccessImageData = string.Format("images/asset-holder.jpg");
            }
        }

        private async Task DeleteAssetImg(string filename, string assetcode)
        {
            var confirmResult = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmation",
                Text = "Pernamently delete the image? \n You can't undo this.",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No"
            });

            if (confirmResult.IsConfirmed)
            {
                await AssAccImgSvc.DeleteAssetImg(filename, assetcode);
                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);

                await AssAccImgSvc.GetAllImagesPerAss(obj.JMCode);
                assetImgList = AssAccImgSvc.AssetAccessImageTs;

                StateHasChanged();
            }
        }

        #endregion PANEL IMAGE LIST / TABLE

        #region FUNCTIONS

        private async Task LoadMainAssetImg(string jmcode)
        {
            var imagemodel = await AssetImageService.GetImageData(jmcode);
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
            REMARKS = await AccRemarksService.GetObjList(obj.AssetCode);
            obj = await AssetAccService.GetSingleObj((int)Id);
            leftPanelOpen = false; detailsPanelOpen = false; lastCheckOpen = false;
        }

        private async Task LoadAccessImg(string jmcode)
        {
            var imagemodel = await AssAccImgSvc.GetImageData(jmcode);
            if (imagemodel != null)
            {
                var base642 = Convert.ToBase64String(imagemodel);
                AccessImageData = string.Format("data:image/png;base64,{0}", base642);
            }
        }

        private async Task GenerateQR(int id)
        {
            await Task.Delay(0);
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            QRCodeData qrCodeData = qrGenerator.CreateQrCode($"http://sonicsales.net:1113/asset-accessories/details/{id}", QRCodeGenerator.ECCLevel.H);

            var qrCode = new PngByteQRCode(qrCodeData);

            byte[] imageByteArray = qrCode.GetGraphic(20);

            var base642 = Convert.ToBase64String(imageByteArray);
            QRIMAGE = string.Format("data:image/*;base64,{0}", base642);
        }

        private async Task PrintQR()
        {
            try
            {
                isLoadingPrintQR = true;
                string url = await AssetAccService.QRGenerate(obj.AssetCode);
                //await jsRuntime.InvokeAsync<object>("open", url, "_blank");
                GlobalConfigService.OpenPDFInNewTab(url);
                isLoadingPrintQR = false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isLoadingPrintQR = false;
            }
        }

        private Anchor anchor;
        private bool leftPanelOpen, detailsPanelOpen, lastCheckOpen;

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            this.anchor = anchor;
            leftPanelOpen = (drawerx == "leftPanelOpen");
            detailsPanelOpen = (drawerx == "detailsPanelOpen");
            lastCheckOpen = (drawerx == "lastCheckOpen");

            if (drawerx == "lastCheckOpen")
            {
                obj.LastCheckDate = DateTime.Now;
            }
        }

        #endregion FUNCTIONS

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
                    builder.AddAttribute(1, "Class", @GetTabChipClass(1));
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
                    builder.AddAttribute(2, "Icon", @Icons.Material.Outlined.Image);
                    builder.AddAttribute(3, "Size", Size.Small);
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(2));
                    builder.AddContent(6, "Gallery");
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