using NUnit.Framework;
using Coypu;
using Coypu.Drivers.Selenium;
using System.Threading;
using System;
using AutomationCoypu.Pages;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AutomationCoypu.Common
{
    public class BaseTest
    {
        protected BrowserSession Browser;
        
        [SetUp]
        public void Setup()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("config.json")
                .Build();

            var sessionConfig = new SessionConfiguration
            {
                AppHost = "http://ninjaplus-web",
                Port = 5000,
                SSL = false,
                Driver = typeof(SeleniumWebDriver),
                Timeout = TimeSpan.FromSeconds(10)
            };

            if (config["browser"].Equals("chrome"))
            {
                sessionConfig.Browser = Coypu.Drivers.Browser.Chrome;
            }

            if (config["browser"].Equals("firefox"))
            {
                sessionConfig.Browser = Coypu.Drivers.Browser.Firefox;
            }
            Browser = new BrowserSession(sessionConfig);

            Browser.MaximiseWindow();
        }

        public string CoverPath()
        {
            var outputPath = Environment.CurrentDirectory;
            return outputPath + "\\Images\\";
        }
        public void TakeScreenshot()
        {   
            var shotPath = Environment.CurrentDirectory + "\\Screenshots\\";
            var resultId = TestContext.CurrentContext.Test.ID;


            if(!Directory.Exists(shotPath))
            {
                Directory.CreateDirectory(shotPath);
            }

            var screenshot = ($"{shotPath}\\{resultId}.png");
            Browser.SaveScreenshot(screenshot);
            TestContext.AddTestAttachment(screenshot);
        }


        [TearDown]
        public void Finish()
        {   
            try
            {
                TakeScreenshot();
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro ao capturar o Screenshot");
                throw new Exception(e.Message);
            }
            finally
            {
                Browser.Dispose();
            }
        }
    }
}