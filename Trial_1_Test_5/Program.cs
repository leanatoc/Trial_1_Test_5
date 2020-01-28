using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace Lea_test
{
	[TestFixture]
	public class TestLea
	{

		[Test]
		public void Test_SauceDemo()
		{
			//Step 1
			IWebDriver driver = new ChromeDriver();
			driver.Url = "https://www.saucedemo.com/";
			driver.Manage().Window.Maximize();

			//Step 2
			driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
			driver.FindElement(By.Id("password")).SendKeys("secret_sauce");

			//Step 3
			driver.FindElement(By.XPath("//input[@value='LOGIN']")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			//Step 4
			driver.FindElement(By.XPath("//option[contains(text(),'Price (high to low)')]")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			//Step 5
			driver.FindElement(By.XPath("(//button[contains(.,'ADD TO CART')])[1]")).Click();
			driver.FindElement(By.XPath("(//button[contains(.,'ADD TO CART')])[2]")).Click();
			driver.FindElement(By.XPath("(//button[contains(.,'ADD TO CART')])[3]")).Click();
			driver.FindElement(By.XPath("(//button[contains(.,'ADD TO CART')])[3]")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			//Step 6
			driver.FindElement(By.XPath("//*[contains(@class,'svg-inline--fa fa-shopping-cart fa-w-18 fa-3x')]")).Click();

			//Step 7
			driver.FindElement(By.XPath("(//button[contains(.,'REMOVE')])[1]")).Click();

			//Step 8
			driver.FindElement(By.XPath("//a[contains(.,'CHECKOUT')]")).Click();
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

			//Step 9
			driver.FindElement(By.Id("first-name")).SendKeys("Lea");
			driver.FindElement(By.Id("last-name")).SendKeys("Natoc");
			driver.FindElement(By.Id("postal-code")).SendKeys("1200");

			//Step 10
			driver.FindElement(By.XPath("//input[@value='CONTINUE']")).Click();


			//Step 11-13 Comparing Values
			IList<IWebElement> list = driver.FindElements(By.XPath("//div[@class = 'inventory_item_price']"));
			foreach (var item in list)
			{
				Console.WriteLine(item.Text);
			}

			var value = driver.FindElement(By.XPath("//div[@class='summary_subtotal_label']"));
			Assert.IsTrue(value.Displayed);
			Assert.AreEqual(value.Text.ToLower(),actual: "Item total: $33.97".ToLower());

		}
	}
}