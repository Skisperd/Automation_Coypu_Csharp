using Coypu;

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
        public void Save(string title)
        {
            _browser.FindCss("input[name=title]").SendKeys(title);
        }
    }
}