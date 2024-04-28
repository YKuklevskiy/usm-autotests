using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects.Scrum
{
    public class ScrumTasksPage
    {
        public ScrumBacklog Backlog => new ScrumBacklog();

        public UsmPage OpenUSM()
        {
            new WebItem("//div[contains(@class, 'move-to-usm-button')]//a", "Кнопка для перехода в привязанную к команде USM")
                .Click();

            return new UsmPage();
        }
    }
}
