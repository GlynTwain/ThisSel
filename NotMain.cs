using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private string textOffer = "Offers";
        private string textDashboard = "Dashboard";

        private IWebElement ButtonOffers = null;
        private IWebElement ButtonDashboard = null;

        private string[] arrOffer = { "myName","ThisKey","ICategory","INetworks","IGroup"};

        public IWebDriver driver = null;
        #endregion=================== EndDate

        public void StartTest(IWebDriver driverBasic)
        {
            driver = driverBasic;

            driver.Navigate().GoToUrl("https://test-task.plarium.com/dashboard");            
            Thread.Sleep(2000); 

            IWebElement ButtonMeny = driver.FindElement(By.CssSelector("div.mat-slide-toggle-thumb"));
            OnClick(ButtonMeny, nameof(ButtonMeny));
            Thread.Sleep(2500);

            ReadOnlyCollection<IWebElement> ButtonsRightMeny = driver.FindElements(By.CssSelector("button.mat-button.mat-button-base"));
            foreach (IWebElement ButtonsRMeny in ButtonsRightMeny)
            {
                string buf = ButtonsRMeny.Text;
                //Console.WriteLine(buf);
                if (buf == textOffer)
                {
                    ButtonOffers = ButtonsRMeny;
                }
                else if(buf == textDashboard)
                {
                    ButtonDashboard = ButtonsRMeny;
                }
                
            }         
            OnClick(ButtonOffers, nameof(ButtonOffers));
            Thread.Sleep(2000);

            IWebElement ButtonAddOffer = driver.FindElement(By.CssSelector("button.mat-raised-button.mat-button-base.mat-primary.ng-star-inserted"));
            OnClick(ButtonAddOffer, nameof(ButtonAddOffer));
            Thread.Sleep(2000);

            CreateOffer();
        }

        

        private void CreateOffer()
        {
            
            IWebElement InputName = driver.FindElement(By.Name("name"));
            InputName.SendKeys(arrOffer[0]);
            Thread.Sleep(2000);

            IWebElement InputKey = driver.FindElement(By.Name("key"));
            InputKey.SendKeys(arrOffer[1]);
            Thread.Sleep(2000);

            

            IWebElement InputFieldCategory = driver.FindElement(By.Id("mat-input-2"));
            OnClick(InputFieldCategory, nameof(InputFieldCategory));
            Thread.Sleep(1000);           

            ReadOnlyCollection<IWebElement> AllCategory = driver.FindElements(By.CssSelector("option.ng-star-inserted"));
            foreach (IWebElement element in AllCategory)
            {              
                PrintArrElements(nameof(AllCategory), element.Text);
            }

            OnClick(AllCategory[1], AllCategory[1].Text);


            IWebElement InputSelectNetworks = driver.FindElement(By.Name("networks"));
            OnClick(InputSelectNetworks, nameof(InputSelectNetworks));
            Thread.Sleep(1000);
            
            IWebElement SelectNetwork = driver.FindElement(By.Name("1"));
            OnClick(SelectNetwork, nameof(SelectNetwork));
        }

        private void AddPoint(IWebElement element, string nameElement)
        {
            
        }

        private void PrintArrElements(string arr, string element)
        {
            Console.WriteLine(arr+ " have the following elements:");
            Console.WriteLine(" - " + element);
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
