using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreMVCTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoreMVCTest.Controllers
{
    public class TestController : Controller
    {
        List<TestModel> testModels;

        public TestController(List<TestModel> testModels)
        {
            this.testModels = testModels;
        }

        // GET: Test
        public ActionResult Index(string s1, string s2, string s3)
        {
            ViewData["testParam"] = "This param was set in the controller";
            ViewData["TestParamQueryString1"] = s1;
            ViewData["TestParamQueryString2"] = s2;
            ViewData["TestParamQueryString3"] = s3;
            return View();
        }

        // GET: Test/Details/5
        public ActionResult Details(int id)
        {
            return View(testModels.Where(model => model.Id == id).First() );
        }

        // GET: Test/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        //This is set in the asp-action on the form. Optional parameter of asp-controller could be set.
        public ActionResult Create(TestModel model)
        {
            try
            {
                // TODO: Add insert logic here
                model.Id = testModels.Max(M => M.Id)+1;
                testModels.Add(model);

                return RedirectToAction(nameof(Details), new { id = model.Id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Test/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Test/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Test/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}