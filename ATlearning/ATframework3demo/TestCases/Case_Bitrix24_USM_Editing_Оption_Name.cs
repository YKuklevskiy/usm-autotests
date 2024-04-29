using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;
using atFrameWork2.BaseFramework.LogTools;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_USM_Editing_Оption_Name : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Редактирование названиея опции в USM", homePage => EditingOptionNameUSM(homePage)));
            return caseCollection;
        }
        void EditingOptionNameUSM(PortalHomePage homePage)
        {
            string scrumTeamName = "Новая скрам-команда " + DateTime.Now.Ticks;
            Bitrix24User scrumMaster = homePage.GetCurrentUserName();
            var testScrumDetails = new Bitrix24ScrumTeamDetail(scrumTeamName, scrumMaster);
            string optionTitle = "testTitle " + DateTime.Now.Ticks;
            var optionDetail = new Bitrix24USMOption(optionTitle);
            string newOptionTitle = "editedTitle " + DateTime.Now.Ticks;
            var newOptionDetail = new Bitrix24USMOption(newOptionTitle);
            var usmPageAfterCreation = homePage
                .LeftMenu
                .OpenTasks()
                .OpenScram()
                .CreateScrumTeam()
                .FillScrumTeamForm(testScrumDetails)
                .CreateUSM()
                .CreateOption(optionDetail)
                .OpenOptionView(optionDetail)
                .OpenOptionEditForm()
                .SetNameInEditForm(newOptionDetail)
                .SaveChangesInOption()
                .CloseOptionViewForm()
                .RefreshPage();
            // Проверяем, что опция с новым заголовком присутствует
            bool isNewOptionPresent = usmPageAfterCreation.IsOptionExist(newOptionDetail);
            if (!isNewOptionPresent)
            {
                Log.Error($"<b>Опция с новым заголовком '{newOptionDetail.Title}' не найдена</b>");
            }
            else
            {
                Log.Info($"<b>Опция с новым заголовком '{newOptionDetail.Title}' найдена</b>");
            }
            // Проверяем, что опция со старым заголовком отсутствует
            bool isOldOptionPresent = usmPageAfterCreation.IsOptionExist(optionDetail);
            if (isOldOptionPresent)
            {
                Log.Error($"<b>Опция со старым заголовком '{optionDetail.Title}' все еще присутствует</b>");
            }
            else
            {
                Log.Info($"<b>Опция со старым заголовком '{optionDetail.Title}' успешно отредактирована и не присутствует на USM диаграмме</b>");
            }
        }
    }
}
