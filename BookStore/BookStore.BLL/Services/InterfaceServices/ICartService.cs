using BookStore.BLL.Services.Base;
using BookStore.BLL.Services.ViewModels;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BLL.Services.InterfaceServices
{
    public interface ICartService : IBaseService<Cart>
    {

        Task<int> AddCartAsync(CartVm cartVm);

        Task<bool> UpdateCartAsync(int id, CartVm cartVm);

        Task<bool> DeleteByIdAsync(int id);

        Task<Cart?> GetByCartIdAsync(int id);

        Task<IEnumerable<Cart>> GetAllCartAsync();
    }
}