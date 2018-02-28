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
    public class HouseController : Controller
    {
        string url = "http://localhost:5888/";
        List<HouseModels> Houses;
        List<CharacterModels> Characters;

        // GET: House
        public ActionResult Index()
        {
            return View();
        }

        // GET: House/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: House/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: House/Create
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

        // GET: House/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: House/Edit/5
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

        // GET: House/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: House/Delete/5
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

        [HttpGet]
        public async Task<ActionResult> GetHouses()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/House/getEntities");
                if (response.IsSuccessStatusCode)
                {
                    string jsondata = await response.Content.ReadAsStringAsync();
                    Houses = JsonConvert.DeserializeObject<IEnumerable<HouseModels>>(jsondata).ToList();
                }


                HttpResponseMessage response2 = await client.GetAsync("api/Character/getEntities");
                if (response.IsSuccessStatusCode)
                {
                    string jsondata2 = await response.Content.ReadAsStringAsync();
                    Characters = JsonConvert.DeserializeObject<IEnumerable<CharacterModels>>(jsondata2).ToList();
                }
                

                foreach (var house in Houses)
                {
                    foreach (var idChar in house.ListCharacterId)
                    {
                        house.AddCharacter(Characters.Find(character => character.IdCharacter.Equals(idChar)));
                    }
                };

                string jsonSerialize = JsonConvert.SerializeObject(Houses, Formatting.Indented);
                
                return View(jsonSerialize);
            }
        }
    }
}
