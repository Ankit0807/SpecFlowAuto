using Gherkin.CucumberMessages.Types;
using LivingDoc.Dtos;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

[Binding]

public sealed class LoginStepDef
{
#pragma warning restore CS8618 //Non-nullable field 'driver' must contain a non-null value when exiting constructor.Consider declaring the field as nullable.

    private IWebDriver driver;

#pragma warning restore  CS8618 //Non-nullable field 'driver' must contain a non-null value when exiting constructor.Consider declaring the field as nullable.
    //For additional details on SpecFlow step definations see https://go.specflow.org/doc-stepdef


    [Given(@"Open the browser")]

    public void GivenOpenTheBrowser()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
    }
    [When (@"Enter the URL")]
    public void whenEntertheURL()
    {
        driver.Url = "https://webflow.com/dashboard/login";
        Thread.Sleep(5000);
    }
    [When (@"Enter the Login Credentials")]
    public void whenEnterTheLoginCredentials()
    {
        driver.FindElement(By.Name("Username")).SendKeys("student");
        driver.FindElement(By.Name("Password")).SendKeys("Password123");
        driver.FindElement(By.Id("Submit")).Click();
        Thread.Sleep(5000);
    }

    [Then(@"User on Home Page")]

    public void TheUserOnHomePage()
    {

        Boolean homepage = driver.FindElement(By.XPath("//*[@id=\"loop-container\"]/div/article/div[2]/div/div/div/a")).Displayed;

        if (homepage == true)
        {
            Console.WriteLine("on home page");

        }
        else
        {
            Console.WriteLine("Failed to launch the page");
        }
        driver.Quit();
    }

}