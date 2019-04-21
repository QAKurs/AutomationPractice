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
        Utilities ut = new Utilities(Driver);

        [Given(@"user opens sign in page")]
        public void GivenUserOpensSignInPage()
        {
            HomePage hp = new HomePage(Driver);
            ut.ClickOnElement(hp.signIn);
        }
        
        [Given(@"enters correct credentials")]
        public void GivenEntersCorrectCredentials()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.EnterTextInElement(ap.username, TestConstants.Username);
            ut.EnterTextInElement(ap.password, TestConstants.Password);
        }

        [Given(@"initiates a flow for creating an account")]
        public void GivenInitiatesAFlowForCreatingAnAccount()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            string email = ut.GenerateRandomEmail();
            ut.EnterTextInElement(ap.email, email);
            ut.ClickOnElement(ap.createAcc);

        }

        [Given(@"user enters all required personal details")]
        public void GivenUserEntersAllRequiredPersonalDetails()
        {
            SignUpPage sup = new SignUpPage(Driver);
            ut.EnterTextInElement(sup.firstName, TestConstants.FirstName);
            ut.EnterTextInElement(sup.lastName, TestConstants.LastName);
            string fullname = TestConstants.FirstName + " " + TestConstants.LastName;
            ScenarioContext.Current.Add(TestConstants.FullName, fullname);
            ut.EnterTextInElement(sup.password, TestConstants.Password);
            ut.EnterTextInElement(sup.adFirstName, TestConstants.FirstName);
            ut.EnterTextInElement(sup.adLastName, TestConstants.LastName);
            ut.EnterTextInElement(sup.address, TestConstants.Address);
            ut.EnterTextInElement(sup.city, TestConstants.City);
            ut.DropdownSelect(sup.state, TestConstants.State);
            ut.EnterTextInElement(sup.zipCode, TestConstants.ZipCode);
            ut.EnterTextInElement(sup.phone, TestConstants.MobilePhone);
            ut.EnterTextInElement(sup.alias, TestConstants.AddressAlias);
        }

        [When(@"submits the sign up form")]
        public void WhenSubmitsTheSignUpForm()
        {
            SignUpPage sup = new SignUpPage(Driver);
            ut.ClickOnElement(sup.registerBtn);
        }

        [StepDefinition(@"user submits the login form")]
        public void WhenUserSubmitsTheLoginForm()
        {
            AuthenticationPage ap = new AuthenticationPage(Driver);
            ut.ClickOnElement(ap.signInBtn);
        }

        [Given(@"user is logged in")]
        public void GivenUserIsLoggedIn()
        {
            GivenUserOpensSignInPage();
            GivenEntersCorrectCredentials();
        }


        [When(@"user opens my wishlist")]
        public void WhenUserOpensMyWishlist()
        {
            MyAccount ma = new MyAccount(Driver);
            ut.ClickOnElement(ma.wishlist);
        }

        [Then(@"user will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
            MyAccount ma = new MyAccount(Driver);
            Assert.True(ut.ElementDisplayed(ma.logOut), "User is not logged in");
        }

        [Then(@"user can add new wishlist")]
        public void ThenUserCanAddNewWishlist()
        {
            MyWishlistPage mwp = new MyWishlistPage(Driver);
            Assert.True(ut.ElementDisplayed(mwp.newWish), "Form for adding new wishlist is not present");
        }

        [Then(@"user's full name is displayed")]
        public void ThenUserSFullNameIsDisplayed()
        {
            string fullName = ScenarioContext.Current.Get<string>(TestConstants.FullName);
            Assert.True(ut.TextPresentInElement(fullName).Displayed, "User's full name is not displayed");
        }

    }
}
