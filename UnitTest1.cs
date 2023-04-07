#region using
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Data;
using System.Linq;
using System;
using System.Runtime.InteropServices;
#endregion

namespace Pruebas_automatizadas;
[TestFixture]
public class Tests
{
    IWebDriver driver;
    private Loginpage action;

    [OneTimeSetUp]
    public void Setup()
    {
        driver = new ChromeDriver();
        driver.Manage().Window.Maximize();
        driver.Navigate().GoToUrl("https://www.wattpad.com/?locale=es_ES");
        //driver.Url = "C:\\Users\\user\\Desktop\\all\\ITLA\\2023\\ProgIII\\Proyectos\\Pruebas _automatizadas\\Index.html";
        action = new Loginpage(driver);
    }
   
    [Test]
    public void ToLoginbut()
    {
        action.goToLogin();
        
    }

    [Test]
    public void Tosearch()
    {
        action.tosearch("Hechos sin dichos");
    }

    [OneTimeTearDown]
    public void Close(){
        //si necesita que se cierre la prueba quite los signos de comentario de abajo
        //driver.Close();
    }
}

class Loginpage 
{

    private IWebDriver driver;

    public Loginpage(IWebDriver browser)
    {
        driver = browser;
    }
    private By Btn = By.CssSelector("button[class='btn btn-sm']");
    private IWebElement btnlogin =>driver.FindElement(Btn);

    public void goToLogin()
    {
        btnlogin.Click();
    }

    private By Search = By.Id("search-query");
    private IWebElement fSearch => driver.FindElement(Search);
    private By btnsearch = By.CssSelector("span[class='fa fa-search fa-wp-neutral-1']");
    private IWebElement Btnsea => driver.FindElement(btnsearch);
    public void tosearch(string name)
    {
        
        fSearch.Click();
        fSearch.SendKeys(name);
        Btnsea.Click();
    }
    
}


