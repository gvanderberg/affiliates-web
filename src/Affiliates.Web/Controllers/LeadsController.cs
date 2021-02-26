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

        private readonly LeadApiSettings _settings;

        public LeadsController(ILogger<LeadsController> logger, ILeadService leadService, LeadApiSettings settings)
        {
            _logger = logger;
            _leadService = leadService;
            _settings = settings;
        }

        public IActionResult Form1()
        {
            ViewBag.Url = $"{_settings.BaseUri}/{_settings.PostUri}";

            return View();
        }

        public IActionResult Form2()
        {
            return View();
        }

        public IActionResult Form3()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Form2(LeadInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var reponse = await _leadService.SubmitAsync(model);

            return RedirectToAction(nameof(Success), new { reference = reponse.ReferenceNumber });
        }

        [HttpPost]
        public async Task<JsonResult> Form3([FromBody] LeadInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return Json(model);
            }

            var reponse = await _leadService.SubmitAsync(model);

            return Json(reponse.ReferenceNumber);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Success(string reference)
        {
            return View(new ResultModel { ReferenceNumber = reference });
        }
    }
}