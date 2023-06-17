using System;
using System.Collections.Generic;

namespace AFOP_OPTICAL_TESTINGv5.Models;

public partial class Tblsetupdut
{
    public int Id { get; set; }

    public int? CompanyId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? PartNumber { get; set; }

    public int? Type { get; set; }

    public int? Fibers { get; set; }

    public string? PortNames { get; set; }

    public string? IsActive { get; set; }
}
