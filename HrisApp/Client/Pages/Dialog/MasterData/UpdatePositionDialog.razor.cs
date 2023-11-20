using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdatePositionDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }

        private List<AreaT> Areas = new();


        private PositionT position = new();
        void Cancel() => MudDialog.Cancel();
        protected override async Task OnInitializedAsync()
        {
            await AreaService.GetArea();
            Areas = AreaService.AreaTs;
        }

        protected override async Task OnParametersSetAsync()
        {
            position = await PositionService.GetSinglePosition(Id);
        }

        async Task UpdateArea()
        {
            if (position == null)
                return;

            MudDialog.Close();

            var confirmResult = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmation",
                Text = "Are you sure you want to update the " + position.Name + "?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No"
            });

            if (confirmResult.IsConfirmed)
            {
                await PositionService.UpdatePosition(position);
                await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

                _toastService.ShowSuccess(position.Name + " Updated Successfully!");

                await PositionService.GetPosition();
                var newList = PositionService.PositionTs;
                StateService.SetState("PositionList", newList);
            }
        }
    }
}
