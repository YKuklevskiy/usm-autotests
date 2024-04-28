using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;
using ATframework3demo.PageObjects.Scrum;
using ATframework3demo.TestEntities;

namespace ATframework3demo.TestCases.Scrum
{
    public class Case_Bitrix24_Backlog : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            return new List<TestCase>
            {
                new TestCase("Автоматическое создание связанной с опцией USM задачи в бэклоге Скрама", homePage => Case_OptionLinkageToBacklogOnCreation(homePage)),
            };
        }

        private ScrumTeamPage QuickCreateScrumTeam(PortalHomePage homePage, Bitrix24ScrumTeam team)
        {
            return homePage
                .LeftMenu.OpenTasks()
                .OpenScrum()
                .CreateScrumTeam(team)
                .EnterTeamName()
                .SelectTeamConfidentiality()
                .SelectScrumMasterFromTeamEntity()
                .FinishCreation();
        }

        private void Case_OptionLinkageToBacklogOnCreation(PortalHomePage homePage)
        {
            Bitrix24ScrumTeam scrumTeam = new Bitrix24ScrumTeam($"team{DateTime.Now.Ticks}", homePage.GetCurrentUser());            
            Bitrix24UsmOption testOption = new Bitrix24UsmOption($"option{DateTime.Now.Ticks}");

            QuickCreateScrumTeam(homePage, scrumTeam)
                .OpenTasks()
                .OpenUSM()
                .CreateOption(testOption);

            var scrumBacklog = homePage
                .LeftMenu.OpenTasks()
                .OpenScrum()
                .SortByActivityDate(ascending: true)
                .SelectScrumTeam(scrumTeam)
                .OpenTasks()
                .Backlog;

            if(!scrumBacklog.IsTaskPresent(testOption.LinkedTask))
            {
                Log.Error($"Для созданной опции {testOption.Title} не создалась задача в бэклоге скрама.");
            }
        }
    }
}
