using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;

namespace PetShopApp.Tests
{
    [TestClass]
    public class NormalizationTests
    {
        [TestMethod]
        public void LoginNormalizeInput_ReturnsEmpty_ForWhitespace()
        {
            var result = InvokeNormalizeInput("PetShopApp.Login", "   ", "Введите логин");
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void LoginNormalizeInput_ReturnsEmpty_ForPlaceholder()
        {
            var result = InvokeNormalizeInput("PetShopApp.Login", "Введите логин", "Введите логин");
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void LoginNormalizeInput_TrimsValidValue()
        {
            var result = InvokeNormalizeInput("PetShopApp.Login", "  pet_user  ", "Введите логин");
            Assert.AreEqual("pet_user", result);
        }

        [TestMethod]
        public void RegistrationNormalizeInput_ReturnsEmpty_ForPlaceholder()
        {
            var result = InvokeNormalizeInput("PetShopApp.Registration", "Введите пароль...", "Введите пароль...");
            Assert.AreEqual(string.Empty, result);
        }

        [TestMethod]
        public void RegistrationNormalizeInput_TrimsValidValue()
        {
            var result = InvokeNormalizeInput("PetShopApp.Registration", "  Иван  ", "Введите имя...");
            Assert.AreEqual("Иван", result);
        }

        private static string InvokeNormalizeInput(string typeName, string value, string placeholder)
        {
            var type = typeof(PetShopApp.Login).Assembly.GetType(typeName);
            Assert.IsNotNull(type, $"Type {typeName} was not found.");

            var method = type.GetMethod("NormalizeInput", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.IsNotNull(method, $"{typeName}.NormalizeInput not found.");

            var result = method.Invoke(null, new object[] { value, placeholder });
            return result as string;
        }
    }
}
