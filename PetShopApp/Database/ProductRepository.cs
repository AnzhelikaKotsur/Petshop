using PetShopApp.Models;
using System.Linq;

namespace PetShopApp.Database
{
    internal static class ProductRepository
    {
        public static void Add(string article, string name, string categoryName, string unit, decimal price)
        {
            using (var db = new PetShopContext())
            {
                if (db.Products.Any(p => p.Article == article))
                    return;

                db.Products.Add(new Product
                {
                    Article = article,
                    Name = name,
                    CategoryName = categoryName,
                    Unit = unit,
                    Price = price,
                    Stock = 0
                });
                db.SaveChanges();
            }
        }

        public static void Update(string article, string name, string categoryName, string unit, decimal price)
        {
            using (var db = new PetShopContext())
            {
                var product = db.Products.FirstOrDefault(p => p.Article == article);
                if (product == null)
                    return;

                product.Name = name;
                product.CategoryName = categoryName;
                product.Unit = unit;
                product.Price = price;
                db.SaveChanges();
            }
        }

        public static void DeleteByArticle(string article)
        {
            using (var db = new PetShopContext())
            {
                var product = db.Products.FirstOrDefault(p => p.Article == article);
                if (product != null)
                {
                    db.Products.Remove(product);
                    db.SaveChanges();
                }
            }
        }
    }
}
