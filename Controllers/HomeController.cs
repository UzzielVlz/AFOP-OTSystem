using AFOP_OPTICAL_TESTINGv5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AFOP_OPTICAL_TESTINGv5.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        private readonly Afop2023Context _context;

        public HomeController(Afop2023Context context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string buscar)
        {
            List<claseMeasuremnts> resultado = await (from tb1 in _context.Tblacquisitions
                                                      join tb2 in _context.Tblunitduts on tb1.UnitDutid equals tb2.Id
                                                      join tb3 in _context.Tblsetupduts on tb2.SetupDutid equals tb3.Id
                                                      where tb1.Results != ""
                                                      select new claseMeasuremnts
                                                      {
                                                          Id = tb1.Id,
                                                          SerialNumber = tb2.SerialNumber,
                                                          Name = tb3.Name,
                                                          Description = tb3.Description,
                                                          Wavelength = tb1.Wavelength,
                                                          Results = tb1.Results,
                                                          DateTime = tb1.DateTime
                                                      }).ToListAsync();


            IEnumerable<claseMeasuremnts> bRegistro = resultado;

            if (!String.IsNullOrEmpty(buscar))
            {
                bRegistro = bRegistro.Where(s => s.SerialNumber!.Contains(buscar));
            }

            return View(bRegistro.ToList());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}