using System;
using System.Collections.Generic;

namespace AFOP_OPTICAL_TESTINGv5.Models;

public partial class Tblsetupspec
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Type { get; set; }

    public double? MinSpec { get; set; }

    public double? MaxSpec { get; set; }

    public string? Setup { get; set; }

    public string? TableHeader { get; set; }

    public string? IsActive { get; set; }
}
