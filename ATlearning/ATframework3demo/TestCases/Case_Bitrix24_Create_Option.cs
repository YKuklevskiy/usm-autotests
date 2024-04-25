using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;
using atFrameWork2.BaseFramework.LogTools;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_Create_Option : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание опции в USM", homePage => CreateOptionUSM(homePage)));
            return caseCollection;
        }
        void CreateOptionUSM(PortalHomePage homePage)
        {
            string scrumTeamName = "Ванкувер";
            string optionTitle = "testTitle " + new Random().Next(100, 999);
            var testTitle = new Bitrix24Option(optionTitle);
            var usmPageWithOption = homePage
                .LeftMenu
                .OpenTasks()
                .OpenScram()
                .SelectScrumTeam(scrumTeamName)
                .OpenUSM()
                .CreateOption(testTitle);
            bool isOptionPresent = usmPageWithOption.IsOptionExist(testTitle);
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
