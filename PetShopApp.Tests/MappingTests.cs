using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetShopApp.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace PetShopApp.Tests
{
    [TestClass]
    public class MappingTests
    {
        [TestMethod]
        public void Category_HasExpectedTableMapping()
        {
            var attr = GetTableAttribute(typeof(Category));
            Assert.AreEqual("Categories", attr.Name);
            Assert.AreEqual("public", attr.Schema);
        }

        [TestMethod]
        public void Product_HasExpectedTableMapping()
        {
            var attr = GetTableAttribute(typeof(Product));
            Assert.AreEqual("Products", attr.Name);
            Assert.AreEqual("public", attr.Schema);
        }

        [TestMethod]
        public void User_HasExpectedTableMapping()
        {
            var attr = GetTableAttribute(typeof(User));
            Assert.AreEqual("Users", attr.Name);
            Assert.AreEqual("public", attr.Schema);
        }

        [TestMethod]
        public void Product_HasExpectedColumnNames()
        {
            AssertColumnName(typeof(Product), nameof(Product.Id), "Id");
            AssertColumnName(typeof(Product), nameof(Product.Article), "Article");
            AssertColumnName(typeof(Product), nameof(Product.Name), "Name");
            AssertColumnName(typeof(Product), nameof(Product.CategoryName), "CategoryName");
            AssertColumnName(typeof(Product), nameof(Product.Unit), "Unit");
            AssertColumnName(typeof(Product), nameof(Product.Price), "Price");
            AssertColumnName(typeof(Product), nameof(Product.Stock), "Stock");
        }

        [TestMethod]
        public void Category_HasExpectedColumnNames()
        {
            AssertColumnName(typeof(Category), nameof(Category.Id), "Id");
            AssertColumnName(typeof(Category), nameof(Category.Name), "Name");
        }

        private static TableAttribute GetTableAttribute(Type type)
        {
            return type.GetCustomAttributes(typeof(TableAttribute), false).Cast<TableAttribute>().Single();
        }

        private static void AssertColumnName(Type type, string propertyName, string expectedColumn)
        {
            var prop = type.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Instance);
            Assert.IsNotNull(prop, $"Property {propertyName} not found.");

            var column = prop.GetCustomAttributes(typeof(ColumnAttribute), false).Cast<ColumnAttribute>().Single();
            Assert.AreEqual(expectedColumn, column.Name);
        }
    }
}
