﻿using System;
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
            int parsedID;

            using (InventoryContext context = new InventoryContext())
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new Exception("ID cannot be empty");
                }
                else if (!int.TryParse(id, out parsedID))
                {
                    throw new Exception("ID must be an int");
                }

                result = context.Products.Where(product => product.ID == parsedID).SingleOrDefault();

                if (result.Discontinued == 0)
                {
                    throw new Exception("Product has already been discontinued");
                }

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
            int parsedId;
            int parsedQuant;

            using (InventoryContext context = new InventoryContext())
            {

                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new Exception("Quantity must not be empty");
                }
                else if (!int.TryParse(id, out parsedId))
                {
                    throw new Exception("Quantity must be an ID");
                }
                else if (!context.Products.Any(x => x.ID == parsedId))
                {
                    throw new Exception("This product does not exist");
                }

                if (string.IsNullOrWhiteSpace(quantity))
                {
                    throw new Exception("Quantity must not be empty");
                }
                else if (!int.TryParse(quantity, out parsedQuant))
                {
                    throw new Exception("Quantity must be an ID");
                }

                result = context.Products.Where(product => product.ID == parsedId).SingleOrDefault();

                result.Quantity += parsedQuant;
                context.SaveChanges();
            }
            return result;
        }

        public Product SendProductByID(string id, string quantity)
        {
            id = !string.IsNullOrWhiteSpace(id) ? id.Trim() : null;
            Product result;
            quantity = !string.IsNullOrWhiteSpace(quantity) ? quantity.Trim() : null;

            using (InventoryContext context = new InventoryContext())
            {
                result = context.Products.Where(product => product.ID == int.Parse(id)).SingleOrDefault();

                result.Quantity -= int.Parse(quantity);
                context.SaveChanges();
            }
            return result;
        }

        public List<Product> GetInventory()
        {
            List<Product> results;
            using (InventoryContext context = new InventoryContext())
            {
                results = context.Products.Where(x => x.Discontinued == 1).ToList();
            }
            return results;
        }

        public Product GetProductByID(string id)
        {
            Product result;
            int parsedID;

            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id), nameof(id) + " is null.");
            }
            if (!int.TryParse(id, out parsedID))
            {
                throw new ArgumentException(nameof(id) + " is not valid.", nameof(id));
            }

            using (InventoryContext context = new InventoryContext())
            {
                result = context.Products.Where(x => x.ID == parsedID).Single();
            }
            return result;
        }


    }
}
