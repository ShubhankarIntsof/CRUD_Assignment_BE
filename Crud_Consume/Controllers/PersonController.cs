using Crud_Consume.Helper;
using Crud_Consume.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System;
using System.Text;

namespace Crud_Consume.Controllers
{
    public class PersonController : Controller
    {
        PersonApi _api = new PersonApi();
        public async Task<IActionResult> Index()
        {
            List<Person> persons = new List<Person>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Person");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                persons = JsonConvert.DeserializeObject<List<Person>>(results);
            }
            return View(persons);
        }
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Person person)
        {
            person.Id = new System.Guid();
            HttpClient client = _api.Initial();
            var response = await client.PostAsJsonAsync("api/Person", person);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            
            return View();

        }
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            HttpClient client = _api.Initial();
            Person person = null;
            HttpResponseMessage response = await client.GetAsync("api/Person/" + id);
            if (response.IsSuccessStatusCode)
            {
                person = await response.Content.ReadAsAsync<Person>();
            }

            return View(person);
        }
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            HttpClient client = _api.Initial();
            Person person = null;
            HttpResponseMessage response = await client.GetAsync("api/Person/" + id);
            if (response.IsSuccessStatusCode)
            {
                person = await response.Content.ReadAsAsync<Person>();
            }
            
            return View(person);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage response = await client.DeleteAsync($"api/Person/{id}");
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();


        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Person/"+ id);
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var results = res.Content.ReadAsStringAsync().Result;
            var person = JsonConvert.DeserializeObject<Person>(results);
            return View(person);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Person person)
        {
            var id = person.Id;
            HttpClient client = _api.Initial();
            var serializedDoc = JsonConvert.SerializeObject(person);
            var requestContent = new StringContent(serializedDoc, Encoding.UTF8, "application/json-patch+json");
            var response = await client.PatchAsync($"api/Person/{id}", requestContent);
            
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View();

        }


    }
}
