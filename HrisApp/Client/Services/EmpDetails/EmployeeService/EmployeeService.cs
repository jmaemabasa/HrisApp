using HrisApp.Client.HelperToken;
using NPOI.SS.Formula.Functions;
using System.ComponentModel.Design;
using System.Data;
using System.Net.Http;

namespace HrisApp.Client.Services.EmpDetails.EmployeeService
{
#nullable disable
    public class EmployeeService : IEmployeeService
    {
        public HttpClient _httpClient;
        MainsService _mainService = new MainsService();
        public EmployeeService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<EmployeeT> EmployeeTs { get; set; } = new List<EmployeeT>();

        public async Task<List<EmployeeT>> GetEmployeeList()
        {
            return await _httpClient.GetFromJsonAsync<List<EmployeeT>>("api/Employee");
        }

        public async Task GetEmployee()
        {
            var result = await _httpClient.GetFromJsonAsync<List<EmployeeT>>("api/Employee/GetEmployee");
            if (result != null)
            {
                EmployeeTs = result;
            }
        }

        public async Task<EmployeeT> GetSingleEmployee(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EmployeeT>($"api/Employee/{id}");
            if (result != null)
                return result;
            throw new Exception("employee not found");

        }

        public async Task<EmployeeT> GetSingleEmployeeByVerId(string verId)
        {
            var result = await _httpClient.GetFromJsonAsync<EmployeeT>($"api/Employee/GetSingleEmployeeByVerId/{verId}");
            if (result != null)
                return result;
            throw new Exception("employee not found");

        }

        public async Task SetEmployees(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<EmployeeT>>();
            EmployeeTs = response;
        }

