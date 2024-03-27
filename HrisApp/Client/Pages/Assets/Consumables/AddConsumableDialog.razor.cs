namespace HrisApp.Client.Pages.Assets.Consumables
{
    public partial class AddConsumableDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }

        private ConsumablesT obj = new();
        private List<AssetTypesT> TYPES = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();
        private List<AreaT> AREA = new();
        private List<UOMT> UOM = new();
        public IMask currMask = new RegexMask(@"^\$?[0-9,\.]*$");

        private int uomHolder = 1;

        protected override async Task OnInitializedAsync()
        {
            TYPES = await AssetTypeService.GetObjList();
            CAT = await AssetCatService.GetObjList();
            SUBCAT = await AssetSubCatService.GetObjList();
            AREA = await AreaService.GetAreaList();
            UOM = await UOMService.GetObjList();
            await StaticService.GetAssetStatus();
            imgBase64 = "./images/addIconImage.png";
        }

        private async Task ConfirmCreate()
        {
            obj.CreatedById = Int32.Parse(GlobalConfigService.User_Id);
            obj.UOMId = uomHolder;
            await ConsumablesService.CreateObj(obj);
            await SaveAlLRemarks(obj.AssetCode);
            await OnsavingImg(obj.CategoryId, obj.SubCategoryId, obj.JMCode, "First image uploaded.");

            MudDialog?.Close();
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
            _toastService.ShowSuccess("Created Successfully!");
            StateService.SetState("ConsumableList", await ConsumablesService.GetObjList());
        }

        #region FUNCTIONS

        private async Task PriceTotal(string text)
        {
            await Task.Delay(0);
            if (!string.IsNullOrEmpty(text))
            {
                obj.PricePerUOM = Convert.ToDecimal(text);
                obj.TotalPurchaseAmount = obj.Quantity * (decimal)obj.PricePerUOM;
            }
            else
            {
                obj.TotalPurchaseAmount = 0;
            }
        }

        private async Task QuantityTotal(string text)
        {
            await Task.Delay(0);
            if (!string.IsNullOrEmpty(text))
            {
                obj.Quantity = Convert.ToInt32(text);
                if (obj.PricePerUOM != null)
                {
                    obj.TotalPurchaseAmount = obj.Quantity * (decimal)obj.PricePerUOM;
                }
            }
            else
            {
                obj.TotalPurchaseAmount = 0;
            }
        }

        private bool disabledsubcat = true;
        private bool disabledcat = true;

        private void OnChangeType(int id)
        {
            obj.TypeId = id;
            disabledcat = false;
        }

        private void OnChangeCat(int id)
        {
            obj.CategoryId = id;
            disabledsubcat = false;
        }

        private async Task OnChangeSCat(int id)
        {
            obj.SubCategoryId = id;
            await OnGenerateCode();
        }

        private async Task OnGenerateCode()
        {
            int lastCount = await ConsumablesService.GetLastCode(obj.TypeId, obj.CategoryId, obj.SubCategoryId) + 1;

            var catcode = CAT.Where(e => e.Id == obj.CategoryId).FirstOrDefault()!.ACat_Code;
            var subcode = SUBCAT.Where(e => e.Id == obj.SubCategoryId).FirstOrDefault()!.ASubCat_Code;
            string count = lastCount.ToString().PadLeft(4, '0');
            obj.JMCode = $"CSM-{catcode}-{subcode}-{count}";
            obj.AssetCode = $"CSM-{catcode}-{subcode}-{count}";
        }

        private void Cancel() => MudDialog?.Cancel();

        #endregion FUNCTIONS

        #region IMAGE VARIABLES AND FUNCTION

        //image
        public string imgBase64 { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
        public string ImgFileName { get; set; } = string.Empty;
        public string ImgContentType { get; set; } = string.Empty;

        private MultipartFormDataContent ConsumableImage = new();
        private IList<IBrowserFile> Imagesfile = new List<IBrowserFile>();

        public async Task uploadImage(InputFileChangeEventArgs e)
        {
            long lngImage = long.MaxValue;
            var brwModel = e.File;
            var imgFilename = e.File.Name;
            var imgContent = e.File.ContentType;
            var imgBuffer = new byte[e.File.Size];
            var imgURL = $"data:{imgContent};base64,{Convert.ToBase64String(imgBuffer)}";

            using (var _stream = brwModel.OpenReadStream(lngImage))
            {
                await _stream.ReadAsync(imgBuffer);
            }

            if (e.File.Name is null)
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Error",
                    Text = "No image uploaded!",
                    Icon = SweetAlertIcon.Error
                });
                return;
            }
            else
            {
                using var content = new MultipartFormDataContent();
                var fileContent = new StreamContent(brwModel.OpenReadStream(lngImage));
                fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(imgContent);

                ImageUrl = imgURL;
                ImgContentType = imgContent;
                ImgFileName = imgFilename;
                ConsumableImage.Add(content: fileContent, name: imgFilename, fileName: imgFilename);

                var base642 = Convert.ToBase64String(imgBuffer);
                imgBase64 = string.Format("data:image/*;base64,{0}", base642);
            }
        }

        public async Task OnsavingImg(int cat, int subcat, string jmcode, string remarks)
        {
            using var _contentImg = new MultipartFormDataContent();

            if (ConsumableImage.Any())
            {
                _contentImg.Add(ConsumableImage.LastOrDefault()!);
                await ConsImgService.AttachFile(_contentImg, cat, subcat, jmcode, remarks);
            }
            else
            {
            }
        }

        #endregion IMAGE VARIABLES AND FUNCTION

        #region REMARKS

        private string newRemark = "";
        public List<ConsumableRemarksT> listOfNewRemarks = new();

        public void AddNewRemark(string code, string remark)
        {
            var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            if (!string.IsNullOrEmpty(newRemark))
                listOfNewRemarks.Add(new ConsumableRemarksT { ConsumableCode = code, Remark = remark, VerifyId = verifyCode });
            newRemark = "";
        }

        public void CloseRemark(MudChip chip)
        {
            var remarkToRemove = listOfNewRemarks.FirstOrDefault(item => item.Remark == chip.Text);

            if (remarkToRemove != null)
            {
                listOfNewRemarks.Remove(remarkToRemove);
            }
        }

        public async Task SaveAlLRemarks(string code)
        {
            var validtechSkill = listOfNewRemarks
               .Where(obj => !string.IsNullOrEmpty(obj.Remark)).ToList();

            if (validtechSkill.Count == 0)
            {
                return;
            }

            foreach (var item in validtechSkill)
            {
                item.ConsumableCode = code;

                int isExistTech = await MainRemarksService.GetExistObj(item.VerifyId);
                if (isExistTech == 0)
                {
                    await ConsRemarksSvc.CreateObj(item);
                }
                else
                {
                    await ConsRemarksSvc.UpdateObj(item);
                }
            }

            listOfNewRemarks.Clear();
        }

        #endregion REMARKS
    }
}