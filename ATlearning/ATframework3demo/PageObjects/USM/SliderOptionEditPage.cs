using atFrameWork2.SeleniumFramework;
using ATframework3demo.TestEntities;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects.USM
{
    public class SliderOptionEditPage
    {
        WebItem inputOptionEditForm =>
            new WebItem("//input[@data-bx-id='task-edit-title']",
                "Поле ввода заголовка опции");
        WebItem btnSaveChange =>
            new WebItem("//button[@data-bx-id='task-edit-submit']",
                "Кнопка 'сохранить изменения'");
        public SliderOptionEditPage SetNameInEditForm(Bitrix24USMOption newTestTitle)
        {
            inputOptionEditForm.SendKeys(Keys.Control + "a");
            inputOptionEditForm.SendKeys(Keys.Delete);
            inputOptionEditForm.SendKeys(newTestTitle.Title);
            return this;
        }

        public SliderOptionViewPage SaveChangesInOption()
        {
            btnSaveChange.Click();
            return new SliderOptionViewPage();
        }

    }
}
