using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DotNetPizza.Models.Repository;
using DotNetPizza.Models;
using DotNetPizza.Models.ClientViewModel;

namespace DotNetPizza.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClientController : Controller
    {
        private IRepository<Client> repositoryClient;
        public ClientController(IRepository<Client> repository)
        {
            repositoryClient = repository;
        }
        public IActionResult Index()
        {
            List<ClientViewModel> clientsVM = new List<ClientViewModel>();

            repositoryClient.GetAll.ToList().ForEach(c =>
            {
                ClientViewModel clientVM = new ClientViewModel
                {
                    ClientID = c.ClientID,
                    Lastname = c.Lastname,
                    Firstname = c.Firstname,
                    Address = c.Address,
                    City = c.City,
                    ZipCode = c.ZipCode,
                    Gender = c.Gender
                };

                clientsVM.Add(clientVM);
            });

            return View(clientsVM);
        }

        public IActionResult Details(int id)
        {
            var client = repositoryClient.GetOne(id);
            
            ClientViewModel clientVM = new ClientViewModel
            {
                ClientID = client.ClientID,
                Lastname = client.Lastname,
                Firstname = client.Firstname,
                Address = client.Address,
                City = client.City,
                ZipCode = client.ZipCode,
                Gender = client.Gender
            };


            return View(clientVM);
        }
    }
}