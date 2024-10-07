using System;
using System.Collections.Generic;

namespace CalSystem2._0.Entities;

public partial class Pmscheduledetail
{
    public string MachineidSn { get; set; }

    public string Pmdurationhrs { get; set; }

    public DateTime? Actualpmdate { get; set; }

    public string Pmadherence { get; set; }

    public decimal Currentpmstatus { get; set; }

    public string Toollist { get; set; }

    public string Requiredcriticalsparepartlist { get; set; }

    public string Headcountsize { get; set; }

    public string Dccchecklistlink { get; set; }

    public string Planthead { get; set; }

    public string Pmscheduleflow { get; set; }

    public DateTime? Threedaysalert { get; set; }

    public DateTime? Onedayalert { get; set; }

    public DateTime? Onedayafter { get; set; }

    public DateTime? Twodaysafter { get; set; }

    public DateTime? Threedaysafter { get; set; }

    public DateTime? Secondtimepmschedule { get; set; }

    public DateTime? Thirdtimepmschedule { get; set; }

    public DateTime? Fourthtimepmschedule { get; set; }

    public DateTime? Fifthtimepmschedule { get; set; }

    public DateTime? Sixthtimepmschedule { get; set; }

    public DateTime? Seventhtimepmschedule { get; set; }

    public DateTime? Eighthtimepmschedule { get; set; }

    public DateTime? Ninthtimepmschedule { get; set; }

    public DateTime? Tenthtimepmschedule { get; set; }

    public DateTime? Eleventhtimepmschedule { get; set; }

    public DateTime? Twelfthtimepmschedule { get; set; }

    public string Pmworkflow { get; set; }

    public string Engineeringmanager { get; set; }

    public string Month { get; set; }

    public DateTime? Modified { get; set; }

    public DateTime? Created { get; set; }

    public string Createdby { get; set; }

    public string Modifiedby { get; set; }
}
