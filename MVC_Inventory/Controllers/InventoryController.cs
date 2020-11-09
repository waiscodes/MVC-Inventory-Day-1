using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_Inventory.Controllers;
using MVC_Inventory.Models;

namespace ProductInformation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductAPIController : ControllerBase
    {
        [HttpPost("Create")]
        public ActionResult<Product> ProductCreate_POST(string name, string quantity)
        {
            ActionResult<Product> result;
            try
            {
                result = new ProductController().CreateProduct(name, quantity);
            }
            catch
            {
                result = StatusCode(500, "Unknown error occurred, please try again later.");
            }
            return result;
        }
    }
}