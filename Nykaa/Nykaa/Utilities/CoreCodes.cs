using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nykaa.Utilities
{
    internal class CoreCodes
    {
        public Dictionary<string, string>? properties;
        public  IWebDriver driver;

        public ExtentReports extent;
        ExtentSparkReporter sparkReporter;
        public ExtentTest test;

        public void ReadConfigsetting()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            properties = new Dictionary<string, string>();
            string fileName = currDir + "/Configsetting/Config.properties";
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }

        }
        public static void ScrollIntoView(IWebDriver driver, IWebElement? element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("argument[0].scrollIntoView(true);", element);
        }



        public bool CheckLinkStatus(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)
                    System.Net.WebRequest.Create(url);
                request.Method = "HEAD";
                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        [OneTimeSetUp]
        public void InitializeBrowser()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            extent = new ExtentReports();
            sparkReporter = new ExtentSparkReporter(currDir + "/ExtentReports/extent-report-"
                                  + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".html");
            extent.AttachReporter(sparkReporter);

            ReadConfigsetting();
            if (properties["browser"].ToLower() == "chrome")
            {
                driver = new ChromeDriver();

            }
            else if (properties["browser"].ToLower() == "edge")
            {
                driver = new EdgeDriver();
            }

            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();



        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
        }


        public void TakeScreenShotTest()

        {
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();

            string curDir = Directory.GetParent(@"../../../").FullName;
            string filename = curDir + "/ScreenShot/ss_" + DateTime.Now.ToString("dd/mm/yyyy_hhmmss") + ".png";
            screenshot.SaveAsFile(filename);
        }
    


      /*  protected void LogTestResult(string testName, string result, string errorMessage = null)
        {
            Log.Information(result);
            test = extent.CreateTest(testName);
            if(errorMessage != null)
            {
                Log.Information(testName+ "Passed");
                test.Pass(result);
            }
            else
            {
                Log.Error($"Test failed for {testName}. \n Exception: \n {errorMessage}");
                test.Fail(result);
            }

        }*/

}
        }
    

