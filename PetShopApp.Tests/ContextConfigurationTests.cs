using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShopApp.Database;
using System.Data.Entity;
using System.Reflection;

namespace PetShopApp.Tests
{
    [TestClass]
    public class ContextConfigurationTests
    {
        [TestMethod]
        public void PetShopContext_HasDbSetProperties()
        {
            var categoriesProp = typeof(PetShopContext).GetProperty("Categories", BindingFlags.Public | BindingFlags.Instance);
            var productsProp = typeof(PetShopContext).GetProperty("Products", BindingFlags.Public | BindingFlags.Instance);
            var usersProp = typeof(PetShopContext).GetProperty("Users", BindingFlags.Public | BindingFlags.Instance);

            Assert.IsNotNull(categoriesProp);
            Assert.IsNotNull(productsProp);
            Assert.IsNotNull(usersProp);

            Assert.AreEqual(typeof(DbSet<PetShopApp.Models.Category>), categoriesProp.PropertyType);
            Assert.AreEqual(typeof(DbSet<PetShopApp.Models.Product>), productsProp.PropertyType);
            Assert.AreEqual(typeof(DbSet<PetShopApp.Models.User>), usersProp.PropertyType);
        }

        [TestMethod]
        public void PetShopContext_HasParameterlessConstructor()
        {
            var ctor = typeof(PetShopContext).GetConstructor(System.Type.EmptyTypes);
            Assert.IsNotNull(ctor);
        }
    }
}
