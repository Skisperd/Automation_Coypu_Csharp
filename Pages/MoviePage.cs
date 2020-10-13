using System.Collections.Generic;
using System.Threading;
using AutomationCoypu.Models;
using Coypu;
using OpenQA.Selenium;

namespace AutomationCoypu.Pages
{
    public class MoviePage
    {
        private readonly BrowserSession _browser;
        public MoviePage(BrowserSession browser)
        {
            _browser = browser;
        }

        public void Add()
        {
            _browser.FindCss(".movie-add").Click();
        }
        public void SelectStatus(string status)
        {
            //_browser.Select("Disponível").From("SELECTOR_DO_ELEMENTO");
            _browser.FindCss("input[placeholder=Status]").Click();
            var option = _browser.FindCss("ul li span", text: status);
            option.Click();
        }
        private void InputCast(List<string> cast)
        {
            var element = _browser.FindCss("input[placeholder$=ator]");

            foreach (var actor in cast)
            {
                element.SendKeys(actor);
                element.SendKeys(Keys.Tab);
                Thread.Sleep(500);
            }
        }

        private void UploadCover(string cover)
        {
            var jsScript = "document.getElementById('upcover').classList.remove('el-upload__input');";
            _browser.ExecuteScript(jsScript);
            
            _browser.FindCss("#upcover").SendKeys(cover);
        }

        public void Save(MovieModel movie)
        {
            _browser.FindCss("input[name=title]").SendKeys(movie.Title);
            SelectStatus(movie.Status);

            _browser.FindCss("input[name=year]").SendKeys(movie.Year.ToString());
            _browser.FindCss("input[name=release_date]").SendKeys(movie.ReleaseDate);
            InputCast(movie.Cast);
            _browser.FindCss("textarea[name=overview]").SendKeys(movie.Plot);
            UploadCover(movie.Cover);


        }
    }
}