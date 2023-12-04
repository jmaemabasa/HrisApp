using static MudBlazor.CategoryTypes;

namespace HrisApp.Client.Pages.Dialog.MasterData
{
    public partial class UpdatePositionDialog : Microsoft.AspNetCore.Components.ComponentBase
    {
#nullable disable
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        [Parameter]
        public int Id { get; set; }

        private List<AreaT> Areas = new();
        public List<PositionTechSkillT> listOfTechSkills = new();
        public List<PositionKnowledgeT> listOfKnowledge = new();
        public List<PositionComAppT> listOfComApp = new();
        public List<PositionWorkExpT> listOfWorkExp = new();
        public List<PositionEducT> listOfEduc = new();
        private string newTechSkill;
        private string newKnowledge;
        private string newComApp;
        private string newWorkExp;
        private string newEduc;

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
            listOfTechSkills = await PositionService.GetTechSkill(position.PosCode);
            listOfKnowledge = await PositionService.GetKnowledge(position.PosCode);
            listOfComApp = await PositionService.GetComApp(position.PosCode);
            listOfWorkExp = await PositionService.GetWorkExp(position.PosCode);
            listOfEduc = await PositionService.GetEduc(position.PosCode);
        }

        async Task UpdateArea()
        {
            if (position == null)
                return;

            MudDialog.Close();

            if (string.IsNullOrWhiteSpace(position.Name))
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
                    await SaveNewTechSkills(position.PosCode);
                    await SaveNewKnowledge(position.PosCode);
                    await SaveNewComApp(position.PosCode);
                    await SaveNewWorkExp(position.PosCode);
                    await SaveNewEduc(position.PosCode);
                    await AuditlogService.CreateLog(Int32.Parse(GlobalConfigService.User_Id), "UPDATE", "Content", DateTime.Now);

                    _toastService.ShowSuccess(position.Name + " Updated Successfully!");

                    await PositionService.GetPosition();
                    var newList = PositionService.PositionTs;
                    StateService.SetState("PositionList", newList);
                }
            }
        }

        #region TECH SKILLS
        public async Task SaveNewTechSkills(string posCode)
        {
            var listApi = await PositionService.GetTechSkill(posCode);
            List<string> arrApi = new();

            var validtechSkill = listOfTechSkills
               .Where(obj => !string.IsNullOrEmpty(obj.PosCode) || !string.IsNullOrEmpty(obj.SkillName))
               .ToList();

            var listtechskills = validtechSkill.OrderByDescending(obj => obj.VerifyId).ToList();

            if (listtechskills.Count == 0)
            {
                foreach (var item in listApi)
                {
                    await PositionService.DeleteTechSkills(item.VerifyId);
                }
                return;
            }

            foreach (var pays in listApi)
            {
                var P = listtechskills.Where(p => p.VerifyId == pays.VerifyId).Count();
                
                if (P == 0)
                {
                    await PositionService.DeleteTechSkills(pays.VerifyId);
                }
            }

            foreach (var item in listtechskills)
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
            //Console.WriteLine(verifyCode);
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

        #region KNOWDLEGDE
        public async Task SaveNewKnowledge(string posCode)
        {
            var listApi = await PositionService.GetKnowledge(posCode);
            List<string> arrApi = new();

            var validtechSkill = listOfKnowledge
               .Where(obj => !string.IsNullOrEmpty(obj.PosCode) || !string.IsNullOrEmpty(obj.KnowName))
               .ToList();

            var listtechskills = validtechSkill.OrderByDescending(obj => obj.VerifyId).ToList();

            if (listtechskills.Count == 0)
            {
                foreach (var item in listApi)
                {
                    await PositionService.DeleteKnowledge(item.VerifyId);
                }
                return;
            }

            foreach (var pays in listApi)
            {
                var P = listtechskills.Where(p => p.VerifyId == pays.VerifyId).Count();

                if (P == 0)
                {
                    await PositionService.DeleteKnowledge(pays.VerifyId);
                }
            }

            foreach (var item in listtechskills)
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
            //Console.WriteLine(verifyCode);
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

        #region COM APP
        public async Task SaveNewComApp(string posCode)
        {
            var listApi = await PositionService.GetComApp(posCode);
            List<string> arrApi = new();

            var validtechSkill = listOfComApp
               .Where(obj => !string.IsNullOrEmpty(obj.PosCode) || !string.IsNullOrEmpty(obj.ComName))
               .ToList();

            var listtechskills = validtechSkill.OrderByDescending(obj => obj.VerifyId).ToList();

            if (listtechskills.Count == 0)
            {
                foreach (var item in listApi)
                {
                    await PositionService.DeleteComApp(item.VerifyId);
                }
                return;
            }

            foreach (var pays in listApi)
            {
                var P = listtechskills.Where(p => p.VerifyId == pays.VerifyId).Count();

                if (P == 0)
                {
                    await PositionService.DeleteComApp(pays.VerifyId);
                }
            }

            foreach (var item in listtechskills)
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

            listOfComApp.Clear();
        }

        public void AddNewComApp(string code, string newSkill)
        {
            var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            if (!string.IsNullOrEmpty(newComApp))
                listOfComApp.Add(new PositionComAppT { PosCode = code, ComName = newSkill, VerifyId = verifyCode });
                newComApp = "";
            //Console.WriteLine(verifyCode);
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

        #region EXP
        public async Task SaveNewWorkExp(string posCode)
        {
            var listApi = await PositionService.GetWorkExp(posCode);
            List<string> arrApi = new();

            var validtechSkill = listOfWorkExp
               .Where(obj => !string.IsNullOrEmpty(obj.PosCode) || !string.IsNullOrEmpty(obj.ExpName))
               .ToList();

            var listtechskills = validtechSkill.OrderByDescending(obj => obj.VerifyId).ToList();

            if (listtechskills.Count == 0)
            {
                foreach (var item in listApi)
                {
                    await PositionService.DeleteWorkExp(item.VerifyId);
                }
                return;
            }

            foreach (var pays in listApi)
            {
                var P = listtechskills.Where(p => p.VerifyId == pays.VerifyId).Count();

                if (P == 0)
                {
                    await PositionService.DeleteWorkExp(pays.VerifyId);
                }
            }

            foreach (var item in listtechskills)
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

            listOfWorkExp.Clear();
        }

        public void AddNewWorkExp(string code, string newSkill)
        {
            var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            if (!string.IsNullOrEmpty(newWorkExp))
                listOfWorkExp.Add(new PositionWorkExpT { PosCode = code, ExpName = newSkill, VerifyId = verifyCode });
                newWorkExp = "";
            //Console.WriteLine(verifyCode);
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

        #region EDUC
        public async Task SaveNewEduc(string posCode)
        {
            var listApi = await PositionService.GetEduc(posCode);
            List<string> arrApi = new();

            var validtechSkill = listOfEduc
               .Where(obj => !string.IsNullOrEmpty(obj.PosCode) || !string.IsNullOrEmpty(obj.EducName))
               .ToList();

            var listtechskills = validtechSkill.OrderByDescending(obj => obj.VerifyId).ToList();

            if (listtechskills.Count == 0)
            {
                foreach (var item in listApi)
                {
                    await PositionService.DeleteEduc(item.VerifyId);
                }
                return;
            }

            foreach (var pays in listApi)
            {
                var P = listtechskills.Where(p => p.VerifyId == pays.VerifyId).Count();

                if (P == 0)
                {
                    await PositionService.DeleteEduc(pays.VerifyId);
                }
            }

            foreach (var item in listtechskills)
            {
                item.PosCode = posCode;

                int isExistTech = await PositionService.GetExistEduc(item.VerifyId);
                if (isExistTech == 0)
                {
                    await PositionService.CreateEduc(item);
                }
                else
                {
                    await PositionService.UpdateEduc(item);
                }
            }

            listOfEduc.Clear();
        }

        public void AddNewEduc(string code, string newSkill)
        {
            var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");
            if (!string.IsNullOrEmpty(newEduc))
                listOfEduc.Add(new PositionEducT { PosCode = code, EducName = newSkill, VerifyId = verifyCode });
            newEduc = "";
            //Console.WriteLine(verifyCode);
        }
        public void CloseEduc(MudChip chip)
        {
            var skillToRemove = listOfEduc.FirstOrDefault(item => item.EducName == chip.Text);

            if (skillToRemove != null)
            {
                listOfEduc.Remove(skillToRemove);
            }
        }

        #endregion
    }
}
