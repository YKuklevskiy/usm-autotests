namespace ATframework3demo.TestEntities
{
    public class Bitrix24Option
    {
        public Bitrix24Option(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }
        public string Title { get; set; }
    }
}
