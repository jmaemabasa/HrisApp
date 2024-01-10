using HrisApp.Client.Pages.Employee;

namespace HrisApp.Client.Pages.Applicant
{
    public partial class NewApplicant : ComponentBase
    {
#nullable disable
        MudTabs tabs;
        ApplicantT applicant = new();
        App_AddressT address = new();
        App_SelfDeclarationT selfdec = new();

        public List<GenderT> GendersL = new();
        public List<CivilStatusT> CivilStatusL = new();
        public List<ReligionT> ReligionsL = new();
        public List<EmerRelationshipT> EmerRelationshipsL = new();

        #region self dec variables
        public bool YesCB1 { get; set; } = false;
        public bool NoCB1 { get; set; } = false;
        public bool YesCB2 { get; set; } = false;
        public bool NoCB2 { get; set; } = false;
        public bool YesCB3 { get; set; } = false;
        public bool NoCB3 { get; set; } = false;
        public bool YesCB4 { get; set; } = false;
        public bool NoCB4 { get; set; } = false;
        public bool YesCB5 { get; set; } = false;
        public bool NoCB5 { get; set; } = false;
        public bool YesCB6 { get; set; } = false;
        public bool NoCB6 { get; set; } = false;
        public bool YesCB7 { get; set; } = false;
        public bool NoCB7 { get; set; } = false;
        #endregion

        public DateTime? bday { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await StaticService.GetGenderList();
            GendersL = StaticService.GenderTs;
            await StaticService.GetCivilStatusList();
            CivilStatusL = StaticService.CivilStatusTs;
            await StaticService.GetReligionList();
            ReligionsL = StaticService.ReligionTs;
            await StaticService.GetEmerRelationshipList();
            EmerRelationshipsL = StaticService.EmerRelationshipTs;

            AddNewSibling(applicant.App_VerifyId);
            AddNewBgProf(applicant.App_VerifyId);
            AddNewPrimary(applicant.App_VerifyId);
            AddNewSecondary(applicant.App_VerifyId);
            AddNewSHS(applicant.App_VerifyId);
            AddNewCollege(applicant.App_VerifyId);
            AddNewMasteral(applicant.App_VerifyId);
            AddNewDoctorate(applicant.App_VerifyId);
            AddNewOthers(applicant.App_VerifyId);
            AddNewLicense(applicant.App_VerifyId);
            AddNewTrainings(applicant.App_VerifyId);
            AddNewOtherAwards(applicant.App_VerifyId);
        }

