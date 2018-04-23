using ImasTestFromWeb.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImasTestFromWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DAFromDB2 s = new DAFromDB2();
            DataTable dt = null;//s.GetData();  

            //s.DeliveryAgainstIndentEntry();
            //DataTable dt = new DAFromDB2().DeliveryAgainstIndentView();
            //var webservicecall = new DAFromDB2().postXMLData(null, null);
            //var webservicecall = new DAFromDB2().XmlCalling();
            var v = new BridgeBetweenSQLNDB2().ReadDataFromSql();            
            return View(dt);
            //return View();

        }
        public JsonResult GetAutocompleteData()
        {
            var v = new ArrayList();
            v.Add(new { Value = "0111111", Display = "Khan" });
            v.Add(new { Value = "0111112", Display = "Khan1" });
            v.Add(new { Value = "0111113", Display = "Khan2" });
            return Json(v, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}