using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CHS_Auction_Site.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CHS_Auction_Site.Controllers
{
    public class ContactsController : Controller
    {

        private IContactRepo repository;
        public ContactsController(IContactRepo repo)
        {
            repository = repo;
        }
        public ViewResult Contact() => View(repository.Contacts);
    }
}
