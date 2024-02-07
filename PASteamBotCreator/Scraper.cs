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
    
    private void FirstPage()
    {
        driver.Navigate().GoToUrl(url: url);
        Thread.Sleep(5000);
        IWebElement EmailInput = driver.FindElement(By.Id("email"));
        Thread.Sleep(5000);
        EmailInput.SendKeys("kurwa@bober.pl");
        Thread.Sleep(5000);
        using (FileStream fs = new FileStream("test.txt", FileMode.OpenOrCreate))
        {
            byte[] buffer = Encoding.Default.GetBytes(driver.PageSource);
            fs.Write(buffer);
        }
    }
}