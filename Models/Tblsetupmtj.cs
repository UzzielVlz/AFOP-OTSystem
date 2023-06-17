using System;
using System.Collections.Generic;

namespace AFOP_OPTICAL_TESTINGv5.Models;

public partial class Tblsetupmtj
{
    public int Id { get; set; }

    public int? CompanyId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? PartNumber { get; set; }

    public int? Fibers { get; set; }

    public string? Connector { get; set; }

    public string? IsFanout { get; set; }

    public string? IsActive { get; set; }
}
