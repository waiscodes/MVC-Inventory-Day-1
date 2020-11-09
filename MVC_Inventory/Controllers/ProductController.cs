using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MVC_Inventory.Models;

namespace MVC_Inventory.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public Product CreateProduct(string name, string quantity)
        {

        }

        //public Product DiscontinueProductByID(string id)
        //{

        //}

        //public Product ReceiveProductByID(string id)
        //{

        //}

        //public Product SendProductByID(string id)
        //{

        //}

        //public List<Product> GetInventory()
        //{

        //}

        //public Product GetProductByID(string id)
        //{

        //}


    }
}
