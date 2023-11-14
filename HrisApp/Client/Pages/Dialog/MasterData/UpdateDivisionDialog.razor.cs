using Newtonsoft.Json;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdateDivisionDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }


        private DivisionT division = new();


        void Cancel() => MudDialog.Cancel();


        protected override async Task OnParametersSetAsync()
        {
            //division = DivisionService.DivisionTs.Find(d => d.Id == Id);
            division = await DivisionService.GetSingleDivision(Id);
        }

        async Task UpdateArea()
        {
            if (division == null)
                return;

            MudDialog.Close();

            var confirmResult = await Swal.FireAsync(new SweetAlertOptions
            {
                Title = "Confirmation",
                Text = "Are you sure you want to update the " + division.Name + "?",
                Icon = SweetAlertIcon.Question,
                ShowCancelButton = true,
                ConfirmButtonText = "Yes",
                CancelButtonText = "No"
            });

            if (confirmResult.IsConfirmed)
            {
                await DivisionService.UpdateDivision(division);
                await AuditlogGlobal.CreateAudit(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "DivisionT", $"DivisionId: {division.Id} updated successfully.", JsonConvert.SerializeObject(division), DateTime.Now);

                _toastService.ShowSuccess(division.Name + " Updated Successfully!");

                await DivisionService.GetDivision();
                var newList = DivisionService.DivisionTs;
                StateService.SetState("DivisionList", newList);
            }
        }
    }
}
