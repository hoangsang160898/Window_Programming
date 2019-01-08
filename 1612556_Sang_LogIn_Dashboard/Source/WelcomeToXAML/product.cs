using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIn
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string CoverImage { get; set; }
    }

    public class ProductManager
    {
        public static List<Product> GetProducts()
        {
            var products = new List<Product>();
            products.Add(new Product { ProductID = 1, Title = "IMac 4K", Price = "38.500.00đ", CoverImage = "img/data/1.jpg" });
            products.Add(new Product { ProductID = 2, Title = "IMac 5K", Price = "56.500.00đ", CoverImage = "img/data/2.jpg" });
            products.Add(new Product { ProductID = 3, Title = "Mac Mini (Space Gray)", Price = "22.500.00đ", CoverImage = "img/data/3.jpg" });
            products.Add(new Product { ProductID = 4, Title = "MacBook Air 2018 (Gold)", Price = "22.500.00đ", CoverImage = "img/data/4.jpg" });
            products.Add(new Product { ProductID = 5, Title = "Iphone XS", Price = "29.500.00đ", CoverImage = "img/data/5.jpg" });
            products.Add(new Product { ProductID = 6, Title = "MacBook Air 2018 (Silver)", Price = "22.500.00đ", CoverImage = "img/data/6.jpg" });
            products.Add(new Product { ProductID = 7, Title = "MacBook Air 2018 (Space Gray)", Price = "22.500.00đ", CoverImage = "img/data/7.jpg" });
            products.Add(new Product { ProductID = 8, Title = "MacBook Pro 13-inch 2017 (Silver)", Price = "34.500.00đ", CoverImage = "img/data/8.jpg" });
            products.Add(new Product { ProductID = 9, Title = "MacBook Pro 13-inch 2017 (Space Gray)", Price = "34.500.00đ", CoverImage = "img/data/9.jpg" });
            products.Add(new Product { ProductID = 10, Title = "MacBook Pro 2017 13-inch TouchBar (Silver)", Price = "46.500.00đ", CoverImage = "img/data/10.jpg" });
            products.Add(new Product { ProductID = 11, Title = "MacBook Pro 2017 15-inch TouchBar (Silver)", Price = "60.500.00đ", CoverImage = "img/data/11.jpg" });
            products.Add(new Product { ProductID = 12, Title = "MacBook Pro 2017 13-inch TouchBar (Space Gray)", Price = "46.500.00đ", CoverImage = "img/data/12.jpg" });
            products.Add(new Product { ProductID = 13, Title = "MacBook Pro 2017 15-inch TouchBar (Space Gray)", Price = "60.500.00đ", CoverImage = "img/data/13.jpg" });
            products.Add(new Product { ProductID = 14, Title = "Mac Mini (Silver)", Price = "22.500.00đ", CoverImage = "img/data/14.jpg" });
            return products;
        }
    }
}
