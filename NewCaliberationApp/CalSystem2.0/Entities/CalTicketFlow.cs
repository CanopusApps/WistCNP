using System;
using System.Collections.Generic;

namespace CalSystem2._0.Entities;

public partial class CalTicketFlow
{
    public string Ticketno { get; set; }

    public string Step { get; set; }

    public string Picid { get; set; }

    public string Picname { get; set; }

    public string Picmail { get; set; }

    public string Status { get; set; }

    public DateTime? Signdate { get; set; }

    public string Remark { get; set; }
}
