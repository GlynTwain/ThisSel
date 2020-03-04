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

        private string textOffer = "Offers";// Для работы с правым меню
        private string textDashboard = "Dashboard";// *Скорее всего это костыль, следует переделать

        private IWebElement ButtonOffers = null;// Хранение элемента правого меню
        private IWebElement ButtonDashboard = null;// Хранение элемента правого меню

        private string[] arrOffer = { "testName", "testKey", "ICategory","INetworks","IGroup"};// Данные для полей при создании Офера?

        public IWebDriver driver = null;// Внёс из-за того что передаётся в один лишь метод, а мне удобно делить на несклько и там работать
        #endregion=================== EndDate


        #region ================= Metods

        //Начальные действия по тесту
        public void StartTest(IWebDriver driverBasic)
        {
            driver = driverBasic;

            driver.Navigate().GoToUrl("https://test-task.plarium.com/dashboard");            
            Thread.Sleep(2000); 

            IWebElement ButtonMeny = driver.FindElement(By.CssSelector("div.mat-slide-toggle-thumb"));
            OnClick(ButtonMeny, nameof(ButtonMeny));// Метод для кликов с сообщением о результате выполнения
            Thread.Sleep(2500);// Ожидания, для прогрузки страниц

            ReadOnlyCollection<IWebElement> ButtonsRightMeny = driver.FindElements(By.CssSelector("button.mat-button.mat-button-base"));
            foreach (IWebElement ButtonsRMeny in ButtonsRightMeny)
            {
                string buf = ButtonsRMeny.Text;
                if (buf == textOffer)
                {
                    ButtonOffers = ButtonsRMeny;
                }
                else if(buf == textDashboard)
                {
                    ButtonDashboard = ButtonsRMeny;
                }
                
            }  // Пробегаюсь по элементу содержащему кнопки в правом меню и раздаю их переменным       
            OnClick(ButtonOffers, nameof(ButtonOffers));
            Thread.Sleep(2000);

            IWebElement ButtonAddOffer = driver.FindElement(By.CssSelector("button.mat-raised-button.mat-button-base.mat-primary.ng-star-inserted"));
            OnClick(ButtonAddOffer, nameof(ButtonAddOffer));
            Thread.Sleep(2000);

            CreateOffer();
        }

        //Создание офера
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
            Console.WriteLine();
            Console.WriteLine(arr + " have the following elements -- " + element);
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

        #endregion
    }
}
