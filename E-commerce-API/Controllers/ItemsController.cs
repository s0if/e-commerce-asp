using E_commerce_core.DTO_s;
using E_commerce_core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public ItemsController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        [HttpGet("GetItem")]
       
        public async Task<IActionResult> GetItem(int pageIndex,int pageSize)
        {
            var item = await unitOfWork.ItemRepository.GetItemsAsync(pageIndex,pageSize);
            return Ok(item);
        }
    }
}
