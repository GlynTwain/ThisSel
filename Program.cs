using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace ThisSel
{
    [TestClass]
    class Program
    {
        [TestMethod]
        static void Main(string[] args)
        {
            Console.WriteLine("Start testing!");
            IWebDriver driver = new ChromeDriver(); //Установить хром как браузер, и открыть
            if (driver == null) Console.WriteLine("Ошибка: Chrome Driver не удалось создать!");
            driver.Manage().Window.Maximize();// Развернуть на весь экран
            
            NotMain Test = new NotMain(); // Создать экземпляр класса для тестирования

            Test.StartTest(driver); // Начать тестирование и передать драйвер браузера

            //driver.Quit(); // Дорабоать 
            Console.ReadKey(); // Для того что бы консоль 
        }
        
    }
}
