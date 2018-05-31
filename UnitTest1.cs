using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        ChromeDriver chrome;

        [TestMethod]
        public void TestMethodWithValidLoginAndPass()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("http://www.i.ua");
            chrome.FindElement(By.XPath("/html/body/div[2]/div[3]/ul[1]/li[2]/a")).Click();
            chrome.FindElement(By.ClassName("width_100")).SendKeys("Testusr111");
            chrome.FindElement(By.XPath("(//input[@name='pass'])[2]")).SendKeys("qwerty1234");
            chrome.FindElement(By.XPath("//*[@id='FloatLogin']/div/div/form/input[6]")).Click();
            chrome.FindElement(By.XPath("/html/body/div[2]/div[3]/ul[1]/li[8]/a")).Click();

        }

        [TestMethod]
        public void TestMethodWithInvalidLoginAndPass()
        {
            chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("http://www.i.ua");
            chrome.FindElement(By.XPath("/html/body/div[2]/div[3]/ul[1]/li[2]/a")).Click();
            chrome.FindElement(By.ClassName("width_100")).SendKeys("Testuser111");
            chrome.FindElement(By.XPath("(//input[@name='pass'])[2]")).SendKeys("qwerty12345");
            chrome.FindElement(By.XPath("//*[@id='FloatLogin']/div/div/form/input[6]")).Click();
            try
            {
                chrome.FindElement(By.XPath("/html/body/div[2]/div[3]/ul[1]/li[8]/a")).Click();
            }
            catch (Exception e)
            {
                Console.WriteLine("Login and pass not valid", e.Message);
                chrome.Quit();
            }
        }
        [TestCleanup]
        public void TearDown()
        {
            chrome.Quit();
        }
    }
}
