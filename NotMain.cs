using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ThisSel
{
    class NotMain
    {

        #region ===================== Date

        private string passed = " -- Passed";
        private string error = " -- Error";

        #endregion=================== EndDate

        public void StartTest(IWebDriver driver)
        {
            
            driver.Navigate().GoToUrl("https://test-task.plarium.com/dashboard");

            Thread.Sleep(5000); 
            IWebElement ButtonMeny = driver.FindElement(By.CssSelector("div.mat-slide-toggle-thumb"));
            OnClick(ButtonMeny, nameof(ButtonMeny));
            Thread.Sleep(5000);
            IWebElement ButtonOffers = driver.FindElement(By.CssSelector("button.mat-button mat-button-base"));
            OnClick(ButtonOffers, nameof(ButtonOffers));
            Thread.Sleep(5000);
        }

        private void OnClick(IWebElement element, string nameElement)
        {

            if (element == null)
            {
                Console.WriteLine(nameElement + error);
            }
            else
            {
                element.Click();
                Console.WriteLine(nameElement + passed);
            }
        }



    }
}
