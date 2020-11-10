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
                    parsedQuant = 0;
                }
                else if (int.TryParse(quantity, out parsedQuant))
                {
                    if(parsedQuant < 0)
                    {
                        throw new Exception("Quantity cannot be below 0");
                    }
                }

                Product newProduct = new Product()
                {
                    Name = name,
                    Quantity = parsedQuant,
                    Discontinued = 1
                };
                context.Products.Add(newProduct);
                context.SaveChanges();

                return newProduct;
            }
        }

        public Product DiscontinueProductByID(string id)
        {
            id = !string.IsNullOrWhiteSpace(id) ? id.Trim() : null;
            Product result;

            using (InventoryContext context = new InventoryContext())
            {
                result = context.Products.Where(product => product.ID == int.Parse(id)).SingleOrDefault();

                result.Discontinued = 0;
                context.SaveChanges();
            }
            return result;

        }

        public Product ReceiveProductByID(string id, string quantity)
        {
            id = !string.IsNullOrWhiteSpace(id) ? id.Trim() : null;
            Product result;
            quantity = !string.IsNullOrWhiteSpace(quantity) ? quantity.Trim() : null;

            using (InventoryContext context = new InventoryContext())
            {
                result = context.Products.Where(product => product.ID == int.Parse(id)).SingleOrDefault();

                result.Quantity += int.Parse(quantity);
                context.SaveChanges();
            }
            return result;
        }

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
