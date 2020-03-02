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
            Console.WriteLine("Hello world");
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            //driver.Manage().Timeouts();
            //PageLoadTimeout(10, TimeUnit.SECONDS)

            NotMain Test = new NotMain();

            Test.StartTest(driver);

            //driver.Quit();
            Console.ReadKey();
        }
        
    }
}
