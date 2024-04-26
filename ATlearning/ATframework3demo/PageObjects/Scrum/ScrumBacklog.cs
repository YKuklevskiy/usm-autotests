using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects.Scrum
{
    public class ScrumBacklog
    {
        // Both sprint and backlog are present on task page so tasks need to be precursed with backlog div's xpath
        private string backlogPrecursor = "//div[@class='tasks-scrum__backlog']";

        private WebItem GetTaskLinkItem(Bitrix24Task task)
        {
            return new WebItem(backlogPrecursor + $"//a[@class='tasks-scrum__item--title ' and text()='{task.Title}']", $"Задача в бэклоге с названием {task.Title}");

        }

        public bool IsTaskPresent(Bitrix24Task task)
        {
            return GetTaskLinkItem(task).WaitElementDisplayed();
        }
    }
}
