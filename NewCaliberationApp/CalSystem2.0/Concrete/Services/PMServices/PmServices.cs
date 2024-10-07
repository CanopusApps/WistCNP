using CalSystem2._0.Concrete.IServices.ICommonServices;
using CalSystem2._0.Concrete.IServices.IPMServices;
using CalSystem2._0.Concrete.Services.CommonServices;
using CalSystem2._0.DataContext;
using CalSystem2._0.Entities;
using ExcelDataReader;
using Microsoft.EntityFrameworkCore;
using System;
using System.Text;
using System.Text.RegularExpressions;
using static CalSystem2._0.Models.CommonModel.PagedResponseModels;
using static CalSystem2._0.Models.CommonModel.ResponseModels;
using static CalSystem2._0.Models.PmDetailsModel.PmDataModel;

namespace CalSystem2._0.Concrete.Services.PMServices
{
    public class PmServices : IPmServices
    {
        private readonly ApplicationDbContext _context;
        private readonly ICurrentUserServices _currentUserServices;

        public PmServices(ApplicationDbContext context, ICurrentUserServices currentUserServices)
        {
            _currentUserServices = currentUserServices;
            _context = context;
        }

        public async Task<ApiResponse> AddPmDetailsAdd(PMScheduleModel model, bool isAuto)
        {
            var result = await _context.Pmdetails.FirstOrDefaultAsync(x => x.MachineidSn == model.MachineIdSn);
            if (result == null)
            {
                var pm = new Pmdetail
                {
                    Machinecategory = model.MachineCategory,
                    MachineidSn = model.MachineIdSn,
                    Machinename = model.MachineName,
                    Machinelocation = model.MachineLocation,
                    Pmmanager = model.PmManager,
                    Make = model.Make,
                    Checklistno = model.ChecklistNo,
                    Firsttimepmscheduledate = model.FirstTimePmScheduleDate,
                    Ischecked = 0,
                    Line = model.Line,
                    Vendordri = model.VendorDRI,
                    Project = model.Project,
                    TataDriname = model.TataDRIName,
                    Subline = model.SubLine
                };
                var frequen = ParseFrequency(model.Frequency).value.ToString();
                pm.Frequency = frequen;
                bool isMonth = ParseFrequency(model.Frequency).unit.Equals("month");

                await _context.Pmdetails.AddAsync(pm);

                var resultsche = await _context.Pmscheduledetails.FirstOrDefaultAsync(x => x.MachineidSn == model.MachineIdSn);
                if (result == null)
                {
                    if (isAuto)
                    {
                        var schedule = new Pmscheduledetail
                        {
                            MachineidSn = model.MachineIdSn,
                            Currentpmstatus = (model.CurrentPmStatus) ? 1 : 0,
                            Dccchecklistlink = model.DccCheckListLink,
                            Engineeringmanager = model.EngineeringManager,
                            Toollist = model.ToolList,
                            Pmadherence = model.PmAdherence,
                            Pmdurationhrs = model.PmDurationHrs,
                            Actualpmdate = model.ActualPmDate,
                            // Onedayalert = model.OneDayAlert,
                            // Onedayafter = model.OneDayAfter,
                            // Twodaysafter =model.TwoDaysAfter,
                            // Threedaysafter = model.ThreeDaysAfter,
                            // Threedaysalert = model.ThreeDaysAfter,
                            // Secondtimepmschedule=model.SecondTimePmSchedule,
                            // Thirdtimepmschedule=model.ThirdTimePmSchedule,
                            // Fourthtimepmschedule = model.FourthTimePmSchedule,
                            // Fifthtimepmschedule = model.FourthTimePmSchedule,
                            // Sixthtimepmschedule = model.SixthTimePmSchedule,
                            // Seventhtimepmschedule = model.SeventhTimePmSchedule,
                            // Eighthtimepmschedule = model.EighthTimePmSchedule,
                            // Ninthtimepmschedule = model.NinthTimePmSchedule,
                            // Tenthtimepmschedule = model.TenthTimePmSchedule,
                            // Eleventhtimepmschedule = model.EleventhTimePmSchedule,
                            // Twelfthtimepmschedule=model.TwelfthTimePmSchedule,
                            // Headcountsize = model.HeadCountSize,
                            // Planthead = model.PlantHead,
                            // Pmworkflow = model.PmWorkFlow,
                            // Pmscheduleflow = model.PmScheduleFlow,
                            // Requiredcriticalsparepartlist = model.RequiredCriticalSparePartList,
                            // Month = model.Month,
                            // Modified = model.Modified,
                            // Created = model.Created,

                            Createdby = _currentUserServices.EmpID,
                            //Modifiedby = model.ModifiedBy
                        };
                        var dates = PmDateSunday(model.FirstTimePmScheduleDate, frequen, isMonth);
                        schedule.Secondtimepmschedule = dates.FirstTimePmSchedule;
                        schedule.Thirdtimepmschedule = dates.SecondTimePmSchedule;
                        schedule.Fourthtimepmschedule = dates.ThirdTimePmSchedule;
                        schedule.Fifthtimepmschedule = dates.FourthTimePmSchedule;
                        schedule.Sixthtimepmschedule = dates.FourthTimePmSchedule;
                        schedule.Seventhtimepmschedule = dates.SixthTimePmSchedule;
                        schedule.Eighthtimepmschedule = dates.SeventhTimePmSchedule;
                        schedule.Ninthtimepmschedule = dates.EighthTimePmSchedule;
                        schedule.Tenthtimepmschedule = dates.NinthTimePmSchedule;
                        schedule.Eleventhtimepmschedule = dates.TenthTimePmSchedule;
                        schedule.Twelfthtimepmschedule = dates.EleventhTimePmSchedule;
                        await _context.Pmscheduledetails.AddAsync(schedule);
                    }

                    else
                    {
                        var schedule = new Pmscheduledetail
                        {
                            MachineidSn = model.MachineIdSn
                        };
                    }
                }
                else
                {
                    return new(400, $"MachineIdSn id Allready Existes {model.MachineIdSn}");
                }
                await _context.SaveChangesAsync();
                await Dayalert(model.MachineIdSn);
                return new(200, "Pm added SucessFully");
            }
            return new(400, $"MachineIdSn id Allready Existes {model.MachineIdSn}");
        }
        public async Task<bool> Dayalert(string machineIdSn)
        {
            var result = await _context.Pmscheduledetails
                                       .FirstOrDefaultAsync(x => x.MachineidSn == machineIdSn);

            if (result == null)
            {
                return false;
            }

            DateTime today = DateTime.Today;

            DateTime?[] scheduleDates =
            {
                result.Secondtimepmschedule,
                result.Thirdtimepmschedule,
                result.Fourthtimepmschedule,
                result.Fifthtimepmschedule,
                result.Sixthtimepmschedule,
                result.Seventhtimepmschedule,
                result.Eighthtimepmschedule,
                result.Ninthtimepmschedule,
                result.Tenthtimepmschedule,
                result.Eleventhtimepmschedule,
                result.Twelfthtimepmschedule
            };

            var upcomingDates = scheduleDates
         .Where(date => date.HasValue && date.Value > today)
         .OrderBy(date => date.Value)
         .ToList();

            if (upcomingDates.Any())
            {
                DateTime earliestDate = upcomingDates.First().Value;
                result.Onedayalert = earliestDate.AddDays(-3);
                // result.Twodaysafter = earliestDate.AddDays(-2); 
                result.Threedaysalert = earliestDate.AddDays(-1);
                result.Onedayafter = earliestDate.AddDays(2);
                result.Twodaysafter = earliestDate.AddDays(3);
            }
            else
            {
                result.Onedayalert = null;
                result.Twodaysafter = null;
                result.Threedaysalert = null;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        public static (int value, string unit) ParseFrequency(string frequency)
        {
            var match = Regex.Match(frequency, @"^(\d+)\s*(Week|Month)$", RegexOptions.IgnoreCase);

            if (match.Success)
            {
                int value = int.Parse(match.Groups[1].Value);
                string unit = match.Groups[2].Value.ToLower();

                return (value, unit);
            }

            return (0, null);
        }

        //public static DateTime PmDateSunday(DateTime inputDate, string frequency)
        //{
        //    if (int.TryParse(frequency, out int duration))
        //    {
        //        DateTime targetDate = inputDate.AddDays(duration);

        //        int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)targetDate.DayOfWeek + 7) % 7;
        //        DateTime nextSunday = targetDate.AddDays(daysUntilSunday);

        //        return nextSunday;
        //    }
        //    else
        //    {
        //        throw new ArgumentException("Invalid frequency value. Please enter a valid integer.");
        //    }
        //}
        public static DateModel PmDateSunday(DateTime inputDate, string frequencyInDays, bool isMonth)
        {
            if (int.TryParse(frequencyInDays, out int duration))
            {
                DateModel model = new DateModel();
                DateTime currentDate = inputDate;

                DateTime?[] properties = new DateTime?[]
                {
                    model.FirstTimePmSchedule,
                    model.SecondTimePmSchedule,
                    model.ThirdTimePmSchedule,
                    model.FourthTimePmSchedule,
                    model.FifthTimePmSchedule,
                    model.SixthTimePmSchedule,
                    model.SeventhTimePmSchedule,
                    model.EighthTimePmSchedule,
                    model.NinthTimePmSchedule,
                    model.TenthTimePmSchedule,
                    model.EleventhTimePmSchedule,
                    model.TwelfthTimePmSchedule
                };

                for (int i = 1; i < properties.Length; i++)
                {
                    DateTime targetDate;

                    targetDate = isMonth ? currentDate.AddMonths(i * duration) : currentDate.AddDays(i * duration * 7);

                    int daysUntilSunday = ((int)DayOfWeek.Sunday - (int)targetDate.DayOfWeek + 7) % 7;
                    DateTime nextSunday = targetDate.AddDays(daysUntilSunday);

                    properties[i - 1] = nextSunday;
                }

                model.FirstTimePmSchedule = properties[0];
                model.SecondTimePmSchedule = properties[1];
                model.ThirdTimePmSchedule = properties[2];
                model.FourthTimePmSchedule = properties[3];
                model.FifthTimePmSchedule = properties[4];
                model.SixthTimePmSchedule = properties[5];
                model.SeventhTimePmSchedule = properties[6];
                model.EighthTimePmSchedule = properties[7];
                model.NinthTimePmSchedule = properties[8];
                model.TenthTimePmSchedule = properties[9];
                model.EleventhTimePmSchedule = properties[10];
                model.TwelfthTimePmSchedule = properties[11];

                return model;
            }
            else
            {
                throw new ArgumentException("Invalid frequency value. Please enter a valid integer.");
            }
        }


        public async Task<ApiResponse> UploadExcel(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return new(400, "No file uploaded.");
            }

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var schedules = new List<PMScheduleModel>();

            try
            {
                using (var stream = file.OpenReadStream())
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true
                        }
                    });

