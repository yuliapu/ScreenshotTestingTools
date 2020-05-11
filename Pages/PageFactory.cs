using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;


namespace Pages
{
    public static class PageFactory<T>
    {
        public static void Init(T page, IWebDriver driver)
        {
            PageFactory.InitElements(driver, page);
        }
    }
}
