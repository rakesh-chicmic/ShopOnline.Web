using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.Api.Extensions;
using ShopOnline.Api.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public ShoppingCartController(IShoppingCartRepository shoppingCartRepository,IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("{userId/GetItems}")]
        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetItems (int userId)
        {
            try
            {
                var cartItems = await _shoppingCartRepository.GetItems(userId);
                if(cartItems == null)
                {
                    return NoContent();
                }
                var products = await _productRepository.GetItems();
                if(products == null)
                {
                    throw new Exception("No products Exits in the system");
                }
                var cartItemDto = cartItems.ConvertToDto(products);
                return Ok(cartItemDto);
            }
            catch (Exception ex)
            {

              return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CartItemDto>> GetItem(int id)
        {
            try
            {
                var cartItem = await _shoppingCartRepository.GetItem(id);
                if(cartItem == null)
                {
                    return NotFound();
                }
                var product = await _productRepository.GetItem(cartItem.ProductId);
                if(product == null)
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