                    var dataTable = dataSet.Tables.Count > 0 ? dataSet.Tables[0] : null;

                    if (dataTable == null)
                    {
                        return new(400, "No data found in the file.");
                    }

                    for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
                    {
                        var row = dataTable.Rows[rowIndex];

                        if (row == null || row.ItemArray.Length < 21)
                        {
                            return new(400, $"Invalid data format at row {rowIndex + 1}.");
                        }

                        try
                        {
                            var schedule = new PMScheduleModel
                            {
                                MachineIdSn = row[0]?.ToString(),
                                MachineName = row[1]?.ToString(),
                                Project = row[2]?.ToString(),
                                Line = row[3]?.ToString(),
                                SubLine = row[4]?.ToString(),
                                MachineLocation = row[5]?.ToString(),
                                Make = row[6]?.ToString(),
                                ChecklistNo = row[7]?.ToString(),
                                MachineCategory = row[8]?.ToString(),
                                TataDRIName = row[9]?.ToString(),
                                VendorDRI = row[10]?.ToString(),
                                FirstTimePmScheduleDate = DateTime.TryParse(row[11]?.ToString(), out var date) ? date : default,
                                Frequency = row[12]?.ToString(),
                                PmDurationHrs = row[13]?.ToString(),
                                ActualPmDate = DateTime.TryParse(row[14]?.ToString(), out var actualDate) ? actualDate : (DateTime?)null,
                                PmAdherence = row[15]?.ToString(),
                                // CurrentPmStatus = bool.TryParse(row[16]?.ToString(), out var status) ? status : false,
                                CurrentPmStatus = (row[16]?.ToString()).Equals("OPEN"),
                                PmManager = row[17]?.ToString(),
                                EngineeringManager = row[18]?.ToString(),
                                DccCheckListLink = row[19]?.ToString(),
                                ToolList = row[20]?.ToString()
                            };

                            schedules.Add(schedule);
                        }
                        catch (FormatException ex)
                        {
                            return new(400, $"Error parsing data at row {rowIndex + 1}: {ex.Message}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex}");
                return new(StatusCodes.Status500InternalServerError, $"Internal server error: {ex.Message}");
            }
            foreach (var data in schedules)
            {
                try
                {
                    var res = await AddPmDetailsAdd(data, true);
                    if (res.StatusCode == 400)
                    {
                        return new(400, res.Message);
                    }
                }
                catch (Exception ex)
                {
                    return new(400, ex.Message + "Error while adding pm " + $"{data.MachineIdSn}");
                }
            }
            return new(200, "Added sucessfully");
        }

