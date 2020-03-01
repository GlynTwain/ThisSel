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
            Console.WriteLine("Hello World!");
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://test-task.plarium.com/dashboard");
            IWebElement ButtonMeny = driver.FindElement(By.CssSelector("div.mat-slide-toggle-thumb"));

            //ButtonMeny.Click();
            if (ButtonMeny == null)
            {
                Console.WriteLine("Ошибка: Не найдена кнопка");
            }
            else
            {
                ButtonMeny.Click();
                Console.WriteLine(" Done");
            }

            driver.Quit();


            //ButtonMeny.;
            //ButtonMeny. IWebElement ButtonMeny = .Click()
            //InfoTest();
            Console.ReadKey();
        }
        /*
        static public void InfoTest()
        {
            private string _tougleMeny = "Ошибка";
        }*/
    }
}
