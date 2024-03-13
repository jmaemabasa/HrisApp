namespace HrisApp.Client.Pages.Assets.Components
{
#nullable disable

    public partial class AccessoryMultiImage : ComponentBase
    {
        [Parameter] public int AccAssetId { get; set; }
        [Parameter] public string AccAssetCode { get; set; } = string.Empty;
        [Parameter] public string JMCode { get; set; } = string.Empty;
        [Parameter] public int Catid { get; set; }
        [Parameter] public int SubCatid { get; set; }

        [Parameter]
        public Action OnFileAdded { get; set; }

        private List<AssetAccessImageT> listOfImages = new();
        private string imgBase64 { get; set; }

        private bool visible;
        private DialogOptions dialogOptions = new() { FullWidth = true, NoHeader = true };

        private string _remarks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Delay(0);
            listOfImages.Add(new AssetAccessImageT());
        }

        private async Task Submit()
        {
            if (SelectedImages.Count <= 0 || SelectedImages == null)
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Error",
                    Text = "Select an image.",
                    Icon = SweetAlertIcon.Error
                });
                return;
            }
            else if (string.IsNullOrWhiteSpace(_remarks))
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Error",
                    Text = "Remarks is required.",
                    Icon = SweetAlertIcon.Error
                });
                return;
            }
            else
            {
                await OnPDFSaving();
            }
        }

        private void OpenDialog()
        {
            _remarks = "";
            SelectedImages.Clear();
            imgfile.Clear();
            listOfImages.Clear();
            listOfImages.Add(new AssetAccessImageT());
            visible = true;
        }

        private void CloseDialog() => visible = false;

        //attachment
        private string ImgBase64 { get; set; }

        private string ImgUrl { get; set; }
        private string ImgFileName { get; set; }
        private string ImgContentType { get; set; }
        private byte[] ImgData { get; set; }
        private bool Imgbool12 { get; set; }
        private bool IMGbool12 { get; set; }
        private IList<IBrowserFile> imgfile = new List<IBrowserFile>();
        private List<MultipartFormDataContent> SelectedImages = new();

        public class AssetAccessImageT
        {
            public IList<IBrowserFile> ImgFile { get; set; } = new List<IBrowserFile>();
        }

        private async Task UpPdfSec12(InputFileChangeEventArgs e, int index)
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
                imgBase64 = "Images/empty1.png";
            }
            else
            {
                var content = new MultipartFormDataContent();
                var fileContent = new StreamContent(brwModel.OpenReadStream(lngImage));
                fileContent.Headers.ContentType = new MediaTypeHeaderValue(imgContent);

                ImgFileName = imgFilename;
                ImgUrl = imgURL;
                ImgData = imgBuffer;

                content.Add(content: fileContent, name: imgFilename, fileName: imgFilename);

                var pdfbase64 = Convert.ToBase64String(imgBuffer);
                imgBase64 = string.Format("data:image/*;base64,{0}", pdfbase64);

                Imgbool12 = false;
                IMGbool12 = true;
                listOfImages[index].ImgFile.Add(e.File);
                SelectedImages.Add(content);
            }
        }

        private async Task OnPDFSaving()
        {
            var confirmResult = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmation",
                Text = "Are you sure to upload this image/s?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No"
            });

            if (confirmResult.IsConfirmed)
            {
                foreach (var formdata in SelectedImages)
                {
                    await AssAccImgSvc.AttachFilePanel(formdata, Catid, SubCatid, JMCode, _remarks);
                }
                OnFileAdded?.Invoke();
                visible = false;
            }
        }
    }
}