        public async Task<ApiResponse> DeletePM(PmIdModel model)
        {
            var machineIdSn = model.MachineIdSn;
            var result = await _context.Pmdetails.FirstOrDefaultAsync(s => s.MachineidSn == machineIdSn); ;
            if (result == null)
            {
                return new(400, $"MachineIdSn {machineIdSn} not exsit in Pmdetails Table");
            }
            _context.Pmdetails.Remove(result);
            var results = await _context.Pmscheduledetails.FirstOrDefaultAsync(s => s.MachineidSn == machineIdSn); ;
            if (result == null)
            {
                return new(400, $"MachineIdSn {machineIdSn} not exsit in Pmdetails Table");
            }
            _context.Pmscheduledetails.Remove(results);
            await _context.SaveChangesAsync();
            return new(200, $"MachineIdSn {machineIdSn} Removed");
        }

        //public async Task<ServiceResponse<List<PMScheduleModel>>> GetPmdeatilsAll()
        //{
        //    try
        //    {
        //        var pmDetailsList = await _context.Pmdetails.ToListAsync();
        //        var pmScheduleDetailsList = await _context.Pmscheduledetails.ToListAsync();

        //        var pmDetails = from pd in pmDetailsList
        //                        join ps in pmScheduleDetailsList
        //                        on pd.MachineidSn equals ps.MachineidSn
        //                        select new PMScheduleModel
        //                        {
        //                            MachineIdSn = pd.MachineidSn,
        //                            IsCheck = pd.Ischecked == 1,
        //                            LastCheck = pd.Lastcheck.HasValue ? DateOnly.FromDateTime(pd.Lastcheck.Value) : (DateOnly?)null,
        //                            MachineName = pd.Machinename,
        //                            Project = pd.Project,
        //                            Line = pd.Line,
        //                            SubLine = pd.Subline,
        //                            MachineLocation = pd.Machinelocation,
        //                            Make = pd.Make,
        //                            ChecklistNo = pd.Checklistno,
        //                            MachineCategory = pd.Machinecategory,
        //                            TataDRIName = pd.TataDriname,
        //                            VendorDRI = pd.Vendordri,
        //                            FirstTimePmScheduleDate = pd.Firsttimepmscheduledate,
        //                            Frequency = pd.Frequency,

