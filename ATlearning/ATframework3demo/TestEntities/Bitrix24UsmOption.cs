using atFrameWork2.TestEntities;

namespace ATframework3demo.TestEntities
{
    public class Bitrix24UsmOption
    {
        public Bitrix24UsmOption(string title)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
        }
        public string Title { get; set; }

        public Bitrix24Task LinkedTask => new Bitrix24Task(Title);
    }
}
