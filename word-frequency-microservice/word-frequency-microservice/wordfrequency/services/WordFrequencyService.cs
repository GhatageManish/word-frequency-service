using System.Text.RegularExpressions;
using wordfrequency.schema.Messages;

namespace wordfrequency.services
{
    public class WordFrequencyService
    {
        public WordFrequencyResponse Process(string text, int topN)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentException("Invalid input: text must be a non-empty string");

            if (topN <= 0)
                throw new ArgumentException("Invalid input: topN must be a positive integer");

            // Normalize and extract words (alphanumeric only)
            var words = Regex.Matches(text.ToLower(), "[a-z0-9]+")
                             .Select(m => m.Value)
                             .ToList();

            int totalWords = words.Count;

            // Frequency calculation
            var frequencies = words
                .GroupBy(w => w)
                .Select(g => new WordFrequencyItem
                {
                    Word = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(w => w.Count)
                .ThenBy(w => w.Word)
                .Take(topN)
                .ToList();

            return new WordFrequencyResponse
            {
                WordFrequencies = frequencies,
                TotalWords = totalWords
            };
        }
    }
}