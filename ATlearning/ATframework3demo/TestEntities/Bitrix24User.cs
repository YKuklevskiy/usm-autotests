namespace ATframework3demo.TestEntities
{
    public class Bitrix24User
    {
        public Bitrix24User(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
        }
        public string UserName { get; set; }
    }
}
