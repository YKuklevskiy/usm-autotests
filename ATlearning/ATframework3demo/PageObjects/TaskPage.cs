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
        
        public TaskPage<BasePageObject> Edit()
        {
            new WebItem("//a[contains(@class, 'task-view-button') and contains(@class, 'edit')]", "Кнопка 'Редактировать' в слайдере задачи")
                .Click();

            return this;
        }

        public TaskPage<BasePageObject> ChangeTaskName(string name)
        {
            WebItem taskNameInput = new WebItem("//input[@data-bx-id='task-edit-title']", "Поле названия задачи");
            taskNameInput.Clear();
            taskNameInput.SendKeys(name);

            return this;
        }

        public TaskPage<BasePageObject> Apply()
        {
            new WebItem("//button[@data-bx-id='task-edit-submit']", "Кнопка 'Сохранить изменения' в форме редактирования задачи")
                .Click();

            return this;
        }

        public BasePageObject Close()
        {
            WebDriverActions.SwitchToDefaultContent();
            new WebItem(iFrameSliderXpath +
                "//ancestor::div[contains(@class, 'side-panel-overlay-open')]" +
                "//div[contains(@class, 'side-panel-label-icon-close')]", "Кнопка закрытия слайдера")
                .Click();

            return new BasePageObject();
        }

        public BasePageObject Delete()
        {
            new WebItem("//span[@data-bx-id='task-view-b-open-menu']", "Кнопка 'Еще'")
                .Click();
            new WebItem("//div[@class='menu-popup-items']//span[@title='Удалить' and contains(@class, 'menu-popup-item-delete')]", "Кнопка 'Удалить")
                .Click();
            
            WebDriverActions.SwitchToDefaultContent();

            Waiters.StaticWait_s(3);
            return new BasePageObject();
        }
    }
}
