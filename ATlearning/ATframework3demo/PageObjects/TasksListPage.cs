
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;

namespace atFrameWork2.PageObjects
{
    public class TasksListPage
    {
        public ScrumTeamsListPage OpenScrum()
        {
            new WebItem("//a[contains(@class, 'main-buttons-item-link') and contains(@href, '/tasks/scrum/')]", "Кнопка для перехода в Scrum")
                .Click();
            return new ScrumTeamsListPage();
        }
    }
}