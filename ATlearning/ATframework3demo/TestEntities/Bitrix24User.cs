namespace ATframework3demo.TestEntities
{
    public class Bitrix24User
    {
        public Bitrix24User(string fullName)
        {
            FullName = fullName ?? throw new ArgumentNullException(nameof(fullName));
        }

        public string FullName { get; set; }
    }
}
