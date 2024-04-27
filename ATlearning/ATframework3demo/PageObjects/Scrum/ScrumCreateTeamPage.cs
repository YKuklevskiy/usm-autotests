using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;

namespace ATframework3demo.PageObjects.Scrum
{
    public class ScrumCreateTeamPage
    {
        Bitrix24ScrumTeam _team;
        WebItem SubmitActionButton => new WebItem("//button[@id='sonet_group_create_popup_form_button_submit']", "Кнопка для принятия шага в создании скрам-команды");

        public ScrumCreateTeamPage(Bitrix24ScrumTeam team) 
        { 
            _team = team;
        }

        public ScrumCreateTeamPage EnterTeamName()
        {
            new WebItem("//input[@id='GROUP_NAME_input']", "Поле для ввода названия команды")
                .SendKeys(_team.Title);
            SubmitActionButton.Click();

            return this;
        }

        public ScrumCreateTeamPage SelectTeamType()
        {
            string teamType = _team.GetTeamTypeToString();
            new WebItem($"//div[contains(@class, 'socialnetwork-group-create-ex__group-selector--title') and text()='{teamType}']" +
                "//ancestor::div[contains(@class, 'socialnetwork-group-create-ex__group-selector') and @data-bx-confidentiality-type]", $"Кнопка '{teamType}' выбора типа команды")
                .Click();
            SubmitActionButton.Click();

            return this;
        }

        private ScrumCreateTeamPage SelectUserAsScrumMaster(Bitrix24User user)
        {
            new WebItem("//div[@id='SCRUM_MASTER_selector']//span[@class='ui-tag-selector-add-button-caption']", "Кнопка добавления скрам-мастера")
                .Click();
            new WebItem($"//div[@class='ui-selector-item-title' and text()='{user.FullName}']", $"Пользователь {user.FullName} в меню выбора скрам-мастера")
                .Click();

            return this;
        }

        public ScrumCreateTeamPage SelectGroupOwnerAsScrumMaster()
        {
            string groupOwnerName = new WebItem("//div[@id='GROUP_OWNER_selector']//div[@class='ui-tag-selector-tag-title']", "Имя владельца команды")
                .InnerText();

            return SelectUserAsScrumMaster(new Bitrix24User(groupOwnerName));
        }

        public ScrumCreateTeamPage SelectScrumMasterFromTeamEntity()
        {
            return SelectUserAsScrumMaster(_team.ScrumMaster);
        }

        public ScrumTeamPage FinishCreation()
        {
            SubmitActionButton.Click();
            WebDriverActions.SwitchToDefaultContent();
            return new ScrumTeamPage();
        }
    }
}
