using System.Threading.Tasks;

using Affiliates.Web.Models;
using Affiliates.Web.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Affiliates.Web.Controllers
{
    public class LeadsController : Controller
    {
        private readonly ILeadService _leadService;

        private readonly ILogger<LeadsController> _logger;

        public LeadsController(ILogger<LeadsController> logger, ILeadService leadService)
        {
            _logger = logger;
            _leadService = leadService;
        }

        public IActionResult Form1()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Form1(LeadInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var reponse = await _leadService.SubmitAsync(model);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}