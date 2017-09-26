using AventStack.ExtentReports;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlmonFuncTestNunit.PageObjects
{
    public class PagesManager 
    {
        private readonly IWebDriver _driver;
        protected ExtentTest Test { get; set; }
        //public ILogger Logger { get; set; }
        public PagesManager(IWebDriver driver)
        {
            _driver = driver;
        }
        private List<PageBase> _pages = new List<PageBase>();
        private List<PageBase> _openedPopUps = new List<PageBase>();

        public TPage GetPage<TPage>() where TPage : PageBase
        {
            TPage page = _pages.OfType<TPage>().FirstOrDefault();
            if (page == null)
            {
                page = (TPage)Activator.CreateInstance(typeof(TPage), this);
                _pages.Add(page);
            }
            return page;
        }

        public TPage GetOpenedPopUp<TPage>() where TPage : PageBase
        {
            var popUp = _openedPopUps.OfType<TPage>().FirstOrDefault();
            if (popUp == null) throw new InvalidOperationException($"В список открытых всплывающих окон еще не добавлено окно типа {typeof(TPage)}");
            return popUp;
        }

        public void AddOpenedPopUp<TPage>(TPage popUpPage) where TPage : PageBase
        {
            var popUp = _openedPopUps.OfType<TPage>().FirstOrDefault();
            if (popUp != null) throw new InvalidElementStateException($"В список открытых всплывающих окон уже добавлено окно типа {typeof(TPage)}");
            _openedPopUps.Add(popUpPage);
        }

        public void RemoveOpenedPopUp<TPage>(TPage popUpPage) where TPage : PageBase
        {
            var popUp = _openedPopUps.OfType<TPage>().FirstOrDefault();
            if (popUp != null)
            {
                var tmp = _openedPopUps.Where(p => p.GetType() == typeof(TPage)).FirstOrDefault();
                _openedPopUps.Remove(tmp);
            }
        }

        public  IWebDriver driver => _driver;

        [Obsolete("Use GetPage<LoginPageObjects>()")]
        public LoginPageObjects LoginPageObjects => GetPage<LoginPageObjects>();
        //[Obsolete("Use GetPage<MainPage>()")]
        //public MainMenu MainMenu => GetPage<MainMenu>();
        //[Obsolete("Use GetPage<HomeMenu>()")]
        //public HomeMenu HomeMenu => GetPage<HomeMenu>();
        //[Obsolete("Use GetPage<ControlPanelMenu>()")]
        //public ControlPanelMenu ControlpanelMenu => GetPage<ControlPanelMenu>();
        //[Obsolete("Use GetPage<StyleFolder>()")]
        //public StyleFolderMain StyleFolder => GetPage<StyleFolderMain>();

    }
}
