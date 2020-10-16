using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hedgar.Exchanges.Backend.API.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Sets the objects that will be used by the formatters to produce sample requests/responses.
        /// </summary>
        /// <param name="config">The <see cref="HttpConfiguration"/>.</param>
        /// <param name="sampleObjects">The sample objects.</param>
        public ActionResult Index()
        {

            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
