using ExcelDataReader.Log;
using Nykaa.PageObjectModels;
using Nykaa.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nykaa.TestScripts
{
    internal class NykaaTest : CoreCodes
    {
       /* public void ReadConfigSettings()
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

        }*/

        [Test]

        public void ClickOnLogo()
        {
            //Assert.AreEqual("Nykaa", driver.Title);
            Assert.That(driver.Title.Contains("Nykaa"));
            Console.WriteLine("Title passed");
        }
    
}

        [Test]
        public void CreateAccount()
        {
            string curDir = Directory.GetParent(@"../../../").FullName;
            string filename = curDir + "/Logs/log_" + DateTime.Now.ToString("dd/mm/yyyy_hhmmss") + ".txt";



            
              