        //                            // Use integer comparison for boolean-like fields
        //                            PmDurationHrs = ps.Pmdurationhrs,
        //                            ActualPmDate = ps.Actualpmdate,
        //                            PmAdherence = ps.Pmadherence,
        //                            CurrentPmStatus = ps.Currentpmstatus != 0, // Adjusted to handle non-zero as true
        //                            PmManager = pd.Pmmanager,
        //                            EngineeringManager = ps.Engineeringmanager,
        //                            DccCheckListLink = ps.Dccchecklistlink,
        //                            ToolList = ps.Toollist
        //                        };

        //        var pmDetailsListResult = pmDetails.ToList();

        //        if (pmDetailsListResult == null || !pmDetailsListResult.Any())
        //        {
        //            return new ServiceResponse<List<PMScheduleModel>>(200, "No data found.", new List<PMScheduleModel>());
        //        }

        //        return new ServiceResponse<List<PMScheduleModel>>(200, "Data retrieved successfully.", pmDetailsListResult);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new ServiceResponse<List<PMScheduleModel>>(500, $"An error occurred: {ex.Message}", null);
        //    }
        //}

        public async Task<ServiceResponses<List<PMScheduleModel>>> GetPmdeatilsAll(string searchTerm = null,int pageNumber = 1,int pageSize = 10)
        {
            try
            {
                var pmDetailsList = await _context.Pmdetails.ToListAsync();
                var pmScheduleDetailsList = await _context.Pmscheduledetails.ToListAsync();

                var pmDetailsQuery =  from pd in pmDetailsList
                                     join ps in pmScheduleDetailsList
                                     on pd.MachineidSn equals ps.MachineidSn
                                     select new PMScheduleModel
                                     {
                                         MachineIdSn = pd.MachineidSn,
                                         IsCheck = pd.Ischecked == 1,
                                         LastCheck = pd.Lastcheck.HasValue ? DateOnly.FromDateTime(pd.Lastcheck.Value) : (DateOnly?)null,
                                         MachineName = pd.Machinename,
                                         Project = pd.Project,
                                         Line = pd.Line,
                                         SubLine = pd.Subline,
                                         MachineLocation = pd.Machinelocation,
                                         Make = pd.Make,
                                         ChecklistNo = pd.Checklistno,
                                         MachineCategory = pd.Machinecategory,
                                         TataDRIName = pd.TataDriname,
                                         VendorDRI = pd.Vendordri,
                                         FirstTimePmScheduleDate = pd.Firsttimepmscheduledate,
                                         Frequency = pd.Frequency,
                                         PmDurationHrs = ps.Pmdurationhrs,
                                         ActualPmDate = ps.Actualpmdate,
                                         PmAdherence = ps.Pmadherence,
                                         CurrentPmStatus = ps.Currentpmstatus != 0, 
                                         PmManager = pd.Pmmanager,
                                         EngineeringManager = ps.Engineeringmanager,
                                         DccCheckListLink = ps.Dccchecklistlink,
                                         ToolList = ps.Toollist
                                     };

                if (!string.IsNullOrWhiteSpace(searchTerm))
                {
                    pmDetailsQuery = pmDetailsQuery
                        .Where(p => p.MachineIdSn.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) );
                }

                var totalRecords = pmDetailsQuery.Count();

                var pmDetailsListResult =  pmDetailsQuery
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

                if (!pmDetailsListResult.Any())
                {
                    return new (200, "No data found.", new List<PMScheduleModel>());
                }

                return new (200, "Data retrieved successfully.", pmDetailsListResult)
                {
                    TotalCount = totalRecords,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                };
            }
            catch (Exception ex)
            {
                return new(500, $"An error occurred: {ex.Message}", null);
            }
        }





