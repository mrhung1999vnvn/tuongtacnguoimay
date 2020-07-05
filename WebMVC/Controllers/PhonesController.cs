using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebMVC.Models;

namespace WebMVC.Controllers
{
    public class PhonesController : Controller
    {
        // GET: Phones
        public ActionResult Index()
        {
            IEnumerable<mvcPhoneModel> emplist;
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Phones").Result;
            emplist = response.Content.ReadAsAsync<IEnumerable<mvcPhoneModel>>().Result;
            return View(emplist);
        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcPhoneModel());
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Phones/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcPhoneModel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcPhoneModel emp)
        {
            if (emp.Id == 0)
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Phones", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Phones/" + emp.Id, emp).Result;
                TempData["SuccessMessage"] = "Updated Successfully";
            }
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.WebApiClient.DeleteAsync("Phones/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}