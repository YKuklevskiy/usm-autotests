using atFrameWork2.BaseFramework;
using atFrameWork2.PageObjects;
using atFrameWork2.TestEntities;
using ATframework3demo.TestEntities;

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
            string scrumTeamName = "Брайтон";
            string optionTitle = "testTitle " + new Random().Next(100, 999); ;
            var testTitle = new Bitrix24Option(optionTitle);

            homePage
                .LeftMenu
                // Перейти в "Задачи и проекты"
                .OpenTasks()
                // Перейти в Скрам
                .OpenScram()
                // Выбрать скрам-команду
                .SelectScrumTeam(scrumTeamName)
                // В слайдере скрам-команды перейти в USM
                .OpenUSM()
                // Создать опцию
                .CreateOption(testTitle)
                // Проверить наличие созданной опции
                .isOptionExist(testTitle)
                // Открыть слайдер и проверить title
                .OpenOptionView(testTitle);
        }
    }
}
