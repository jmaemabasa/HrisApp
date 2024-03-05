using HrisApp.Client.Pages.Dialog.Assets.AssetAccess;
using HrisApp.Client.Pages.Dialog.Assets.MainAsset;
using HrisApp.Client.Pages.Employee;

namespace HrisApp.Client.Pages.Assets
{
    public partial class AssetMainDetails : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Parameter] public int Id { get; set; }

        private AssetMasterT obj = new();
        private AssetMasterHistoryT assetHistoryObj = new();
        private AssetLastCheckT lastchkObj = new();
        private List<AssetAccessoryT> ACCESSORIES = new();
        private List<AssetTypesT> TYPES = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();
        private List<DivisionT> DIVISION = new();
        private List<DepartmentT> DEPARTMENT = new();
        private List<EmployeeT> EMPLOYEE = new();
        private List<AssetStatusT> STATUS = new();
        private List<AreaT> AREA = new();
        private List<AssetMasterHistoryT> MAINHISTORY = new();
        private List<AssetLastCheckT> LASTCHK = new();

        private List<AssetImageT> assetImgList = new();

        private string infoFormat = "{first_item}-{last_item} of {all_items}";

        private string ImageData { get; set; } = string.Empty;
        private string ImageEmployee { get; set; } = string.Empty;

        //image
        public string imgBase64 { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
        public string ImgFileName { get; set; } = string.Empty;
        public string ImgContentType { get; set; } = string.Empty;

        private MultipartFormDataContent EmpImage = new();
        private IList<IBrowserFile> Imagesfile = new List<IBrowserFile>();

        public PatternMask MacAddMask = new("##:##:##:##:##:##")
        {
            MaskChars = new[] { new MaskChar('#', @"[0-9a-fA-F]") },
            CleanDelimiters = false,
            Transformation = AllUpperCase
        };

        public IMask ipv4Mask = RegexMask.IPv4();
        public IMask currMask = new RegexMask(@"^\$?[0-9,\.]*$");

        private static char AllUpperCase(char c) => c.ToString().ToUpperInvariant()[0];

        private bool leftPanelOpen;
        private bool detailsPanelOpen;
        private bool assignPanelOpen;
        private bool assignReturnPanelOpen;
        private bool mtsChkPanelOpen;
        private Anchor anchor;

        protected override async Task OnInitializedAsync()
        {
            TYPES = await AssetTypeService.GetObjList();
            CAT = await AssetCatService.GetObjList();
            SUBCAT = await AssetSubCatService.GetObjList();
            ACCESSORIES = await AssetAccService.GetObjList();
            DIVISION = await DivisionService.GetDivisionList();
            DEPARTMENT = await DepartmentService.GetDepartmentList();
            EMPLOYEE = await EmployeeService.GetEmployeeList();
            await StaticService.GetAssetStatus();
            STATUS = StaticService.AssetStatusTs;
            AREA = await AreaService.GetAreaList();
            MAINHISTORY = await AssetMasHistorySvc.GetObjList();
            LASTCHK = await AssetLastChkSvc.GetObjList();
        }

        protected override async Task OnParametersSetAsync()
        {
            try
            {
                obj = await AssetMasterService.GetSingleObj((int)Id);

                await AssetImg(obj.Code);//image

                await AssetImageService.GetAllImagesPerAss(obj.Code);
                assetImgList = AssetImageService.AssetImageTs;

                await ImgByAssetData();

                if (obj.EmployeeId != null)
                {
                    await EmpImg(obj.Employee!.Verify_Id);//image
                    divid = obj.Employee!.DivisionId;
                    deptid = obj.Employee!.DepartmentId;
                    empid = (int)obj.EmployeeId;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
                //Console.WriteLine(ex.Message);
                ImageData = string.Format("images/asset-holder.jpg");
                ImageEmployee = string.Format("images/imgholder.jpg");
            }
        }

        private List<string> ImgByAssetList = new();

        private async Task ImgByAssetData()
        {
            foreach (var item in assetImgList)
            {
                try
                {
                    var imagemodel = await AssetImageService.GetImageDataAll(item.Img_Filename);
                    if (imagemodel != null)
                    {
                        var base642 = Convert.ToBase64String(imagemodel);
                        ImgByAssetList.Add(string.Format("data:image/png;base64,{0}", base642) + "xxJMGWAPAxx" + item.Img_Filename);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("animal");
                }
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
                await AssetImageService.DeleteAssetImg(filename, assetcode);
                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "DELETE", "Model", DateTime.Now);

                await AssetImageService.GetAllImagesPerAss(obj.Code);
                assetImgList = AssetImageService.AssetImageTs;

                ImgByAssetList.Clear();
                await ImgByAssetData();

                try
                {
                    await AssetImg(obj.Code);//image
                }
                catch (Exception)
                {
                    ImageData = string.Format("images/asset-holder.jpg");
                }

                StateHasChanged();
            }
        }

        private async void RefreshPdfFileList()
        {
            try
            {
                ImgByAssetList.Clear();
                await AssetImageService.GetAllImagesPerAss(obj.Code);
                assetImgList = AssetImageService.AssetImageTs;

                await ImgByAssetData();
                await AssetImg(obj.Code);//image
                StateHasChanged();
            }
            catch (Exception)
            {
                ImageData = string.Format("images/asset-holder.jpg");
            }
        }

        private async Task SaveUpdate()
        {
            await AssetMasterService.UpdateObj(obj);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);
            _toastService.ShowSuccess(obj.Asset + " Updated Successfully!");

            // Update the List using the StateService
            obj = await AssetMasterService.GetSingleObj(Id);
            leftPanelOpen = false; detailsPanelOpen = false; assignPanelOpen = false; assignReturnPanelOpen = false; mtsChkPanelOpen = false;
        }

        private async Task SaveAssignEmp()
        {
            try
            {
                obj.EmployeeId = empid;
                obj.AssetStatusId = 1;
                obj.AssignedDate = DateTime.Now;
                obj.InUseStatusDate = DateTime.Now;
                await AssetMasterService.UpdateObj(obj);

                assetHistoryObj.AssignedDateToReturn = obj.AssignedDateToReturn;
                assetHistoryObj.AssignedDateReleased = obj.AssignedDateReleased;
                assetHistoryObj.EmployeeId = empid;
                assetHistoryObj.MainAssetId = obj.Id;
                assetHistoryObj.MainAssetCode = obj.Code;
                await AssetMasHistorySvc.CreateObj(assetHistoryObj);

                foreach (var item in ACCESSORIES.Where(e => e.MainAssetId == obj.Id))
                {
                    var model = await AssetAccService.GetSingleObj(item.Id);
                    model.AssetStatusId = 1;
                    model.InUseStatusDate = DateTime.Now;
                    await AssetAccService.UpdateObj(model);
                }

                obj = await AssetMasterService.GetSingleObj(Id);
                await EmpImg(obj.Employee!.Verify_Id);//image
                ACCESSORIES = await AssetAccService.GetObjList();
                leftPanelOpen = false; detailsPanelOpen = false; assignPanelOpen = false; assignReturnPanelOpen = false; mtsChkPanelOpen = false;
                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);
                _toastService.ShowSuccess(obj.Employee.LastName + " Assigned Successfully!");
            }
            catch (Exception)
            {
                ImageEmployee = string.Format("images/imgholder.jpg");
            }
        }

        private async Task SaveAssignDateReturned()
        {
            await AssetMasHistorySvc.UpdateDateReturned((int)obj.EmployeeId!, obj.Id, obj.AssignedDateReleased, assetHistoryObj);

            obj.EmployeeId = null;
            obj.AssetStatusId = 2;
            obj.AssignedDate = null;
            obj.InUseStatusDate = null;
            obj.AssignedDateReleased = null;
            obj.AssignedDateToReturn = null;
            await AssetMasterService.UpdateObj(obj);

            foreach (var item in ACCESSORIES.Where(e => e.MainAssetId == obj.Id))
            {
                var model = await AssetAccService.GetSingleObj(item.Id);
                model.AssetStatusId = 2;
                model.InUseStatusDate = null;
                await AssetAccService.UpdateObj(model);
            }

            ImageEmployee = "";
            empid = divid = deptid = 0;
            obj = await AssetMasterService.GetSingleObj(Id);
            MAINHISTORY = await AssetMasHistorySvc.GetObjList();
            ACCESSORIES = await AssetAccService.GetObjList();
            leftPanelOpen = false; detailsPanelOpen = false; assignPanelOpen = false; assignReturnPanelOpen = false; mtsChkPanelOpen = false;
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);
            _toastService.ShowSuccess(obj.Asset + " Returned Successfully!");
        }

        private async Task SaveLastChkDate()
        {
            lastchkObj.MainAssetId = obj.Id;
            await AssetLastChkSvc.CreateObj(lastchkObj);
            leftPanelOpen = false; detailsPanelOpen = false; assignPanelOpen = false; assignReturnPanelOpen = false; mtsChkPanelOpen = false;
            LASTCHK = await AssetLastChkSvc.GetObjList();
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);
            _toastService.ShowSuccess("Successful!");
            StateHasChanged();
        }

        private string TruncateString(string value, int maxLength)
        {
            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
        }

        private async Task RefreshTable()
        {
            ACCESSORIES = await AssetAccService.GetObjList();
        }

        private void OpenManageAccessories()
        {
            var parameters = new DialogParameters<AddMainAssetAccessoryDialog>
            {
                { x => x.Id, obj.Id },
                { x => x.OnAddSuccess, EventCallback.Factory.Create(this, RefreshTable) }
            };
            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Small, DisableBackdropClick = true, NoHeader = true };
            DialogService.Show<AddMainAssetAccessoryDialog>("", parameters, options);
        }

        private void OpenAccessoriesDialog(int id)
        {
            var parameters = new DialogParameters<UpdateAssetAccDialog>();
            parameters.Add(x => x.Id, id);

            var options = new DialogOptions { CloseOnEscapeKey = true, FullWidth = true, MaxWidth = MaxWidth.Medium, NoHeader = true };
            DialogService.Show<UpdateAssetAccDialog>("", parameters, options);
        }

        private async Task AssetImg(string jmcode)
        {
            var imagemodel = await AssetImageService.GetImageData(jmcode);
            if (imagemodel != null)
            {
                var base642 = Convert.ToBase64String(imagemodel);
                ImageData = string.Format("data:image/png;base64,{0}", base642);
            }
        }

        private async Task EmpImg(string verid)
        {
            var imageEmp = await EmpImgService.GetImageData(verid);
            if (imageEmp != null)
            {
                var base642 = Convert.ToBase64String(imageEmp);
                ImageEmployee = string.Format("data:image/png;base64,{0}", base642);
            }
        }

        private string _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
        private bool _isShow;
        private InputType _passwordInput = InputType.Password;

        private void ButtonShowPassword()
        {
            if (_isShow)
            {
                _isShow = false;
                _passwordInputIcon = Icons.Material.Filled.VisibilityOff;
                _passwordInput = InputType.Password;
            }
            else
            {
                _isShow = true;
                _passwordInputIcon = Icons.Material.Filled.Visibility;
                _passwordInput = InputType.Text;
            }
        }

        private string PasswordHolder = "●●●●●●●●●";
        private bool _isShowPass;
        private string _passwordDisplayIcon = Icons.Material.Filled.VisibilityOff;

        private void DisplayPassword()
        {
            if (_isShowPass)
            {
                _isShowPass = false;
                _passwordDisplayIcon = Icons.Material.Filled.VisibilityOff;
                PasswordHolder = "●●●●●●●●●";
            }
            else
            {
                _isShowPass = true;
                _passwordDisplayIcon = Icons.Material.Filled.Visibility;
                PasswordHolder = obj.PasswordAdmin;
            }
        }

        private void OpenDrawer(Anchor anchor, string drawerx)
        {
            leftPanelOpen = (drawerx == "leftPanelOpen");
            detailsPanelOpen = (drawerx == "detailsPanelOpen");
            assignPanelOpen = (drawerx == "assignPanelOpen");
            assignReturnPanelOpen = (drawerx == "assignReturnPanelOpen");
            mtsChkPanelOpen = (drawerx == "mtsChkPanelOpen");
            this.anchor = anchor;

            if (assignPanelOpen) obj.AssignedDateReleased = DateTime.Now;

            if (assignReturnPanelOpen) assetHistoryObj.EndDate = DateTime.Now;
        }

        private int divid, deptid;
        private int empid;
        private bool isdisableDept = true, isdisableEmp = true;

        private void OnDivChange(int id)
        {
            divid = id;
            isdisableDept = false;
        }

        private void OnDepChange(int id)
        {
            deptid = id;
            isdisableEmp = false;
        }

        #region MUD TABS / TAB PANEL

        private MudTabs? tabs;
        private int activeIndex;

        private RenderFragment tabHeader(int tabId)
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
                    builder.AddContent(6, "Main Asset");
                    builder.CloseComponent();
                }
                else if (tabId == 1)
                {
                    builder.OpenComponent<MudIconButton>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(1));
                    builder.AddAttribute(2, "Icon", @Icons.Material.Rounded.PermDeviceInformation);
                    builder.AddAttribute(3, "Size", Size.Small);
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(1));
                    builder.AddContent(6, "Device Info");
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