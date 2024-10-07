using System;
using System.Collections.Generic;

namespace CalSystem2._0.Entities;

public partial class Pmdetail
{
    public string MachineidSn { get; set; }

    public string Machinename { get; set; }

    public string Project { get; set; }

    public string Line { get; set; }

    public string Subline { get; set; }

    public string Machinelocation { get; set; }

    public string Make { get; set; }

    public string Checklistno { get; set; }

    public string Machinecategory { get; set; }

    public string TataDriname { get; set; }

    public string Vendordri { get; set; }

    public string Pmmanager { get; set; }

    public DateTime Firsttimepmscheduledate { get; set; }

    public string Frequency { get; set; }

    public int? Ischecked { get; set; }

    public DateTime? Lastcheck { get; set; }
}
