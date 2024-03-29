﻿namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class AddAreaDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        private string newArea = "";

        void Cancel() => MudDialog.Cancel();


        private async Task ConfirmCreateArea()
        {
            MudDialog.Close();

            if (string.IsNullOrWhiteSpace(newArea))
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Warning",
                    Text = "Please fill up the division name!",
                    Icon = SweetAlertIcon.Warning
                });
            }
            else
            {
                var confirmResult = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Confirmation",
                    Text = "Are you sure you want to add " + newArea + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (confirmResult.IsConfirmed)
                {
                    await AreaService.CreateArea(newArea);

                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

                    _toastService.ShowSuccess(newArea + " Created Successfully!");

                    // Update the areaList using the StateService
                    await AreaService.GetAreaList();
                    var newAreaList =  AreaService.AreaTs;
                    StateService.SetState("AreaList", newAreaList);
                }
            }
        }

    }
}
