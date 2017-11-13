using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetPizza.Models.Repository;
using DotNetPizza.Models;
using DotNetPizza.Models.PizzaViewModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace DotNetPizza.Areas.admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class PizzaController : Controller
    {
        private IRepository<Pizza> repository;
        private IHostingEnvironment _env;

        public PizzaController(IRepository<Pizza> repository, IHostingEnvironment env)
        {
            this.repository = repository;
            _env = env;
        }

        public IActionResult Index()
        {

            List<PizzaViewModel> pizzasVM = new List<PizzaViewModel>();

            repository.GetAll.ToList().ForEach(p =>
                {
                    PizzaViewModel pizzaVM = new PizzaViewModel
                    {
                        PizzaID = p.PizzaID,
                        Title = p.Title,
                        Description = p.Description,
                        PriceHT = p.Price,
                        Image = p.Image
                    };

                    pizzasVM.Add(pizzaVM);
                });

            return View(pizzasVM);
        }

        [HttpGet]
        public IActionResult Create() => View(new PizzaViewModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PizzaViewModel p)
        {
            long size = p.UploadImage?.Length ?? 0;
            var fileName = string.Empty;


            if (ModelState.IsValid)
            {
                if (size > 0)
                {
                    fileName = await CreateFileOnServerAsync(p.UploadImage);

                    Pizza pizza = new Pizza
                    {
                        PizzaID = p.PizzaID,
                        Title = p.Title,
                        Description = p.Description,
                        Price = p.PriceHT,
                        Image = fileName
                    };

                    await this.repository.CreateAsync(pizza);

                }
            }
            else
            {
                ModelState.AddModelError("Error Model", "Pas bien");
                return View(p);
            }

            return RedirectToAction("Index");

            //return Ok(new { size, filePath });
        }

        [HttpGet]
        //[Route("[area]/[controller]/[action]/{id:int}")]
        public IActionResult Edit(int id)
        {
            PizzaViewModel pizzaVM = new PizzaViewModel();

            Pizza pizza = repository.GetOne(id);

            pizzaVM.Title = pizza.Title;
            pizzaVM.PizzaID = pizza.PizzaID;
            pizzaVM.Description = pizza.Description;
            pizzaVM.PriceHT = pizza.Price;
            pizzaVM.Image = pizza.Image;

            return View(pizzaVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PizzaViewModel p)
        {
            long size = p.UploadImage?.Length ?? 0;
            var filePath = string.Empty;
            p.Title = "try bad format";

            if (ModelState.IsValid && TryValidateModel(p))
            {
                if (size > 0)
                {
                    filePath = await CreateFileOnServerAsync(p.UploadImage);
                }
            }
            else
            {
                ModelState.AddModelError("Error Model", "Pas bien");
                return View(p);
            }

            return RedirectToAction("Index");

            //return Ok(new { size, filePath });
        }

        //[Route("[area]/[controller]/[action]/{id:int}")]
        public IActionResult Details(int id)
        {
            PizzaViewModel pizzasVM = new PizzaViewModel();
            var pizza = repository.GetOne(id);

            PizzaViewModel pizzaVM = new PizzaViewModel
            {
                PizzaID = pizza.PizzaID,
                Title = pizza.Title,
                Description = pizza.Description,
                PriceHT = pizza.Price,
                Image = pizza.Image
            };

            return View(pizzaVM);
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("api/[controller]/pizzas")]
        public string GetAllPizzas()
        {
            return JsonConvert.SerializeObject(repository.GetAll, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpGet]
        [Route("api/[controller]/pizzas/{nbPages,itemsCount}")]
        public ObjectResult GetAllPizzasPaging(int nbPages, int itemsCount)
        {
            string serialize = JsonConvert.SerializeObject(repository.GetAll, Formatting.Indented, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });



            if (serialize.Equals(string.Empty))
            {
                return StatusCode(404, new { Bad = "Empty values" });
            }
            else
            {
                return Ok(serialize);
            }


        }

        [HttpGet]
        [Route("api/[controller]/pizza/{pizzaID}")]
        [AllowAnonymous]
        public ObjectResult Get(int pizzaID)
        {
            Pizza pizza = null;

            if (pizza == null)
            {
                return StatusCode(404, new { Bad = "Empty values" });
            }
            else
            {
                pizza = new Pizza
                {
                    PizzaID = 10,
                    Title = "Reine",
                    Description = "Jambon, champignons, sauce tomate, fromage",
                    Image = "Pizza_636459256050093378.jpg",
                    Price = 10.00m
                };
                return StatusCode(200, new { Pizza = pizza });

            }
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("api/[controller]/pizza")]
        public void Post([FromBody] Pizza pizza)
        {

        }

        [HttpPut]
        [Route("api/[controller]/pizza")]
        public void Put()
        {

        }

        [HttpDelete]
        [Route("api/[controller]/pizza/{pizzaID}")]
        public void Delete(int pizzaID)
        {

        }

        private async Task<string> CreateFileOnServerAsync(IFormFile file)
        {
            var webRoot = _env.WebRootPath;
            var fileName = $"Pizza_{DateTime.Now.Ticks}.jpg";
            var filePath = Path.Combine(webRoot + @"\images\", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
    }
}