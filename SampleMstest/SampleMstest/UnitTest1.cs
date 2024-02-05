using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SampleMstest
{
    [TestClass]
    public class SeleniumTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TestMethod]
        public void PerformGoogleSearch()
        {
            driver.Navigate().GoToUrl("https://www.google.com");

            IWebElement searchInput = driver.FindElement(By.Name("q"));

            searchInput.SendKeys("Selenium testing");

            searchInput.SendKeys(Keys.Enter);

            System.Threading.Thread.Sleep(2000);

            Assert.IsTrue(driver.PageSource.Contains("Selenium"));
        }

        [TestCleanup]
        public void Cleanup()
        {
            
            driver.Quit();
        }
    }

}