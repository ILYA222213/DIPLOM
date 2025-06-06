using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace Sklad1.UnitTest
{
    [TestClass]
    public class ProductTests
    {
        // Замените connectionString на актуальный для тестов
        private const string TestConnectionString = "Server=(local);Database=TestDB;Trusted_Connection=True;";

        // Метод для тестирования (скопирован из вашего кода)
        private decimal GetProductPriceById(int productId)
        {
            using (SqlConnection connection = new SqlConnection(TestConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Цена FROM Товары WHERE ID_товара = @ProductId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ProductId", productId);
                    object result = command.ExecuteScalar();

                    if (result != null && decimal.TryParse(result.ToString(), out decimal price))
                    {
                        return price;
                    }
                    else
                    {
                        throw new Exception("Цена товара не найдена.");
                    }
                }
                catch (Exception ex)
                {
                    // Логируем ошибку и пробрасываем исключение дальше
                    throw new Exception($"Ошибка при получении цены товара: {ex.Message}");
                }
            }
        }

        // Тест 1: Проверка корректного возврата цены товара
        [TestMethod]
        public void GetProductPriceById_ValidProductId_ReturnsPrice()
        {
            // Arrange
            int productId = 1; // Предположим, что товар с ID=1 существует и имеет цену 100.50
            decimal expectedPrice = 100.50m;

            // Act
            decimal actualPrice = GetProductPriceById(productId);

            // Assert
            Assert.AreEqual(expectedPrice, actualPrice, $"Ожидаемая цена: {expectedPrice}, фактическая цена: {actualPrice}");
        }

        // Тест 2: Проверка выброса исключения при отсутствии товара
        [TestMethod]
        public void GetProductPriceById_InvalidProductId_ThrowsException()
        {
            // Arrange
            int invalidProductId = -1; // Предположим, что товара с ID=-1 не существует

            // Act & Assert
            var exception = Assert.ThrowsException<Exception>(() => GetProductPriceById(invalidProductId));
            Assert.AreEqual("Цена товара не найдена.", exception.Message);
        }
    }
}
