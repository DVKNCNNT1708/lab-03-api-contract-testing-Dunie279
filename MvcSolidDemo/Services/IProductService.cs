using MvcSolidDemo.Models;

namespace MvcSolidDemo.Services
{
    // Interface Product Service
    public interface IProductService
    {
        List<Product> GetAllProducts();
    }

    // Class triển khai thực tế
    public class ProductService : IProductService
    {
        private readonly IDiscountStrategy _discountStrategy;

        // Bơm DI Container qua Constructor
        public ProductService(IDiscountStrategy discountStrategy)
        {
            _discountStrategy = discountStrategy;
        }

        public List<Product> GetAllProducts()
        {
            var list = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop ASUS TUF", Price = 20000000, Stock = 10 },
                new Product { Id = 2, Name = "Chuột Logitech G102", Price = 400000, Stock = 50 },
                new Product { Id = 3, Name = "Bàn phím Akko K316", Price = 1500000, Stock = 5 }
            };

            foreach (var prod in list)
            {
                prod.Price = _discountStrategy.ApplyDiscount(prod.Price);
            }
            return list;
        }
    }
}