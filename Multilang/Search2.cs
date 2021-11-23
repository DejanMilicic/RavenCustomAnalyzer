using Raven.Client.Documents.Indexes;

namespace Multilang
{
    public class Search2 : AbstractIndexCreationTask<Article>
    {
        public class Entry
        {
            public Dictionary<string, object> Text { get; set; }
        }

        public Search2()
        {
            Map = articles => from article in articles
                select new
                {
                    _ = CreateField("Text_" + article.Language, article.Text)
                };

            AnalyzersStrings = new Dictionary<string, string>()
            {
                {"Text_en", "StandardAnalyzer"},
                {"Text_fr", "FrenchAnalyzer"}
            };
        }
    }
}