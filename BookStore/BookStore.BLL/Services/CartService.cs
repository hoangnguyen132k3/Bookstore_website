using BookStore.BLL.Services.Base;
using BookStore.BLL.Services.InterfaceServices;
using BookStore.BLL.Services.ViewModels;
using BookStore.DAL.Infrastructure;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Services
{
    public class CartService : BaseService<Cart>, ICartService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CartService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> AddCartAsync(CartVm cartVm)
        {
            if (cartVm == null)
            {
                throw new ArgumentNullException(nameof(cartVm), "dữ liệu Cart không thể rỗng");
            }

            var cart = new Cart
            {
                UserId = cartVm.UserId,
                BookId = cartVm.BookId,
                Quantity = cartVm.Quantity,
                AddedAt = cartVm.AddedAt != default ? cartVm.AddedAt : DateTime.UtcNow 
            };

            await _unitOfWork.GenericRepository<Cart>().AddAsync(cart);

            var result = await _unitOfWork.SaveChangesAsync();

            return result;
        }

        public async Task<bool> UpdateCartAsync(int id, CartVm cartVm)
        {
            var cart = await GetByIdAsync(id);
            cart.BookId = cartVm.BookId;
            cart.Quantity = cartVm.Quantity;
            cart.UserId = cartVm.UserId;
            cart.AddedAt = cartVm.AddedAt;
            return await UpdateAsync(cart) > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            return await DeleteAsync(id) > 0;
        }

        public async Task<Cart?> GetByCartIdAsync(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<Cart>> GetAllCartAsync()
        {
            return await GetAllAsync();
        }
    }

}
