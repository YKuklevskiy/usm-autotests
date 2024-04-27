
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.Scrum
{
    public class ScrumTeamsListPage
    {
        WebItem activityDateSortingButton => new WebItem("//th[@data-sort-by='ACTIVITY_DATE']", "Пункт 'Активность' меню сортировки списка команд");
        WebItem scrumTeamCreateButton => new WebItem("//a[@id='projectAddButton']", "Кнопка 'Создать' для создания скрам-команды");

        public ScrumCreateTeamPage CreateScrumTeam(Bitrix24ScrumTeam team)
        {
            scrumTeamCreateButton.Click();

            new WebItem("//iframe[@class='side-panel-iframe']", "Слайдер для создания скрам-команды")
                .SwitchToFrame();
            WebItem submitActionButton = new WebItem("//button[@id='sonet_group_create_popup_form_button_submit']", "Кнопка для принятия шага в создании скрам-команды");

            return new ScrumCreateTeamPage(team);
        }

        public ScrumTeamsListPage SortByActivityDate(bool ascending = true)
        {
            string sortOrderAttribute = "data-sort-order";
            string expectedSortOrder = ascending ? "asc" : "desc";

            while (activityDateSortingButton.GetAttribute(sortOrderAttribute) != expectedSortOrder)
            {
                activityDateSortingButton.Click();
            }

            return this;
        }

        public ScrumTeamPage SelectScrumTeam(Bitrix24ScrumTeam team)
        {
            new WebItem($"//a[contains(@class, 'sonet-group-grid-name-text') and text()='{team.Title}']", $"Ссылка на страницу скрам-команды '{team.Title}'")
                .Click();

            return new ScrumTeamPage();
        }
    }
}
