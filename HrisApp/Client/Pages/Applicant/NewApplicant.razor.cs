using HrisApp.Shared.Models.App_Education;
using HrisApp.Shared.Models.App_LiscenseAndTraining;
using HrisApp.Shared.Models.Application.App_Family;
using HrisApp.Shared.Models.Application.App_LiscenseAndTraining;
using HrisApp.Shared.Models.Application.App_ProfBackground;

namespace HrisApp.Client.Pages.Applicant
{
    public partial class NewApplicant : ComponentBase
    {
#nullable disable
        MudTabs tabs;
        ApplicantT applicant = new();
        App_AddressT address = new();

        public List<GenderT> GendersL = new();
        public List<CivilStatusT> CivilStatusL = new();
        public List<ReligionT> ReligionsL = new();
        public List<EmerRelationshipT> EmerRelationshipsL = new();

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
