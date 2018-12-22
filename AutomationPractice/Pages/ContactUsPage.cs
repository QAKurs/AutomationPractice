using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Pages
{
    class ContactUsPage
    {
        readonly IWebDriver driver;

        public By subjectHeading = By.Id("id_contact");
        public By contactEmail = By.Id("email");
        public By message = By.Id("message");
        public By sendBtn = By.Id("submitMessage");
        public By successMessage = By.ClassName("alert-success");

        public ContactUsPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id("contact")));
        }
    }
}
