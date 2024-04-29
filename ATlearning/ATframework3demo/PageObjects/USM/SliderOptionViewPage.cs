using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.USM
{
    public class SliderOptionViewPage
    {
        public WebItem frameSlider =>
            new WebItem("//iframe[@class='side-panel-iframe']",
                "Фрейм формы просмотра опции");
        WebItem btnOpenOptionEditForm =>
           new WebItem("//a[contains(text(), 'Редактировать')]",
               "Кнопка редактировать в слайдере");
        public WebItem btnCloseSlider =>
            new WebItem("//div[@title='Закрыть']",
                "Кнопка закрытия слайдера");
        public WebItem btnMoreActions =>
            new WebItem("//span[@data-bx-id='task-view-b-open-menu' and normalize-space() = 'Ещё']",
                "Кнопка еще");
        public WebItem btnDeleteOption =>
            new WebItem("//span[@title='Удалить' and contains(@class, 'menu-popup-item-delete')]",
                "Кнопка удалить");
        public SliderOptionEditPage OpenOptionEditForm()
        {
            frameSlider.SwitchToFrame();
            btnOpenOptionEditForm.Click();
            return new SliderOptionEditPage();
        }
        public UserStoryMapPage CloseOptionViewForm()
        {
            WebDriverActions.SwitchToDefaultContent();
            btnCloseSlider.Click();
            return new UserStoryMapPage();
        }
        public SliderOptionViewPage OpenMoreActionsInForm()
        {
            frameSlider.SwitchToFrame();
            btnMoreActions.Click();
            return this;
        }
        public UserStoryMapPage DeleteOptionInViewForm()
        {
            btnDeleteOption.Click();
            CloseOptionViewForm();
            return new UserStoryMapPage();
        }
    }
}
