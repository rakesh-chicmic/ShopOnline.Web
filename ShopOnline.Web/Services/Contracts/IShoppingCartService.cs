using ShopOnline.Models.Dtos;

namespace ShopOnline.Web.Services.Contracts
{
    public interface IShoppingCartService
    {
        Task<IEnumerable<CartItemDto>> GetItems();
        Task<CartItemDto> AddItem(CartItemDto cartItemDto);
    }
}
