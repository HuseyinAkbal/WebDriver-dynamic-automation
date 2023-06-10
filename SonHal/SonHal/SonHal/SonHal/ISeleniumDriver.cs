using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace SonHal
{
    public interface ISeleniumDriver
    {
        public void Navigate(string url);
        public void SetWindowSize(int x, int y);
        public void Click(string adress);
        public void SendKeys(string adress, string value);
        public void MouseOver(string adress);
        public void MouseOut(string adress);
        public void DisableCookies();
        public void MouseDownAt(string XPath, int offsetX, int offsetY);
        public void MouseUpAt(string XPath, int offsetX, int offsetY);
        public void Close();
        public void DoubleClick(string XPath);

    }
}
