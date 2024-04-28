using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;
using System.ComponentModel;
using atFrameWork2.BaseFramework.LogTools;

namespace ATframework3demo.PageObjects.USM
{
    public class UserStoryMapPage
    {
        WebItem btnAddOption =>
            new WebItem("//div[@class='add-new-option']",
                "Кнопка добавления опции на USM");
        WebItem inputNewOption =>
            new WebItem("//div[@class='dndrop-container vertical']//input[@type='text']",
                "Созданная пустая опция");
        private WebItem GetOptionLinkByTitle(Bitrix24USMOption testTitle)
        {
            return new WebItem($"//div[@class='option']//a[contains(text(), '{testTitle.Title}')]",
                $"Ссылка опция с заголовком '{testTitle.Title}'");
        }
        public UserStoryMapPage RefreshPage()
        {
            WebDriverActions.Refresh();
            return this;
        }
        public SliderOptionViewPage OpenOptionView(Bitrix24USMOption testTitle)
        {
            WebItem createdOptionByTest = GetOptionLinkByTitle(testTitle);
            createdOptionByTest.Click();
            return new SliderOptionViewPage();
        }
        public UserStoryMapPage CreateOption(Bitrix24USMOption testTitle)
        {
            btnAddOption.Click();
            inputNewOption.SendKeys(testTitle.Title + Keys.Enter);
            RefreshPage();
            return this;
        }
        public bool IsOptionExist(Bitrix24USMOption testTitle)
        {
            WebItem ActorOnUSMPage = new WebItem("//div[contains(@class, 'card-column-header actor')]", "Актер в USM");
            ActorOnUSMPage.WaitElementDisplayed();
            WebItem createdOptionByTest = GetOptionLinkByTitle(testTitle);
            return createdOptionByTest.WaitElementDisplayed();
        }
    }
}
