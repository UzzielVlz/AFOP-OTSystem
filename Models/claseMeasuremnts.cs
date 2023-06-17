using System;
using System.Collections.Generic;

namespace AFOP_OPTICAL_TESTINGv5.Models
{
    public class claseMeasuremnts
    {
        public int Id { get; set; }
        public string? SerialNumber { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Wavelength { get; set; }
        public string? Results { get; set; }
        public DateTime? DateTime { get; set; }

    }

}
