using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Pages
{
    class AuthenticationPage
    {
        readonly IWebDriver driver;

        public By username = By.Id("email");
        public By password = By.Id("passwd");
        public By signInBtn = By.Id("SubmitLogin");
        public By email = By.Id("email_create");
        public By createAcc = By.Id("SubmitCreate");

        public AuthenticationPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("authentication")));
        }
    }
}