        public async Task CreateApplicant()
        {
            await Task.Delay(1);
            if (applicant.App_DOB.HasValue)
            {
                DateTime currentDate = DateTime.Today;
                int age = currentDate.Year - applicant.App_DOB.Value.Year;

                if (applicant.App_DOB.Value > currentDate.AddYears(-age))
                    age--;

                applicant.App_Age = age;
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(applicant.App_EmerName) && !string.IsNullOrWhiteSpace(applicant.App_EmerAddress) && !string.IsNullOrWhiteSpace(applicant.App_ContactNo) && applicant.App_EmerRelationshipId != 0 && !string.IsNullOrWhiteSpace(selfdec.Q1Ans) && !string.IsNullOrWhiteSpace(selfdec.Q2Ans) && !string.IsNullOrWhiteSpace(selfdec.Q3Ans) && !string.IsNullOrWhiteSpace(selfdec.Q4Ans) && !string.IsNullOrWhiteSpace(selfdec.Q5Ans) && !string.IsNullOrWhiteSpace(selfdec.Q6Ans) && !string.IsNullOrWhiteSpace(selfdec.Q7Ans))
                {
                    var verifyCode = DateTime.Now.ToString("yyyyMMddhhmmssfff");

                    //CREATE APPLICANT
                    applicant.App_VerifyId = verifyCode;
                    //var verifyId = await ApplicantService.CreateApplicant(applicant);

                    //CREATE ADDRESS
                    address.Verify_Id = verifyCode;
                    //var adres = await AppAddressService.CreateAddress(address);

                    //CREATE Self Dec
                    selfdec.App_VerifyId = verifyCode;
                    selfdec.Q1Ans = (YesCB1 == true) ? "Yes" : "No";
                    selfdec.Q2Ans = (YesCB2 == true) ? "Yes" : "No";
                    selfdec.Q3Ans = (YesCB3 == true) ? "Yes" : "No";
                    selfdec.Q4Ans = (YesCB4 == true) ? "Yes" : "No";
                    selfdec.Q5Ans = (YesCB5 == true) ? "Yes" : "No";
                    selfdec.Q6Ans = (YesCB6 == true) ? "Yes" : "No";
                    selfdec.Q7Ans = (YesCB7 == true) ? "Yes" : "No";
                    //var sd = await AppLicenseTrainingService.CreateSelfDeclaration(selfdec);


                    ////CREATE EDUCATIONS
                    await CreatePrimaryRecords(verifyCode);
                    await CreateSecondaryRecords(verifyCode);
                    await CreateSeniorHSRecords(verifyCode);
                    await CreateCollegeRecords(verifyCode);
                    await CreateMasteralRecords(verifyCode);
                    await CreateDoctorateRecords(verifyCode);
                    await CreateOtherEducRecords(verifyCode);

                    await CreateTrainRecords(verifyCode);
                    await CreateLicRecords(verifyCode);
                    await CreateProfBGRecords(verifyCode);
                    await CreateOtherAwardRecords(verifyCode);

                    await CreateChildRecords(verifyCode);
                    await CreateSiblingRecords(verifyCode);

                    clsEmerName = clsEmerRel = clsEmerNo = clsEmerAdd = "";
                    mesEmerName = mesEmerAdd = mesEmerNo = mesEmerRel = "";

                    clsQ1 = clsQ2 = clsQ3 = clsQ4 = clsQ5 = clsQ6 = clsQ7 = "";

                }
                else
                {
                    clsEmerName = string.IsNullOrWhiteSpace(applicant.App_EmerName) ? "mud-input-error" : string.Empty;
                    mesEmerName = string.IsNullOrWhiteSpace(applicant.App_EmerName) ? "Name is required" : string.Empty;
                    clsEmerAdd = string.IsNullOrWhiteSpace(applicant.App_EmerAddress) ? "mud-input-error" : string.Empty;
                    mesEmerAdd = string.IsNullOrWhiteSpace(applicant.App_EmerAddress) ? "Address is required" : string.Empty;
                    clsEmerNo = string.IsNullOrWhiteSpace(applicant.App_EmerMobNum) ? "mud-input-error" : string.Empty;
                    mesEmerNo = string.IsNullOrWhiteSpace(applicant.App_EmerMobNum) ? "Contact No is required" : string.Empty;

                    clsEmerRel = applicant.App_EmerRelationshipId == 0 ? "mud-input-error" : string.Empty;
                    mesEmerRel = applicant.App_EmerRelationshipId == 0 ? "Please select." : string.Empty;

                    clsQ1 = string.IsNullOrWhiteSpace(selfdec.Q1Ans) ? "text-error" : string.Empty;
                    clsQ2 = string.IsNullOrWhiteSpace(selfdec.Q2Ans) ? "text-error" : string.Empty;
                    clsQ3 = string.IsNullOrWhiteSpace(selfdec.Q3Ans) ? "text-error" : string.Empty;
                    clsQ4 = string.IsNullOrWhiteSpace(selfdec.Q4Ans) ? "text-error" : string.Empty;
                    clsQ5 = string.IsNullOrWhiteSpace(selfdec.Q5Ans) ? "text-error" : string.Empty;
                    clsQ6 = string.IsNullOrWhiteSpace(selfdec.Q6Ans) ? "text-error" : string.Empty;
                    clsQ7 = string.IsNullOrWhiteSpace(selfdec.Q7Ans) ? "text-error" : string.Empty;

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


            public void Activate(int index)
        {
            tabs.ActivatePanel(index);
        }

        public async void ActivateAddressField()
        {
            validFam = !validFam;
            await JSRuntime.InvokeVoidAsync("scrollToDiv");
        }


        bool success;
        private void OnValidSubmitPersonal(EditContext context)
        {
            if (context.Validate())
            {
                success = true;
                tabs.ActivatePanel(1);
            }
            else
            {
                context.NotifyFieldChanged(FieldIdentifier.Create(() => applicant.App_GenderId));
                context.NotifyFieldChanged(FieldIdentifier.Create(() => applicant.App_ReligionId));
                context.NotifyFieldChanged(FieldIdentifier.Create(() => applicant.App_CivilStatusId));
            }
        }

        private string clsMotherName;
        private string mesMotherName;
        private string clsFatherName;
        private string mesFatherName;

        private string clsEmerName;
        private string mesEmerName;
        private string clsEmerRel;
        private string mesEmerRel;
        private string clsEmerAdd;
        private string mesEmerAdd;
        private string clsEmerNo;
        private string mesEmerNo;

        private string clsQ1;
        private string clsQ2;
        private string clsQ3;
        private string clsQ4;
        private string clsQ5;
        private string clsQ6;
        private string clsQ7;

        private bool validFam = true;
        private void OnValidSubmitFamily()
        {
            clsMotherName = string.IsNullOrWhiteSpace(applicant.App_MotherName) ? "mud-input-error" : string.Empty;
            mesMotherName = string.IsNullOrWhiteSpace(applicant.App_MotherName) ? "Mother Name is required" : string.Empty;
            clsFatherName = string.IsNullOrWhiteSpace(applicant.App_FatherName) ? "mud-input-error" : string.Empty;
            mesFatherName = string.IsNullOrWhiteSpace(applicant.App_FatherName) ? "Father Name is required" : string.Empty;

            if (!string.IsNullOrWhiteSpace(applicant.App_MotherName) || !string.IsNullOrWhiteSpace(applicant.App_FatherName))
            {
                tabs.ActivatePanel(2);
            }
        }

        #region functions 
        public string CalculateAge(DateTime? selectedDate)
        {
            if (selectedDate.HasValue)
            {
                DateTime currentDate = DateTime.Today;
                int age = currentDate.Year - selectedDate.Value.Year;

                if (selectedDate.Value > currentDate.AddYears(-age))
                    age--;

                return age.ToString();
            }

            return string.Empty;
        }
        #endregion

        #region Siblings
        public List<App_SiblingT> listofSiblings = new();
        public void AddNewSibling(string applicantVerifyId)
        {
            if (listofSiblings.Count <= 10)
            {
                listofSiblings.Add(new App_SiblingT { App_VerifyId = applicantVerifyId });
                StateHasChanged();
            }
        }

        public void RemoveSibling()
        {
            if (listofSiblings.Count < 1) { }
            else
            {
                listofSiblings.RemoveAt(listofSiblings.Count - 1);
            }
        }

        public async Task CreateSiblingRecords(string verid)
        {
            var validRecords = listofSiblings
                .Where
                (bg => !string.IsNullOrEmpty(bg.App_SiblingName) || !string.IsNullOrEmpty(bg.App_SiblingOccupation))
                .ToList();
            if (validRecords.Count == 0)
            {
                return;
            }
            foreach (var obj in validRecords)
            {
                obj.App_VerifyId = verid;
                await AppSibChildService.CreateSibling(obj);
            }

            listofSiblings.Clear();
            AddNewSibling(verid);
        }

        public async Task CreateChildRecords(string verid)
        {
            var validRecords = listofChildren
                .Where
                (bg => !string.IsNullOrEmpty(bg.App_ChildrenName) || !string.IsNullOrEmpty(bg.App_ChildrenOccupation))
                .ToList();
            if (validRecords.Count == 0)
            {
                return;
            }
            foreach (var obj in validRecords)
            {
                obj.App_VerifyId = verid;
                await AppSibChildService.CreateChildren(obj);
            }

            listofChildren.Clear();
            AddNewChild(verid);
        }
        #endregion
        #region Children
        public List<App_ChildrenT> listofChildren = new();
        public void AddNewChild(string applicantVerifyId)
        {
            if (listofChildren.Count <= 10)
            {
                listofChildren.Add(new App_ChildrenT { App_VerifyId = applicantVerifyId });
                StateHasChanged();
            }
        }

        public void RemoveChild()
        {
            if (listofChildren.Count < 1) { }
            else
            {
                listofChildren.RemoveAt(listofChildren.Count - 1);
            }
        }
        #endregion
        #region Prof Background
        public List<App_ProfBackgroundT> listofBgProf = new();
        public void AddNewBgProf(string applicantVerifyId)
        {
            if (listofBgProf.Count <= 10)
            {
                listofBgProf.Add(new App_ProfBackgroundT { App_VerifyId = applicantVerifyId });
                StateHasChanged();
            }
        }

        public void RemoveBgProf()
        {
            if (listofBgProf.Count < 1) { }
            else
            {
                listofBgProf.RemoveAt(listofBgProf.Count - 1);
            }
        }

        public async Task CreateProfBGRecords(string verid)
        {
            var validRecords = listofBgProf
                .Where
                (bg => !string.IsNullOrEmpty(bg.App_CompanyName) || !string.IsNullOrEmpty(bg.App_Position)
                     || !string.IsNullOrEmpty(bg.App_BasicSalary) || !string.IsNullOrEmpty(bg.App_RSLeaving))
                .ToList();
            if (validRecords.Count == 0)
            {
                return;
            }
            foreach (var obj in validRecords)
            {
                obj.App_VerifyId = verid;
                await AppLicenseTrainingService.CreateProfBg(obj);
            }

            listofBgProf.Clear();
            AddNewBgProf(verid);
        }

        public async Task CreateLicRecords(string verid)
        {
            var validRecords = listOfLicense
                .Where
                (bg => !string.IsNullOrEmpty(bg.Examination)
                     || !string.IsNullOrEmpty(bg.LicenseNo) || !string.IsNullOrEmpty(bg.Rating))
                .ToList();
            if (validRecords.Count == 0)
            {
                return;
            }
            foreach (var obj in validRecords)
            {
                obj.Verify_Id = verid;
                await AppLicenseTrainingService.CreateLicense(obj);
            }

            listOfLicense.Clear();
            AddNewLicense(verid);
        }

        public async Task CreateTrainRecords(string verid)
        {
            var validRecords = listOfTrainings
                .Where
                (bg => !string.IsNullOrEmpty(bg.TrainingName)
                     || !string.IsNullOrEmpty(bg.SponsorSpeaker))
                .ToList();
            if (validRecords.Count == 0)
            {
                return;
            }
            foreach (var obj in validRecords)
            {
                obj.Verify_Id = verid;
                await AppLicenseTrainingService.CreateTraining(obj);
            }

            listOfTrainings.Clear();
            AddNewTrainings(verid);
        }

        public async Task CreateOtherAwardRecords(string verid)
        {
            var validRecords = listOfOtherAwards
                .Where
                (bg => !string.IsNullOrEmpty(bg.Name))
                .ToList();
            if (validRecords.Count == 0)
            {
                return;
            }
            foreach (var obj in validRecords)
            {
                obj.Verify_Id = verid;
                await AppLicenseTrainingService.CreateOtherAwards(obj);
            }

            listOfOtherAwards.Clear();
            AddNewOtherAwards(verid);
        }
        #endregion
        #region EDUCATION BACKGROUND
        //EDUCATION
        public List<App_CollegeT> listOfCollege = new();
        public List<App_OtherEducT> listOfOthers = new();
        public List<App_SecondaryT> listOfSecondary = new();
        public List<App_DoctorateT> listOfDoctorate = new();
        public List<App_PrimaryT> listOfPrimary = new();
        public List<App_MasteralT> listOfMasteral = new();
        public List<App_SeniorHST> listOfShs = new();

        public List<App_TrainingT> listOfTrainings = new();
        public List<App_LicenseT> listOfLicense = new();
        public List<App_OtherAwardsT> listOfOtherAwards = new();

        public bool IsListaddshs;
        public bool IsListaddcoll;
        public bool IsListaddmas;
        public bool IsListaddothers;
        public bool IsListadddoc;

        #region ADD REMOVE BUTTONS EDUC
        public void AddNewPrimary(string applicantVerifyId)
        {
            if (listOfPrimary.Count <= 10)
            {
                listOfPrimary.Add(new App_PrimaryT { Verify_Id = applicantVerifyId });
                StateHasChanged();
            }
        }
        public void RemovePrimary()
        {
            if (listOfPrimary.Count < 1) { }
            else
            {
                listOfPrimary.RemoveAt(listOfPrimary.Count - 1);
            }
        }

        public void AddNewSecondary(string applicantVerifyId)
        {
            if (listOfSecondary.Count <= 10)
            {
                listOfSecondary.Add(new App_SecondaryT { Verify_Id = applicantVerifyId });
                StateHasChanged();
            }
        }
        public void RemoveSecondary()
        {
            if (listOfSecondary.Count < 1) { }
            else
            {
                listOfSecondary.RemoveAt(listOfSecondary.Count - 1);
            }
        }

        public void AddNewSHS(string applicantVerifyId)
        {
            if (listOfShs.Count <= 10)
            {
                listOfShs.Add(new App_SeniorHST { Verify_Id = applicantVerifyId });
                StateHasChanged();
            }
        }
        public void RemoveSHS()
        {
            if (listOfShs.Count < 1) { }
            else
            {
                listOfShs.RemoveAt(listOfShs.Count - 1);
            }
        }

        public void AddNewCollege(string applicantVerifyId)
        {
            if (listOfCollege.Count <= 10)
            {
                listOfCollege.Add(new App_CollegeT { Verify_Id = applicantVerifyId });
                StateHasChanged();
            }
        }
        public void RemoveCollege()
        {
            if (listOfCollege.Count < 1) { }
            else
            {
                listOfCollege.RemoveAt(listOfCollege.Count - 1);
            }
        }

        public void AddNewMasteral(string applicantVerifyId)
        {
            if (listOfMasteral.Count <= 10)
            {
                listOfMasteral.Add(new App_MasteralT { Verify_Id = applicantVerifyId });
                StateHasChanged();
            }
        }
        public void RemoveMasteral()
        {
            if (listOfMasteral.Count < 1) { }
            else
            {
                listOfMasteral.RemoveAt(listOfMasteral.Count - 1);
            }
        }

        public void AddNewDoctorate(string applicantVerifyId)
        {
            if (listOfDoctorate.Count <= 10)
            {
                listOfDoctorate.Add(new App_DoctorateT { Verify_Id = applicantVerifyId });
                StateHasChanged();
            }
        }
        public void RemoveDoctorate()
        {
            if (listOfDoctorate.Count < 1) { }
            else
            {
                listOfDoctorate.RemoveAt(listOfDoctorate.Count - 1);
            }
        }

        public void AddNewOthers(string applicantVerifyId)
        {
            if (listOfOthers.Count <= 10)
            {
                listOfOthers.Add(new App_OtherEducT { Verify_Id = applicantVerifyId });
                StateHasChanged();
            }
        }
        public void RemoveOthers()
        {
            if (listOfOthers.Count < 1) { }
            else
            {
                listOfOthers.RemoveAt(listOfOthers.Count - 1);
            }
        }

        public void AddNewTrainings(string applicantVerifyId)
        {
            if (listOfTrainings.Count <= 10)
            {
                listOfTrainings.Add(new App_TrainingT { Verify_Id = applicantVerifyId });
                StateHasChanged();
            }
        }
        public void RemoveTrainings()
        {
            if (listOfTrainings.Count < 1) { }
            else
            {
                listOfTrainings.RemoveAt(listOfTrainings.Count - 1);
            }
        }

        public void AddNewLicense(string applicantVerifyId)
        {
            if (listOfLicense.Count <= 10)
            {
                listOfLicense.Add(new App_LicenseT { Verify_Id = applicantVerifyId });
                StateHasChanged();
            }
        }
        public void RemoveLicense()
        {
            if (listOfLicense.Count < 1) { }
            else
            {
                listOfLicense.RemoveAt(listOfLicense.Count - 1);
            }
        }

        public void AddNewOtherAwards(string applicantVerifyId)
        {
            if (listOfOtherAwards.Count <= 10)
            {
                listOfOtherAwards.Add(new App_OtherAwardsT { Verify_Id = applicantVerifyId });
                StateHasChanged();
            }
        }
        public void RemoveOtherAwards()
        {
            if (listOfOtherAwards.Count < 1) { }
            else
            {
                listOfOtherAwards.RemoveAt(listOfOtherAwards.Count - 1);
            }
        }
        #endregion

        #region CREATE SAVE EDUC
        public async Task CreatePrimaryRecords(string verid)
        {
            //primary
            var validRecords = listOfPrimary
                .Where
                (pri => !string.IsNullOrEmpty(pri.PriSchoolName) || !string.IsNullOrEmpty(pri.PriSchoolLoc)
                     || !string.IsNullOrEmpty(pri.PriAward) || !string.IsNullOrEmpty(pri.PriSchoolYear))
                .ToList();
            if (validRecords.Count == 0)
            {
                return;
            }
            foreach (var pri in validRecords)
            {
                pri.Verify_Id = verid;
                await AppEducService.CreatePrimary(pri);
            }

            listOfPrimary.Clear();
            AddNewPrimary(verid);
        }
        public async Task CreateSecondaryRecords(string verid)
        {
            //secondary
            var validSecodary = listOfSecondary
               .Where
               (sec => !string.IsNullOrEmpty(sec.SecSchoolName) || !string.IsNullOrEmpty(sec.SecSchoolLoc)
                    || !string.IsNullOrEmpty(sec.SecAward) || !string.IsNullOrEmpty(sec.SecSchoolYear))
               .ToList();
            if (validSecodary.Count == 0)
            {
                return;
            }
            foreach (var sec in validSecodary)
            {
                sec.Verify_Id = verid;
                await AppEducService.CreateSecondary(sec);
            }

            listOfSecondary.Clear();
            AddNewSecondary(verid);
        }
        public async Task CreateSeniorHSRecords(string verid)
        {  //shs
            var validShs = listOfShs
               .Where
               (shs => !string.IsNullOrEmpty(shs.ShsSchoolName) || !string.IsNullOrEmpty(shs.ShsSchoolLoc)
                    || !string.IsNullOrEmpty(shs.ShsAward) || !string.IsNullOrEmpty(shs.ShsSchoolYear))
               .ToList();
            if (validShs.Count == 0)
            {
                return;
            }
            foreach (var shs in validShs)
            {
                shs.Verify_Id = verid;
                await AppEducService.CreateSeniorHS(shs);
            }

            listOfShs.Clear();
            AddNewSHS(verid);
        }
        public async Task CreateCollegeRecords(string verid)
        {
            //college
            var validCollege = listOfCollege
               .Where
               (coll => !string.IsNullOrEmpty(coll.CollSchoolName) || !string.IsNullOrEmpty(coll.CollSchoolLoc)
                    || !string.IsNullOrEmpty(coll.CollAward) || !string.IsNullOrEmpty(coll.CollSchoolYear)
                    || !string.IsNullOrEmpty(coll.CollCourse))
               .ToList();
            if (validCollege.Count == 0)
            {
                return;
            }
            foreach (var coll in validCollege)
            {
                coll.Verify_Id = verid;
                await AppEducService.CreateCollege(coll);
            }

            listOfCollege.Clear();
            AddNewCollege(verid);

        }
        public async Task CreateMasteralRecords(string verid)
        {
            //masteral
            var validMasteral = listOfMasteral
               .Where
               (mas => !string.IsNullOrEmpty(mas.MasSchoolName) || !string.IsNullOrEmpty(mas.MasSchoolLoc)
                    || !string.IsNullOrEmpty(mas.MasAward) || !string.IsNullOrEmpty(mas.MasSchoolYear)
                    || !string.IsNullOrEmpty(mas.MasCourse))
               .ToList();
            if (validMasteral.Count == 0)
            {
                return;
            }
            foreach (var mas in validMasteral)
            {
                mas.Verify_Id = verid;
                await AppEducService.CreateMasteral(mas);
            }

            listOfMasteral.Clear();
            AddNewMasteral(verid);
        }
        public async Task CreateDoctorateRecords(string verid)
        {
            //doctorate
            var validDoctorate = listOfDoctorate
               .Where
               (doc => !string.IsNullOrEmpty(doc.DocSchoolName) || !string.IsNullOrEmpty(doc.DocSchoolLoc)
                    || !string.IsNullOrEmpty(doc.DocAward) || !string.IsNullOrEmpty(doc.DocSchoolYear)
                    || !string.IsNullOrEmpty(doc.DocCourse))
               .ToList();
            if (validDoctorate.Count == 0)
            {
                return;
            }
            foreach (var doc in validDoctorate)
            {
                doc.Verify_Id = verid;
                await AppEducService.CreateDoctorate(doc);
            }

            listOfDoctorate.Clear();
            AddNewDoctorate(verid);
        }
        public async Task CreateOtherEducRecords(string verid)
        {
            //othereduc
            var validothers = listOfOthers
               .Where
               (other => !string.IsNullOrEmpty(other.OthersSchoolType) || !string.IsNullOrEmpty(other.OthersSchoolName)
                    || !string.IsNullOrEmpty(other.OthersSchoolLoc) || !string.IsNullOrEmpty(other.OthersAward)
                    || !string.IsNullOrEmpty(other.OthersSchoolYear) || !string.IsNullOrEmpty(other.OthersCourse))
               .ToList();
            if (validothers.Count == 0)
            {
                return;
            }
            foreach (var others in validothers)
            {
                others.Verify_Id = verid;
                await AppEducService.CreateOtherEduc(others);
            }

            listOfOthers.Clear();
            AddNewOthers(verid);
        }
        //public async Task CreateLicenses(string employeeVerifyId)
        //{
        //    //training
        //    var validLicenses = listOfLicense
        //       .Where
        //       (license =>
        //            !string.IsNullOrEmpty(license.Examination) ||
        //            !string.IsNullOrEmpty(license.Rating) ||
        //            !string.IsNullOrEmpty(license.LicenseNo))
        //       .ToList();
        //    if (validLicenses.Count == 0)
        //    {
        //        return;
        //    }
        //    foreach (var license in validLicenses)
        //    {
        //        license.Verify_Id = employeeVerifyId;
        //        await LicenseTrainingService.CreateLicense(license);
        //    }

        //    listOfLicense.Clear();
        //    AddNewLicense(employeeVerifyId);
        //}
        #endregion
        #endregion

        #region TAB CLASS
        //TAB PANEL
        int activeIndex;
        string GetTabChipClass(int tabId)
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
        string GetTabTextClass(int tabId)
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
        RenderFragment tabHeader(int tabId)
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
                    builder.AddContent(6, "Step 1");
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
                    builder.AddContent(6, "Step 2");
                    builder.CloseComponent();
                }
                else if (tabId == 2)
                {
                    builder.OpenComponent<MudChip>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(2));
                    builder.AddAttribute(3, "Text", $"{tabId + 1}");
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(2));
                    builder.AddContent(6, "Step 3");
                    builder.CloseComponent();
                }
                else if (tabId == 3)
                {
                    builder.OpenComponent<MudChip>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(3));
                    builder.AddAttribute(3, "Text", $"{tabId + 1}");
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(3));
                    builder.AddContent(6, "Step 4");
                    builder.CloseComponent();
                }
                else if (tabId == 4)
                {
                    builder.OpenComponent<MudChip>(0);
                    builder.AddAttribute(1, "Class", @GetTabChipClass(4));
                    builder.AddAttribute(3, "Text", $"{tabId + 1}");
                    builder.CloseComponent();
                    builder.OpenElement(4, "span");
                    builder.AddAttribute(5, "class", @GetTabTextClass(4));
                    builder.AddContent(6, "Step 5");
                    builder.CloseComponent();
                }
            };
        }
        #endregion
    }
}
