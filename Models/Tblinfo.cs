using System;
using System.Collections.Generic;

namespace AFOP_OPTICAL_TESTINGv5.Models;

public partial class Tblinfo
{
    public int Id { get; set; }

    public int? Revision { get; set; }

    public string? Created { get; set; }

    public int? ScriptId { get; set; }
}
