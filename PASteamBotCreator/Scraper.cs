using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V85.Profiler;
using System;  
using System.IO;  
using System.Text; 

namespace PASteamBotCreator;

public class Scraper
{
    private IWebDriver driver;
    private readonly string url;
    public Scraper()
    {
        driver = new ChromeDriver();
        url = "https://store.steampowered.com/join";
        driver.Manage().Window.Maximize();
    }

    public void Start()
    {
        try
        {
            FirstPage();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
        finally
        {
            driver.Close();
            driver.Quit();
        }
    }
    // /html/body/div[1]/div[7]/div[6]/div/div[1]/div[2]/form/div/div/div[4]/div[1]/div/select/option[14]
    private void FirstPage()
    {
        driver.Navigate().GoToUrl(url: url);
        Thread.Sleep(5000);
        driver.FindElement(By.CssSelector("#email")).SendKeys("otobasgumats@gmail.com");
        driver.FindElement(By.CssSelector("#reenter_email")).SendKeys("otobasgumats@gmail.com");
        IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("document.getElementById('g-recaptcha-response').removeAttribute('disabled')");
        Console.WriteLine("Done");
        Thread.Sleep(500000);
        driver.FindElement(By.CssSelector("#country")).Click();
        Thread.Sleep(5000);
        driver.FindElement(By.XPath("//*[@id=\"country\"]/option[8]")).Click();
        Thread.Sleep(5000);
        
    }
}