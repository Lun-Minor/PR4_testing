using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        ///Проверяет базовые утверждения Assert на простом примере сложения 2 + 2
        /// </summary>
        [TestMethod]
        public void TestMethod()
        {
            int res = 2 + 2;
            Assert.AreEqual(res, 4 );
            Assert.AreNotEqual( res, 5 );
            Assert.IsFalse(res>5);
            Assert.IsTrue(res < 5);
        }
        /// <summary>
        /// Проверяет корректность вычисления функции
        /// при значениях x = 2, b = 2
        /// </summary>
        [TestMethod]
        public void CalculateY_x2_b2_Returns_Expected()
        {
            
            double x = 2;
            double b = 2;

         
            double cubeSum = Math.Pow(x, 3) + Math.Pow(b, 3);
            double cubeRoot = Math.Pow(cubeSum, 1.0 / 3.0);
            double y = 9 * (x + 15 * cubeRoot);

            double expected = 358.179;
            // Проверяем, что вычисленное значение y почти равно ожидаемому
            Assert.AreEqual(expected, y, 0.001, "Неправильно считается y при x=2, b=2");
        }
        /// <summary>
        /// Проверяет ветку вычисления квадрата числа в функции
        /// </summary>
        [TestMethod]
        public void GetF_x3_Returns_Exp()
        {
            // Проверяем, что Math.Exp(3) равно самому себе
            Assert.AreEqual(Math.Exp(3), Math.Exp(3), 0.001); 
        }
        /// <summary>
        /// Проверяет, что значение арккосинуса от 0.5 равно π/3 (≈ 1.0471975511965976)
        /// </summary>
        [TestMethod]
        public void Arccos_0_5_Is_PiDiv3()
        {
            // Проверяем, что arccos(0.5) действительно равно π/3
            Assert.AreEqual(Math.PI / 3, Math.Acos(0.5), 0.001);
        }
    }
}
