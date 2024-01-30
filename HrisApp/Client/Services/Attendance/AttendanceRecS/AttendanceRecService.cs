using System.Data;

namespace HrisApp.Client.Services.Attendance.AttendanceRecS
{
#nullable disable
    public class AttendanceRecService : IAttendanceRecService
    {
        MainsService _mainService = new MainsService();
        private readonly HttpClient _httpClient;
        public AttendanceRecService()
        {
            _httpClient = _mainService.Get_Http();
        }

        public List<AttendanceRecordT> AttendanceRecordTs { get; set; }

        public async Task CreateAttendanceRec(AttendanceRecordT obj)
        {
            var res = await _httpClient.PostAsJsonAsync("api/AttendanceRec/CreateAttendanceRecord", obj);
        }

        public async Task GetAttendanceRec()
        {
            var res = await _httpClient.GetFromJsonAsync<List<AttendanceRecordT>>("api/AttendanceRec/GetAttendanceRecord");
            if (res != null)
            {
                AttendanceRecordTs = res;
            }
        }

        public async Task<List<AttendanceRecordT>> GetAttendanceRecList()
        {
            var res = await _httpClient.GetFromJsonAsync<List<AttendanceRecordT>>("api/AttendanceRec");
            if (res != null)
            {
                return res;
            }
            else { return null; }
        }

        public async Task<AttendanceRecordT> GetSingleAttendanceRec(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<AttendanceRecordT>($"api/AttendanceRec/{id}");
            if (result != null)
            {
                return result;
            }
            throw new Exception("employee not found");
        }

        //GET NUMBER OBJECTS COUNT
        public async Task<int> GetExistingCount(string time, string no, string state)
        {
            return await _httpClient.GetFromJsonAsync<int>($"api/AttendanceRec/GetExistingObj?time={time}&no={no}&state={state}");
        }


        //SAVING  / IMPORT OBJECTS FROM EXCEL
        public async Task<string> QueryAttendanceForUpload(DataTable dtable, string filename)
        {
            try
            {
                if (filename.Contains("Attendance_Template"))
                {
                    int colCount = 7;
                    int colnumCount = dtable.Columns.Count;

                    if (colCount == colnumCount)
                    {
                        for (int a = 0; a < dtable.Rows.Count; a++)
                        {
                            //SETTING VARIABLES VALUE FROM EXCEL
                            var acno = dtable.Rows[a][0].ToString();
                            var name = dtable.Rows[a][1].ToString();
                            var time = dtable.Rows[a][2].ToString();
                            var state = dtable.Rows[a][3].ToString();
                            var newstate = dtable.Rows[a][4].ToString();
                            var ex = dtable.Rows[a][5].ToString();
                            var op = dtable.Rows[a][6].ToString();

                            DateTime? datetime = string.IsNullOrWhiteSpace(time) ? (DateTime?)null : Convert.ToDateTime(time);

                            AttendanceRecordT obj = new()
                            {
                                AC_No = acno,
                                Name = name,
                                Time = datetime,
                                State = state,
                                NewState = newstate,
                                Exception = ex,
                                Operation = op
                            };

                            //CHECK IF THE OBJECT ALREADY EXISTS
                            if (obj.Exception == "OK")
                            {
                                //IF NOT EXISTS SAVE TO DATABASE
                                await CreateAttendanceRec(obj);
                            }
                        }
                        return TokenCons.IsSuccess;
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
                Console.WriteLine(ex);
                Console.WriteLine(ex.Message);
                return ex.Message.ToString();
            }
        }


    }
}
