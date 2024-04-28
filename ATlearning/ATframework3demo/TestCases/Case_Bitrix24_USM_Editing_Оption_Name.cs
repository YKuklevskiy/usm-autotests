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
            string scrumMasterName = "David Zhemaitis";
            var testScrumDetails = new Bitrix24ScrumTeamDetail(scrumTeamName, scrumMasterName);
            string optionTitle = "testTitle " + DateTime.Now.Ticks;
            var testTitle = new Bitrix24USMOption(optionTitle);
            string newOptionTitle = "editedTitle " + DateTime.Now.Ticks;
            var newTestTitle = new Bitrix24USMOption(newOptionTitle);
            var usmPageAfterCreation = homePage
                .LeftMenu
                .OpenTasks()
                .OpenScram()
                .CreateScrumTeam()
                .FillScrumTeamForm(testScrumDetails)
                .CreateUSM()
                .CreateOption(testTitle);
            bool isOptionCreated = usmPageAfterCreation.IsOptionExist(testTitle);
            if (!isOptionCreated)
            {
                Log.Error($"<b>Опция с исходным заголовком '{testTitle.Title}' не найдена</b>");
                return;
            }
            else
            {
                Log.Info($"<b>Опция с исходным заголовком '{testTitle.Title}' найдена</b>");
            }
            var usmPageWithOption = usmPageAfterCreation
                .OpenOptionView(testTitle)
                .OpenOptionEditForm()
                .SetNameInEditForm(newTestTitle)
                .SaveChangesInOption()
                .CloseOptionViewForm()
                .RefreshPage(); 
            bool isOptionPresent = usmPageWithOption.IsOptionExist(newTestTitle);
            if (!isOptionPresent)
            {
                Log.Error($"<b>Опция с новым заголовком '{newTestTitle.Title}' не найдена</b>");
            }
            else
            {
                Log.Info($"<b>Опция с новым заголовком '{newTestTitle.Title}' найдена</b>");
            }
        }
    }
}
