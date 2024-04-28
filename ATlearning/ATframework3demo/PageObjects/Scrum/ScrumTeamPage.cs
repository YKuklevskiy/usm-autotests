using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.Scrum
{
    public class ScrumTeamPage
    {
        public ScrumTeamPage()
        {
            WebDriverActions.SwitchToDefaultContent();
            slider.SwitchToFrame();
        }

        WebItem slider => new WebItem("//div[contains(@class, 'bitrix24-group-slider-content')]//iframe[@class='side-panel-iframe']", "Фрейм слайдера команды USM");
        
        public ScrumTasksPage OpenTasks()
        {
            new WebItem("//span[@class='main-buttons-item-text-box' and text()='Задачи']" +
                "//ancestor::a[@class='main-buttons-item-link']", "Кнопка 'Задачи' в меню скрама")
                .Click();
            
            return new ScrumTasksPage();
        }
    }
}
