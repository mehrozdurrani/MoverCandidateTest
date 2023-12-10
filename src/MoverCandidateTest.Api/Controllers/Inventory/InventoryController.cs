using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<InventoryController> _logger;
        public InventoryController(IInventoryService inventoryService, ILogger<InventoryController> logger)
        {
            _inventoryService = inventoryService;
            _logger = logger;
        }

        [HttpPost("AddInventoryItem")]
        public IActionResult AddInventoryItem(AddInventoryItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid request received for AddInventoryItem.");
                return BadRequest(ModelState);
            }
            InventoryItem inventoryItem = InventoryItem.Create(request.Sku, request.Description, request.Quantity);
            _inventoryService.AddInventoryItem(inventoryItem);
            return Ok("Inventory Item Added Successfully");
        }

        [HttpPut("RemoveInventoryItem")]
        public IActionResult RemoveInventoryItem(RemoveInventoryItemRequest request)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogWarning("Invalid request received for RemoveInventoryItem.");
                return BadRequest(ModelState);
            }
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