        public async Task<ServiceResponse<ScheduleModel>> GetScheduleList(PmIdModel model)
        {
            var result = await _context.Pmscheduledetails
         .Where(x => x.MachineidSn == model.MachineIdSn)
         .Select(s => new ScheduleModel
         {
             MachineIdSn = s.MachineidSn,
             //PmDurationHrs = s.Pmdurationhrs,
             //ActualPmDate = s.Actualpmdate,
             //PmAdherence = s.Pmadherence,
             //CurrentPmStatus = s.Currentpmstatus,
             //ToolList = s.Toollist,
             RequiredCriticalSparePartList = s.Requiredcriticalsparepartlist,
             //HeadcountSize = s.Headcountsize,
             //DccChecklistLink = s.Dccchecklistlink,
             PlantHead = s.Planthead,
             PmScheduleFlow = s.Pmscheduleflow,
             ThreeDaysAlert = s.Threedaysalert,
             OneDayAlert = s.Onedayalert,
             OneDayAfter = s.Onedayafter,
             TwoDaysAfter = s.Twodaysafter,
             ThreeDaysAfter = s.Threedaysafter,
             SecondTimePmSchedule = s.Secondtimepmschedule,
             ThirdTimePmSchedule = s.Thirdtimepmschedule,
             FourthTimePmSchedule = s.Fourthtimepmschedule,
             FifthTimePmSchedule = s.Fifthtimepmschedule,
             SixthTimePmSchedule = s.Sixthtimepmschedule,
             SeventhTimePmSchedule = s.Seventhtimepmschedule,
             EighthTimePmSchedule = s.Eighthtimepmschedule,
             NinthTimePmSchedule = s.Ninthtimepmschedule,
             TenthTimePmSchedule = s.Tenthtimepmschedule,
             EleventhTimePmSchedule = s.Eleventhtimepmschedule,
             TwelfthTimePmSchedule = s.Twelfthtimepmschedule,
             PmWorkFlow = s.Pmworkflow,
             Month = s.Month,
             Modified = s.Modified,
             Created = s.Created,
             CreatedBy = s.Createdby,
             ModifiedBy = s.Modifiedby,
             HeadCountSize = s.Headcountsize
         })
         .FirstOrDefaultAsync();
            result.FirstTimePmSchedule = await _context.Pmdetails.Where(s => s.MachineidSn == model.MachineIdSn).Select(x => x.Firsttimepmscheduledate).FirstOrDefaultAsync();
            if (result == null)
            {
                return new(400, "", null);
            }
            return new(200, "Sucess", result);
        }

