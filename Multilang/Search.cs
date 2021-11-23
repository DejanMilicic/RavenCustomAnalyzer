namespace Multilang;

using Raven.Client.Documents.Indexes;

public class Search : AbstractIndexCreationTask<Article>
{
    public class Entry
    {
        public string Text_en { get; set; }

        public string Text_fr { get; set; }

        public Dictionary<string, object> Text { get; set; }
    }

    public Search()
    {
        Map = articles => from article in articles
            select new
            {
                _ = CreateField("Text_" + article.Language.ToLower(), article.Text)
            };

        AnalyzersStrings = new Dictionary<string, string>
        {
            {"Text_en", "StandardAnalyzer"},
            {"Text_fr", "FrenchAnalyzer"}
        };
    }
}
