using AutomationPractice.Helpers;
using AutomationPractice.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationPractice.Steps
{
    [Binding]
    public class ContactSteps : Base
    {
        Utilities ut = new Utilities(Driver);

        [Given(@"user opens contact us page")]
        public void GivenUserOpensContactUsPage()
        {
            //Utilities ut = new Utilities(Driver);
            HomePage hp = new HomePage(Driver);
            ut.ClickOnElement(hp.contactUs);
        }
        
        [Given(@"fills in all required fields with '(.*)' heading and '(.*)' message")]
        public void GivenFillsInAllRequiredFields(string heading, string message)
        {
            Utilities ut = new Utilities(Driver);
            ContactUsPage cup = new ContactUsPage(Driver);
            ut.DropdownSelect(cup.subjectHeading, heading);
            ut.EnterTextInElement(cup.contactEmail, ut.GenerateRandomEmail());
            ut.EnterTextInElement(cup.message, message);
        }
        
        [When(@"user submits the form")]
        public void WhenUserSubmitsTheForm()
        {
            Utilities ut = new Utilities(Driver);
            ContactUsPage cup = new ContactUsPage(Driver);
            ut.ClickOnElement(cup.sendBtn);
        }
        
        [Then(@"message '(.*)' is presented to the user")]
        public void ThenMessageIsPresentedToTheUser(string alertMsg)
        {
            Utilities ut = new Utilities(Driver);
            ContactUsPage cup = new ContactUsPage(Driver);
            Assert.That(ut.ReturnTextFromElement(cup.successMessage), Is.EqualTo(alertMsg), "Message was not sent to customer service");
        }
    }
}
