using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;
using atFrameWork2.BaseFramework.LogTools;


namespace ATframework3demo.PageObjects.Scrum
{
    public class SliderCreateScrumTeam
    {
        public WebItem frameSlider =>
            new WebItem("//iframe[contains(@src, 'IFRAME_TYPE=SIDE_SLIDER')]",
                "Фрейм создания скрам комады");
        public WebItem inputNameScrumTeam =>
            new WebItem("//input[@id='GROUP_NAME_input']",
                "Поле 'название Скрам-команды'");
        public WebItem selectScramMaster =>
            new WebItem("//span[contains(@class, 'add-button-caption') and text()='Назначить Скрам-мастера']",
                "Поле добавления Скрам мастера");
        public WebItem btnСontinue =>
            new WebItem("//button[@id='sonet_group_create_popup_form_button_submit']",
                "Кнопка продолжить");

        private void ClickContinueButton()
        {
            btnСontinue.Click();
        }
        private void SelectScrumMaster(string scrumMasterName)
        {
            selectScramMaster.Click();
            WebItem scrumMasterItem = new WebItem($"//div[contains(@class, 'ui-selector-item-title') and contains(text(), '{scrumMasterName}')]", "Выбор конкретного Скрам-мастера");
            if (scrumMasterItem.WaitElementDisplayed())
            {
                scrumMasterItem.Click();
            }
            else
            {
                Log.Error($"Пользователь для Скрам-мастера '{scrumMasterName}' не найден.");
            }
        }
        public SliderScrumTeamPage FillScrumTeamForm(Bitrix24ScrumTeamDetail scrumTeamDetails)
        {
            frameSlider.SwitchToFrame();
            // Заполняем название скрам-команды
            inputNameScrumTeam.SendKeys(scrumTeamDetails.ScrumTeamName);
            // Жмем 'продолжить' для перехода в окно выбора уровеня конфиденциальности скрам-команды
            ClickContinueButton();
            // Здесь также нажимаем 'продолжить' так как автоматически выбран тип
            // "открытый, что соответствует нужному значению для теста
            ClickContinueButton();
            // Выбираем скрам-мастера из списка пользователей
            SelectScrumMaster(scrumTeamDetails.ScrumMaster.UserName);
            // Нажимаем далее и создается скрам-коаманда
            ClickContinueButton();
            WebItem confirmationElement = new WebItem($"//span[contains(@class, 'profile-menu-name') and contains(text(), '{scrumTeamDetails.ScrumTeamName}')]", "Имя созданной скрам-команду");
            Waiters.WaitForCondition(() => confirmationElement.WaitElementDisplayed(), 2, 10, $"Ожидание создания скрам-команды '{scrumTeamDetails.ScrumTeamName}'");
            WebDriverActions.Refresh();
            return new SliderScrumTeamPage();
        }

    }
}
