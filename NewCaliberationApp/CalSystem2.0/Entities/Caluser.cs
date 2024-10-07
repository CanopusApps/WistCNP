using System;
using System.Collections.Generic;

namespace CalSystem2._0.Entities;

public partial class Caluser
{
    public string Loginid { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Department { get; set; }

    public string Right { get; set; }

    public DateTime? Logdate { get; set; }

    public string Emplid { get; set; }

    public string Id { get; set; }
}
