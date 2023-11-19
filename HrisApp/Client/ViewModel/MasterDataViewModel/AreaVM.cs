namespace HrisApp.Client.ViewModel.MasterDataViewModel
{
    public class AreaVM : BaseViewModel
    {
        IAreaService _areaService = new AreaService();
        IAuditlogService _auditlogService = new AuditlogService();

        private AreaT area = new();

        int _paramID;
        public int ParameterID { get => _paramID; set => SetValue(ref _paramID, value); }


        private readonly GlobalConfigService GlobalConfigService;
        public AreaVM(GlobalConfigService globalConfigService)
        {
            GlobalConfigService = globalConfigService;
        }

        public MudMessageBox Message_Box { get; set; }

        public async Task OnRefreshPage()
        {
            ParameterID = 0;
            OnChange += OnStateChanged;
            await LoadAreaList();
        }

        #region TABLES DATA
        //TABLEEES
        public string infoFormat = "{first_item}-{last_item} of {all_items}";
        public string searchString1 = "";
        public List<AreaT> areaList = new();
        public AreaT selectedItem1 = null;
        public HashSet<AreaT> selectedItems = new();

        public bool FilterFunc1(AreaT area) => FilterFunc(area, searchString1);

        private bool FilterFunc(AreaT area, string searchString)
        {
            if (string.IsNullOrWhiteSpace(searchString))
                return true;
            if (area.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                return true;
            return false;
        }
        //END FOR TABLES

        //OPEN DIALOGS
        public async Task OpenUpdateArea(int id)
        {

            ParameterID = id;
            await Message_Box.Show();
            area = await _areaService.GetSingleArea(id);
            OnChange += OnStateChanged;
            newArea = area.Name;
        }

        public async Task OpenAddArea()
        {
            newArea = string.Empty;
            await Message_Box.Show();
        }
        #endregion

        public async Task LoadAreaList()
        {
            await _areaService.GetArea();
            SetState("AreaList", _areaService.AreaTs);
        }

        public void OnStateChanged()
        {
            // Handle state changes, e.g., update the areaList
            areaList = GetState<List<AreaT>>("AreaList");
            //StateHasChanged();
        }

        public string newArea = "";
        public async Task<string> ConfirmCreateArea()
        {

            if (string.IsNullOrWhiteSpace(newArea))
            {
                return $"{TokenConst.AlertError}xxxFill out name.";
            }


            if (ParameterID == 0)
            {
                await _areaService.CreateArea(newArea);

                await _auditlogService.CreateLog(Convert.ToInt32(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                //_toastService.ShowSuccess(newArea + " Created Successfully!");

                // Update the areaList using the StateService
                await _areaService.GetAreaList();
                var newAreaList = _areaService.AreaTs;
                SetState("AreaList", newAreaList);
                return $"{TokenConst.AlertSuccess}xxxSuccessfully Created.";
            }
            else
            {
                area.Name = newArea;
                await _areaService.UpdateArea(area);
                await _auditlogService.CreateLog(Convert.ToInt32(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

                //_toastService.ShowSuccess(area.Name + " Updated Successfully!");

                // Update the areaList using the StateService
                await _areaService.GetAreaList();
                var newAreaList = _areaService.AreaTs;
                SetState("AreaList", newAreaList);
                return $"{TokenConst.AlertSuccess}xxxSuccessfully Updated.";
            }
        }

        public bool isVisible;
        public async void OpenOverlay()
        {
            isVisible = true;
            await Task.Delay(3000);
            isVisible = false;
            //StateHasChanged();
        }

    }
}
