using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;
using atFrameWork2.BaseFramework.LogTools;
using System.ComponentModel;

namespace ATframework3demo.PageObjects.Scrum
{
    public class UsmPage
    {
        public UsmPage() 
        {
            WaitUsmLoaded();
        }

        public UsmPage WaitUsmLoaded()
        {
            // When actor is shown the whole USM is loaded
            new WebItem("//div[contains(@class, 'card-column-header') and contains(@class, 'actor')]", "Карточка актёра USM")
                .WaitElementDisplayed(maxWait_s: 10);
            
            return this;
        }

        private WebItem GetOptionCardLabel(Bitrix24UsmOption option)
        {
            return new WebItem($"//div[@class='option']//a[text()='{option.Title}']", $"Название на карточке опции '{option.Title}'");
        }

        public TaskPage<UsmPage> OpenOptionDetails(Bitrix24UsmOption option)
        {
            GetOptionCardLabel(option).Click();

            return new TaskPage<UsmPage>();
        }

        public UsmPage CreateOption(Bitrix24UsmOption testTitle)
        {
            new WebItem("//div[@class='add-new-option']", "Кнопка добавления опции на USM")
                .Click();

            WebItem optionNameField = new WebItem("//div[@class='dndrop-container vertical']//input[@type='text']", "Поле для ввода названия опции");
            optionNameField.SendKeys(testTitle.Title);
            optionNameField.SendKeys(Keys.Enter);

            return this;
        }

        public bool IsOptionPresent(Bitrix24UsmOption option)
        {
            return GetOptionCardLabel(option).WaitElementDisplayed();
        }
    }
}
