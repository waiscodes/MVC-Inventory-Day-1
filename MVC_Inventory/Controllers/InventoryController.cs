using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Inventory.Controllers;
using MVC_Inventory.Models;

namespace MVC_Inventory.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        [HttpPost("Create")]
        public ActionResult<Product> ProductCreate_POST(string name, string quantity)
        {
            ActionResult<Product> result;
            try
            {
                result = new ProductController().CreateProduct(name, quantity);
            }
            catch (Exception e)
            {
                result = StatusCode(500, "Error: "+ e.Message);
            }
            return result;
        }


        [HttpPut("Update")]
        public ActionResult<Product> ProductUpdate_PUT(string id)
        {
            ActionResult<Product> result;
            try
            {
                result = new ProductController().DiscontinueProductByID(id);
            }
            catch (Exception e)
            {
                result = NotFound(e.Message);
            }
            return result;
        }
    }
}