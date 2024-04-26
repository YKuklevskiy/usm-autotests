namespace ATframework3demo.TestEntities
{
    public class Bitrix24ScrumTeam
    {
        public Bitrix24ScrumTeam(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public ScrumTeamType TeamType { get; set; }
        //public List<Bitrix24User> Developers { get; set; }
        //public List<Bitrix24User> Stakeholders { get; set; }

        public string GetTeamTypeToString()
        {
            switch (TeamType)
            {
                case ScrumTeamType.Open:
                    return "Открытый";
                case ScrumTeamType.Closed:
                    return "Закрытый";
                case ScrumTeamType.Secret:
                    return "Секретный";
                default:
                    throw new NotImplementedException();
            }
        }
    }

    public enum ScrumTeamType
    {
        Open,
        Closed,
        Secret
    }
}
