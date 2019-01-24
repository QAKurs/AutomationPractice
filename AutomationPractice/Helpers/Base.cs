using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace AutomationPractice.Helpers
{
    [Binding]
    public class Base
    {
        public static IWebDriver Driver { get; private set; }
        private static readonly bool RunLocally = bool.Parse(ConfigurationManager.AppSettings["RunLocally"]);

        [BeforeScenario]
        public static void BeforeScenario()
        {
            //Driver = new ChromeDriver();
            if (RunLocally)
            {
                Driver = new ChromeDriver();
            }
            else
            {
                const string browserVersion = "70.0";
                const string resolution = "1280x1024";

                ChromeOptions options = new ChromeOptions();

                const string slUsername = "mmanic";
                const string slAccessKey = "49f94442-51ef-4abf-ba8e-51647a611ca1";
                const string slPlatform = "Windows 8.1";

                // SauceLabs Capabilities
                options.AddAdditionalCapability("username", slUsername, true);
                options.AddAdditionalCapability("accessKey", slAccessKey, true);
                options.AddAdditionalCapability("platform", slPlatform, true);
                options.AddAdditionalCapability("screenResolution", resolution, true);
                options.AddAdditionalCapability("version", browserVersion, true);
                options.AddAdditionalCapability("name", TestContext.CurrentContext.Test.Name, true);

                // Instantiate the driver on sauce labs and create report
                Driver = new RemoteWebDriver(new Uri("http://ondemand.saucelabs.com:80/wd/hub"), options.ToCapabilities());
                Console.WriteLine(@"SauceOnDemandSessionID={0} job-name={1}", ((RemoteWebDriver)Driver).SessionId, TestContext.CurrentContext.Test.Name);
            }

            Driver.Manage().Window.Maximize();

            var url = ConfigurationManager.AppSettings["live"];
            Driver.Url = url;
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;

            try
            {
                if (!RunLocally)
                {
                    // Logs the result to Sauce Labs
                    ((IJavaScriptExecutor)Driver).ExecuteScript("sauce:job-result=" +
                                                                 (status == TestStatus.Passed ? "passed" : "failed"));
                }
                else
                {
                }
            }
            finally
            {
                Driver?.Quit();
            }
        }
    }
}
