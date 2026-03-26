using PetShopApp.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PetShopApp.Database
{
    internal static class CategoryRepository
    {
        internal sealed class CategoryRow
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public static void Add(string name)
        {
            using (var db = new PetShopContext())
            {
                if (db.Categories.Any(c => c.Name == name))
                    return;

                db.Categories.Add(new Category { Name = name });
                db.SaveChanges();
            }
        }

        public static void DeleteByName(string name)
        {
            using (var db = new PetShopContext())
            {
                var category = db.Categories.FirstOrDefault(c => c.Name == name);
                if (category != null)
                {
                    db.Categories.Remove(category);
                    db.SaveChanges();
                }
            }
        }

        public static List<string> GetAllNames()
        {
            using (var db = new PetShopContext())
            {
                return db.Categories
                    .OrderBy(c => c.Name)
                    .Select(c => c.Name)
                    .ToList();
            }
        }

        public static List<CategoryRow> GetAll(string search = null)
        {
            using (var db = new PetShopContext())
            {
                IQueryable<Category> query = db.Categories;

                if (!string.IsNullOrEmpty(search))
                    query = query.Where(c => c.Name.ToLower().Contains(search.ToLower()));

                return query
                    .OrderBy(c => c.Name)
                    .Select(c => new CategoryRow { Id = c.Id, Name = c.Name })
                    .ToList();
            }
        }

        public static bool UpdateName(int id, string newName)
        {
            using (var db = new PetShopContext())
            {
                var category = db.Categories.Find(id);
                if (category == null)
                    return false;

                category.Name = newName;
                return db.SaveChanges() > 0;
            }
        }
    }
}
