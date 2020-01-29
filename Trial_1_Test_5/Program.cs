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
		private double total;

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

			//Step 8-13
			IList<IWebElement> list = driver.FindElements(By.XPath("//div[@class = 'inventory_item_price']"));
			double sum = 0.00;
			for (int x = 0; x <= list.Count() - 1; x++)
			{
				sum += Convert.ToDouble(list[x].Text);
			}

			Console.WriteLine("The total is: " + sum.ToString());

			driver.FindElement(By.XPath("//a[text() = 'CHECKOUT']")).Click();

			driver.FindElement(By.XPath("//input[@id = 'first-name']")).SendKeys("Lea");
			driver.FindElement(By.XPath("//input[@id = 'last-name']")).SendKeys("Natoc");
			driver.FindElement(By.XPath("//input[@id = 'postal-code']")).SendKeys("1700");
			driver.FindElement(By.XPath("//input[@type = 'submit']")).Click();

			Assert.AreEqual(sum, Convert.ToDouble(driver.FindElement(By.XPath("//div[@class = 'summary_subtotal_label']")).Text.Trim().Split('$').Last()), "The totals are not equal");

			Convert.ToDouble(driver.FindElement(By.XPath("//div[@class = 'summary_tax_label']")).Text.Trim().Split('$').Last());
			total = sum + Convert.ToDouble(driver.FindElement(By.XPath("//div[@class = 'summary_tax_label']")).Text.Trim().Split('$').Last());
			Convert.ToDouble(driver.FindElement(By.XPath("//div[@class = 'summary_total_label']")).Text.Trim().Split('$').Last());
		}
	}
}
