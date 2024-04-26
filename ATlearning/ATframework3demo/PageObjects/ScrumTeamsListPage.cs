
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects.Scrum;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    public class ScrumTeamsListPage
    {
        WebItem activityDateSortingButton => new WebItem("//th[@data-sort-by='ACTIVITY_DATE']", "Пункт 'Активность' меню сортировки списка команд");

        public ScrumTeamPage CreateScrumTeam(Bitrix24ScrumTeam team)
        {
            new WebItem("//a[@id='projectAddButton']", "Кнопка 'Создать' для скрам-команды")
                .Click();

            new WebItem("//iframe[@class='side-panel-iframe']", "Слайдер для создания скрам-команды")
                .SwitchToFrame();
            WebItem submitActionButton = new WebItem("//button[@id='sonet_group_create_popup_form_button_submit']", "Кнопка для принятия шага в создании скрам-команды");
            
            new WebItem("//input[@id='GROUP_NAME_input']", "Поле для ввода")
                .SendKeys(team.Name);
            submitActionButton.Click();

            string teamType = team.GetTeamTypeToString();
            new WebItem($"//div[contains(@class, 'socialnetwork-group-create-ex__group-selector--title') and text()='{teamType}']" +
                "//ancestor::div[contains(@class, 'socialnetwork-group-create-ex__group-selector') and @data-bx-confidentiality-type]", $"Кнопка '{teamType}' выбора типа команды")
                .Click();
            submitActionButton.Click();

            string groupOwnerName = new WebItem("//div[@id='GROUP_OWNER_selector']//div[@class='ui-tag-selector-tag-title']", "Имя владельца команды")
                .InnerText();
            new WebItem("//div[@id='SCRUM_MASTER_selector']//span[@class='ui-tag-selector-add-button-caption']", "Кнопка добавления скрам-мастера")
                .Click();
            new WebItem($"//div[@class='ui-selector-item-title' and text()='{groupOwnerName}']", $"Пользователь {groupOwnerName} в меню выбора скрам-мастера")
                .Click();

            // Here goes code for filling out the rest of team members

            submitActionButton.Click();

            WebDriverActions.SwitchToDefaultContent();
            return new ScrumTeamPage();
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
            new WebItem($"//a[contains(@class, 'sonet-group-grid-name-text') and text()='{team.Name}']", $"Ссылка на страницу скрам-команды '{team.Name}'")
                .Click();

            return new ScrumTeamPage();
        }
    }
}
