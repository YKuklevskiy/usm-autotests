namespace ATframework3demo.TestEntities
{
    public class Bitrix24ScrumTeam
    {
        public Bitrix24ScrumTeam(string name, Bitrix24User scrumMaster = default)
        {
            Title = name ?? throw new ArgumentNullException(nameof(name)) ;
            ScrumMaster = scrumMaster;
        }

        public string Title { get; private set; }

        public ScrumTeamConfidentialityLevel ConfidentialityLevel { get; set; }

        public Bitrix24User ScrumMaster { get; set; }
        //public List<Bitrix24User> Developers { get; set; }
        //public List<Bitrix24User> Stakeholders { get; set; }

        public string GetConfidentialityLevelToString()
        {
            switch (ConfidentialityLevel)
            {
                case ScrumTeamConfidentialityLevel.Open:
                    return "Открытый";
                case ScrumTeamConfidentialityLevel.Closed:
                    return "Закрытый";
                case ScrumTeamConfidentialityLevel.Secret:
                    return "Секретный";
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public enum ScrumTeamConfidentialityLevel
    {
        Open,
        Closed,
        Secret
    }
}
