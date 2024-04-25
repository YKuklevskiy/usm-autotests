using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.USM;

namespace ATframework3demo.PageObjects.Scrum
{
    public class SliderScrumTeamPage
    {
        public WebItem frameSlider =>
            new WebItem("//iframe[@class='side-panel-iframe']", 
                "Фрейм слайдера");
        WebItem btnOpenUSM =>
            new WebItem("//span[contains(text(), 'Скрам')]",
                "Кнопка 'Перейти в USM'");
        public UserStoryMapPage OpenUSM()
        {
            frameSlider.SwitchToFrame();
            btnOpenUSM.Click();
            return new UserStoryMapPage();
        }
    }
}
