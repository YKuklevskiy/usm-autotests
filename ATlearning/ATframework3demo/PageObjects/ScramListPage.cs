
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Scrum;

namespace ATframework3demo.PageObjects
{
    public class ScramListPage
    {
        private WebItem scrumTeamName;
        public SliderScrumTeamPage CreateScrumTeam()
        {
            return new SliderScrumTeamPage();
        }
        public SliderScrumTeamPage SelectScrumTeam(string teamName)
        {
            scrumTeamName = new WebItem("//a[contains(@class, 'sonet-group-grid-name-text') and text()='" + teamName + "']",
                "Выбранная скрам-команда");
            scrumTeamName.Click();
            return new SliderScrumTeamPage();
        }
    }
}
