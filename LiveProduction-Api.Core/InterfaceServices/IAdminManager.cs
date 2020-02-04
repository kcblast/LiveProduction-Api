using LiveProduction_Api.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LiveProduction_Api.Core.InterfaceServices
{
    public interface IAdminManager
    {
        Task<Tuple<string, object>> GetSellerAsync(Guid UserId);
        Task<Tuple<string, object>> GetBuyerAsync(Guid UserId);
        Task<Tuple<string, object>> GetProductById(int Id);
        Task<Tuple<string, object>> GetProductByName(string Productname);
        Task<Tuple<string, object>> DeleteProduct(Guid id);
        Task<Tuple<string, object>> ApproveProduct(int productCode);
        Task<Tuple<string, object>> DisapproveProduct(int productCode);
        Task<Tuple<string, object>> GetRequsts();
        Task<Tuple<string, ProductDTO>> GetProduct();

         
    }
}