using System;
using System.Collections.Generic;

namespace AFOP_OPTICAL_TESTINGv5.Models;

public partial class Tblacquisition
{
    public int Id { get; set; }

    public int? UnitTestId { get; set; }

    public int? UnitDutid { get; set; }

    public int? TestStep { get; set; }

    public int? Wavelength { get; set; }

    public int? Dutpath { get; set; }

    public int? DutinputPort { get; set; }

    public int? DutoutputPort { get; set; }

    public int? InputMtjid { get; set; }

    public int? OutputMtjid { get; set; }

    public double? RefPower { get; set; }

    public double? Dutpower { get; set; }

    public string? Results { get; set; }

    public DateTime? DateTime { get; set; }
}
