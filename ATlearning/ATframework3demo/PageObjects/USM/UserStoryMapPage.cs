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
                "Поле для заполнения названия созданной пустой опции на USM");
        private WebItem GetOptionLinkByTitle(Bitrix24USMOption optionDetail)
        {
            return new WebItem($"//div[@class='option']//a[contains(text(), '{optionDetail.Title}')]",
                $"Ссылка опция с заголовком '{optionDetail.Title}'");
        }
        public UserStoryMapPage RefreshPage()
        {
            WebDriverActions.Refresh();
            return this;
        }
        public SliderOptionViewPage OpenOptionView(Bitrix24USMOption optionDetail)
        {
            WebItem createdOptionByTest = GetOptionLinkByTitle(optionDetail);
            createdOptionByTest.Click();
            return new SliderOptionViewPage();
        }
        public UserStoryMapPage CreateOption(Bitrix24USMOption optionDetail)
        {
            btnAddOption.Click();
            inputNewOption.SendKeys(optionDetail.Title + Keys.Enter);
            RefreshPage();
            return this;
        }
        public bool IsOptionExist(Bitrix24USMOption optionDetail)
        {
            WebItem ActorOnUSMPage = new WebItem("//div[contains(@class, 'card-column-header actor')]", "Актер в USM");
            ActorOnUSMPage.WaitElementDisplayed();
            WebItem createdOptionByTest = GetOptionLinkByTitle(optionDetail);
            return createdOptionByTest.WaitElementDisplayed();
        }
    }
}
