using Antlr.Runtime.Misc;
using CarMVC.Helper;
using CarMVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;


namespace CarMVC.Controllers
{
    public class HomeController : Controller
    {
        ProductAPI _api = new ProductAPI();

        public async Task<ActionResult> Index()
        {
            List<ProductData> products = new List<ProductData>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/product");
            if (res.IsSuccessStatusCode)

            {
                var results = res.Content.ReadAsStringAsync().Result;
                products = JsonConvert.DeserializeObject<List<ProductData>>(results);
            }
            return View(products);
        }

        public async Task<ActionResult> Details(int Id)
        {
            var product = new ProductData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/product/{Id}");
            if (res.IsSuccessStatusCode)

            {
                var results = res.Content.ReadAsStringAsync().Result;
                product = JsonConvert.DeserializeObject<ProductData>(results);
            }
            return View(product);
        }
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]

        public ActionResult create(ProductData product)
        {
            HttpClient client = _api.Initial();

            //HTTP POST
            var postTask = client.PostAsJsonAsync<ProductData>("api/product", product);
            postTask.Wait();

            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<ActionResult> Delete(int Id)
        {
            var product = new ProductData();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/product/{Id}");

            return RedirectToAction("Index");
        }

        //just a method

        public ActionResult Edit()
        {
            return View();
        }
    }
}