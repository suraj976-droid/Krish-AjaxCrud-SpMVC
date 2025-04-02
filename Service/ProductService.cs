using JanBatchCodeFirstApprochImpl.Data;
using JanBatchCodeFirstApprochImpl.Models;
using JanBatchCodeFirstApprochImpl.Repository;

namespace JanBatchCodeFirstApprochImpl.Service
{
    public class ProductService : IProduct
    {
        private readonly ApplicationDbContext db;
        public ProductService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void AddProduct(Product p)
        {
            db.products.Add(p);
            db.SaveChanges();
        }

        public List<Product> FetchProducts()
        {
            var data=db.products.ToList();
            return data;
        }

        public void DeleteProduct(int id)
        {
            var data=db.products.Find(id);
            if(data!=null)
            {
                db.products.Remove(data);
                db.SaveChanges();
            }
            
        }

        public List<Product> searchProduct(string str)
        {
            var data=db.products.Where(x => x.Pname.Contains(str) || x.Pcat.Contains(str) || x.Price.ToString().Contains(str)).ToList();
            return data;

            //db.products.OrderBy(x => x.Price).ToList();
            //db.products.OrderByDescending(x=>x.Price).ToList()
            //db.products.Take(5).ToList();
        }
    }
}
