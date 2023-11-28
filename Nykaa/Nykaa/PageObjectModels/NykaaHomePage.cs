using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nykaa.PageObjectModels
{
    internal class NykaaHomePage
    {
        IWebDriver driver;
        public NykaaHomePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//*[@id='NykaaLogo']")]
        [CacheLookup]
        private IWebElement? Logo { get; set; }


        [FindsBy(How = How.ClassName, Using = "search-suggestions-nykaa")]
        [CacheLookup]
        private IWebElement? SearchInput { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@class='css-1gzc5zn']")]
        [CacheLookup]
        private IWebElement? SignInButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@class='css-b9is7u']")]
        [CacheLookup]
        private IWebElement?CreateAccount { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@name='mobileNumber']")]
        [CacheLookup]
        private IWebElement? MobileNumberInput { get; set; }



        [FindsBy(How = How.XPath, Using = "//*[@class='css-1512uas']")]
        [CacheLookup]
        private IWebElement? SendOTP { get; set; }

       


        [FindsBy(How = How.XPath, Using = "//button[@class='css-65och3']")]
        [CacheLookup]
        private IWebElement? SignInwithMobileorEmailButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@name='emailMobile']")]
        [CacheLookup]
        private IWebElement? EmailorMobile { get; set; }

        


        [FindsBy(How = How.XPath, Using = "//*[@id='submitVerification']")]
        [CacheLookup]
        private IWebElement? ProceedButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@type='email']")]
        [CacheLookup]
        private IWebElement? SignInGoogle { get; set; }






        public void ClickOnLogo()
        {
            Logo?.Click();
        }

        public void ClickOnSignInButton()
        {
            SignInButton?.Click();
        }

        public void ClickOnSignInWithMobileOrEmail()
        {
            SignInwithMobileorEmailButton.Click();
        }
        public void ClickOnProceedButton()
        {
            ProceedButton?.Click();
        }
        public void CreateAccountLink(string email, string mobilenumber)

        {

            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(10);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            Console.WriteLine(fwait.Message);

            IWebElement modal = fwait.Until(d => d.FindElement
            (By.XPath("(//div[@class='modal-inner-wrap'])[position()=2]")));


            MobileNumberInput.SendKeys(mobilenumber);
            EmailorMobile.SendKeys(email);

           


          









        }
    }
}
