using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Text;
using DocumentFormat.OpenXml.Office2010.CustomUI;
using SeleniumRunner;
using System.Reflection;
using static System.Net.WebRequestMethods;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Windows.Forms;
using SonHal;

namespace SonHal
{
    public class SideRunner
    {

        private static IWebDriver driver;
        private List<MatchedDto> repeatedList;

        
        public void SideRunnerSteps(List<MatchedDto> matchedDtos, string secilenDriver)
        {
            try
            {
               
                switch (secilenDriver)
                {
                    case "Chrome":
                        ChromeOptions opt = new ChromeOptions();
                        opt.AddUserProfilePreference("excludeSwitches", new List<string>() { "disable-popup-blocking" });
                        driver = new ChromeDriver(opt);
                        break;
                    case "Mozilla Firefox":
                        var firefoxOptions = new FirefoxOptions();
                        firefoxOptions.AddArguments("-disable-popup-blocking");
                        driver = new FirefoxDriver(firefoxOptions);
                        break;
                    case "Edge":
                        var edgeOptions = new EdgeOptions();
                        edgeOptions.AddAdditionalOption("preventBlockingOfSharedProcesses", true);
                        edgeOptions.AddArgument("--disable-popup-blocking");
                        driver = new EdgeDriver(edgeOptions);
                        break;
                    default:
                        ChromeOptions defaultdriver = new ChromeOptions();
                        defaultdriver.AddUserProfilePreference("excludeSwitches", new List<string>() { "disable-popup-blocking" });
                        driver = new ChromeDriver(defaultdriver);
                        break;
                }

                ISeleniumDriver webDriver = new WebDriver(driver);



                foreach (var cellValue in matchedDtos)
                {
                    var isExcelGrid = cellValue.isExcel;
                    var ExcelHeadersGrid = cellValue.ExcelHeaders;
                    var userValuesGrid = cellValue.UserValues;
                    var isRepeatGrid = cellValue.isRepeat;
                    var sideFileGrid = cellValue.sideFile;

                    if (sideFileGrid != "")
                    {
                        string[] sidefileValueParts = sideFileGrid.Split("*");
                        string command = sidefileValueParts[0];
                        string value = sidefileValueParts[1];
                        string target = sidefileValueParts[2];

                        if (!string.IsNullOrEmpty(userValuesGrid))
                        {
                            value = userValuesGrid;
                        }


                        switch (command)
                        {
                            case "type":
                                webDriver.SendKeys(value, target);

                                break;
                            case "click":
                                webDriver.Click(target);

                                break;
                            case "open":
                                webDriver.Navigate(value);

                                break;
                            case "setWindowSize":
                                string[] targetParts = target.Split('x');
                                string x = targetParts[0];
                                string y = targetParts[1];

                                int width = int.Parse(x);
                                int height = int.Parse(y);
                                webDriver.SetWindowSize(width, height);
                                break;
                            case "mouseOver":
                                webDriver.MouseOver(target);
                                break;
                            case "mouseOut":
                                webDriver.MouseOut(target);
                                break;
                            default:
                                MessageBox.Show("farklı bir identifier var");
                                break;
                        }
                        
                    }
                    else
                    {
                        webDriver.Close();
                        break;
                    }
                    
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Side dosyanızda işlem yapılamamakta. Side dosyanızı oluşturduğunuz sayfa ya da sayfalarda dinamik bir yapı bulunmakta. Side dosyanızı gerekli kontrolleri yaparak yeniden oluşturunuz.\n" + ex);
                driver.Quit();
                driver = null;

            }
        }

        public void ExportExcel(List<dynamic> excelRows, List<MatchedDto> matchedDtos, string secilenDriver)
        {

            var repeatedList = new List<MatchedDto>();

            foreach (var cellValue in matchedDtos)
            {
                var isExcel = cellValue.isExcel;
                var ExcelHeaders = cellValue.ExcelHeaders;
                var userValues = cellValue.UserValues;
                var isRepeat = cellValue.isRepeat;
                var sideFile = cellValue.sideFile;


                if (!isRepeat && repeatedList.Count <= 0)
                {

                    if (isExcel == false)
                    {

                        SetSideRunnerCommand(sideFile, userValues, secilenDriver);
                    }

                }


                else if (!isRepeat && repeatedList.Count > 0)
                {
                    foreach (var row in excelRows)
                    {

                        for (int i = 0; i < repeatedList.Count; i++)
                        {
                            var repeatedMatched = repeatedList[i];
                            var excelRowValues = row.GetType().GetField(repeatedMatched.ExcelHeaders);

                            if (excelRowValues != null)
                            {
                                var value2 = excelRowValues.GetValue(row);
                                var excelValue = Convert.ToString(value2);
                                SetSideRunnerCommand(repeatedMatched.sideFile, excelValue, secilenDriver);

                            }
                            else
                            {
                                SetSideRunnerCommand(repeatedMatched.sideFile, userValues, secilenDriver);
                            }
                        }

                    }

                    repeatedList = new List<MatchedDto>();

                    if (isExcel == false)
                    {
                        SetSideRunnerCommand(sideFile, userValues, secilenDriver);
                    }
                }
                else
                {
                    if (cellValue.sideFile != "")
                    {
                        repeatedList.Add(cellValue);
                    }

                }

            }

        }


        public void SetSideRunnerCommand(string sideFile, string UserValues, string secilenDriver)
        {
            try
            {
                if (driver == null)
                {
                    switch (secilenDriver)
                    {
                        case "Chrome":
                            ChromeOptions opt = new ChromeOptions();
                            opt.AddUserProfilePreference("excludeSwitches", new List<string>() { "disable-popup-blocking" });
                            driver = new ChromeDriver(opt);
                            break;
                        case "Mozilla Firefox":
                            var firefoxOptions = new FirefoxOptions();
                            firefoxOptions.AddArguments("-disable-popup-blocking");
                            driver = new FirefoxDriver(firefoxOptions);
                            break;
                        case "Edge":
                            var edgeOptions = new EdgeOptions();
                            edgeOptions.AddAdditionalOption("preventBlockingOfSharedProcesses", true);
                            edgeOptions.AddArgument("--disable-popup-blocking");
                            driver = new EdgeDriver(edgeOptions);
                            break;
                        default:
                            ChromeOptions defaultdriver = new ChromeOptions();
                            defaultdriver.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);
                            defaultdriver.AddArgument("--disable-popup-blocking");
                            driver = new ChromeDriver(defaultdriver);
                            break;
                    }
                }


                ISeleniumDriver webDriver = new WebDriver(driver);

                var stringBuilder = new StringBuilder();

                if (sideFile != "")
                {
                    string[] sidefileValueParts = sideFile.Split("|");
                    string command = sidefileValueParts[0];
                    string value = sidefileValueParts[1];
                    string target = sidefileValueParts[2];

                    if (!string.IsNullOrEmpty(UserValues))
                    {
                        value = UserValues;
                    }


                    switch (command)
                    {
                        case "type":
                            webDriver.SendKeys(value, target);
                            stringBuilder.AppendLine("-" + "SendKeys: " + value + " " + target);
                            break;
                        case "click":
                            webDriver.Click(target);
                            stringBuilder.AppendLine("-" + "Click: " + target);
                            break;
                        case "open":
                            webDriver.Navigate(value);
                            stringBuilder.AppendLine("-" + "Navigate: " + value);
                            break;
                        case "setWindowSize":
                            string[] targetParts = target.Split('x');
                            string x = targetParts[0];
                            string y = targetParts[1];

                            int width = int.Parse(x);
                            int height = int.Parse(y);
                            webDriver.SetWindowSize(width, height);
                            stringBuilder.AppendLine("-" + "setWindowSize: " + targetParts);
                            break;
                        case "mouseOver":
                            webDriver.MouseOver(target);
                            break;
                        case "mouseOut":
                            webDriver.MouseOut(target);
                            break;
                        case "doubleClick":
                            webDriver.DoubleClick(target);
                            stringBuilder.AppendLine("-" + "DoubleClick" + target);
                            break;
                        case "mouseDownAt":
                            string[] downValueParts = value.Split(",");
                            string downPart = downValueParts[0];
                            string downPart1 = downValueParts[1];

                            int downOffSetX = int.Parse(downPart);
                            int downOffSetY = int.Parse(downPart);
                            webDriver.MouseDownAt(target, downOffSetX, downOffSetY);
                            break;
                        case "mouseUpAt":
                            string[] upValueParts = value.Split(",");
                            string upPart = upValueParts[0];
                            string upPart1 = upValueParts[1];

                            int upOffSetX = int.Parse(upPart);
                            int upOffsetY = int.Parse(upPart);
                            webDriver.MouseUpAt(target, upOffSetX, upOffsetY);
                            break;
                        case "close":
                            driver.Quit();
                            driver = null;
                            break;
                        default:
                            MessageBox.Show("farklı bir identifier var\n" + command);
                            break;
                    }
                    string currentDirectory = Directory.GetCurrentDirectory();
                    string fileName = $"output_{DateTime.Now.ToString("yyyyMMdd_HHmm")}.txt";
                    string outputPath = Path.Combine(currentDirectory, fileName);

                    using (StreamWriter writer = new StreamWriter(outputPath, true))
                    {
                        writer.Write(stringBuilder.ToString());
                    }
                }

                else
                {
                    driver.Quit();
                    driver = null;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);  
                driver.Quit();
                driver = null;

            }
            
        }

    }
}
