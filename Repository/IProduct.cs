using JanBatchCodeFirstApprochImpl.Models;

namespace JanBatchCodeFirstApprochImpl.Repository
{
    public interface IProduct
    {
        void AddProduct(Product p);

        List<Product> FetchProducts();

        void DeleteProduct(int id);

        List<Product> searchProduct(string str);
    }
}
