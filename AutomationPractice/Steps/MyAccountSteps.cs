using AutomationPractice.Helpers;
using AutomationPractice.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationPractice.Steps
{
    [Binding]
    public class MyAccountSteps : Base
    {
        [Given(@"user opens sign in page")]
        public void GivenUserOpensSignInPage()
        {
            Utilities ut = new Utilities(Driver);
            HomePage hp = new HomePage(Driver);
            ut.ClickOnElement(hp.signIn);
        }
        
        [Given(@"enters correct credentials")]
        public void GivenEntersCorrectCredentials()
        {
            Utilities ut = new Utilities(Driver);
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.username, TestConstants.Username);
            ut.EnterTextInElement(ap.password, TestConstants.Password);
        }
        
        [When(@"user submits the login form")]
        public void WhenUserSubmitsTheLoginForm()
        {
            Utilities ut = new Utilities(Driver);
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(ap.signInBtn);
        }
        
        [Then(@"user will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            Utilities ut = new Utilities(Driver);
            MyAccount ma = new MyAccount(Driver);
            Assert.True(ut.ElementDisplayed(ma.logOut), "User is not logged in");
        }
    }
}
