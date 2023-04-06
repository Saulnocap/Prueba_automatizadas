using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using System.Text;

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
 /*
    [Test]
    public void BDeposittest()
    {
        action.deposito("1200");
        Assert.Pass();
    }

    [Test]
    public void CWithdrawtest()
    {
        action.Withdraw("400");
        Assert.Pass();
    }

    [Test]
    public void DTransfertest()
    {
        
    }

    [Test]
    public void ELogofftest()
    {
        action.Logoff();
        Assert.IsTrue(driver.Url.Contains("Welcome"));
    }
    */

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

    #region comment
    /*
    #region login
    private By usuario = By.Id("username");
    private IWebElement Username => driver.FindElement(usuario);

    private By contraseña = By.Id("password");
    private IWebElement Password => driver.FindElement(contraseña);

    private By loginclick = By.Id("buttonxd");
    private IWebElement BtnLogin => driver.FindElement(loginclick);

    public void LoginApp(string username, string password)
    {
        Username.SendKeys(username);
        Password.SendKeys(password);
        BtnLogin.Click();
    }
    #endregion
    #region deposit
    private By amount = By.Id("amount");
    private IWebElement Amount => driver.FindElement(amount);
    private By deposit = By.Id("botondeposito");
    private IWebElement Deposit => driver.FindElement(deposit);

    public void deposito(string monto)
    {
        Amount.SendKeys(monto);
        Deposit.Click();
    }
    #endregion
    #region withdraw
    private By withdraw = By.Id("botonsacar");
    private IWebElement Sacar => driver.FindElement(withdraw);

    public void Withdraw(string monto)
    {
        Amount.SendKeys(monto);
        Sacar.Click();
    }
    #endregion
    #region transfer
    #endregion
    #region logoff
    private By logoff = By.Id("botonsalir");
    private IWebElement Salir => driver.FindElement(logoff);

    public void Logoff()
    {
        Salir.Click();
    }
    #endregion
    */
    #endregion
    public void goToLogin()
    {
        btnlogin.Click();
        Assert.Pass();
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
        Boolean verifyTitle = driver.Title.Equals("Hechos sin dichos - Wattpad");
        if (verifyTitle is true){
            Assert.Pass();
        } else {
            Assert.Fail();
        }
    }
}

