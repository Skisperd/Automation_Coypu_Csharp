using NUnit.Framework;
using AutomationCoypu.Pages;
using AutomationCoypu.Common;
using System.Threading;

namespace AutomationCoypu.Tests
{
    public class SaveMovieTest : BaseTest
    {
        private LoginPage _login;

        private MoviePage _movie;

        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _movie = new MoviePage(Browser);
            _login.With("tiago.dias@sidia.com", "123456");
        }
        [Test]
        public void ShouldSaveMovie()
        {
            _movie.Add();
            _movie.Save("Resident Evil");
            Thread.Sleep(5000);

        }

    }

}