using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectMars.Utilities
{
    public class CommonDriver
    {
        public static IWebDriver driver;
        public void BrowserSetup()
        {
            driver= new ChromeDriver();
            driver.Manage().Window.Maximize();
           driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);


        }
    }
}
