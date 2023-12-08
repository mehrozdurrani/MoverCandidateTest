using Microsoft.AspNetCore.Mvc;
using MoverCandidateTest.Contracts.Inventory;
using MoverCandidateTest.Models.Inventory;
using MoverCandidateTest.Services.Inventory;

namespace MoverCandidateTest.Api.Controllers.Inventory
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : ApiController
    {
        private readonly IInventoryService _inventoryService;
        public InventoryController(IInventoryService inventoryService)
        {
            _inventoryService = inventoryService;
        }
        [HttpPost("AddInventoryItem")]
        public IActionResult AddInventoryItem(AddInventoryItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            InventoryItem inventoryItem = InventoryItem.Create(request.Sku, request.Description, request.Quantity);
            _inventoryService.AddInventoryItem(inventoryItem);
            return Ok("Inventory Item Added Successfully");
        }

        [HttpPut("RemoveInventoryItem")]
        public IActionResult RemoveInventoryItem(RemoveInventoryItemRequest request)
        {
            _inventoryService.RemoveInventoryItem(request.Sku, request.Quantity);
            return Ok("Inventory Item Removed Successfully");
        }
        [HttpGet("GetInventoryList")]
        public IActionResult GetInventoryList()
        {
            GetInventoryListResponse inventoryList = new GetInventoryListResponse(_inventoryService.GetInventoryList());
            return Ok(inventoryList);
        }

    }
}