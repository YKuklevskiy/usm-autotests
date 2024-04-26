using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Scrum;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class TaskPage<BasePageObject> where BasePageObject : new()
    {
        private string iFrameSliderXpath = "//iframe[@class='side-panel-iframe' and contains(@src, 'task/view')]";
        private WebItem slider => new WebItem(iFrameSliderXpath, "Слайдер задачи");

        public TaskPage() 
        {
            WebDriverActions.SwitchToDefaultContent();
            slider.SwitchToFrame();
        }

        public BasePageObject Delete()
        {
            new WebItem("//span[@data-bx-id='task-view-b-open-menu']", "Кнопка 'Еще'")
                .Click();
            new WebItem("//div[@class='menu-popup-items']//span[@title='Удалить' and contains(@class, 'menu-popup-item-delete')]", "Кнопка 'Удалить")
                .Click();
            
            WebDriverActions.SwitchToDefaultContent();

            //new WebItem("//div[@class='ui-notification-balloon-content']", "Попап при удалении задачи").WaitWhileElementDisplayed(maxWait_s: 40);
            // Either a popup or closing frame are blocking the OpenUSM button, no dynamic waiters can handle that event
            Waiters.StaticWait_s(3);
            return new BasePageObject();
        }
    }
}
