using System;
using System.Collections.Generic;

namespace CalSystem2._0.Entities;

public partial class Calchecklist
{
    public string Assetag { get; set; }

    public string Cycletime { get; set; }

    public string Auditlevel { get; set; }

    public string Auditor { get; set; }

    public string Checkflag { get; set; }

    public DateTime Publishdate { get; set; }

    public DateTime? Updatedate { get; set; }

    public DateTime? Createdate { get; set; }

    public string Memo { get; set; }

    public string Status { get; set; }

    public string ApproveMsg { get; set; }

    public DateTime? ApproveDate { get; set; }

    public string Seq { get; set; }

    public string Id { get; set; }
}
