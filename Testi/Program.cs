using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Testi
{
	internal class Program
	{
		static void Main(string[] args)
		{
			IWebDriver driver = new ChromeDriver();
			driver.Navigate().GoToUrl("https://www.flipkart.com/");
			driver.Manage().Window.Maximize();
			IWebElement CloseIcon = driver.FindElement(By.XPath("//button[text()='✕']"));
			CloseIcon.Click();

			IWebElement searchbox = driver.FindElement(By.XPath("//input[@name='q']"));
			searchbox.SendKeys("ipad");
			searchbox.SendKeys(Keys.Enter);
			
			WebDriverWait wait=new WebDriverWait(driver, TimeSpan.FromSeconds(5));
			
			wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Availability']//..//div")));

			IWebElement Filter = driver.FindElement(By.XPath("//div[text()='Availability']//..//div"));
			Filter.Click();

			IWebElement  OutofStock= driver.FindElement(By.XPath("//div[text()='Exclude Out of Stock']//../div"));
			OutofStock.Click();

			Thread.Sleep(1000);
			wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//a[@rel]//div[contains(text(),'iPad')])[1]")));
			IWebElement ipad = driver.FindElement(By.XPath("(//a[@rel]//div[contains(text(),'iPad')])[1]"));

			ipad.Click();
			IList<string> windows = driver.WindowHandles;
			foreach (string window in windows)
			{
				driver.SwitchTo().Window(window);
			}

			IWebElement GotoCart = driver.FindElement(By.XPath("//*[name()='svg']//..//..//button[not(contains(@type,'submit'))]"));
			Actions action = new Actions(driver);
			 action.MoveToElement(GotoCart).Click().Perform();

			wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text()='Place Order']")));
			IWebElement PlaceOrder = driver.FindElement(By.XPath("//span[text()='Place Order']"));

			PlaceOrder.Click();
			IWebElement LoginNum = driver.FindElement(By.XPath("//input[@type='text']"));
			LoginNum.SendKeys("9876543210");

			IWebElement Continue = driver.FindElement(By.XPath("//span[text()='CONTINUE']"));
			Continue.Click();

			Thread.Sleep(5000);
			driver.Quit();



		}
	}
}
