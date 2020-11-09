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
            name = !string.IsNullOrWhiteSpace(name) ? name.Trim() : null;
            quantity = !string.IsNullOrWhiteSpace(quantity) ? quantity.Trim() : null;
            int dfltQuant = 0;
            int parsedQuant;

            using (InventoryContext context = new InventoryContext())
            {

                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("Name cannot be null");
                }
                else if (name.Length > 30)
                {
                    throw new Exception("Name must be under 30 characters");
                }
                else if (context.Products.Any(x => x.Name.ToLower() == name.ToLower()))
                {
                    throw new Exception("This product already exists");
                }

                if(string.IsNullOrWhiteSpace(quantity))
                {

                }
            }
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
