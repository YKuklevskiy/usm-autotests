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
                new TestCase("Автоматическое удаление связанных опций USM и бэклога", homePage => Case_OptionLinkageToBacklogOnDeletion(homePage)),
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

        private void Case_OptionLinkageToBacklogOnDeletion(PortalHomePage homePage)
        {
            Bitrix24ScrumTeam scrumTeam = new Bitrix24ScrumTeam($"team{DateTime.Now.Ticks}");            
            Bitrix24UsmOption testOption = new Bitrix24UsmOption($"option_for_del{DateTime.Now.Ticks}");
            Bitrix24UsmOption testOption2 = new Bitrix24UsmOption($"option_for_remote_del{DateTime.Now.Ticks}");

            homePage
                .LeftMenu.OpenTasks()
                .OpenScrum()
                .CreateScrumTeam(scrumTeam)
                .OpenTasks()
                .OpenUSM()
                .CreateOption(testOption)
                .CreateOption(testOption2)
                .OpenOptionDetails(testOption)
                .Delete();

            var backlog = homePage
                .LeftMenu.OpenTasks()
                .OpenScrum()
                .SortByActivityDate(ascending: true)
                .SelectScrumTeam(scrumTeam)
                .OpenTasks()
                .Backlog;

            if (backlog.IsTaskPresent(testOption.LinkedTask))
            {
                Log.Error($"Связанная с удалённой опцией {testOption.Title} задача в бэклоге не удалилась");
            }

            backlog
                .OpenTask(testOption2.LinkedTask)
                .Delete();
            
            var USM = backlog
                .BackToTasksPage() // there's a bug with frames, all bitrix frames are subjects of main frame, so go to parent frame doesnt work, alas - cant put backlog as generic type in TaskPage 
                .OpenUSM();

            if (USM.IsOptionPresent(testOption2))
            {
                Log.Error($"Связанная с удалённой задачей бэклога {testOption2.Title} опция в бэклоге не удалилась");
            }
        }
    }
}
