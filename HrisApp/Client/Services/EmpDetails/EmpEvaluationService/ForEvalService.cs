namespace HrisApp.Client.Services.EmpDetails.EmpEvaluationService
{
#nullable disable

    public class ForEvalService : IForEvalService
    {
        public HttpClient _httpClient;
        private MainsService _mainService = new MainsService();

        public ForEvalService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<Emp_EvaluationT> Emp_EvaluationTs { get; set; } = new List<Emp_EvaluationT>();

        private string statusEval { get; set; }

        public async Task<List<Emp_EvaluationT>> GetForEvallist(string verCode)
        {
            return await _httpClient.GetFromJsonAsync<List<Emp_EvaluationT>>($"api/EmpEvaluation/GetForEvallist?verCode={verCode}");
        }

        public async Task GetForEval()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Emp_EvaluationT>>("api/EmpEvaluation/GetForEval");
            if (result != null)
            {
                Emp_EvaluationTs = result;
            }
        }

        public async Task<Emp_EvaluationT> GetSingleEval(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Emp_EvaluationT>($"api/EmpEvaluation/{id}");
            if (result != null)
                return result;
            throw new Exception("eval not found");
        }

        public async Task<string> CreateForEval(Emp_EvaluationT eval)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("api/EmpEvaluation/CreateForEval", eval);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Error: " + errorMessage);
            }
            return eval.Verify_Id;
        }

        public async Task UpdateForEval(Emp_EvaluationT eval)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/EmpEvaluation/UpdateFinalStatus/{eval.Verify_Id}", eval);
            await SetEval(result);
        }

        public async Task SetEval(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Emp_EvaluationT>>();
            Emp_EvaluationTs = response;
        }

        public async Task<Emp_EvaluationT> GenerateStatus(string verifyId, DateTime datehired, string _evalStatus)
        {
            await Task.Delay(1);
            int calculateMonth = 0;
            int totalMonth = 12;

            DateTime todayDate = DateTime.Now;
            calculateMonth = todayDate.Month - datehired.Month;

            if (calculateMonth < 0)
            {
                calculateMonth += totalMonth;
            }
            else if (calculateMonth > 0)
            {
                Console.WriteLine("calmonth " + calculateMonth);
            }

            switch (calculateMonth)
            {
                case 0:
                    if (datehired.Year < DateTime.Now.Year - 1)
                    {
                        Emp_EvaluationT case0eval = new()
                        {
                            Verify_Id = verifyId,
                            Eval1Status = "Done",
                            Eval2Status = "Done",
                            Eval3Status = "Done",
                            Eval5Status = "Done",
                            EvalStatus = "Done",
                            DateHired = datehired,
                            DateEvaluate = todayDate,
                            TimesEvaluate = +1
                        };
                        return case0eval;
                    }
                    else
                    {
                        Emp_EvaluationT case0eval = new()
                        {
                            Verify_Id = verifyId,
                            Eval1Status = "Pending",
                            Eval2Status = "Pending",
                            Eval3Status = "Pending",
                            Eval5Status = "Pending",
                            EvalStatus = "Pending",
                            DateHired = datehired,
                            DateEvaluate = todayDate,
                            TimesEvaluate = +1
                        };
                        return case0eval;
                    }
                case 1:
                    if (datehired.Year < DateTime.Now.Year - 1)
                    {
                        Emp_EvaluationT case0eval = new()
                        {
                            Verify_Id = verifyId,
                            Eval1Status = "Done",
                            Eval2Status = "Done",
                            Eval3Status = "Done",
                            Eval5Status = "Done",
                            EvalStatus = "Done",
                            DateHired = datehired,
                            DateEvaluate = todayDate,
                            TimesEvaluate = +1
                        };
                        return case0eval;
                    }
                    else
                    {
                        Emp_EvaluationT case1eval = new()
                        {
                            Verify_Id = verifyId,
                            Eval1Status = _evalStatus,
                            Eval2Status = "Pending",
                            Eval3Status = "Pending",
                            Eval5Status = "Pending",
                            EvalStatus = "Pending",
                            DateHired = datehired,
                            DateEvaluate = todayDate,
                            TimesEvaluate = +1
                        };
                        return case1eval;
                    }
                case 2:
                    if (datehired.Year < DateTime.Now.Year - 1)
                    {
                        Emp_EvaluationT case0eval = new()
                        {
                            Verify_Id = verifyId,
                            Eval1Status = "Done",
                            Eval2Status = "Done",
                            Eval3Status = "Done",
                            Eval5Status = "Done",
                            EvalStatus = "Done",
                            DateHired = datehired,
                            DateEvaluate = todayDate,
                            TimesEvaluate = +1
                        };
                        return case0eval;
                    }
                    else
                    {
                        Emp_EvaluationT case2eval = new()
                        {
                            Verify_Id = verifyId,
                            Eval1Status = "Done",
                            Eval2Status = _evalStatus,
                            Eval3Status = "Pending",
                            Eval5Status = "Pending",
                            EvalStatus = "Pending",
                            DateHired = datehired,
                            DateEvaluate = todayDate,
                            TimesEvaluate = +1
                        };
                        return case2eval;
                    }
                case 3:
                    if (datehired.Year < DateTime.Now.Year - 1)
                    {
                        Emp_EvaluationT case0eval = new()
                        {
                            Verify_Id = verifyId,
                            Eval1Status = "Done",
                            Eval2Status = "Done",
                            Eval3Status = "Done",
                            Eval5Status = "Done",
                            EvalStatus = "Done",
                            DateHired = datehired,
                            DateEvaluate = todayDate,
                            TimesEvaluate = +1
                        };
                        return case0eval;
                    }
                    else
                    {
                        Emp_EvaluationT case3eval = new()
                        {
                            Verify_Id = verifyId,
                            Eval1Status = "Done",
                            Eval2Status = "Done",
                            Eval3Status = _evalStatus,
                            Eval5Status = "Pending",
                            EvalStatus = "Pending",
                            DateHired = datehired,
                            DateEvaluate = todayDate,
                            TimesEvaluate = +1
                        };
                        return case3eval;
                    }
                case 5:
                    if (datehired.Year < DateTime.Now.Year - 1)
                    {
                        Emp_EvaluationT case0eval = new()
                        {
                            Verify_Id = verifyId,
                            Eval1Status = "Done",
                            Eval2Status = "Done",
                            Eval3Status = "Done",
                            Eval5Status = "Done",
                            EvalStatus = "Done",
                            DateHired = datehired,
                            DateEvaluate = todayDate,
                            TimesEvaluate = +1
                        };
                        return case0eval;
                    }
                    else
                    {
                        Emp_EvaluationT case5eval = new()
                        {
                            Verify_Id = verifyId,
                            Eval1Status = "Done",
                            Eval2Status = "Done",
                            Eval3Status = "Done",
                            Eval5Status = _evalStatus,
                            EvalStatus = "Done",
                            DateHired = datehired,
                            DateEvaluate = todayDate,
                            TimesEvaluate = +1
                        };
                        return case5eval;
                    }
                default:
                    Emp_EvaluationT defaulteval = new Emp_EvaluationT()
                    {
                        Verify_Id = verifyId,
                        Eval1Status = "Done",
                        Eval2Status = "Done",
                        Eval3Status = "Done",
                        Eval5Status = "Done",
                        EvalStatus = "Done",
                        DateHired = datehired,
                        DateEvaluate = todayDate,
                        TimesEvaluate = +1
                    };
                    return defaulteval;
            }
        }

        public async Task<string> GetStatusPerEmp(string verifyId)
        {
            var masterData = await _httpClient.GetFromJsonAsync<List<Emp_EvaluationT>>("api/EmpEvaluation/GetForEval");
            var returnModel = masterData.Where(e => e.Verify_Id == verifyId).FirstOrDefault();

            return returnModel.EvalStatus;
        }

        public string GetStatusForEval(string verifyId)
        {
            var returnstring = "";
            foreach (var item in Emp_EvaluationTs)
            {
                if (verifyId == item.Verify_Id)
                {
                    returnstring = item.EvalStatus;
                    return returnstring;
                }
            }
            return returnstring;
        }

        private async void GetStat(string verifyId)
        {
            var masterData = await _httpClient.GetFromJsonAsync<List<Emp_EvaluationT>>("api/EmpEvaluation/GetForEval");
            var returnModel = masterData.Where(e => e.Verify_Id == verifyId).FirstOrDefault();

            statusEval = returnModel.EvalStatus;
        }
    }
}