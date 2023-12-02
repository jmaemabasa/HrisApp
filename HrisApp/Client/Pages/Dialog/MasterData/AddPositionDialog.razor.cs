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

        //Skills
        public List<PositionTechSkillT> listOfTechSkills = new();
        public List<PositionKnowledgeT> listOfKnowledge = new();
        public List<PositionComAppT> listOfComApp = new();
        public List<PositionWorkExpT> listOfWorkExp = new();

        private int selectedDivision = 0;
        private int selectedDepartment = 0;
        private int selectedSection = 0;
        private int selectedArea = 0;
        private string newPosition = "";
        private string newPosCode = "";
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

            if (selectedArea == 0)
            {
                await Swal.FireAsync(new SweetAlertOptions
                {
                    Title = "Warning",
                    Text = "Please select an Area!",
                    Icon = SweetAlertIcon.Warning
                });
            }
            else if (string.IsNullOrWhiteSpace(newPosition))
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
            var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            var divisionId = selectedDivision;
            var departmentId = selectedDepartment;
            var sectionId = selectedSection;
            var areaId = selectedArea;
            var positionName = newPosition;
            var plantillacount = newPlantilla;
            newPosCode = generateposcode(divisionId, departmentId, sectionId);

            // Check if the selected department has sections
            var departmentHasSections = Sections.Any(s => s.DepartmentId == selectedDepartment);

            if (departmentHasSections)
            {
                // Create a position in the section
                await PositionService.CreatePositionPerSection(positionName, newPosCode, divisionId, departmentId, sectionId, areaId, newSummary, newEduc, newWorkExp, newTechSkill, newKnowledge, newComApp, newOtherComp, newRestrict, plantillacount, verifyCode);
                await SaveNewTechSkills(newPosCode);
                await SaveNewKnowledge(newPosCode);
                await SaveNewComApp(newPosCode);
                await SaveNewWorkExp(newPosCode);
            }
            else
            {

                // Create a position in the department
                await PositionService.CreatePositionPerDept(positionName, newPosCode, divisionId, departmentId, areaId, newSummary, newEduc, newWorkExp, newTechSkill, newKnowledge, newComApp, newOtherComp, newRestrict, plantillacount, verifyCode);
                await SaveNewTechSkills(newPosCode);
                await SaveNewKnowledge(newPosCode);
                await SaveNewComApp(newPosCode);
                await SaveNewWorkExp(newPosCode);
            }

            _toastService.ShowSuccess(positionName + " Created Successfully!");
            await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "CREATE", "Model", DateTime.Now);

            await PositionService.GetPosition();
            var newList = PositionService.PositionTs;
            StateService.SetState("PositionList", newList);
        }

        #region TECH SKILLS
        public async Task SaveNewTechSkills(string posCode)
        {
            var validtechSkill = listOfTechSkills
               .Where
               (obj => !string.IsNullOrEmpty(obj.PosCode) || !string.IsNullOrEmpty(obj.SkillName))
               .ToList();

            if (validtechSkill.Count == 0)
            {
                return;
            }

            foreach (var item in validtechSkill)
            {
                item.PosCode = posCode;

                int isExistTech = await PositionService.GetExistTech(item.VerifyId);
                if (isExistTech == 0)
                {
                    await PositionService.CreateTechSkill(item);
                }
                else
                {
                    await PositionService.UpdateTechSkill(item);
                }
            }

            listOfTechSkills.Clear();
        }

        public void AddNewTechSkill(string code, string newSkill)
        {
            var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            if (!string.IsNullOrEmpty(newTechSkill))
                listOfTechSkills.Add(new PositionTechSkillT { PosCode = code, SkillName = newSkill, VerifyId = verifyCode });
                newTechSkill = "";
            Console.WriteLine(verifyCode);
        }
        public void CloseTechSkill(MudChip chip)
        {
            var skillToRemove = listOfTechSkills.FirstOrDefault(item => item.SkillName == chip.Text);

            if (skillToRemove != null)
            {
                listOfTechSkills.Remove(skillToRemove);
            }
        }
        #endregion

        #region KNOWLEDGE
        public async Task SaveNewKnowledge(string posCode)
        {
            var validtechSkill = listOfKnowledge
               .Where
               (obj => !string.IsNullOrEmpty(obj.PosCode) || !string.IsNullOrEmpty(obj.KnowName))
               .ToList();

            if (validtechSkill.Count == 0)
            {
                return;
            }

            foreach (var item in validtechSkill)
            {
                item.PosCode = posCode;

                int isExistTech = await PositionService.GetExistKnowledge(item.VerifyId);
                if (isExistTech == 0)
                {
                    await PositionService.CreateKnowledge(item);
                }
                else
                {
                    await PositionService.UpdateKnowledge(item);
                }
            }

            listOfKnowledge.Clear();
        }

        public void AddNewKnowledge(string code, string newSkill)
        {
            var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            if (!string.IsNullOrEmpty(newKnowledge))
                listOfKnowledge.Add(new PositionKnowledgeT { PosCode = code, KnowName = newSkill, VerifyId = verifyCode });
                newKnowledge = "";
        }
        public void CloseKnowledge(MudChip chip)
        {
            var skillToRemove = listOfKnowledge.FirstOrDefault(item => item.KnowName == chip.Text);

            if (skillToRemove != null)
            {
                listOfKnowledge.Remove(skillToRemove);
            }
        }
        #endregion

        #region COMAPP
        public async Task SaveNewComApp(string posCode)
        {
            var validtechSkill = listOfComApp
               .Where
               (obj => !string.IsNullOrEmpty(obj.PosCode) || !string.IsNullOrEmpty(obj.ComName))
               .ToList();

            if (validtechSkill.Count == 0)
            {
                return;
            }

            foreach (var item in validtechSkill)
            {
                item.PosCode = posCode;

                int isExistTech = await PositionService.GetExistComApp(item.VerifyId);
                if (isExistTech == 0)
                {
                    await PositionService.CreateComApp(item);
                }
                else
                {
                    await PositionService.UpdateComApp(item);
                }
            }

            listOfKnowledge.Clear();
        }

        public void AddNewComApp(string code, string newSkill)
        {
            var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            if (!string.IsNullOrEmpty(newComApp))
                listOfComApp.Add(new PositionComAppT { PosCode = code, ComName = newSkill, VerifyId = verifyCode });
                newComApp = "";
        }
        public void CloseComApp(MudChip chip)
        {
            var skillToRemove = listOfComApp.FirstOrDefault(item => item.ComName == chip.Text);

            if (skillToRemove != null)
            {
                listOfComApp.Remove(skillToRemove);
            }
        }
        #endregion

        #region WORKEXP
        public async Task SaveNewWorkExp(string posCode)
        {
            var validtechSkill = listOfWorkExp
               .Where
               (obj => !string.IsNullOrEmpty(obj.PosCode) || !string.IsNullOrEmpty(obj.ExpName))
               .ToList();

            if (validtechSkill.Count == 0)
            {
                return;
            }

            foreach (var item in validtechSkill)
            {
                item.PosCode = posCode;

                int isExistTech = await PositionService.GetExistWorkExp(item.VerifyId);
                if (isExistTech == 0)
                {
                    await PositionService.CreateWorkExp(item);
                }
                else
                {
                    await PositionService.UpdateWorkExp(item);
                }
            }

            listOfKnowledge.Clear();
        }

        public void AddNewWorkExp(string code, string newSkill)
        {
            var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            if (!string.IsNullOrEmpty(newWorkExp))
                listOfWorkExp.Add(new PositionWorkExpT { PosCode = code, ExpName = newSkill, VerifyId = verifyCode });
                newWorkExp = "";
        }
        public void CloseWorkExp(MudChip chip)
        {
            var skillToRemove = listOfWorkExp.FirstOrDefault(item => item.ExpName == chip.Text);

            if (skillToRemove != null)
            {
                listOfWorkExp.Remove(skillToRemove);
            }
        }
        #endregion

        #region POSITION CODE
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
                string codename = lastPosCode.Substring(0, lastPosCode.Length - 2);

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
            }
            else
            {
                departmentCode = string.Concat(departmentName.Split(' ').Select(word => word[0]));
            }

            // Generate the new PosCode with a two-digit number
            string posCode = $"{departmentCode}{sectionCode}{01:D2}".ToUpper();

            return posCode;
        }
        #endregion
    }
}
