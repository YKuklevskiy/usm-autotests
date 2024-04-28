using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;
using atFrameWork2.BaseFramework.LogTools;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_USM_Delete_Option : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Удаление опции в USM", homePage => DeleteOptionUSM(homePage)));
            return caseCollection;
        }
        void DeleteOptionUSM(PortalHomePage homePage)
        {
            string scrumTeamName = "Новая скрам-команда " + DateTime.Now.Ticks;
            string scrumMasterName = "David Zhemaitis";
            var testScrumDetails = new Bitrix24ScrumTeamDetail(scrumTeamName, scrumMasterName);
            string optionTitle = "testTitle " + DateTime.Now.Ticks;
            var optionToDelete = new Bitrix24USMOption(optionTitle);
            var usmPageAfterCreation = homePage
                .LeftMenu
                .OpenTasks()
                .OpenScram()
                .CreateScrumTeam()
                .FillScrumTeamForm(testScrumDetails)
                .CreateUSM()
                .CreateOption(optionToDelete);
            bool isOptionPresentBeforeDeletion = usmPageAfterCreation.IsOptionExist(optionToDelete);
            if (!isOptionPresentBeforeDeletion)
            {
                Log.Error($"<b>Опция '{optionToDelete.Title}' для удаления не найдена</b>");
                return;
            }
            else
            {
                Log.Info($"<b>Опция с исходным заголовком '{optionToDelete.Title}' найдена</b>");
            }
            var usmPageWithOption = usmPageAfterCreation
                .OpenOptionView(optionToDelete)
                .OpenMoreActionsInForm()
                .DeleteOptionInViewForm()
                .RefreshPage();
            bool isOptionPresentAfterDeletion = usmPageAfterCreation.IsOptionExist(optionToDelete);
            if (isOptionPresentAfterDeletion)
            {
               Log.Error($"<b>Опция '{optionToDelete.Title}' по-прежнему присутствует после попытки удаления</b>");
            }
            else
            {
                Log.Info($"<b>Опция '{optionToDelete.Title}' успешно удалена</b>");
            }
        }
    }
}
