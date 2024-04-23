using atFrameWork2.BaseFramework;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;
using atFrameWork2.BaseFramework.LogTools;
using System.ComponentModel;

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
        private WebItem GetOptionByTitle(Bitrix24Option testTitle)
        {
            return new WebItem($"//div[@class='option']//a[contains(text(), '{testTitle.Title}')]",
                $"Опция с заголовком '{testTitle.Title}'");
        }
        public SliderOptionViewPage OpenOptionView(Bitrix24Option testTitle)
        {
            WebItem createdOptionByTest = GetOptionByTitle(testTitle);
            createdOptionByTest.Click();
            Waiters.StaticWait_s(5);
            return new SliderOptionViewPage();
        }
        public UserStoryMapPage CreateOption(Bitrix24Option testTitle)
        {
            btnAddOption.Click();
            inputNewOption.SendKeys(testTitle.Title + Keys.Enter);
            WebDriverActions.Refresh();
            return this;
        }
        public UserStoryMapPage isOptionExist(Bitrix24Option testTitle)
        {
            WebItem ActorOnUSMPage = new WebItem("//div[@class='card-column-header actor']h", "Актер в USM");
            ActorOnUSMPage.WaitElementDisplayed(); 
            WebItem createdOptionByTest = GetOptionByTitle(testTitle);
            bool isDisplayedCreatedOption = createdOptionByTest.WaitElementDisplayed();
            if (isDisplayedCreatedOption)
            {
                Log.Info($"<b>Опция с заголовком '{testTitle.Title}' найдена</b>");
            }
            else
            {
                throw new Exception($"<b>Опция с заголовком '{testTitle.Title}' не найдена</b>");
            }
            return this;
        }
    }
}
