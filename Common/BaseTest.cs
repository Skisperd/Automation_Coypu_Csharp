using NUnit.Framework;
using Coypu;
using Coypu.Drivers.Selenium;
using System.Threading;
using System;
using AutomationCoypu.Pages;

namespace AutomationCoypu.Common
{
    public class BaseTest
    {
        protected BrowserSession Browser;
        
        [SetUp]
        public void Setup()
        {
            var configs = new SessionConfiguration
            {
                AppHost = "http://ninjaplus-web",
                Port = 5000,
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                Browser = Coypu.Drivers.Browser.Chrome,
                Timeout = TimeSpan.FromSeconds(10)
            };

            Browser = new BrowserSession(configs);

            Browser.MaximiseWindow();
        }

        public string CoverPath()
        {
            var outputPath = Environment.CurrentDirectory;
            return outputPath + "\\Images\\";
        }
        [TearDown]
        public void Finish()
        {
            Browser.Dispose();
        }
    }
}