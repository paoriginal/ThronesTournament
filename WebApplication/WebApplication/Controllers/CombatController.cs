using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CombatController : Controller
    {
        // GET: Combat
        public ActionResult Index()
        {
            return View();
        }

        // GET: Combat/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Combat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Combat/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Combat/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Combat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Combat/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Combat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        string url = "http://localhost:5888/";
        List<CombatModels> Combats;

        [HttpPost]
        public async Task<ActionResult> SendFight(List<CombatModels> json)
        {
            //Combats = JsonConvert.DeserializeObject<IEnumerable<CombatModels>>(json).ToList();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string data = JsonConvert.SerializeObject(json, Formatting.Indented);
                //HttpResponseMessage response = await client.PostAsJsonAsync<List<CombatModels>>("api/Fight/getDataFromClient", json);
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Fight/getDataFromClient", data);

                if (response.IsSuccessStatusCode)
                {
                    return Json("Success");
                }
            }
            return Json("An Error Has occoured");
        }
    }
}
