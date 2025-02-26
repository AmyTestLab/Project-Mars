using BoDi;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectMars.Utilities
{
    [Binding]
    public class Hooks:CommonDriver
    {

        [BeforeScenario]
        public void Setup()
        {
            BrowserSetup();
        }
        [AfterScenario]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
