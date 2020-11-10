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


        [HttpPatch("Discontinue")]
        public ActionResult<Product> Discontinue_PUT(string id)
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

        [HttpPatch("Receive")]
        public ActionResult<Product> Receive_PUT(string id, string quantity)
        {
            ActionResult<Product> result;
            try
            {
                result = new ProductController().ReceiveProductByID(id, quantity);
            }
            catch (Exception e)
            {
                result = NotFound(e.Message);
            }
            return result;
        }

        [HttpPatch("Send")]
        public ActionResult<Product> Send_PUT(string id, string quantity)
        {
            ActionResult<Product> result;
            try
            {
                result = new ProductController().SendProductByID(id, quantity);
            }
            catch (Exception e)
            {
                result = NotFound(e.Message);
            }
            return result;
        }

        [HttpGet("All")]
        public ActionResult<IEnumerable<Product>> GetAllProducts_GET(string listType)
        {
            return new ProductController().GetInventory(listType);
        }

        [HttpGet("ByID")]
        public ActionResult<Product> ProductByID_GET(string id)
        {
            ActionResult<Product> result;
            try
            {
                result = new ProductController().GetProductByID(id);
            }
            catch (ArgumentNullException e)
            {
                result = BadRequest(e.Message);
            }
            catch (ArgumentException e)
            {
                result = BadRequest(e.Message);
            }
            catch (InvalidOperationException e)
            {
                result = NotFound(e.Message);
            }
            return result;
        }
    }
}