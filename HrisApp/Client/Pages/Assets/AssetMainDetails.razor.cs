using HrisApp.Client.Pages.Dialog.Assets.AssetAccess;
using HrisApp.Client.Pages.Dialog.Assets.MainAsset;
using static MudBlazor.CategoryTypes;

namespace HrisApp.Client.Pages.Assets
{
    public partial class AssetMainDetails : Microsoft.AspNetCore.Components.ComponentBase
    {
        [Parameter] public int Id { get; set; }

        private AssetMasterT obj = new();
        private List<AssetAccessoryT> ACCESSORIES = new();
        private List<AssetTypesT> TYPES = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();
        private List<DivisionT> DIVISION = new();
        private List<DepartmentT> DEPARTMENT = new();
        private List<EmployeeT> EMPLOYEE = new();
        private List<AssetStatusT> STATUS = new();

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
        }

        protected override async Task OnParametersSetAsync()
        {
            obj = await AssetMasterService.GetSingleObj((int)Id);
        }

        private async Task SaveUpdate()
        {
            await AssetMasterService.UpdateObj(obj);
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

            _toastService.ShowSuccess(obj.Asset + " Updated Successfully!");

            // Update the List using the StateService
            obj = await AssetMasterService.GetSingleObj(Id);
            leftPanelOpen = false; detailsPanelOpen = false; assignPanelOpen = false;
        }

        private async Task SaveAssignEmp()
        {
            obj.EmployeeId = empid;
            obj.AssetStatusId = 1;
            obj.AssignedDate = DateTime.Now;
            obj.InUseStatusDate = DateTime.Now;
            await AssetMasterService.UpdateObj(obj);

            foreach (var item in ACCESSORIES.Where(e => e.MainAssetId == obj.Id))
            {
                var model = await AssetAccService.GetSingleObj(item.Id);
                model.AssetStatusId = 1;
                model.InUseStatusDate = DateTime.Now;
                await AssetAccService.UpdateObj(model);
            }

            obj = await AssetMasterService.GetSingleObj(Id);
            leftPanelOpen = false; detailsPanelOpen = false; assignPanelOpen = false;
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
            this.anchor = anchor;
        }

        private int divid, deptid, empid;
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
    }
}