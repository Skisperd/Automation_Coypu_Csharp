using NUnit.Framework;
using AutomationCoypu.Pages;
using AutomationCoypu.Common;
using System.Threading;
using AutomationCoypu.Models;
using System;
using AutomationCoypu.Lib;

namespace AutomationCoypu.Tests
{
    public class SearchMovieTests : BaseTest
    {
        private LoginPage _login;
        private MoviePage _movie;

        [SetUp]
        public void Before()
        {
            _login = new LoginPage(Browser);
            _movie = new MoviePage(Browser);

            _login.With("tiago.dias@sidia.com", "123456");

            Database.InsertMovies();
        }

        [Test]
        public void ShouldFindUniqueMovie()
        {
            var target = "Coringa";
            _movie.Search(target);

            Assert.That(
                _movie.HasMovie(target),
                $"Erro ao verificar se o filme {target} foi encontrado."
            );
            Browser.HasNoContent("Puxa! não encontramos nada aqui :(");
            Assert.AreEqual(1, _movie.CountMovie());
        }

        [Test]
        public void ShouldFindMovies()
        {
            var target = "Batman";
            _movie.Search(target);

            Assert.That(
                _movie.HasMovie("Batman Begins"),
                $"Erro ao verificar se o filme {target} foi encontrado."
            );
            Assert.That(
                _movie.HasMovie("Batman O Cavaleiro das Trevas"),
                $"Erro ao verificar se o filme {target} foi encontrado."
            );
            Browser.HasNoContent("Puxa! não encontramos nada aqui :(");
            Assert.AreEqual(2, _movie.CountMovie());
        }

        [Test]
        public void ShouldDisplayNoMovieFound()
        {
            _movie.Search("Os Trapalhoes");
            Assert.AreEqual("Puxa! não encontramos nada aqui :(", _movie.SearchAlert());
        }
    }
}