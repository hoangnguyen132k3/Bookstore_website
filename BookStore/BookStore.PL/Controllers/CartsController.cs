using BookStore.BLL.Services.InterfaceServices;
using BookStore.BLL.Services.ViewModels;
using BookStore.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetAllCarts()
        {
            var carts = await _cartService.GetAllCartAsync();
            if (carts == null || !carts.Any())
            {
                return NotFound("Không tìm thấy carts.");
            }
            return Ok(carts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCartById(int id)
        {
            var cart = await _cartService.GetByCartIdAsync(id);
            if (cart == null)
            {
                return NotFound($"Cart với ID {id} không tìm thấy.");
            }
            return Ok(cart);
        }

        [HttpPost]
        public async Task<ActionResult<Cart>> AddCart([FromBody] CartVm cart)
        {
            if (cart == null)
            {
                return BadRequest("Cart dữ liệu là null.");
            }

            var result = await _cartService.AddCartAsync(cart);
            if (result > 0)
            {
                return Ok();
            }
            return BadRequest("Lỗi khi thêm cart.");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(int id, CartVm cartVm)
        {
            if (cartVm == null)
            {
                return BadRequest("dữ liệu Cart không hợp lệ.");
            }

            var updated = await _cartService.UpdateCartAsync(id, cartVm);
            if (updated)
            {
                return NotFound($"Cart với ID {id} không tìm thấy.");
            }

            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCart(int id)
        {
            var deleted = await _cartService.DeleteByIdAsync(id);
            if (deleted)
            {
                return NotFound($"Cart với ID {id} không tìm thấy.");
            }

            return NoContent();  
        }
    }
}
