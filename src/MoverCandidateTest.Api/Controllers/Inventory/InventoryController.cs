using Microsoft.AspNetCore.Mvc;

namespace MoverCandidateTest.Api.Controllers.Inventory
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ApiController
    {
        [HttpPost("AddInventoryItem")]
        public IActionResult AddInventoryItem()
        {
            return Ok("I am in AddInventoryItem Post method");
        }

        [HttpPut("RemoveInventoryItem")]
        public IActionResult RemoveInventoryItem()
        {
            return Ok("I am in AddInventoryItem Put method");
        }
        [HttpGet("GetInventoryList")]
        public IActionResult GetInventoryList()
        {
            return Ok("I am in AddInventoryItem Get method");
        }
    }
}