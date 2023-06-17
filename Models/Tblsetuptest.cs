using System;
using System.Collections.Generic;

namespace AFOP_OPTICAL_TESTINGv5.Models;

public partial class Tblsetuptest
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Sources { get; set; }

    public int? J1channels { get; set; }

    public int? J2channels { get; set; }

    public int? Duttype { get; set; }

    public int? Dutfibers { get; set; }

    public string? SetupSpecIds { get; set; }

    public string? TestSteps { get; set; }

    public int? BiDirectional { get; set; }

    public int? Pdlmode { get; set; }

    public int? Opmdevices { get; set; }

    public string? IsActive { get; set; }
}
