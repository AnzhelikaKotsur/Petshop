using System.Data.Entity;
using PetShopApp.Models;

namespace PetShopApp.Database
{
    /// <summary>
    /// EF6 контекст базы данных зоомагазина (PostgreSQL).
    /// </summary>
    public class PetShopContext : DbContext
    {
        public PetShopContext()
            : base("name=PetShopConnection")
        {
            // Не создаём и не мигрируем схему автоматически — таблицы уже есть
            System.Data.Entity.Database.SetInitializer<PetShopContext>(null);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            base.OnModelCreating(modelBuilder);
        }
    }
}
