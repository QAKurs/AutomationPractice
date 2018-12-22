using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Pages
{
    class PDPPage
    {
        readonly IWebDriver driver;

        public By quantity = By.Id("quantity_wanted");
        public By pdpDialog = By.ClassName("primary_block");
        public By addButton = By.Id("add_to_cart");
        public By productName = By.XPath("//h1[@itemprop='name']");

        public PDPPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(pdpDialog));
        }
    }
}
