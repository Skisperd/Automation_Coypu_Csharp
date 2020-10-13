using NUnit.Framework;
using AutomationCoypu.Pages;
using AutomationCoypu.Common;
using System.Threading;

namespace AutomationCoypu.Tests
{
    public class LoginTest : BaseTest
    {   
        private LoginPage _login;
        private Sidebar _side;

        [SetUp]
        public void Start()
        {
            _login = new LoginPage(Browser);
            _side = new Sidebar(Browser);
        }           
        [Test]
        [Category("Critical")]
        public void ShouldSeeLoggedUser()
        {
            _login.With("tiago.dias@sidia.com", "123456");
            Thread.Sleep(1000);
            Assert.AreEqual("tiago", _side.LoggedUser());

        }
        [Test]
        public void  ShouldSeeIncorrectPass()
        {
    
            _login.With("tiago.dias@sidia.com", "1234563");
            Assert.AreEqual("Usuário e/ou senha inválidos", _login.AlertMessage());
        }
        [Test]
        public void  ShouldSeeIncorrectUser()
        {
            _login.With("tiago.diasa@sidia.com", "123456");
            Assert.AreEqual("Usuário e/ou senha inválidos", _login.AlertMessage());
        }
        [Test]
        public void ShouldSeeRequiredEmail()
        {
            _login.With("", "123456");
            Assert.AreEqual("Opps. Cadê o email?", _login.AlertMessage());
        }
        [Test]
        public void ShouldSeeRequiredPass()
        {
            _login.With("tiago.dias@sidia.com", "");
            Assert.AreEqual("Opps. Cadê a senha?", _login.AlertMessage());
        }
    }
}