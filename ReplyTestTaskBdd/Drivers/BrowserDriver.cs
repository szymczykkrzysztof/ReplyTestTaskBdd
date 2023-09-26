using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace ReplyTestTaskBdd.Drivers
{
    /// <summary>
    /// Manages a browser instance using Selenium
    /// </summary>
    public class BrowserDriver : IDisposable
    {
        private readonly Lazy<IWebDriver> _currentWebDriverLazy;
        private bool _isDisposed;

        protected BrowserDriver()
        {
            _currentWebDriverLazy = new Lazy<IWebDriver>(CreateWebDriver);
        }

        /// <summary>
        /// The Selenium IWebDriver instance
        /// </summary>
        public IWebDriver Current => _currentWebDriverLazy.Value;

        /// <summary>
        /// Creates the Selenium web driver (opens a browser)
        /// </summary>
        /// <returns></returns>
        private IWebDriver CreateWebDriver()
        {
            IWebDriver? driver = null;
            switch (Hooks.Hooks.Configuration?["browser"])
            {
                case "Chrome":
                {
                    var chromeDriverService = ChromeDriverService.CreateDefaultService();
                    var chromeOptions = new ChromeOptions();
                    var chromeDriver = new ChromeDriver(chromeDriverService, chromeOptions);
                    driver =  chromeDriver;
                    break;
                }
                case "Firefox":
                {
                    var fireFoxDriverService = FirefoxDriverService.CreateDefaultService();
                    var fireFoxOptions = new FirefoxOptions();
                    var geckoDriver = new FirefoxDriver(fireFoxDriverService, fireFoxOptions);
                    driver = geckoDriver;
                    break;
                }
            }
            
            return driver;
        }

        /// <summary>
        /// Disposes the Selenium web driver (closing the browser)
        /// </summary>
        public void Dispose()
        {
            if (_isDisposed)
            {
                return;
            }

            if (_currentWebDriverLazy.IsValueCreated)
            {
                Current.Quit();
            }

            _isDisposed = true;
        }
    }
}