        public async Task<ServiceResponse<string>> UpdatePmSchedule(ScheduleModel model, string machineId)
        {
            var result = await _context.Pmscheduledetails.FirstOrDefaultAsync(x => x.MachineidSn == machineId);
            if (result != null)
            {
                result.Planthead = model.PlantHead;
                result.Pmscheduleflow = model.PmScheduleFlow;
                result.Threedaysalert = model.ThreeDaysAlert;
                result.Onedayalert = model.OneDayAlert;
                result.Onedayafter = model.OneDayAfter;
                result.Twodaysafter = model.TwoDaysAfter;
                result.Threedaysafter = model.ThreeDaysAfter;
                result.Secondtimepmschedule = model.SecondTimePmSchedule;
                result.Thirdtimepmschedule = model.ThirdTimePmSchedule;
                result.Fourthtimepmschedule = model.FourthTimePmSchedule;
                result.Fifthtimepmschedule = model.FourthTimePmSchedule;
                result.Sixthtimepmschedule = model.SixthTimePmSchedule;
                result.Seventhtimepmschedule = model.SecondTimePmSchedule;
                result.Eighthtimepmschedule = model.EighthTimePmSchedule;
                result.Ninthtimepmschedule = model.NinthTimePmSchedule;
                result.Tenthtimepmschedule = model.TenthTimePmSchedule;
                result.Eleventhtimepmschedule = model.EighthTimePmSchedule;
                result.Twelfthtimepmschedule = model.EighthTimePmSchedule;
                result.Pmworkflow = model.PmWorkFlow;
                result.Month = model.Month;
                result.Modified = model.Modified;
                result.Created = model.Created;
                result.Createdby = model.CreatedBy;
                result.Modifiedby = model.ModifiedBy;
                result.Headcountsize = model.HeadCountSize;
                result.Requiredcriticalsparepartlist = model.RequiredCriticalSparePartList;
                result.Pmscheduleflow = model.PmScheduleFlow;
                result.Modifiedby = _currentUserServices.EmpID;

                try
                {
                    _context.Pmscheduledetails.Update(result);
                    await _context.SaveChangesAsync();
                    return new ServiceResponse<string>(200, "Update successful", machineId);
                }
                catch (Exception ex)
                {
                    return new ServiceResponse<string>(500, $"An error occurred while updating: {ex.Message}", null);
                }
            }

            return new ServiceResponse<string>(404, $"MachineIdSn {machineId} does not exist", null);

        }

        public async Task<ApiResponse> IsCheckedPmMachine(string machineId, DateTime? checkDate)
        {
            var result = await _context.Pmdetails.FirstOrDefaultAsync(x => x.MachineidSn == machineId);

            if (result != null)
            {
                    result.Lastcheck = checkDate;
                    result.Ischecked = result.Ischecked == 1 ? 0 : 1; 

                _context.Pmdetails.Update(result);
                await _context.SaveChangesAsync();

                return new ApiResponse(200, "Success");
            }
            return new ApiResponse(400, "Machine not found");
        }

    }

}