        public async Task<string> CreateEmployee(EmployeeT employee)
        {
            Console.WriteLine("Saving Services sa create employee");


            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/Employee/CreateEmployee", employee);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error: " + errorMessage);
            }
            return employee.Verify_Id;

        }
        public async Task UpdateEmployee(EmployeeT employee)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Employee/{employee.Id}", employee);
            await SetEmployees(result);
        }

        public async Task DeleteEmployee(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/Employee/{id}");
            //await SetEmployees(result);
        }

        public async Task<string> Getname(int id)
        {
            var returnlist = await _httpClient.GetFromJsonAsync<List<EmployeeT>>($"api/Employee/GetEmpName/{id}");


            var returnmodel = returnlist.Where(e => e.Id == id).FirstOrDefault();

            return $"{CapitalizeFirstLetter(returnmodel.FirstName)} {CapitalizeFirstLetter(returnmodel.LastName)}";
        }

        public string CapitalizeFirstLetter(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return char.ToUpper(input[0]) + input[1..];
        }

        public async Task<int> GetCountEmployee()
        {
            var response = await _httpClient.GetFromJsonAsync<int>("api/Employee/EmployeeCount");
            return response;
        }


        public async Task<HttpResponseMessage> EmpDetailsPrint(string verid)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Report/GetReport?verid={verid}");
                return response;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"HttpResponse : {ex.Message}");
                return null;
            }
        }

        public async Task<string> EmpDetailsGenerate(string verid)
        {
            try
            {
                var result = await EmpDetailsPrint(verid);
                var url = result.RequestMessage.RequestUri.ToString();
                return url;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"String Response : {ex.Message}");
                return null;
            }
        }


        public async Task<string> QueryEmployeeForUpload(DataTable dtable, string filename)
        {
            try
            {
                if (filename.Contains("EmployeeDataTemplate"))
                {
                    int colCount = 45;
                    int colnumCount = dtable.Columns.Count;

                    if (colCount == colnumCount)
                    {
                        if (dtable.Rows.Count == 0)
                        {
                            return TokenCons.MISSINGFIELD;
                        }
                        else
                        {
                            var hhmm = DateTime.Now.ToString("hhmm");
                            var ssff = DateTime.Now.ToString("ssfff");

                            for (int a = 0; a < dtable.Rows.Count; a++)
                            {
                                var lastname = dtable.Rows[a][0].ToString();
                                var firstname = dtable.Rows[a][1].ToString();
                                var middlename = dtable.Rows[a][2].ToString();
                                var suffix = dtable.Rows[a][3].ToString();
                                var dob = dtable.Rows[a][4].ToString();
                                var age = dtable.Rows[a][5].ToString();
                                var gender = dtable.Rows[a][6].ToString();
                                var civils = dtable.Rows[a][7].ToString();
                                var nationality = dtable.Rows[a][8].ToString();
                                var religion = dtable.Rows[a][9].ToString();
                                var mobileno = dtable.Rows[a][10].ToString();
                                var email = dtable.Rows[a][11].ToString();
                                var sss = dtable.Rows[a][12].ToString();
                                var philhealth = dtable.Rows[a][13].ToString();
                                var hdmf = dtable.Rows[a][14].ToString();
                                var pagibig = dtable.Rows[a][15].ToString();
                                var tin = dtable.Rows[a][16].ToString();
                                var companyno = dtable.Rows[a][17].ToString();
                                var biometricid = dtable.Rows[a][18].ToString();
                                var area = dtable.Rows[a][19].ToString();
                                var status = dtable.Rows[a][20].ToString();
                                var employmentstatus = dtable.Rows[a][21].ToString();
                                var datehired = dtable.Rows[a][22].ToString();
                                var regularization = dtable.Rows[a][23].ToString();
                                var division = dtable.Rows[a][24].ToString();
                                var dep = dtable.Rows[a][25].ToString();
                                var sec = dtable.Rows[a][26].ToString();
                                var position = dtable.Rows[a][27].ToString();
                                var basicsalary = dtable.Rows[a][28].ToString();
                                var ratetype = dtable.Rows[a][29].ToString();
                                var cashbond = dtable.Rows[a][30].ToString();
                                var emername = dtable.Rows[a][31].ToString();
                                var emerrel = dtable.Rows[a][32].ToString();
                                var emeraddress = dtable.Rows[a][33].ToString();
                                var emermobile = dtable.Rows[a][34].ToString();

                                var curradd = dtable.Rows[a][35].ToString();
                                var currcity = dtable.Rows[a][36].ToString();
                                var currprov = dtable.Rows[a][37].ToString();
                                var currzip = dtable.Rows[a][38].ToString();
                                var currcountry = dtable.Rows[a][39].ToString();
                                var permadd = dtable.Rows[a][40].ToString();
                                var permcity = dtable.Rows[a][41].ToString();
                                var permprov = dtable.Rows[a][42].ToString();
                                var permzip = dtable.Rows[a][43].ToString();
                                var permcountry = dtable.Rows[a][44].ToString();


                                DateTime outreg = Convert.ToDateTime(regularization);
                                var outdate = outreg.ToString("yyyyMMdd");
                                var verifyformat = $"{outdate}{hhmm}{ssff}";

                                #region SETTING FK ID
                                var depid = await _httpClient.GetFromJsonAsync<int>($"api/Department/GetDepartmentId/{dep}");
                                var areaid = await _httpClient.GetFromJsonAsync<int>($"api/Area/GetAreaId/{area}");
                                var divisionid = await _httpClient.GetFromJsonAsync<int>($"api/Division/GetDivisionId/{division}");
                                int secid = sec == "None" ? 0 : await _httpClient.GetFromJsonAsync<int>($"api/Section/GetSectionId/{sec}");
                                var genderid = await _httpClient.GetFromJsonAsync<int>($"api/Static/GetGenderId/{gender}");
                                var csid = await _httpClient.GetFromJsonAsync<int>($"api/Static/GetCivilStatusId/{civils}");
                                var statusid = await _httpClient.GetFromJsonAsync<int>($"api/Static/GetStatusId/{status}");
                                var empstatusid = await _httpClient.GetFromJsonAsync<int>($"api/Static/GetEmploymentStatusId/{employmentstatus}");
                                var religionid = await _httpClient.GetFromJsonAsync<int>($"api/Static/GetReligionId/{religion}");
                                var erelid = await _httpClient.GetFromJsonAsync<int>($"api/Static/GetEmerRelationshipId/{emerrel}");
                                var ratetypeid = await _httpClient.GetFromJsonAsync<int>($"api/Static/GetRateTypeId/{ratetype}");
                                var cbid = await _httpClient.GetFromJsonAsync<int>($"api/Static/GetCashbondId/{cashbond}");
                                #endregion

                                var positionid = await _httpClient.GetFromJsonAsync<int>($"api/Position/GetSubPositionId/{position.Split(" - ").Last()}");


                                EmployeeT EmployeeModel = new EmployeeT()
                                {
                                    LastName = lastname,
                                    FirstName = firstname,
                                    MiddleName = middlename,
                                    Extension = suffix,
                                    Birthdate = Convert.ToDateTime(dob),
                                    Age = Convert.ToInt32(age),
                                    GenderId = genderid,
                                    CivilStatusId = csid,
                                    Nationality = nationality,
                                    ReligionId = religionid,
                                    MobileNumber = mobileno,
                                    Email = email,
                                    EmployeeNo = companyno,
                                    AreaId = areaid,
                                    StatusId = statusid,
                                    EmploymentStatusId = empstatusid,
                                    DateHired = Convert.ToDateTime(datehired),
                                    DivisionId = divisionid,
                                    DepartmentId = depid,
                                    SectionId = secid,
                                    PositionId = positionid,

                                    EmerName = emername,
                                    EmerRelationshipId = erelid,
                                    EmerAddress = emeraddress,
                                    EmerMobNum = emermobile,
                                    
                                    DateInactiveStatus = null,
                                    Verify_Id = verifyformat
                                };

                                Emp_AddressT AddressModel = new()
                                {
                                    CurrentAdd = curradd,
                                    CurrentCity = currcity,
                                    CurrentProvince = currprov,
                                    CurrentCountry = currcountry,
                                    CurrentZipCode = currzip,
                                    PermanentAdd = permadd,
                                    PermanentCity = permcity,
                                    PermanentCountry = permcountry,
                                    PermanentProvince = permprov,
                                    PermanentZipCode = permzip
                                };

                                Emp_PayrollT PayrollModel = new()
                                {
                                    Rate = basicsalary,
                                    RateTypeId = ratetypeid,
                                    CashbondId = cbid,
                                    SSSNum = sss,
                                    PhilHealthNum = philhealth,
                                    HDMFNum = hdmf,                                    
                                    TINNum = tin,
                                    ScheduleTypeId = 1,
                                    RestDayId = 1,
                                    BiometricID = biometricid
                                };

                                Emp_EmploymentDateT EmploymentDateModel = new()
                                {
                                    EmpmentStatusId = empstatusid,
                                    RegularizationDate = Convert.ToDateTime(regularization)
                                };

                                Emp_PosHistoryT PosHistoryModel = new()
                                {
                                    EmployeeId = 0,
                                    DateStarted = Convert.ToDateTime(datehired),
                                    NewAreaId = areaid,
                                    NewDivisionId = divisionid,
                                    NewDepartmentId = depid,
                                    NewSectionId = secid, 
                                    NewPositionId = positionid,
                                    newPositionCode = "IT01"
                                };

                                Emp_LeaveCreditT LEAVECREDITMODEL = new()
                                {
                                    EL = 0,
                                    ML = 0,
                                    PL = 0,
                                    SL = 0,
                                    VL = 0,
                                    OL = 0
                                };

                                var outletmass = await GetEmployeeExist(EmployeeModel.EmployeeNo);
                                if (outletmass == 0)
                                {
                                    var verifyId = await CreateEmployee(EmployeeModel);

                                    //address
                                    AddressModel.Verify_Id = verifyId;
                                    var adres = await _httpClient.PostAsJsonAsync("api/Address", AddressModel);

                                    //payroll
                                    PayrollModel.Verify_Id = verifyId;
                                    var savepayroll = await _httpClient.PostAsJsonAsync("api/Payroll", PayrollModel);

                                    //employment date
                                    EmploymentDateModel.Verify_Id = verifyId;
                                    var empDate = await _httpClient.PostAsJsonAsync("api/EmploymentDate", EmploymentDateModel);

                                    //CREATE EMPLOYEE HISTORY
                                    PosHistoryModel.Verify_Id = verifyId;
                                    var poshis = await _httpClient.PostAsJsonAsync("api/EmpHistory/CreateEmpHistory", PosHistoryModel);

                                    //foreval
                                    #region FOR EVALUATION MODEL
                                    int calculateMonth = 0;
                                    int totalMonth = 12;

                                    DateTime todayDate = DateTime.Now;
                                    calculateMonth = todayDate.Month - Convert.ToDateTime(datehired).Month;

                                    if (calculateMonth < 0)
                                    {
                                        calculateMonth += totalMonth;
                                    }
                                    else if (calculateMonth > 0)
                                    {
                                        Console.WriteLine("calmonth " + calculateMonth);
                                    }

                                    if (calculateMonth == 0)
                                    {
                                        if (Convert.ToDateTime(datehired).Year < DateTime.Now.Year - 1)
                                        {
                                            Emp_EvaluationT EvalModel = new()
                                            {
                                                Verify_Id = verifyId,
                                                Eval1Status = "Done",
                                                Eval2Status = "Done",
                                                Eval3Status = "Done",
                                                Eval4Status = "Done",
                                                Eval5Status = "Done",
                                                Eval6Status = "Done",
                                                EvalStatus = "Done",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                        else
                                        {
                                            Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                            {
                                                Verify_Id = verifyId,
                                                Eval1Status = "Pending",
                                                Eval2Status = "Pending",
                                                Eval3Status = "Pending",
                                                Eval4Status = "Pending",
                                                Eval5Status = "Pending",
                                                Eval6Status = "Pending",
                                                EvalStatus = "Pending",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                    }
                                    else if (calculateMonth == 1)
                                    {
                                        if (Convert.ToDateTime(datehired).Year < DateTime.Now.Year - 1)
                                        {
                                            Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                            {
                                                Verify_Id = verifyId,
                                                Eval1Status = "Done",
                                                Eval2Status = "Done",
                                                Eval3Status = "Done",
                                                Eval4Status = "Done",
                                                Eval5Status = "Done",
                                                Eval6Status = "Done",
                                                EvalStatus = "Done",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                        else
                                        {
                                            Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                            {
                                                Verify_Id = verifyId,
                                                Eval1Status = "Pending",
                                                Eval2Status = "Pending",
                                                Eval3Status = "Pending",
                                                Eval4Status = "Pending",
                                                Eval5Status = "Pending",
                                                Eval6Status = "Pending",
                                                EvalStatus = "Pending",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                    }
                                    else if (calculateMonth == 2)
                                    {
                                        if (Convert.ToDateTime(datehired).Year < DateTime.Now.Year - 1)
                                        {
                                            Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                            {
                                                Verify_Id = verifyId,
                                                Eval1Status = "Done",
                                                Eval2Status = "Done",
                                                Eval3Status = "Done",
                                                Eval4Status = "Done",
                                                Eval5Status = "Done",
                                                Eval6Status = "Done",
                                                EvalStatus = "Done",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                        else
                                        {
                                            Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                            {
                                                Verify_Id = verifyId,
                                                Eval1Status = "Done",
                                                Eval2Status = "Pending",
                                                Eval3Status = "Pending",
                                                Eval4Status = "Pending",
                                                Eval5Status = "Pending",
                                                Eval6Status = "Pending",
                                                EvalStatus = "Pending",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                    }
                                    else if (calculateMonth == 3)
                                    {
                                        if (Convert.ToDateTime(datehired).Year < DateTime.Now.Year - 1)
                                        {
                                            Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                            {
                                                Verify_Id = verifyId,
                                                Eval1Status = "Done",
                                                Eval2Status = "Done",
                                                Eval3Status = "Done",
                                                Eval4Status = "Done",
                                                Eval5Status = "Done",
                                                Eval6Status = "Done",
                                                EvalStatus = "Done",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                        else
                                        {
                                            Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                            {
                                                Verify_Id = verifyId,
                                                Eval1Status = "Done",
                                                Eval2Status = "Done",
                                                Eval3Status = "Pending",
                                                Eval4Status = "Pending",
                                                Eval5Status = "Pending",
                                                Eval6Status = "Pending",
                                                EvalStatus = "Pending",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                    }
                                    else if (calculateMonth == 4)
                                    {
                                        if (Convert.ToDateTime(datehired).Year < DateTime.Now.Year - 1)
                                        {
                                            Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                            {
                                                Verify_Id = verifyId,
                                                Eval1Status = "Done",
                                                Eval2Status = "Done",
                                                Eval3Status = "Done",
                                                Eval4Status = "Done",
                                                Eval5Status = "Done",
                                                Eval6Status = "Done",
                                                EvalStatus = "Done",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                        else
                                        {
                                            Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                            {
                                                Verify_Id = verifyformat,
                                                Eval1Status = "Done",
                                                Eval2Status = "Done",
                                                Eval3Status = "Done",
                                                Eval4Status = "Pending",
                                                Eval5Status = "Pending",
                                                Eval6Status = "Pending",
                                                EvalStatus = "Pending",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                    }
                                    else if (calculateMonth == 5)
                                    {
                                        if (Convert.ToDateTime(datehired).Year < DateTime.Now.Year - 1)
                                        {
                                            Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                            {
                                                Verify_Id = verifyId,
                                                Eval1Status = "Done",
                                                Eval2Status = "Done",
                                                Eval3Status = "Done",
                                                Eval4Status = "Done",
                                                Eval5Status = "Done",
                                                Eval6Status = "Done",
                                                EvalStatus = "Done",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                        else
                                        {

                                            Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                            {
                                                Verify_Id = verifyId,
                                                Eval1Status = "Done",
                                                Eval2Status = "Done",
                                                Eval3Status = "Done",
                                                Eval4Status = "Done",
                                                Eval5Status = "Pending",
                                                Eval6Status = "Pending",
                                                EvalStatus = "Pending",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                    }
                                    else if (calculateMonth == 6)
                                    {
                                        if (Convert.ToDateTime(datehired).Year < DateTime.Now.Year - 1)
                                        {
                                            Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                            {
                                                Verify_Id = verifyId,
                                                Eval1Status = "Done",
                                                Eval2Status = "Done",
                                                Eval3Status = "Done",
                                                Eval4Status = "Done",
                                                Eval5Status = "Done",
                                                Eval6Status = "Done",
                                                EvalStatus = "Done",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                        else
                                        {
                                            Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                            {
                                                Verify_Id = verifyId,
                                                Eval1Status = "Done",
                                                Eval2Status = "Done",
                                                Eval3Status = "Done",
                                                Eval4Status = "Done",
                                                Eval5Status = "Done",
                                                Eval6Status = "Pending",
                                                EvalStatus = "Pending",
                                                DateHired = Convert.ToDateTime(datehired),
                                                DateEvaluate = todayDate,
                                                TimesEvaluate = +1
                                            };
                                            var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                        }
                                    }
                                    else
                                    {
                                        Emp_EvaluationT EvalModel = new Emp_EvaluationT()
                                        {
                                            Verify_Id = verifyId,
                                            Eval1Status = "Done",
                                            Eval2Status = "Done",
                                            Eval3Status = "Done",
                                            Eval4Status = "Done",
                                            Eval5Status = "Done",
                                            Eval6Status = "Done",
                                            EvalStatus = "Done",
                                            DateHired = Convert.ToDateTime(datehired),
                                            DateEvaluate = todayDate,
                                            TimesEvaluate = +1
                                        };
                                        var saveeval = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", EvalModel);
                                    }

                                    #endregion

                                    //LEAVE CREDIT
                                    LEAVECREDITMODEL.Verify_Id = verifyId;
                                    var cred = await _httpClient.PostAsJsonAsync("api/LeaveCredit/CreateLeaveCredit", LEAVECREDITMODEL);


                                    #region UPDATE SUBPOSITION
                                    var subposup = await _httpClient.GetFromJsonAsync<SubPositionT>($"api/Position/GetSingleSubPosition/{positionid}");

                                    subposup.Status = "Active";
                                    subposup.Emp_VerifyId = verifyId;
                                    subposup.ActiveDate = Convert.ToDateTime(datehired);
                                    var updatesubpos = await _httpClient.PutAsJsonAsync($"api/Position/UpdateSubPosition", subposup);
                                    #endregion
                                }
                                else
                                {
                                    await UpdateEmployee(EmployeeModel);
                                }

                            }

                            return "Success";
                        }
                    }
                    else
                    {
                        return TokenCons.INVALIDFORMAT;
                    }
                }
                else
                {
                    return TokenCons.INVALIDFILE;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return ex.Message.ToString();
            }
        }

        public async Task<int> GetEmployeeExist(string companyId)
        {
            var response = await _httpClient.GetFromJsonAsync<int>($"api/Employee/GetEmployeeExist/{companyId}");
            return response;
        }

    }
}
