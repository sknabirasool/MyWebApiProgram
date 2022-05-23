using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApiDemo.Models;


namespace WebApiDemo.Controllers
{
    public class ProductsController : Controller
    {
        static readonly IProductRepository repository = new ProductRepository();
        public IEnumerable<Product> GetAllProducts()
            {
                return repository.GetAll();
            }
        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)
        {
            return repository.GetAll().Where(
                p => string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

    }
}
