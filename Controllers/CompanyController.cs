using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQueryDataTables.Services;

namespace JQueryDataTables.Controllers
{
    public class CompanyController : Controller
    {
        //
        // GET: /Company/

        private ICompanyService _companyService;
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Details(string id)
        {
            var m = _companyService.GetCompanyDetails(id);
            return View(m);
        }

        [HttpPost]
        public JsonResult Delete(string id)
        {
            var m = _companyService.DeleteCompanies(id);
            return Json(new { Companies = m });
        }

    }
}
