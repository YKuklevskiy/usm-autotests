using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.USM
{
    public class SliderOptionViewPage
    {
        public WebItem frameSlider =>
            new WebItem("//iframe[@class='side-panel-iframe']",
                "Фрейм формы просмотра опции");
        WebItem btnOpenOptionEditForm =>
           new WebItem("//a[contains(@class, 'task-view-button') and contains(@class, 'edit')]",
               "Кнопка редактировать в слайдере");
        public WebItem btnCloseSlider =>
            new WebItem("//div[@title='Закрыть']",
                "Кнопка закрытия слайдера");
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
    }
}
