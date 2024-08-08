namespace HrisApp.Client.Pages.Assets.Licenses
{
    public partial class AddAssetLicenseDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }

        private AssetLicenseT obj = new();
        private List<AssetTypesT> TYPES = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();
        private List<AssetSubCategory2T> SUBCAT2 = new();
        private bool isSavingAdd = false;

        public string imgBase64 { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string ImgFileName { get; set; } = string.Empty;
        public string ImgContentType { get; set; } = string.Empty;

        private MultipartFormDataContent AssetImage = new();
        public string imguploadclass = "btnimage";

        public IMask currMask = new RegexMask(@"^\$?[0-9,\.]*$");

        private void Cancel() => MudDialog?.Cancel();

        protected override async Task OnInitializedAsync()
        {
            TYPES = await AssetTypeService.GetObjList();
            CAT = await AssetCatService.GetObjList();
            SUBCAT = await AssetSubCatService.GetObjList();
            SUBCAT2 = await AssetSubCatService2.GetObjList();
            await StaticService.GetAssetStatus();
            obj.AssetStatusId = 2;
            imgBase64 = "./images/addIconImage.png";
        }

        private async Task ConfirmCreate()
        {
            isSavingAdd = true;

            obj.LastCheckDate = null;
            obj.CreatedById = Int32.Parse(GlobalConfigService.User_Id);
            await AssLicenseSvc.CreateObj(obj);
            await OnsavingImg(obj.CategoryId, obj.SubCategoryId, obj.JMCode, "First image uploaded.");
            await SaveAlLRemarks(obj.AssetCode);

            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);
            MudDialog?.Close();


            // Update the List using the StateService
            StateService.SetState("AssetLicenseList", await AssLicenseSvc.GetObjList());
            _toastService.ShowSuccess("Created Successfully!");

            isSavingAdd = false;
        }

        #region REMARKS
        private string newRemark = "";
        public List<AssetLicenseRemarksT> listOfNewRemarks = new();

        public void AddNewRemark(string code, string remark)
        {
            var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            if (!string.IsNullOrEmpty(newRemark))
                listOfNewRemarks.Add(new AssetLicenseRemarksT { LicenseAssetCode = code, Remark = remark, VerifyId = verifyCode });
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
                item.LicenseAssetCode = code;

                int isExistTech = await LicenseRemarksSvc.GetExistObj(item.VerifyId);
                if (isExistTech == 0)
                {
                    await LicenseRemarksSvc.CreateObj(item);
                }
                else
                {
                    await LicenseRemarksSvc.UpdateObj(item);
                }
            }

            listOfNewRemarks.Clear();
        }
        #endregion

        #region FUNCTIONS
        public async Task UploadImage(InputFileChangeEventArgs e)
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
                AssetImage.Add(content: fileContent, name: imgFilename, fileName: imgFilename);

                var base642 = Convert.ToBase64String(imgBuffer);
                imgBase64 = string.Format("data:image/*;base64,{0}", base642);
            }
        }

        public async Task OnsavingImg(int cat, int subcat, string jmcode, string remarks)
        {
            using var _contentImg = new MultipartFormDataContent();

            if (AssetImage.Any())
            {
                _contentImg.Add(AssetImage.LastOrDefault()!);
                await AssLicenseImgSvc.AttachFile(_contentImg, cat, subcat, jmcode, remarks);
            }
            else
            {
            }
        }

        private async Task OnGenerateCode()
        {
            int lastCount = await AssLicenseSvc.GetLastCode(obj.CategoryId, obj.SubCategoryId) + 1;

            var catcode = CAT.Where(e => e.Id == obj.CategoryId).FirstOrDefault()!.ACat_Code;
            var subcode = SUBCAT.Where(e => e.Id == obj.SubCategoryId).FirstOrDefault()!.ASubCat_Code;
            string rolesCode = lastCount.ToString().PadLeft(4, '0');
            obj.JMCode = $"{catcode}-{subcode}-{rolesCode}";
            obj.AssetCode = $"{catcode}-{subcode}-{rolesCode}";
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

        #endregion
    }
}
