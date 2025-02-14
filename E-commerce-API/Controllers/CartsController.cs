using E_commerce_API.HelperFunctions;
using E_commerce_core.DTO_s;
using E_commerce_core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartRepository cartRepository;

        public CartsController(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }
        [HttpPost("AddCart")]
        [Authorize(Roles = ("hr"))]
        public async Task<IActionResult> AddCart(CartDTOs cart)
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token Is Missing");
            int? userId = ExtractClaims.ExtractUserId(token);

            if (userId is not null)
            {
                string result = await cartRepository.AddBulkQuantityToCartAsync(cart, userId.Value);
                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized(result);
                }
            }
            else
            {
                return Unauthorized("invalid token");
            }
        }

        [HttpPost("AddOneItem")]
        public async Task<IActionResult> AddOneItem(AddOrDeleteToOneItemDTOs cart)
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token Is Missing");
            int? userId = ExtractClaims.ExtractUserId(token);

            if (userId is not null)
            {
                string result = await cartRepository.AddOneQuantityToCartAsync(cart, userId.Value);
                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return await AddCart(new CartDTOs
                    {
                        Quantity = 1,
                        UnitId = 1,
                        ItemId = cart.ItemId,
                         SoresId = cart.SoresId,
                    });
                }
            }
            else
            {
                return Unauthorized("invalid token");
            }
        }

        [HttpPost("DeleteOneItem")]
        public async Task<IActionResult> DeleteOneItem(AddOrDeleteToOneItemDTOs cart)
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token Is Missing");
            int? userId = ExtractClaims.ExtractUserId(token);

            if (userId is not null)
            {
                string result = await cartRepository.DeleteOneQuantityToCartAsync(cart, userId.Value);
                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound("cart not found");
                }
            }
            else
            {
                return Unauthorized("invalid token");
            }
        }
        [HttpDelete("DeleteItem")]
        public async Task<IActionResult> DeleteItem(AddOrDeleteToOneItemDTOs cart)
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token Is Missing");
            int? userId = ExtractClaims.ExtractUserId(token);

            if (userId is not null)
            {
                string result = await cartRepository.DeleteBulkQuantityToCartAsync(cart, userId.Value);
                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized(result);
                }
            }
            else
            {
                return Unauthorized("invalid token");
            }
        }
        [HttpGet("AllItem")]
        public async Task<IActionResult> AllItems()
        {
            string token = Request.Headers["Authorization"].ToString().Replace("Bearer", "");
            if (string.IsNullOrEmpty(token))
                return Unauthorized("Token Is Missing");
            int? userId = ExtractClaims.ExtractUserId(token);

            if (userId is not null)
            {
                IEnumerable<CartItemsDTOs> result = await cartRepository.GetAllItemInCartAsync( userId.Value);
                if (result is not null)
                {
                    return Ok(result);
                }
                else
                {
                    return Unauthorized(result);
                }
            }
            else
            {
                return Unauthorized("invalid token");
            }
        }


    }
}
