
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Scrum;

namespace atFrameWork2.PageObjects
{
    public class TasksListPage
    {
        WebItem btnOpenScrum =>
            new WebItem("//a[contains(@class, 'main-buttons-item-link') and contains(@href, '/tasks/scrum/')]", 
                "Кнопка для перехода в Scrum");
        public ScramListPage OpenScram()
        {
            btnOpenScrum.Click();
            return new ScramListPage();
        }
    }
}