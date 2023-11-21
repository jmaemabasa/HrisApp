using Microsoft.JSInterop;
using System.Text.RegularExpressions;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class AddPositionDialog : ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        private List<DepartmentT> Department = new();
        private List<DivisionT> Division = new();
        private List<SectionT> Sections = new();
        private List<PositionT> Positions = new();
        private List<AreaT> Areas = new();

        private int selectedDivision =0;
        private int selectedDepartment=0;
        private int selectedSection=0;
        private int selectedArea=0;
        private string newPosition = "";
        private string newSummary = "";
        private string newEduc = "";
        private string newWorkExp = "";
        private string newTechSkill = "";
        private string newKnowledge = "";
        private string newComApp = "";
        private string newOtherComp = "";
        private string newRestrict = "";
        private int newPlantilla;

        void Cancel() => MudDialog.Cancel();

        protected override async Task OnInitializedAsync()
        {
            await DivisionService.GetDivision();
            Division = DivisionService.DivisionTs;

            await DepartmentService.GetDepartment();
            Department = DepartmentService.DepartmentTs;

            await SectionService.GetSection();
            Sections = SectionService.SectionTs;

            await PositionService.GetPosition();
            Positions = PositionService.PositionTs;

            await AreaService.GetArea();
            Areas = AreaService.AreaTs;
        }

        private async Task ConfirmCreatePositionAsync()
        {
            MudDialog.Close();

            if (string.IsNullOrWhiteSpace(newPosition))
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Warning",
                    Text = "Please enter a valid position!",
                    Icon = SweetAlertIcon.Warning
                });
            }
            else
            {
                var result = await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Do you want to create " + newPosition + "?",
                    Icon = SweetAlertIcon.Question,
                    ShowCancelButton = true,
                    ConfirmButtonText = "Yes",
                    CancelButtonText = "No"
                });

                if (result.IsConfirmed)
                {
                    await CreatePositionPerDepOrSect();
                }
            }
        }

        private async Task CreatePositionPerDepOrSect()
        {
            var divisionId = selectedDivision;
            var departmentId = selectedDepartment;
            var sectionId = selectedSection;
            var areaId = selectedArea;
            var positionName = newPosition;
            var plantillacount = newPlantilla;
            string posCode = generateposcode(divisionId, departmentId, sectionId);

            // Check if the selected department has sections
            var departmentHasSections = Sections.Any(s => s.DepartmentId == selectedDepartment);

            if (departmentHasSections)
            {
                // Create a position in the section
                await PositionService.CreatePositionPerSection(positionName, posCode, divisionId, departmentId, sectionId, areaId, newSummary,newEduc, newWorkExp, newTechSkill, newKnowledge, newComApp, newOtherComp, newRestrict ,plantillacount);
            }
            else
            {

                // Create a position in the department
                await PositionService.CreatePositionPerDept(positionName, posCode,divisionId, departmentId, areaId, newSummary, newEduc, newWorkExp, newTechSkill, newKnowledge, newComApp, newOtherComp, newRestrict, plantillacount);
            }

            _toastService.ShowSuccess(positionName + " Created Successfully!");
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

            await PositionService.GetPosition();
            var newList = PositionService.PositionTs;
            StateService.SetState("PositionList", newList);
        }

        private string generateposcode(int divisionId, int departmentId, int sectionId)
        {
            var lastPosCode = Positions
            .Where(s => s.DivisionId == divisionId && s.DepartmentId == departmentId && s.SectionId == sectionId)
            .OrderByDescending(s => s.Id)
            .Select(s => s.PosCode)
            .FirstOrDefault();

            if (lastPosCode != null)
            {
                string numericPart = Regex.Match(lastPosCode, @"\d+").Value;
                string codename = lastPosCode.Substring(0, lastPosCode.Length -2);

                int incrementedNumber = int.Parse(numericPart) + 1;

                string newPosCode = $"{codename}{incrementedNumber:D2}";

                return newPosCode;
            }
            else
            {
                return GenerateNewPosCode(departmentId, sectionId);
            }
        }

        private string GenerateNewPosCode(int departmentId, int sectionId)
        {
            string departmentName = "";
            string sectionName = "";

            foreach (var item in Department)
            {
                if (item.Id == departmentId)
                    departmentName = item.Name;
            }

            foreach (var item in Sections)
            {
                if (item.Id == sectionId)
                    sectionName = sectionId != 0 ? item.Name : string.Empty;
            }


            // Extract the first letter of each word in department name
            string departmentCode = "";

            // If a section exists, add the first two letters of section name
            string sectionCode = sectionId != 0 ? sectionName.Substring(0, Math.Min(3, sectionName.Length)) : string.Empty;

            // If the departmentName has only one word, use the whole word
            if (departmentName.Split(' ').Length == 1)
            {
                departmentCode = departmentName;
            } else
            {
                departmentCode = string.Concat(departmentName.Split(' ').Select(word => word[0]));
            }

            // Generate the new PosCode with a two-digit number
            string posCode = $"{departmentCode}{sectionCode}{01:D2}".ToUpper();

            return posCode;
        }

    }
}
