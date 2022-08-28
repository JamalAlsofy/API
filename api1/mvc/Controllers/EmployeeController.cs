using mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace mvc.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<mvcemployeemodel> empList;
            HttpResponseMessage response = GlobalVaribles.WebApiClient.GetAsync("Employee").Result;
            empList = response.Content.ReadAsAsync<IEnumerable<mvcemployeemodel>>().Result;

            return View(empList);

        }
        public ActionResult AddOrEdit(int id = 0)
        {
            if (id == 0)
                return View(new mvcemployeemodel());
            else
            {
                HttpResponseMessage response = GlobalVaribles.WebApiClient.GetAsync("Employee/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<mvcemployeemodel>().Result);
            }
        }
        [HttpPost]
        public ActionResult AddOrEdit(mvcemployeemodel emp)
        {
            if (emp.EmployeelID == 0)
            {
                HttpResponseMessage response = GlobalVaribles.WebApiClient.PostAsJsonAsync("Employee", emp).Result;
                TempData["SuccessMessage"] = "Saved Successfully";
            }
            else
            {
                HttpResponseMessage response = GlobalVaribles.WebApiClient.PutAsJsonAsync("Employee/" + emp.EmployeelID, emp).Result;
                TempData["SuccessMessage"] = " Updated Successfully";
            }     return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVaribles.WebApiClient.DeleteAsync("Employee/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}