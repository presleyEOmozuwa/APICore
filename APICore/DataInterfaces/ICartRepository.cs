using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using APICore.DataModelService;
using APICore.ModelService;

namespace APICore.DataInterfaces
{
    public interface ICartRepository
    {
        Task<List<Cart>> GetCartList();
        Task<IEnumerable<Course>> GetStoreItems(string id);
        Task<Cart> GetCart(string id);

        Task<int> CreateCart(string id);
        Task<int> GetCartId(string id);
        Task UpdateCart(Cart cart);

        Task DeleteCart(Cart cart);
        Task<ResponseModel> AddProdToCart(AddItemModel req);
        Task<ResponseModel> RemoveProdFromCart(RemoveItemModel req);
    }
}