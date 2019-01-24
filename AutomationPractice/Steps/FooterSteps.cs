using AutomationPractice.Helpers;
using AutomationPractice.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationPractice.Steps
{
    [Binding]
    public class FooterSteps : Base
    {
        Footer ft = new Footer(Driver);

        [When(@"user clicks on '(.*)' option")]
        public void WhenUserClicksOnOption(string option)
        {
            ft.ClickOnInformationLink(option);
        }
        
        [Then(@"correct '(.*)' is displayed")]
        public void ThenCorrectIsDisplayed(string page)
        {
            Assert.True(ft.InformationPageDisplayed(page), "Expected page is not displayed");
        }
    }
}
