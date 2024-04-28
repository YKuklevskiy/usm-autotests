using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.USM;

namespace ATframework3demo.PageObjects.Scrum
{
    public class SliderScrumTeamPage
    {
        WebItem btnCreateUSM =>
             new WebItem("//button[contains(text(), 'Создать USM')]",
                "Кнопка 'Создать USM'");       
        public UserStoryMapPage CreateUSM()
        {
            btnCreateUSM.Click();
            return new UserStoryMapPage();
        }
    }
}
