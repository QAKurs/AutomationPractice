using AutomationPractice.Helpers;
using AutomationPractice.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace AutomationPractice.Steps
{
    [Binding]
    public class PDPSteps : Base
    {
        [Given(@"user opens '(.*)' section")]
        public void GivenUserOpensSection(string cat)
        {
            Utilities ut = new Utilities(Driver);
            HomePage hp = new HomePage(Driver);
            ut.ReturnCategoryList(cat)[1].Click();
        }
        
        [Given(@"opens first product from the list")]
        public void GivenOpensFirstProductFromTheList()
        {
            Utilities ut = new Utilities(Driver);
            PLPPage plp = new PLPPage(Driver);
            ut.ClickOnElement(plp.firstProduct);
        }
        
        [Given(@"increases quantity to (.*)")]
        public void GivenIncreasesQuantityTo(string qty)
        {
            Utilities ut = new Utilities(Driver);
            Driver.SwitchTo().Frame(Driver.FindElement(By.ClassName("fancybox-iframe")));
            PDPPage pdp = new PDPPage(Driver);
            Driver.FindElement(pdp.quantity).Clear();
            ut.EnterTextInElement(pdp.quantity, qty);
            string productName = ut.ReturnTextFromElement(pdp.productName);
            ScenarioContext.Current.Add(TestConstants.ProductName, productName);
        }
        
        [When(@"user clicks on add to cart button")]
        public void WhenUserClicksOnAddToCartButton()
        {
            Utilities ut = new Utilities(Driver);
            PDPPage pdp = new PDPPage(Driver);
            ut.ClickOnElement(pdp.addButton);
        }

        [When(@"user proceeds to checkout")]
        public void WhenUserProceedsToCheckout()
        {
            Utilities ut = new Utilities(Driver);
            CartOverlayPage cart = new CartOverlayPage(Driver);
            ut.ClickOnElement(cart.checkoutBtn);
        }

        [Then(@"cart is opened and product is added to the cart")]
        public void ThenProductIsAddedToTheCart()
        {
            Utilities ut = new Utilities(Driver);
            ShoppingCartPage cart = new ShoppingCartPage(Driver);
            string product = ScenarioContext.Current.Get<string>(TestConstants.ProductName);
            Assert.That(ut.ReturnTextFromElement(cart.productName), Is.EqualTo(product), "Correct product is not present in the cart");
        }
    }
}
