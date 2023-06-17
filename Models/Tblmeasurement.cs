using System;
using System.Collections.Generic;

namespace AFOP_OPTICAL_TESTINGv5.Models;

public partial class Tblmeasurement
{
    public int Id { get; set; }

    public int? AcquisitionId { get; set; }

    public int? SetupSpecId { get; set; }

    public double? Result { get; set; }

    public string? Passed { get; set; }
}
