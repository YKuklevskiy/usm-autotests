using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;
using atFrameWork2.BaseFramework.LogTools;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_USM_Create_Option : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание опции в USM", homePage => CreateOptionUSM(homePage)));
            return caseCollection;
        }
        void CreateOptionUSM(PortalHomePage homePage)
        {
            string scrumTeamName = "Новая скрам-команда " + DateTime.Now.Ticks;
            string scrumMasterName = "David Zhemaitis";
            var testScrumDetails = new Bitrix24ScrumTeamDetail(scrumTeamName, scrumMasterName);
            string optionTitle = "testTitle " + DateTime.Now.Ticks;
            var testTitle = new Bitrix24USMOption(optionTitle);
            var usmPageAfterCreation = homePage
                .LeftMenu
                .OpenTasks()
                .OpenScram()
                .CreateScrumTeam()
                .FillScrumTeamForm(testScrumDetails)
                .CreateUSM()
                .CreateOption(testTitle); 
            bool isOptionPresent = usmPageAfterCreation.IsOptionExist(testTitle);
            if (!isOptionPresent)
            {
                Log.Error($"<b>Опция с заголовком '{testTitle.Title}' не найдена</b>");
            }
            else
            {
                Log.Info($"<b>Опция с заголовком '{testTitle.Title}' найдена</b>");
            }
        }
    }
}
