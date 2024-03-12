using QRCoder;
using System.Security.Policy;

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
        private List<AreaT> AREA = new();

        private QRCodeGenerator qrGenerator = new();

        //image
        public string imgBase64 { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
        public string ImgFileName { get; set; } = string.Empty;
        public string ImgContentType { get; set; } = string.Empty;

        private MultipartFormDataContent MainAssImage = new();
        private IList<IBrowserFile> Imagesfile = new List<IBrowserFile>();

        public PatternMask MacAddMask = new("##:##:##:##:##:##")
        {
            MaskChars = new[] { new MaskChar('#', @"[0-9a-fA-F]") },
            CleanDelimiters = false,
            Transformation = AllUpperCase
        };

        public IMask ipv4Mask = RegexMask.IPv4();
        public IMask currMask = new RegexMask(@"^\$?[0-9,\.]*$");

        protected override async Task OnInitializedAsync()
        {
            TYPES = await AssetTypeService.GetObjList();
            CAT = await AssetCatService.GetObjList();
            SUBCAT = await AssetSubCatService.GetObjList();
            AREA = await AreaService.GetAreaList();
            await StaticService.GetAssetStatus();
            ASSSTATUS = StaticService.AssetStatusTs;
            obj.AssetStatusId = 2;
            obj.StorageType = "SSD";
            imgBase64 = "./images/addIconImage.png";
        }

        private async Task ConfirmCreate()
        {
            try
            {
                await AssetMasterService.CreateObj(obj);
                await OnsavingImg(obj.CategoryId, obj.SubCategoryId, obj.JMCode, "First image uploaded.");

                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                MudDialog?.Close();
                _toastService.ShowSuccess(obj.WorksationName + " Created Successfully!");

                // Update the List using the StateService
                StateService.SetState("AssetMasterList", await AssetMasterService.GetObjList());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine(ex.Message);
            }
        }

        private static char AllUpperCase(char c) => c.ToString().ToUpperInvariant()[0];

        private void Cancel() => MudDialog?.Cancel();

        private async Task OnGenerateCode()
        {
            int lastCount = await AssetMasterService.GetLastCode(obj.TypeId, obj.CategoryId, obj.SubCategoryId) + 1;

            var typecode = TYPES.Where(e => e.Id == obj.TypeId).FirstOrDefault()!.AType_Code;
            var catcode = CAT.Where(e => e.Id == obj.CategoryId).FirstOrDefault()!.ACat_Code;
            var subcode = SUBCAT.Where(e => e.Id == obj.SubCategoryId).FirstOrDefault()!.ASubCat_Code;
            string rolesCode = lastCount.ToString().PadLeft(4, '0');
            obj.JMCode = $"{typecode}-{catcode}-{subcode}-{rolesCode}";
            obj.AssetCode = $"{typecode}-{catcode}-{subcode}-{rolesCode}";

            await GenerateQR();
        }

        public string QRIMAGE { get; set; } = string.Empty;

        private async Task GenerateQR()
        {
            await Task.Delay(0);
            QRCodeGenerator qrGenerator = new QRCodeGenerator();

            Url generator = new Url("https://localhost:44397/main-asset/details/4");
            string payload = generator.ToString();

            QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);

            var qrCode = new PngByteQRCode(qrCodeData);

            byte[] imageByteArray = qrCode.GetGraphic(20);

            var base642 = Convert.ToBase64String(imageByteArray);
            QRIMAGE = string.Format("data:image/*;base64,{0}", base642);
        }

        #region TABS

        public MudTabs? tabs;
        public int activeIndex;

        public void Activate(int index)
        {
            tabs?.ActivatePanel(index);
        }

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
                    builder.AddContent(6, "Main Asset");
                    builder.CloseComponent();
                }
                else if (tabId == 1)
                {
                    builder.OpenComponent<MudChip>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(1));
                    builder.AddAttribute(3, "Text", $"{tabId + 1}");
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(1));
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

        public string imguploadclass = "btnimage";

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
                await AssetImageService.AttachFile(_contentImg, cat, subcat, jmcode, remarks);
            }
            else
            {
            }
        }
    }
}