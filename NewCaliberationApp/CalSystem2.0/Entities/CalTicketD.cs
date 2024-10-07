using System;
using System.Collections.Generic;

namespace CalSystem2._0.Entities;

public partial class CalTicketD
{
    public string Ticketno { get; set; }

    public string Tickettype { get; set; }

    public string Assetag { get; set; }

    public string Plant { get; set; }

    public string Department { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public string Serialno { get; set; }

    public string Englishdesc { get; set; }

    public string LastDate { get; set; }

    public string NextDate { get; set; }

    public string Applicantid { get; set; }

    public string Applicantname { get; set; }

    public string TestPic { get; set; }

    public string TestDate { get; set; }

    public string BfReason { get; set; }

    public string YsReason { get; set; }

    public string WxReason1 { get; set; }

    public string WxReason2 { get; set; }

    public string WxReason3 { get; set; }

    public string Status { get; set; }

    public DateTime? Createdate { get; set; }
}
