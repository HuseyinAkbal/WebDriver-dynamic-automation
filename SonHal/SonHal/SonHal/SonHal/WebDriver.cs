using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Interactions;
using DocumentFormat.OpenXml.Bibliography;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium.Remote;
using System.Xml.Linq;
using System.Diagnostics;
using SeleniumExtras.WaitHelpers;
using System.Security.Policy;

namespace SonHal
{
    public class WebDriver : ISeleniumDriver
    {
        private readonly IWebDriver _webDriver;

        public WebDriver(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public void Navigate(string url)
        {

            try
            {
                Uri uri = new Uri(url);
                _webDriver.Navigate().GoToUrl(uri);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _webDriver.Quit();

            }

        }
        public void SetWindowSize(int x, int y)
        {
            try
            {
                _webDriver.Manage().Window.Size = new System.Drawing.Size(x, y);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _webDriver.Quit();

            }


        }

        public void Click(string XPath)
        {
            try
            {
                var adress = XPath.Substring(XPath.IndexOf('=') + 1);
                string[] parts = XPath.Split('=');
                string identifier = parts[0];

                WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));

                switch (identifier)
                {
                    case "name":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.Name(adress)));
                            _webDriver.FindElement(By.Name(adress)).Click();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "css":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(adress)));
                            _webDriver.FindElement(By.CssSelector(adress)).Click();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "id":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.Id(adress)));
                            _webDriver.FindElement(By.Id(adress)).Click();
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }

                        break;
                    case "linkText":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementIsVisible(By.LinkText(adress)));
                            _webDriver.FindElement(By.LinkText(adress)).Click();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "xpath":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(adress)));
                            _webDriver.FindElement(By.XPath(adress)).Click();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "partialLinkText":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath(adress)));
                            _webDriver.FindElement(By.PartialLinkText(adress)).Click();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;

                }

            }
            catch (Exception ex)
            {
                _webDriver.Quit();
                MessageBox.Show(ex.Message);

            }

        }



        public void DoubleClick(string XPath)
        {

            try
            {
                var adress = XPath.Substring(XPath.IndexOf('=') + 1);
                string[] parts = XPath.Split('=');
                string identifier = parts[0];
                WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));

                switch (identifier)
                {
                    case "css":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(adress)));
                            var csselement = _webDriver.FindElement(By.CssSelector(XPath));
                            Actions cssBuilder = new Actions(_webDriver);
                            cssBuilder.DoubleClick(csselement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "id":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(adress)));
                            var idElement = _webDriver.FindElement(By.Id(XPath));
                            Actions idBuilder = new Actions(_webDriver);
                            idBuilder.DoubleClick(idElement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "xpath":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(adress)));
                            var xPathElement = _webDriver.FindElement(By.XPath(XPath));
                            Actions xPathBuilder = new Actions(_webDriver);
                            xPathBuilder.DoubleClick(xPathElement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "name":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(adress)));
                            var nameElement = _webDriver.FindElement(By.XPath(XPath));
                            Actions nameBuilder = new Actions(_webDriver);
                            nameBuilder.DoubleClick(nameElement).Perform();

                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "className":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector(adress)));
                            var classNameElement = _webDriver.FindElement(By.XPath(XPath));
                            Actions classNameBuilder = new Actions(_webDriver);
                            classNameBuilder.DoubleClick(classNameElement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        public void SendKeys(string value, string XPath)
        {
            try
            {
                var adress = XPath.Substring(XPath.IndexOf('=') + 1);
                string[] parts = XPath.Split('=');
                string identifier = parts[0];
                WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
                switch (identifier)
                {
                    case "name":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.Name(adress)));
                            _webDriver.FindElement(By.Name(adress)).SendKeys(value);
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "id":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.Id(adress)));
                            _webDriver.FindElement(By.Id(adress)).SendKeys(value);
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "css":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(adress)));
                            _webDriver.FindElement(By.CssSelector(adress)).SendKeys(value);
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "xpath":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.XPath(adress)));
                            _webDriver.FindElement(By.XPath(adress)).SendKeys(value);
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "className":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.ClassName(adress)));
                            _webDriver.FindElement(By.ClassName(adress)).SendKeys(value);
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _webDriver.Quit();
            }
        }
        public void MouseOver(string XPath)
        {

            try
            {
                var adress = XPath.Substring(XPath.IndexOf('=') + 1);
                string[] parts = XPath.Split('=');
                string identifier = parts[0];
                WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));

                switch (identifier)
                {
                    case "css":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(adress)));
                            var cssElement = _webDriver.FindElement(By.CssSelector(adress));
                            Actions cssBuilder = new Actions(_webDriver);
                            cssBuilder.MoveToElement(cssElement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "xpath":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.XPath(adress)));
                            var xpathElement = _webDriver.FindElement(By.XPath(adress));
                            Actions xpathBuilder = new Actions(_webDriver);
                            xpathBuilder.MoveToElement(xpathElement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;

                    case "id":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.Id(adress)));
                            var idElement = _webDriver.FindElement(By.Id(adress));
                            Actions idBuilder = new Actions(_webDriver);
                            idBuilder.MoveToElement(idElement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "class":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.ClassName(adress)));
                            var classElement = _webDriver.FindElement(By.ClassName(adress));
                            Actions classBuilder = new Actions(_webDriver);
                            classBuilder.MoveToElement(classElement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "name":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.Name(adress)));
                            var nameElement = _webDriver.FindElement(By.Name(adress));
                            Actions nameBuilder = new Actions(_webDriver);
                            nameBuilder.MoveToElement(nameElement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _webDriver.Quit();
            }



        }

        public void MouseOut(string XPath)
        {
            try
            {
                var adress = XPath.Substring(XPath.IndexOf('=') + 1);
                string[] parts = XPath.Split('=');
                string identifier = parts[0];
                WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));

                switch (identifier)
                {
                    case "css":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(adress)));
                            var cssElement = _webDriver.FindElement(By.CssSelector(adress));
                            Actions cssBuilder = new Actions(_webDriver);
                            cssBuilder.MoveToElement(cssElement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "xpath":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.XPath(adress)));
                            var xpathElement = _webDriver.FindElement(By.XPath(adress));
                            Actions xpathBuilder = new Actions(_webDriver);
                            xpathBuilder.MoveToElement(xpathElement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;

                    case "id":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.Id(adress)));
                            var idElement = _webDriver.FindElement(By.Id(adress));
                            Actions idBuilder = new Actions(_webDriver);
                            idBuilder.MoveToElement(idElement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "class":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.ClassName(adress)));
                            var classElement = _webDriver.FindElement(By.ClassName(adress));
                            Actions classBuilder = new Actions(_webDriver);
                            classBuilder.MoveToElement(classElement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "name":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.Name(adress)));
                            var nameElement = _webDriver.FindElement(By.Name(adress));
                            Actions nameBuilder = new Actions(_webDriver);
                            nameBuilder.MoveToElement(nameElement).Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _webDriver.Quit();
            }

        }

        public void MouseDownAt(string XPath, int offsetX, int offsetY)
        {
            try
            {
                var adress = XPath.Substring(XPath.IndexOf('=') + 1);
                string[] parts = XPath.Split('=');
                string identifier = parts[0];
                WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
                Actions actions = new Actions(_webDriver);

                switch (identifier)
                {
                    case "css":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(adress)));
                            var cssElement = _webDriver.FindElement(By.CssSelector(adress));
                            actions.MoveToElement(cssElement)
                                   .MoveByOffset(offsetX, offsetY)
                                   .ClickAndHold()
                                   .Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "xpath":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.XPath(adress)));
                            var xpathElement = _webDriver.FindElement(By.XPath(adress));
                            actions.MoveToElement(xpathElement)
                                   .MoveByOffset(offsetX, offsetY)
                                   .ClickAndHold()
                                   .Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "id":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.Id(adress)));
                            var idElement = _webDriver.FindElement(By.Id(adress));
                            actions.MoveToElement(idElement)
                                   .MoveByOffset(offsetX, offsetY)
                                   .ClickAndHold()
                                   .Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "class":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.ClassName(adress)));
                            var classElement = _webDriver.FindElement(By.ClassName(adress));
                            actions.MoveToElement(classElement)
                                   .MoveByOffset(offsetX, offsetY)
                                   .ClickAndHold()
                                   .Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "name":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.Name(adress)));
                            var nameElement = _webDriver.FindElement(By.Name(adress));
                            actions.MoveToElement(nameElement)
                                   .MoveByOffset(offsetX, offsetY)
                                   .ClickAndHold()
                                   .Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _webDriver.Quit();
            }
        }

        public void MouseUpAt(string XPath, int offsetX, int offsetY)
        {
            try
            {
                var address = XPath.Substring(XPath.IndexOf('=') + 1);
                string[] parts = XPath.Split('=');
                string identifier = parts[0];
                WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(10));
                Actions actions = new Actions(_webDriver);

                switch (identifier)
                {
                    case "css":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.CssSelector(address)));
                            var cssElement = _webDriver.FindElement(By.CssSelector(address));
                            actions.MoveToElement(cssElement)
                                   .MoveByOffset(offsetX, offsetY)
                                   .Release()
                                   .Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "xpath":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.XPath(address)));
                            var xpathElement = _webDriver.FindElement(By.XPath(address));
                            actions.MoveToElement(xpathElement)
                                   .MoveByOffset(offsetX, offsetY)
                                   .Release()
                                   .Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "id":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.Id(address)));
                            var idElement = _webDriver.FindElement(By.Id(address));
                            actions.MoveToElement(idElement)
                                   .MoveByOffset(offsetX, offsetY)
                                   .Release()
                                   .Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "class":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.ClassName(address)));
                            var classElement = _webDriver.FindElement(By.ClassName(address));
                            actions.MoveToElement(classElement)
                                   .MoveByOffset(offsetX, offsetY)
                                   .Release()
                                   .Perform();
                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }

                        break;
                    case "name":
                        try
                        {
                            wait.Until(ExpectedConditions.ElementExists(By.Name(address)));
                            var nameElement = _webDriver.FindElement(By.Name(address));
                            actions.MoveToElement(nameElement)
                                   .MoveByOffset(offsetX, offsetY)
                                   .Release()
                                   .Perform();

                        }
                        catch (Exception ex)
                        {
                            _webDriver.Quit();
                            MessageBox.Show(ex.Message);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _webDriver.Quit();
            }
        }



        public void DisableCookies()
        {
            Cookie cookie = new Cookie("name", "value");
            _webDriver.Manage().Cookies.DeleteAllCookies();
        }


        public void Close()
        {
            _webDriver.Quit();
        }
    }

}
