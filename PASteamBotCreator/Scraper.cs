using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PASteamBotCreator;

public class Scraper
{
    private readonly IWebDriver driver;
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

    private void recaptcha_solver()
    {
        var elem = driver.FindElement(By.CssSelector("#g-recaptcha-response"));
        var js = (IJavaScriptExecutor)driver;
        js.ExecuteScript("arguments[0].style.removeProperty('display')", elem);
    }
    
    private void FirstPage()
    {
        driver.Navigate().GoToUrl(url: url); // open steam login page
        Thread.Sleep(5000);
        driver.FindElement(By.CssSelector("#email")).SendKeys("otobasgumats@gmail.com"); // input email
        driver.FindElement(By.CssSelector("#reenter_email")).SendKeys("otobasgumats@gmail.com"); // confirm email
        recaptcha_solver(); // solve recaptcha challenge
        Thread.Sleep(5000); 
        driver.FindElement(By.XPath("//*[@id=\"country\"]/option[8]")).Click(); // choose country (Australia) from the list
        Thread.Sleep(5000);
    }
}