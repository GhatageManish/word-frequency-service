namespace wordfrequency.schema.Messages
{
    public class WordFrequencyRequest
    {
        public string Text { get; set; } = string.Empty;
        public int TopN { get; set; }
    }

    public class WordFrequencyResponse
    {
        public List<WordFrequencyItem> WordFrequencies { get; set; } = new();
        public int TotalWords { get; set; }
    }

    public class WordFrequencyItem
    {
        public string Word { get; set; } = string.Empty;
        public int Count { get; set; }
    }
}