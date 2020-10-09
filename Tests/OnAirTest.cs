using NUnit.Framework;
using AutomationCoypu.Pages;
using AutomationCoypu.Common;

namespace AutomationCoypu.Tests
{
    public class OnAirTest : BaseTest
    {
        [Test]
        public void ShouldBeHaveTitle()
        {
            Browser.Visit("/login");
            Assert.AreEqual("Ninja+", Browser.Title);

        }
    }
} 