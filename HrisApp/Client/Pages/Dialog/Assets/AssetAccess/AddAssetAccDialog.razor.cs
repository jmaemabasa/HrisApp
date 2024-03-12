namespace HrisApp.Client.Pages.Dialog.Assets.AssetAccess
{
    public partial class AddAssetAccDialog : ComponentBase
    {
        [CascadingParameter] private MudDialogInstance? MudDialog { get; set; }

        private AssetAccessoryT obj = new();
        private List<AssetTypesT> TYPES = new();
        private List<AssetCategoryT> CAT = new();
        private List<AssetSubCategoryT> SUBCAT = new();

        public string imgBase64 { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string ImgFileName { get; set; } = string.Empty;
        public string ImgContentType { get; set; } = string.Empty;

        private MultipartFormDataContent MainAssImage = new();
        public string imguploadclass = "btnimage";

        private void Cancel() => MudDialog?.Cancel();

        protected override async Task OnInitializedAsync()
        {
            TYPES = await AssetTypeService.GetObjList();
            CAT = await AssetCatService.GetObjList();
            SUBCAT = await AssetSubCatService.GetObjList();
            await StaticService.GetAssetStatus();
            obj.AssetStatusId = 2;
            imgBase64 = "./images/addIconImage.png";
        }

        private async Task ConfirmCreate()
        {
            await AssetAccService.CreateObj(obj);
            await OnsavingImg(obj.CategoryId, obj.SubCategoryId, obj.JMCode, "First image uploaded.");

            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

            MudDialog?.Close();
            _toastService.ShowSuccess(obj.MainAsset + " Created Successfully!");

            // Update the List using the StateService
            StateService.SetState("AssetAccList", await AssetAccService.GetObjList());
        }

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
                MainAssImage.Add(content: fileContent, name: imgFilename, fileName: imgFilename);

                var base642 = Convert.ToBase64String(imgBuffer);
                imgBase64 = string.Format("data:image/*;base64,{0}", base642);
            }
        }

        public async Task OnsavingImg(int cat, int subcat, string jmcode, string remarks)
        {
            using var _contentImg = new MultipartFormDataContent();

            if (MainAssImage.Any())
            {
                _contentImg.Add(MainAssImage.LastOrDefault()!);
                await AssAccImgSvc.AttachFile(_contentImg, cat, subcat, jmcode, remarks);
            }
            else
            {
            }
        }

        private async Task OnGenerateCode()
        {
            int lastCount = await AssetAccService.GetLastCode(obj.CategoryId, obj.SubCategoryId) + 1;

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
    }
}