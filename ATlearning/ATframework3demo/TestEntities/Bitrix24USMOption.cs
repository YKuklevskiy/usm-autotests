namespace ATframework3demo.TestEntities
{
    public class Bitrix24USMOption
    {
        public Bitrix24USMOption(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }
        public string Title { get; set; }
    }
}
