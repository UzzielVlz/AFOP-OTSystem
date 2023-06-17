using System;
using System.Collections.Generic;

namespace AFOP_OPTICAL_TESTINGv5.Models;

public partial class Tblunittest
{
    public int Id { get; set; }

    public int? SetupTestId { get; set; }

    public int? SetupDutid { get; set; }

    public int? CompanyId { get; set; }

    public int? Tester { get; set; }

    public string? Description { get; set; }

    public int? UnitDutids { get; set; }

    public int? CurrentStep { get; set; }

    public string? DebugMode { get; set; }

    public DateTime? StartDateTime { get; set; }

    public DateTime? EndDateTime { get; set; }

    public string? Custom1 { get; set; }

    public string? Custom2 { get; set; }

    public string? Custom3 { get; set; }

    public string? Custom4 { get; set; }

    public string? Custom5 { get; set; }

    public int? ChassisSn { get; set; }

    public int? ModuleSn { get; set; }

    public string? AddSummary { get; set; }

    public int? TestMode { get; set; }

    public int? CurrentDut { get; set; }
}
