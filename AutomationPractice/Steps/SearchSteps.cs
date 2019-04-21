using AutomationPractice.Helpers;
using AutomationPractice.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationPractice.Steps
{
    [Binding]
    public class SearchSteps : Base
    {
        [Given(@"user enters a '(.*)' search term")]
        public void GivenUserEntersASearchTerm(string term)
        {
            Utilities ut = new Utilities(Driver);
            HomePage hp = new HomePage(Driver);
            ut.EnterTextInElement(hp.searchFld, term);
        }
        
        [StepDefinition(@"user submits the search")]
        public void WhenUserSubmitsTheSearch()
        {
            Utilities ut = new Utilities(Driver);
            HomePage hp = new HomePage(Driver);
            ut.ClickOnElement(hp.searchBtn);
        }

        [Then(@"results for a '(.*)' search term are displayed")]
        public void ThenResultsForASearchTermAreDisplayed(string term)
        {
            Utilities ut = new Utilities(Driver);
            SearchResultsPage srp = new SearchResultsPage(Driver);
            Assert.That(ut.ReturnTextFromElement(srp.searchTerm), Does.Contain(term), "Search results for the required term are not displayed");
        }
    }
}
