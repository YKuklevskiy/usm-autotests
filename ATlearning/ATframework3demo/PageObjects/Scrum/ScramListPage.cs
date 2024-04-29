
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.Scrum
{
    public class ScramListPage
    {
        public WebItem btnCreateScrumTeam =>
            new WebItem("//a[@id='projectAddButton']",
                "Кнопка 'создать скрам-команду'");
        public SliderCreateScrumTeam CreateScrumTeam()
        {
            btnCreateScrumTeam.Click();
            return new SliderCreateScrumTeam();
        }
    }
}
